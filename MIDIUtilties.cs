using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System.Threading;

namespace MIDIPresenter {
	internal static class MIDIUtilties {
		internal static Dictionary<int, MidiInCaps> GetMIDIDevices() {
			Dictionary<int, MidiInCaps> returnValue = new Dictionary<int, MidiInCaps>();
			for (int iDevice = 0; iDevice < InputDevice.DeviceCount; iDevice++) {
				MidiInCaps mic = InputDevice.GetDeviceCapabilities(iDevice);
				returnValue.Add(iDevice, mic);
			}

			return returnValue;
		}
	}
}
