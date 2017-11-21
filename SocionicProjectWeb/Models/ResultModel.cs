using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocionicProjectWeb.Models
{
	public class ResultModel
	{
		public int[] GroupOfAnswers { get; set; }
		public int[] ArrayAnswers { get; set; }
		public string CurrentTime { get; set; }
		public string UserInfo { get; set; }
		public string Device { get; set; }
	}
}