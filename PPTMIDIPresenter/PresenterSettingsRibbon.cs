using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Sanford.Multimedia.Midi;
using System.Windows.Forms;

namespace MIDIPresenter {
	public partial class PresenterSettingsRibbon {
		private static List<string> m_songParts = new List<string>();
		private static Dictionary<string, int> m_songPartCCLookup = new Dictionary<string, int>();
		private int m_seconds = 0;
		private Timer m_Timer = new Timer();
		private MIDIMonitor m_Monitor = MIDIMonitor.GetInstance();

		private void PresenterSettingsRibbon_Load(object sender, RibbonUIEventArgs e) {
			RefreshDevices(false);
			RefreshMIDIChannels();
			RefreshSongParts();
			RefreshSortOrder();
			RefreshCCList();
			CheckDeviceState();
		}

		private void EnumerateDevicesButton_Click(object sender, RibbonControlEventArgs e) {
			RefreshDevices(true);
		}

		public int GetDevice() {
			if (!string.IsNullOrEmpty(this.MIDIDevicesComboBox.Text)) {
				Dictionary<int, MidiInCaps> devices = MIDIUtilties.GetMIDIDevices();
				foreach (KeyValuePair<int, MidiInCaps> kvp in devices) {
					if (kvp.Value.name.Equals(this.MIDIDevicesComboBox.Text)) {
						return kvp.Key;
					}
				}
				return -1;
			} else {
				return -1;
			}
		}

		private void RefreshCCList() {
			this.CCNumberComboBox.Items.Clear();
			foreach (string s in MIDIPresenter.Constants.CCValues.Keys) {
				RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
				item.Label = s;
				this.CCNumberComboBox.Items.Add(item);
			}
		}

		private void RefreshSortOrder() {
			this.SortOrderComboBox.Items.Clear();
			for (int i = 1; i <= 10; i++) {
				RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
				item.Label = i.ToString();
				this.SortOrderComboBox.Items.Add(item);
			}
		}

		/// <summary>
		/// Load default set of song parts 
		/// </summary>
		private void RefreshSongParts() {
			// TODO: store this set somewhere
			m_songParts.AddRange(Constants.PART_TAGS);
			this.SongPartsComboBox.Items.Clear();
			foreach (string part in m_songParts) {
				RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
				item.Label = part;
				this.SongPartsComboBox.Items.Add(item);
			}
		}

		/// <summary>
		/// Setup a standard set of MIDI input channels; 1-16
		/// </summary>
		private void RefreshMIDIChannels() {
			this.MIDIChannelComboBox.Items.Clear();

			RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
			item.Label = "OMNI";
			this.MIDIChannelComboBox.Items.Add(item);

			for (int i = 1; i <= 16; i++) {
				item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
				item.Label = i.ToString();
				this.MIDIChannelComboBox.Items.Add(item);
			}
		}

		/// <summary>
		/// Refreshes the list of available MIDI devices
		/// </summary>
		/// <param name="showWarning">Displays a warning to the user if there are no available devices to use</param>
		private void RefreshDevices(bool showWarning=false) {
			this.MIDIDevicesComboBox.Items.Clear();
			Dictionary<int, MidiInCaps> devices = MIDIUtilties.GetMIDIDevices();
			if (devices == null || devices.Count == 0) {
				if (showWarning) {
					System.Windows.Forms.MessageBox.Show(
						"No MIDI input devices available.", 
						"Warning", 
						System.Windows.Forms.MessageBoxButtons.OK, 
						System.Windows.Forms.MessageBoxIcon.Warning);
				}
			} else {
				foreach (KeyValuePair<int, MidiInCaps> kvp in devices) {
					RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
					item.Label = kvp.Value.name;
					this.MIDIDevicesComboBox.Items.Add(item);
				}
			}

			this.MIDIDevicesComboBox.TextChanged += MIDIDevicesComboBox_TextChanged;
		}

		private void CheckDeviceState() {
			if (!string.IsNullOrEmpty(this.MIDIDevicesComboBox.Text) && !string.IsNullOrWhiteSpace(this.MIDIDevicesComboBox.Text)) {
				this.MIDIChannelComboBox.Enabled = true;
			} else {
				this.MIDIChannelComboBox.Enabled = false;
			}
		}

		void MIDIDevicesComboBox_TextChanged(object sender, RibbonControlEventArgs e) {
			CheckDeviceState();
		}

		private void CreatePartsButton_Click(object sender, RibbonControlEventArgs e) {

		}

		private void ApplyTagsButton_Click(object sender, RibbonControlEventArgs e) {
			SlideData.SlideConfiguration config = new SlideData.SlideConfiguration();
			config.song = null;
			config.part = this.SongPartsComboBox.Text;
			config.order = Int32.Parse(this.SortOrderComboBox.Text);
			config.ccNumber = Constants.CCValues[this.CCNumberComboBox.Text];
			Globals.ThisAddIn.SaveConfiguration(config);
			System.Windows.Forms.MessageBox.Show("Saved!");
		}

		internal void UpdateSlideTags(SlideData.SlideConfiguration config) {
			this.SongPartsComboBox.Text = config.part;
			this.SortOrderComboBox.Text = config.order.ToString();
			this.CCNumberComboBox.Text = Constants.CCValues.FirstOrDefault(kvp => kvp.Value.Equals(config.ccNumber)).Key;
		}

		private void PreviousSectionLearnButton_Click(object sender, RibbonControlEventArgs e) {
			if (m_Monitor != null && m_Monitor.InDevice != null) {
				DisposeMonitor();
			}
			m_Monitor = MIDIMonitor.GetInstance();
			m_Monitor.SetDevice(this.GetDevice());
			m_Monitor.InDevice.ChannelMessageReceived += InDevice_ChannelMessageReceived;
			m_seconds = 30;
			m_Timer = new Timer();
			m_Timer.Interval = 1000;
			m_Timer.Tick += t_Tick;
			m_Timer.Start();

		}

		void t_Tick(object sender, EventArgs e) {
			m_seconds--;
			this.PreviousSectionLearnButton.Label = "Learning...{" + m_seconds + "}";
			if (m_seconds == 0) {
				EndLearn(this.PreviousSectionLearnButton);
			}
		}

		void EndLearn(RibbonButton button) {
			button.Label = "Learn";
			m_Timer.Stop();
			DisposeMonitor();
		}

		void DisposeMonitor() {
			if (m_Monitor != null) {
				m_Monitor.InDevice.Close();
				m_Monitor = null;
			}
		}

		void InDevice_ChannelMessageReceived(object sender, ChannelMessageEventArgs e) {
			int MIDIChannel = e.Message.MidiChannel;
			if (e.Message.MessageType == MessageType.Channel) {
				if (e.Message.Command == ChannelCommand.Controller) {
					if (this.MIDIChannelComboBox.Text.Equals("OMNI") || e.Message.MidiChannel == Int32.Parse(this.MIDIChannelComboBox.Text)) {
						int detectedCCValue = e.Message.Data1;
						foreach (KeyValuePair<string, int> CCValue in MIDIPresenter.Constants.CCValues) {
							if (CCValue.Value.Equals(detectedCCValue)) {
								this.PreviousSongCCValueComboBox.Text = CCValue.Key;
								EndLearn(this.PreviousSectionLearnButton);
								return;
							}
						}
					}
				}
			}
		}
	}
}
