using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace MIDIPresenter
{
    public partial class ThisAddIn
    {
		private MIDIMonitor m_Monitor = MIDIMonitor.GetInstance();

		private static Dictionary<int, SlideData.SlideConfiguration> m_SlideConfigurations = new Dictionary<int, SlideData.SlideConfiguration>();

		internal static Dictionary<int, SlideData.SlideConfiguration> SlideConfigurations {
			get { return ThisAddIn.m_SlideConfigurations; }
			set { ThisAddIn.m_SlideConfigurations = value; }
		}

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
			this.Application.PresentationOpen += Application_PresentationOpen;
			this.Application.SlideShowBegin += Application_SlideShowBegin;
			this.Application.SlideShowEnd += Application_SlideShowEnd;
			this.Application.SlideSelectionChanged += Application_SlideSelectionChanged;
        }

		void Application_SlideSelectionChanged(PowerPoint.SlideRange SldRange) {
			var slide = Application.ActiveWindow.View.Slide;
			if (HasTag(slide, Constants.TAG_SLIDE_CONFIG_KEY)) {
				var s = slide.Tags[Constants.TAG_SLIDE_CONFIG_KEY];
				SlideData.SlideConfiguration config = DeserializeSlideConfiguration(s);
				Globals.Ribbons.PresenterSettingsRibbon.UpdateSlideTags(config);
			}
		}

		void Application_SlideShowEnd(PowerPoint.Presentation Pres) {
			if (m_Monitor != null) {
				m_Monitor.Dispose();
			}
		}

		void Application_SlideShowBegin(PowerPoint.SlideShowWindow Wn) {
			// TODO: Start reading incoming MIDI
			int deviceId = Globals.Ribbons.PresenterSettingsRibbon.GetDevice();
			m_Monitor.SetDevice(deviceId);
			
		}

		void Application_PresentationOpen(PowerPoint.Presentation Pres) {
			EnumerateSlidePresenterTags(Pres);
		}

		/// <summary>
		/// Enumerates all slides and adds any missing data tags to them
		/// </summary>
		/// <param name="Pres"></param>
		private void EnumerateSlidePresenterTags(PowerPoint.Presentation Pres) {
			for (int iSlide = 1; iSlide <= Pres.Slides.Count; iSlide++) {
				var slide = Pres.Slides[iSlide];
				if (HasTag(slide, Constants.TAG_SLIDE_CONFIG_KEY)) {
					var s = slide.Tags[Constants.TAG_SLIDE_CONFIG_KEY];
					SlideData.SlideConfiguration config = DeserializeSlideConfiguration(s);
					if (!Constants.PART_TAGS.Contains(config.part)) {
						Constants.PART_TAGS[Constants.PART_TAGS.Length] = config.part;
					}
				} else {
					string value = "{ " +
										"\"song\": \"" + Pres.SectionProperties.Name(slide.sectionIndex) + "\", " +
										"\"part\": \"Blank\", " +
										"\"order\": 1, " +
										"\"ccNumber\": 0" +
									"}";
					slide.Tags.Add(Constants.TAG_SLIDE_CONFIG_KEY, value);
				}
			}
		}
		

		internal bool HasTag(PowerPoint.Slide slide, string tag) {
			for (int i = 1; i <= slide.Tags.Count; i++) {
				if (tag.Equals(slide.Tags.Name(i))) {
					return true;
				}
			}
			return false;
		}

		internal int GetTagIndex(PowerPoint.Slide slide, string tag) {
			for (int i = 1; i <= slide.Tags.Count; i++) {
				if (tag.Equals(slide.Tags.Name(i))) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>Saves the configuration to the active slide</summary>
		/// <param name="config"></param>
		internal void SaveConfiguration(SlideData.SlideConfiguration config) {
			var slide = Application.ActiveWindow.View.Slide;
			if (HasTag(slide, Constants.TAG_SLIDE_CONFIG_KEY)) {
				slide.Tags.Delete(Constants.TAG_SLIDE_CONFIG_KEY);
			}
			string value = "{ " +
								"\"song\": \"" + Application.ActiveWindow.Presentation.SectionProperties.Name(slide.sectionIndex) + "\", " +
								"\"part\": \"" + config.part + "\", " +
								"\"order\": " + config.order + ", " +
								"\"ccNumber\": " + config.ccNumber +
							"}";
			slide.Tags.Add(Constants.TAG_SLIDE_CONFIG_KEY, value);
		}

		private Dictionary<int, SlideData.SlideConfiguration> EnumeratePresentationSettings(PowerPoint.Presentation Pres) {
			m_SlideConfigurations = new Dictionary<int, SlideData.SlideConfiguration>();
			for (int iSlide = 1; iSlide <= Pres.Slides.Count; iSlide++) {
				var slide = Pres.Slides[iSlide];
				if (slide.HasNotesPage == Office.MsoTriState.msoCTrue || slide.HasNotesPage == Office.MsoTriState.msoTrue) {
					PowerPoint.SlideRange notesPages = slide.NotesPage;
					foreach (PowerPoint.Shape shape in notesPages.Shapes) {
						if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoPlaceholder) {
							if (shape.PlaceholderFormat.Type == PowerPoint.PpPlaceholderType.ppPlaceholderBody) {
								System.Diagnostics.Debug.WriteLine("Slide[" + slide.SlideIndex + "] Notes: [" + shape.TextFrame.TextRange.Text + "]");
								try {
									string data = shape.TextFrame.TextRange.Text;
									SlideData.SlideConfiguration sc = DeserializeSlideConfiguration(data);
									m_SlideConfigurations.Add(slide.SlideIndex, sc);
								} catch (Exception ex) {
									System.Windows.Forms.MessageBox.Show(ex.Message);
									return null;
								}								
							}
						}
					}
				}
			}

			return m_SlideConfigurations;
		}

		/// <summary>
		/// Converts a JSON string into a SlideConfiguration object
		/// </summary>
		/// <param name="json"></param>
		/// <returns></returns>
		private SlideData.SlideConfiguration DeserializeSlideConfiguration(string json) {
			SlideData.SlideConfiguration returnValue = null;
			json = json.StripIncompatableQuotes();
			byte[] result = Encoding.UTF8.GetBytes(json);
			using (var s = new System.IO.MemoryStream(result)) {
				using (var jsonReader = JsonReaderWriterFactory.CreateJsonReader(result, XmlDictionaryReaderQuotas.Max)) {
					var outputSerialiser = new DataContractJsonSerializer(typeof(SlideData.SlideConfiguration));
					returnValue = (SlideData.SlideConfiguration)outputSerialiser.ReadObject(jsonReader);
				}
			}
			return returnValue;
		}

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
			m_Monitor.Dispose();
			this.Application.PresentationClose -= Application_PresentationOpen;
			
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
