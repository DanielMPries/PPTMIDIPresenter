using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDIPresenter {
	internal static class Constants {
		internal static string TAG_SLIDE_CONFIG_KEY = "MIDI_PRESENTER_SETTINGS";
		internal static string[] PART_TAGS = new string[] {"Blank", "Verse 1", "Verse 2", "Pre-Chorus", "Chorus 1", "Bridge 1", "Bridge 2", "Outro" };

		private static Dictionary<string, int> m_CCValues = new Dictionary<string, int>();
		internal static Dictionary<string, int> CCValues {
			get {
				PopulateCCValues();
				return m_CCValues;
			}
			private set { m_CCValues = value; }
		}

		private static void PopulateCCValues() {
			#region CC Values array
			string[] ccValue = new string[] {
				"0 - Bank Select (MSB)",
				"1 - Modulation Wheel",
				"2 - Breath controller",
				"3 - (Undefined)",
				"4 - Foot Pedal (MSB)",
				"5 - Portamento Time (MSB)",
				"6 - Data Entry (MSB)",
				"7 - Volume (MSB)",
				"8 - Balance (MSB)",
				"10 - Pan position (MSB)",
				"11 - Expression (MSB)",
				"12 - Effect Control 1 (MSB)",
				"13 - Effect Control 2 (MSB)",
				"14 - Undefined",
				"15 - Undefined",
				"16 - General Purpose Slider 1 or Ribbon Controller",
				"17 - General Purpose Slider 2 or Knob 1",
				"18 - General Purpose Slider 3",
				"19 - General Purpose Slider 4 or Knob 2",
				"20 - Undefined or Knob 3",
				"21 - Undefined or Knob 4",
				"22 - Undefined",
				"23 - Undefined",
				"24 - Undefined",
				"25 - Undefined",
				"26 - Undefined",
				"27 - Undefined",
				"28 - Undefined",
				"29 - Undefined",
				"30 - Undefined",
				"31 - Undefined",
				"32 - Bank Select (LSB)",
				"33 - Modulation Wheel (LSB)",
				"34 - Breath controller (LSB)",
				"36 - Foot Pedal (LSB)",
				"37 - Portamento Time (LSB)",
				"38 - Data Entry (LSB)",
				"39 - Volume (LSB)",
				"40 - Balance (LSB)",
				"41 - Undefined",
				"42 - Pan position (LSB)",
				"43 - Expression (LSB)",
				"44 - Effect Control 1 (LSB)",
				"45 - Effect Control 2 (LSB)",
				"46 - (LSB)",
				"47 - (LSB)",
				"48 - (LSB)",
				"49 - (LSB)",
				"50 - (LSB)",
				"51 - (LSB)",
				"52 - (LSB)",
				"53 - (LSB)",
				"54 - (LSB)",
				"55 - (LSB)",
				"56 - (LSB)",
				"57 - (LSB)",
				"58 - (LSB)",
				"59 - (LSB)",
				"60 - (LSB)",
				"61 - (LSB)",
				"62 - (LSB)",
				"63 - (LSB)",
				"64 - Hold Pedal (on/off)",
				"65 - Portamento (on/off)",
				"66 - Sustenuto Pedal (on/off)",
				"67 - Soft Pedal (on/off)",
				"68 - Legato Pedal (on/off)",
				"69 - Hold 2 Pedal (on/off)",
				"70 - Sound Variation",
				"71 - Resonance (aka Timbre)",
				"72 - Sound Release Time",
				"73 - Sound Attack Time",
				"74 - Frequency Cutoff",
				"75 - Sound Control 6",
				"76 - Sound Control 7",
				"77 - Sound Control 8",
				"78 - Sound Control 9",
				"79 - Sound Control 10",
				"80 - General Purpose Button 1 or Decay",
				"81 - General Purpose Button 2 or Hi Pass Filter Frequency",
				"82 - General Purpose Button 3",
				"83 - General Purpose Button 4",
				"91 - Reverb Level",
				"92 - Tremolo Level",
				"93 - Chorus Level",
				"94 - Celeste Level or Detune",
				"95 - Phaser Level",
				"96 - Data Button increment",
				"97 - Data Button decrement",
				"98 - Non-registered Parameter (LSB)",
				"99 - Non-registered Parameter (MSB)",
				"100 - Registered Parameter (LSB)",
				"101 - Registered Parameter (MSB)",
				"102 - (Undefined)",
				"103 - (Undefined)",
				"104 - (Undefined)",
				"105 - (Undefined)",
				"106 - (Undefined)",
				"107 - (Undefined)",
				"108 - (Undefined)",
				"109 - (Undefined)",
				"110 - (Undefined)",
				"111 - (Undefined)",
				"112 - (Undefined)",
				"113 - (Undefined)",
				"114 - (Undefined)",
				"115 - (Undefined)",
				"116 - (Undefined)",
				"117 - (Undefined)",
				"118 - (Undefined)",
				"119 - (Undefined)",
				"120 - All Sound Off",
				"121 - All Controllers Off",
				"122 - Local Keyboard (on/off)",
				"123 - All Notes Off",
				"124 - Omni Mode Off",
				"125 - Omni Mode On",
				"126 - Mono Operation",
				"127 - Poly Operation"
			};
			#endregion
			m_CCValues.Clear();
			for( int i = 0; i < ccValue.Length ; i++) {
				m_CCValues.Add(ccValue[i], i);
			}
		}
	}
}
