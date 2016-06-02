using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace MIDIPresenter.SlideData {
	
	/// <summary>
	/// Represents a specific slides configuration
	/// </summary>
	[DataContract]
	internal class SlideConfiguration {

		[DataMember(Name="song", IsRequired=false)]
		public string song { get; set; }

		[DataMember(Name = "part", IsRequired = false)]
		public string part { get; set; }

		[DataMember(Name = "order", IsRequired = false)]
		public int order { get; set; }

		[DataMember(Name = "ccNumber", IsRequired = false)]
		public int ccNumber { get; set; }

	}
}
