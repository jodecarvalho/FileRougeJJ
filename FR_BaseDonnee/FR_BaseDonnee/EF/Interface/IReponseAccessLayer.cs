using FR_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.EF.Interface
{
    interface IReponseAccessLayer
    {
        long Add(Reponse reponse);
        Reponse Update(Reponse reponse);
        void Delete(long id);
        Reponse Get(long id, bool tracking = false);
        List<Reponse> GetAll();
    }
}
