namespace MIDIPresenter {
	partial class PresenterSettingsRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public PresenterSettingsRibbon()
			: base(Globals.Factory.GetRibbonFactory()) {
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresenterSettingsRibbon));
			this.MIDIPresenterRibbonTab = this.Factory.CreateRibbonTab();
			this.DeviceSettings = this.Factory.CreateRibbonGroup();
			this.MIDIDevicesComboBox = this.Factory.CreateRibbonComboBox();
			this.MIDIChannelComboBox = this.Factory.CreateRibbonComboBox();
			this.EnumerateDevicesButton = this.Factory.CreateRibbonButton();
			this.SlideSettingsGroup = this.Factory.CreateRibbonGroup();
			this.SongPartsComboBox = this.Factory.CreateRibbonComboBox();
			this.EditPartsButton = this.Factory.CreateRibbonButton();
			this.SortOrderComboBox = this.Factory.CreateRibbonComboBox();
			this.separator1 = this.Factory.CreateRibbonSeparator();
			this.CCNumberComboBox = this.Factory.CreateRibbonComboBox();
			this.ApplyTagsButton = this.Factory.CreateRibbonButton();
			this.PresentationSettingsGroup = this.Factory.CreateRibbonGroup();
			this.PreviousSectionLabel = this.Factory.CreateRibbonLabel();
			this.PreviousSongCCValueComboBox = this.Factory.CreateRibbonComboBox();
			this.PreviousSectionLearnButton = this.Factory.CreateRibbonButton();
			this.separator2 = this.Factory.CreateRibbonSeparator();
			this.NextSectionLabel = this.Factory.CreateRibbonLabel();
			this.button1 = this.Factory.CreateRibbonButton();
			this.comboBox1 = this.Factory.CreateRibbonComboBox();
			this.separator3 = this.Factory.CreateRibbonSeparator();
			this.PreviousSlideLabel = this.Factory.CreateRibbonLabel();
			this.comboBox2 = this.Factory.CreateRibbonComboBox();
			this.button2 = this.Factory.CreateRibbonButton();
			this.separator4 = this.Factory.CreateRibbonSeparator();
			this.NextSlideLabel = this.Factory.CreateRibbonLabel();
			this.comboBox3 = this.Factory.CreateRibbonComboBox();
			this.button3 = this.Factory.CreateRibbonButton();
			this.MIDIPresenterRibbonTab.SuspendLayout();
			this.DeviceSettings.SuspendLayout();
			this.SlideSettingsGroup.SuspendLayout();
			this.PresentationSettingsGroup.SuspendLayout();
			// 
			// MIDIPresenterRibbonTab
			// 
			this.MIDIPresenterRibbonTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
			this.MIDIPresenterRibbonTab.Groups.Add(this.DeviceSettings);
			this.MIDIPresenterRibbonTab.Groups.Add(this.PresentationSettingsGroup);
			this.MIDIPresenterRibbonTab.Groups.Add(this.SlideSettingsGroup);
			this.MIDIPresenterRibbonTab.Label = "MIDI Presenter";
			this.MIDIPresenterRibbonTab.Name = "MIDIPresenterRibbonTab";
			// 
			// DeviceSettings
			// 
			this.DeviceSettings.Items.Add(this.MIDIDevicesComboBox);
			this.DeviceSettings.Items.Add(this.MIDIChannelComboBox);
			this.DeviceSettings.Items.Add(this.EnumerateDevicesButton);
			this.DeviceSettings.Label = "Device Settings";
			this.DeviceSettings.Name = "DeviceSettings";
			// 
			// MIDIDevicesComboBox
			// 
			this.MIDIDevicesComboBox.Image = ((System.Drawing.Image)(resources.GetObject("MIDIDevicesComboBox.Image")));
			this.MIDIDevicesComboBox.Label = "Controllers";
			this.MIDIDevicesComboBox.Name = "MIDIDevicesComboBox";
			this.MIDIDevicesComboBox.ShowImage = true;
			this.MIDIDevicesComboBox.Text = null;
			// 
			// MIDIChannelComboBox
			// 
			this.MIDIChannelComboBox.Image = ((System.Drawing.Image)(resources.GetObject("MIDIChannelComboBox.Image")));
			this.MIDIChannelComboBox.Label = "Channel";
			this.MIDIChannelComboBox.Name = "MIDIChannelComboBox";
			this.MIDIChannelComboBox.ShowImage = true;
			this.MIDIChannelComboBox.Text = null;
			// 
			// EnumerateDevicesButton
			// 
			this.EnumerateDevicesButton.Image = ((System.Drawing.Image)(resources.GetObject("EnumerateDevicesButton.Image")));
			this.EnumerateDevicesButton.Label = "Refresh MIDI Device List";
			this.EnumerateDevicesButton.Name = "EnumerateDevicesButton";
			this.EnumerateDevicesButton.ShowImage = true;
			this.EnumerateDevicesButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.EnumerateDevicesButton_Click);
			// 
			// SlideSettingsGroup
			// 
			this.SlideSettingsGroup.Items.Add(this.SongPartsComboBox);
			this.SlideSettingsGroup.Items.Add(this.EditPartsButton);
			this.SlideSettingsGroup.Items.Add(this.SortOrderComboBox);
			this.SlideSettingsGroup.Items.Add(this.separator1);
			this.SlideSettingsGroup.Items.Add(this.CCNumberComboBox);
			this.SlideSettingsGroup.Items.Add(this.ApplyTagsButton);
			this.SlideSettingsGroup.Label = "Slide Settings";
			this.SlideSettingsGroup.Name = "SlideSettingsGroup";
			// 
			// SongPartsComboBox
			// 
			this.SongPartsComboBox.Image = ((System.Drawing.Image)(resources.GetObject("SongPartsComboBox.Image")));
			this.SongPartsComboBox.Label = "Song Part";
			this.SongPartsComboBox.Name = "SongPartsComboBox";
			this.SongPartsComboBox.ShowImage = true;
			this.SongPartsComboBox.Text = null;
			// 
			// EditPartsButton
			// 
			this.EditPartsButton.Image = ((System.Drawing.Image)(resources.GetObject("EditPartsButton.Image")));
			this.EditPartsButton.Label = "Edit Song Parts";
			this.EditPartsButton.Name = "EditPartsButton";
			this.EditPartsButton.ShowImage = true;
			this.EditPartsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CreatePartsButton_Click);
			// 
			// SortOrderComboBox
			// 
			this.SortOrderComboBox.Image = ((System.Drawing.Image)(resources.GetObject("SortOrderComboBox.Image")));
			this.SortOrderComboBox.Label = "Display Sort Order";
			this.SortOrderComboBox.Name = "SortOrderComboBox";
			this.SortOrderComboBox.ShowImage = true;
			this.SortOrderComboBox.Text = null;
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			// 
			// CCNumberComboBox
			// 
			this.CCNumberComboBox.Label = "CC";
			this.CCNumberComboBox.Name = "CCNumberComboBox";
			this.CCNumberComboBox.Text = null;
			// 
			// ApplyTagsButton
			// 
			this.ApplyTagsButton.Image = ((System.Drawing.Image)(resources.GetObject("ApplyTagsButton.Image")));
			this.ApplyTagsButton.Label = "Apply Tags";
			this.ApplyTagsButton.Name = "ApplyTagsButton";
			this.ApplyTagsButton.ShowImage = true;
			this.ApplyTagsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ApplyTagsButton_Click);
			// 
			// PresentationSettingsGroup
			// 
			this.PresentationSettingsGroup.Items.Add(this.PreviousSectionLabel);
			this.PresentationSettingsGroup.Items.Add(this.PreviousSongCCValueComboBox);
			this.PresentationSettingsGroup.Items.Add(this.PreviousSectionLearnButton);
			this.PresentationSettingsGroup.Items.Add(this.separator2);
			this.PresentationSettingsGroup.Items.Add(this.NextSectionLabel);
			this.PresentationSettingsGroup.Items.Add(this.comboBox1);
			this.PresentationSettingsGroup.Items.Add(this.button1);
			this.PresentationSettingsGroup.Items.Add(this.separator3);
			this.PresentationSettingsGroup.Items.Add(this.PreviousSlideLabel);
			this.PresentationSettingsGroup.Items.Add(this.comboBox2);
			this.PresentationSettingsGroup.Items.Add(this.button2);
			this.PresentationSettingsGroup.Items.Add(this.separator4);
			this.PresentationSettingsGroup.Items.Add(this.NextSlideLabel);
			this.PresentationSettingsGroup.Items.Add(this.comboBox3);
			this.PresentationSettingsGroup.Items.Add(this.button3);
			this.PresentationSettingsGroup.Label = "Global Presentation Settings";
			this.PresentationSettingsGroup.Name = "PresentationSettingsGroup";
			// 
			// PreviousSectionLabel
			// 
			this.PreviousSectionLabel.Label = "Previous Section";
			this.PreviousSectionLabel.Name = "PreviousSectionLabel";
			// 
			// PreviousSongCCValueComboBox
			// 
			this.PreviousSongCCValueComboBox.Label = "CC Value";
			this.PreviousSongCCValueComboBox.Name = "PreviousSongCCValueComboBox";
			this.PreviousSongCCValueComboBox.ShowItemImage = false;
			// 
			// PreviousSectionLearnButton
			// 
			this.PreviousSectionLearnButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviousSectionLearnButton.Image")));
			this.PreviousSectionLearnButton.Label = "Learn";
			this.PreviousSectionLearnButton.Name = "PreviousSectionLearnButton";
			this.PreviousSectionLearnButton.ShowImage = true;
			this.PreviousSectionLearnButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.PreviousSectionLearnButton_Click);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			// 
			// NextSectionLabel
			// 
			this.NextSectionLabel.Label = "Next Section";
			this.NextSectionLabel.Name = "NextSectionLabel";
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Label = "Learn";
			this.button1.Name = "button1";
			this.button1.ShowImage = true;
			// 
			// comboBox1
			// 
			this.comboBox1.Label = "CC Value";
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.ShowItemImage = false;
			// 
			// separator3
			// 
			this.separator3.Name = "separator3";
			// 
			// PreviousSlideLabel
			// 
			this.PreviousSlideLabel.Label = "Previous Slide";
			this.PreviousSlideLabel.Name = "PreviousSlideLabel";
			// 
			// comboBox2
			// 
			this.comboBox2.Label = "CC Value";
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.ShowItemImage = false;
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Label = "Learn";
			this.button2.Name = "button2";
			this.button2.ShowImage = true;
			// 
			// separator4
			// 
			this.separator4.Name = "separator4";
			// 
			// NextSlideLabel
			// 
			this.NextSlideLabel.Label = "Next Slide";
			this.NextSlideLabel.Name = "NextSlideLabel";
			// 
			// comboBox3
			// 
			this.comboBox3.Label = "CC Value";
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.ShowItemImage = false;
			// 
			// button3
			// 
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Label = "Learn";
			this.button3.Name = "button3";
			this.button3.ShowImage = true;
			// 
			// PresenterSettingsRibbon
			// 
			this.Name = "PresenterSettingsRibbon";
			this.RibbonType = "Microsoft.PowerPoint.Presentation";
			this.Tabs.Add(this.MIDIPresenterRibbonTab);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.PresenterSettingsRibbon_Load);
			this.MIDIPresenterRibbonTab.ResumeLayout(false);
			this.MIDIPresenterRibbonTab.PerformLayout();
			this.DeviceSettings.ResumeLayout(false);
			this.DeviceSettings.PerformLayout();
			this.SlideSettingsGroup.ResumeLayout(false);
			this.SlideSettingsGroup.PerformLayout();
			this.PresentationSettingsGroup.ResumeLayout(false);
			this.PresentationSettingsGroup.PerformLayout();

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab MIDIPresenterRibbonTab;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup DeviceSettings;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox MIDIDevicesComboBox;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton EnumerateDevicesButton;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox MIDIChannelComboBox;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup SlideSettingsGroup;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton EditPartsButton;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox SongPartsComboBox;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox SortOrderComboBox;
		internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox CCNumberComboBox;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton ApplyTagsButton;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup PresentationSettingsGroup;
		internal Microsoft.Office.Tools.Ribbon.RibbonLabel PreviousSectionLabel;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox PreviousSongCCValueComboBox;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton PreviousSectionLearnButton;
		internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
		internal Microsoft.Office.Tools.Ribbon.RibbonLabel NextSectionLabel;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox1;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
		internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
		internal Microsoft.Office.Tools.Ribbon.RibbonLabel PreviousSlideLabel;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox2;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
		internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator4;
		internal Microsoft.Office.Tools.Ribbon.RibbonLabel NextSlideLabel;
		internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox3;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
	}

	partial class ThisRibbonCollection {
		internal PresenterSettingsRibbon PresenterSettingsRibbon {
			get { return this.GetRibbon<PresenterSettingsRibbon>(); }
		}
	}
}
