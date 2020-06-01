using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreduzeceProjektniCentar.Models
{
    public class PreduzeceBO
    {
		public int PreduzeceID{ get; set; }

		public string Naziv { get; set; }

		public string Adresa { get; set; }

		public string Opstina { get; set; }

		public int Postanskibroj { get; set; }

		public decimal PIB { get; set; }

		public int SifraDelatnosti { get; set; }

		public string OpisDelatnosti { get; set; }

		public decimal BrRacuna { get; set; }

		public string WebStr { get; set; }

		public string Pecat { get; set; }

		public string Beleska { get; set; }

	}
}