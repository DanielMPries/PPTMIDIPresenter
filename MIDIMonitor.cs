using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System.Threading;
using System.Windows.Forms;

namespace MIDIPresenter {
	internal class MIDIMonitor : IDisposable {
		private static MIDIMonitor m_Monitor = null;

		internal static MIDIMonitor GetInstance() {
			if (m_Monitor == null) {
				m_Monitor = new MIDIMonitor();
			}
			return m_Monitor;
		}

		private MIDIMonitor() { }

		/// <summary>
		/// Represents the input device associated with the parent
		/// </summary>
		private InputDevice m_InDevice = null;

		/// <summary>
		/// Represents the input device associated with the parent
		/// </summary>
		internal InputDevice InDevice {
			get { return m_InDevice; }
			set { m_InDevice = value; }
		}

		//private SynchronizationContext m_Context;

		private void DisableInDevice() {
			if (InDevice != null) {
				InDevice.Close();
				InDevice = null;
			}
		}

		
		internal void SetDevice(int id) {
			DisableInDevice();

			if (InputDevice.DeviceCount == 0) {
				System.Windows.Forms.MessageBox.Show("No MIDI input devices available.", "Warning!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
			} else {
				try {
					//m_Context = SynchronizationContext.Current;
					m_InDevice = new InputDevice(id);
					m_InDevice.StartRecording();
					m_InDevice.Error += new EventHandler<ErrorEventArgs>(m_InDevice_Error);
				} catch (Exception ex) {
					System.Windows.Forms.MessageBox.Show(ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
				}
			}
		}

		void m_InDevice_Error(object sender, ErrorEventArgs e) {
			System.Windows.Forms.MessageBox.Show(e.Error.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
		}

		public void Dispose() {
			DisableInDevice();
			m_Monitor = null;
		}
	}
}
