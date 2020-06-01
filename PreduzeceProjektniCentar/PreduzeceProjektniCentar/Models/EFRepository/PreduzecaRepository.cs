using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PreduzeceProjektniCentar.Models.Interfaces;
using PreduzeceProjektniCentar.Models.LinqSql;

namespace PreduzeceProjektniCentar.Models.EFRepository
{
    public class PreduzecaRepository : IPreduzecaRepository
    {
        private PreduzecaDataContext pDC = new PreduzecaDataContext();


        public IEnumerable<KontaktBO> GetKontakeById(int id)
        {
            List<KontaktBO> kontakti = new List<KontaktBO>();
            foreach (Kontakt kontakt in pDC.Kontakts.Where(t=>t.PreduzeceID == id))
            {
                KontaktBO kontaktBO = new KontaktBO()
                {
                    KontaktID = kontakt.KontaktID,
                    Ime = kontakt.Ime,
                    Prezime = kontakt.Prezime,
                    RadnoMesto = kontakt.RadnoMesto
                };
                kontakti.Add(kontaktBO);
            }
            return kontakti;
        }

        public IEnumerable<MailBO> GetMailsById(int id)
        {
            List<MailBO> mejlovi = new List<MailBO>();
            foreach (Mail mail in pDC.Mails.Where(t => t.KontaktID == id))
            {
                MailBO mailBO = new MailBO()
                {
                    MailAdresa = mail.MailAdresa,
                    OnakaTipa = mail.OnakaTipa
                };
                mejlovi.Add(mailBO);
            }
            return mejlovi;
        }

        public IEnumerable<PreduzeceBO> GetPreduzeca()
        {
            List<PreduzeceBO> preduzeca = new List<PreduzeceBO>();
            foreach(Preduzece preduzece in pDC.Preduzeces)
            {
                PreduzeceBO preduzeceBO = new PreduzeceBO()
                {
                    PreduzeceID = preduzece.PreduzeceID,
                    Naziv = preduzece.Naziv,
                    Adresa = preduzece.Adresa,

        Opstina = preduzece.Opstina,

        Postanskibroj = preduzece.Postanskibroj,

        PIB = preduzece.PIB,

        SifraDelatnosti = preduzece.SifraDelatnosti,

       OpisDelatnosti = preduzece.OpisDelatnosti,

        BrRacuna = preduzece.BrRacuna,

        WebStr = preduzece.WebStr,

        Pecat = preduzece.Pecat,

        Beleska = preduzece.Beleska
    };
                preduzeca.Add(preduzeceBO);
            }
            return preduzeca;
        }

        public IEnumerable<PreduzeceBO> GetPreduzecaById(int id)
        {
            List<PreduzeceBO> preduzeca = new List<PreduzeceBO>();
            foreach (Preduzece preduzece in pDC.Preduzeces.Where(t=>t.PreduzeceID == id))
            {
                PreduzeceBO preduzeceBO = new PreduzeceBO()
                {
                    PreduzeceID = preduzece.PreduzeceID,
                    Naziv = preduzece.Naziv,
                    Adresa = preduzece.Adresa,

                    Opstina = preduzece.Opstina,

                    Postanskibroj = preduzece.Postanskibroj,

                    PIB = preduzece.PIB,

                    SifraDelatnosti = preduzece.SifraDelatnosti,

                    OpisDelatnosti = preduzece.OpisDelatnosti,

                    BrRacuna = preduzece.BrRacuna,

                    WebStr = preduzece.WebStr,

                    Pecat = preduzece.Pecat,

                    Beleska = preduzece.Beleska
                };
                preduzeca.Add(preduzeceBO);
            }
            return preduzeca;
        }

        public IEnumerable<TelefonBO> GetTelefoneById(int id)
        {
            List<TelefonBO> telefoni = new List<TelefonBO>();
            foreach (Telefon telefon in pDC.Telefons.Where(t => t.KontaktID == id))
            {
                TelefonBO telefonBO = new TelefonBO()
                {
                    TelefonID = telefon.TelefonID,
                    BrojTelefona = telefon.BrojTelefona,
                    OznakaTipa = telefon.OznakaTipa,
                    Lokal = telefon.Lokal
                };
                telefoni.Add(telefonBO);
            }
            return telefoni;
        }

        public void UpdateKontakta(KontaktBO kontaktBO)
        {
            Kontakt kontakt = pDC.Kontakts.FirstOrDefault(t => t.KontaktID == kontaktBO.KontaktID);
            kontakt.KontaktID = kontaktBO.KontaktID;
            kontakt.Ime = kontaktBO.Ime;
            kontakt.Prezime = kontaktBO.Prezime;
            kontakt.RadnoMesto = kontaktBO.RadnoMesto;
            pDC.SubmitChanges();
        }

        public void UpdateMaila(MailBO mailBO)
        {
            Mail mail = pDC.Mails.FirstOrDefault(t => t.MailAdresa == mailBO.MailAdresa);
            mail.OnakaTipa = mailBO.OnakaTipa;
            mail.MailAdresa = mailBO.MailAdresa;
            pDC.SubmitChanges();
        }

        public void UpdateTelefona(TelefonBO telefonBO)
        {
            Telefon telefon = pDC.Telefons.FirstOrDefault(t => t.TelefonID == telefonBO.TelefonID);
            telefon.BrojTelefona = telefonBO.BrojTelefona;
            telefon.OznakaTipa = telefonBO.OznakaTipa;
            telefon.Lokal = telefonBO.Lokal;
            pDC.SubmitChanges();
        }
    }
}