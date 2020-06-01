using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PreduzeceProjektniCentar.Models.Interfaces;
using PreduzeceProjektniCentar.Models.LinqSql;
using PreduzeceProjektniCentar.Models.EFRepository;
using PreduzeceProjektniCentar.Models;

namespace PreduzeceProjektniCentar.Controllers
{
    public class PreduzecaController : Controller
    {
        private PreduzecaDataContext pDC = new PreduzecaDataContext();
        IPreduzecaRepository preduzecaRepository = new PreduzecaRepository();
        // GET: Preduzeca

        public ActionResult Dodaj()
        {
            ViewBag.Preduzeca = preduzecaRepository.GetPreduzeca();
            return View();
        }
        [HttpPost]
        public ActionResult Dodaj(Preduzece preduzece)
        {
            if (ModelState.IsValid)
            {


                Preduzece p = new Preduzece();
                p.Naziv = preduzece.Naziv;
                p.Adresa = preduzece.Adresa;
                p.Opstina = preduzece.Opstina;
                p.Postanskibroj = preduzece.Postanskibroj;
                p.PIB = preduzece.PIB;
                p.BrRacuna = preduzece.BrRacuna;
                p.WebStr = preduzece.WebStr;
                p.Beleska = preduzece.Beleska;
                p.OpisDelatnosti = preduzece.OpisDelatnosti;
                p.SifraDelatnosti = preduzece.SifraDelatnosti;
     
                //string fileName = Path.GetFileNameWithoutExtension(preduzece.SlikaFajl.FileName);
                //string ext = Path.GetExtension(preduzece.SlikaFajl.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + ext;
                //preduzece.Pecat = "~/Slike/" + fileName;
                //p.Pecat = preduzece.Pecat;
                //fileName = Path.Combine(Server.MapPath("~/Slike/"), fileName);
                //preduzece.SlikaFajl.SaveAs(fileName);

                pDC.Preduzeces.InsertOnSubmit(p);
                pDC.SubmitChanges();
                int poslednjepreduzece = p.PreduzeceID;

                return RedirectToAction("Index");
            }
            else
                ViewBag.ErrorMessage = "Niste dobro popunili obrazac.";
            return View("Dodaj");

        }
        public ActionResult Index()
        {
            IEnumerable<PreduzeceBO> preduzeces = new List<PreduzeceBO>();
            preduzeces = preduzecaRepository.GetPreduzeca();
            ViewBag.Preduzeca = preduzecaRepository.GetPreduzeca();
            return View(preduzeces);
        }

        public ActionResult GetKontakeByPreduzece(int id)
        {
            ViewBag.Kontakti = preduzecaRepository.GetKontakeById(id);
            return PartialView("_ListaKontakta",preduzecaRepository.GetKontakeById(id));
        }
        public ActionResult GetTelefoneByKontakt(int id)
        {

            return PartialView("_ListaTelefona", preduzecaRepository.GetTelefoneById(id));
        }
        public ActionResult GetMailsByKontakt(int id)
        {

            return PartialView("_ListaMejlova", preduzecaRepository.GetMailsById(id));
        }

        public ActionResult Edit(int id)
        {
            TelefonBO telefonBO = new TelefonBO();
            Telefon telefon= new Telefon();
            telefon = pDC.Telefons.FirstOrDefault(t => t.TelefonID == id);
            telefonBO.TelefonID = telefon.TelefonID;
            telefonBO.OznakaTipa = telefon.OznakaTipa;
            telefonBO.BrojTelefona = telefon.BrojTelefona;
            telefonBO.Lokal = telefon.Lokal;
            return View(telefonBO);

        }
        [HttpPost]
        public ActionResult Edit(TelefonBO telefonBO)
        {
            preduzecaRepository.UpdateTelefona(telefonBO);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteTelefon(int id)
        {
            TelefonBO telefonBO = new TelefonBO();
            Telefon telefon = new Telefon();
            telefon = pDC.Telefons.FirstOrDefault(t => t.TelefonID == id);
            telefonBO.TelefonID = telefon.TelefonID;
            telefonBO.OznakaTipa = telefon.OznakaTipa;
            telefonBO.BrojTelefona = telefon.BrojTelefona;
            telefonBO.Lokal = telefon.Lokal;
            return View(telefonBO);

        }
        [HttpPost,ActionName("DeleteTelefon")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePotvrda(int id)
        {
            Telefon telefon = pDC.Telefons.FirstOrDefault(t => t.TelefonID == id);
            pDC.Telefons.DeleteOnSubmit(telefon);
            
                pDC.SubmitChanges();
           
            return RedirectToAction("Index");

        }

        public ActionResult DeleteMail(string adresa)
        {
            MailBO mailBO = new MailBO();
            Mail mail = new Mail();
            mail = pDC.Mails.FirstOrDefault(t => t.MailAdresa == adresa);
            mailBO.MailAdresa = mail.MailAdresa;
            mailBO.OnakaTipa = mail.OnakaTipa;
            return View(mailBO);

        }
        [HttpPost,ActionName("DeleteMail")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMailPotvrda(string adresa)
        {
            Mail mejl = pDC.Mails.FirstOrDefault(t => t.MailAdresa == adresa);
            pDC.Mails.DeleteOnSubmit(mejl);
            
                pDC.SubmitChanges();
           
            return RedirectToAction("Index");

        }
        public ActionResult EditMail(string adresa)
        {
            MailBO mailBO = new MailBO();
            Mail mail = new Mail();
            mail = pDC.Mails.FirstOrDefault(t => t.MailAdresa == adresa);
            mailBO.MailAdresa = mail.MailAdresa;
            mailBO.OnakaTipa = mail.OnakaTipa;
            return View(mailBO);

        }
        [HttpPost]
        public ActionResult EditMail(MailBO mailBO)
        {
            preduzecaRepository.UpdateMaila(mailBO);
            return RedirectToAction("Index");

        }


        //Kontakt Edit i Delete
        public ActionResult DeleteKontakt(int id)
        {
            KontaktBO kontaktBO = new KontaktBO();
            Kontakt kontakt = new Kontakt();
            kontakt = pDC.Kontakts.FirstOrDefault(t => t.KontaktID == id);
            kontaktBO.KontaktID = kontakt.KontaktID;
            kontaktBO.Ime = kontakt.Ime;
            kontaktBO.Prezime = kontakt.Prezime;
            kontaktBO.RadnoMesto = kontakt.RadnoMesto;
            return View(kontaktBO);

        }
        [HttpPost, ActionName("DeleteKontakt")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteKontaktPotvrda(int id)
        {
            Kontakt kontakt = pDC.Kontakts.FirstOrDefault(t => t.KontaktID == id);
            pDC.Kontakts.DeleteOnSubmit(kontakt);

            pDC.SubmitChanges();

            return RedirectToAction("Index");

        }
        public ActionResult EditKontakt(int id)
        {
            KontaktBO kontaktBO = new KontaktBO();
            Kontakt kontakt = new Kontakt();
            kontakt = pDC.Kontakts.FirstOrDefault(t => t.KontaktID == id);
            kontaktBO.KontaktID = kontakt.KontaktID;
            kontaktBO.Ime = kontakt.Ime;
            kontaktBO.Prezime = kontakt.Prezime;
            kontaktBO.RadnoMesto = kontakt.RadnoMesto;
            return View(kontaktBO);

        }
        [HttpPost]
        public ActionResult EditKontakt(KontaktBO kontaktBO)
        {
            preduzecaRepository.UpdateKontakta(kontaktBO);
            return RedirectToAction("Index");

        }
    }
}