using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace DemoAppBackendApi.Base.Models
{
	public class BaseFeedItem
	{
		[JsonProperty(PropertyName = "id")]
		[Required]
		public string Id
		{
			get;
			set;
		}

		[JsonProperty(PropertyName = "feedItemImageUrl")]
		[Required]
		public string FeedItemImageUrl
		{
			get;
			set;
		}

		[JsonProperty(PropertyName = "feedItemText")]
		[Required]
		public string FeedItemText
		{
			get;
			set;
		}

		[JsonProperty(PropertyName = "linkUrl")]
		public string LinkUrl
		{
			get;
			set;
		}

	}
}
