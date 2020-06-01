using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreduzeceProjektniCentar.Models
{
    public class TelefonBO
    {
		public int TelefonID { get; set; }

		public string OznakaTipa { get; set; }

		public decimal BrojTelefona { get; set; }

		public string Lokal { get; set; }
	}
}