using FR_XamarinResults.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FR_XamarinResults.Service
{
    public class ResultatService
    {

        private static ResultatService instance;

        public static ResultatService GetInstance()
        {
            if (instance == null)
                instance = new ResultatService();
            return instance;
        }

        public ObservableCollection<Resultat> GetResultat()
        {
            return new ObservableCollection<Resultat>
            {
                new Resultat
                {
                    Candidat = "Arnaud",
                    Niveau = "Junior",
                    QuizzId = "3",
                    Result = "100"
                },

                new Resultat
                {
                    Candidat = "Arnaud",
                    Niveau = "Expert",
                    QuizzId = "12",
                    Result = "84"
                }
            };
               
        }
    }
}
