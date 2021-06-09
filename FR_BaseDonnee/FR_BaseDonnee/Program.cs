using FR_DataAccessLayer.Context;
using FR_DataAccessLayer.EF.AccessLayer;
using FR_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FR_JJ())
            {
                if (context.Database.Exists())
                {
                    context.Database.Delete();
                }
                context.Database.Create();
            }

            var reponseAccessLayer = new ReponseAccessLayer();

            Console.WriteLine("Ajout d'une réponse");

            var reponse = new Reponse
            {
                Libelle = "oui"
            };

            reponseAccessLayer.Add(reponse);
        }
    }
}
