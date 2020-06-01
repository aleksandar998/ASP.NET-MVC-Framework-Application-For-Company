using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreduzeceProjektniCentar.Models.Interfaces
{
    interface IPreduzecaRepository
    {
        IEnumerable<PreduzeceBO> GetPreduzeca();
        IEnumerable<KontaktBO> GetKontakeById(int id);
        IEnumerable<TelefonBO> GetTelefoneById(int id);

        IEnumerable<MailBO> GetMailsById(int id);

        void UpdateTelefona(TelefonBO telefonBO);
        void UpdateMaila(MailBO mailBO);

        void UpdateKontakta(KontaktBO kontaktBO);

    }
}
