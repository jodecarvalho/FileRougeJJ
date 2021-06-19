using FR_XamarinResults.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FR_XamarinResults.Models.ViewModels
{
    public class ConnectionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string email;
        private string password;
        private string erreur;
        private bool isLoginVisible = true;
        private bool isResultatVisible = false;


        public ObservableCollection<Resultat> resultats { get; set; }

        private readonly ResultatService resultatService = ResultatService.GetInstance();

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    this.IsPropertyChanged("Email");
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
          {
                if (password != value)
                {
                    password = value;
                    this.IsPropertyChanged("Password");
                }
            }
        }
        public string Erreur
        {
            get { return erreur; }
            set
            {
                if (erreur != value)
                {
                    erreur = value;
                    this.IsPropertyChanged("Erreur");
                }
            }
        }
        public bool IsLoginVisible
        {
            set
            {
                if (isLoginVisible != value)
                {
                    isLoginVisible = value;
                    this.IsPropertyChanged("IsLoginVisible");
                }
            }
            get { return isLoginVisible; }
        }
        public bool IsResultatVisible
        {
            set
            {
                if (isResultatVisible != value)
                {
                    isResultatVisible = value;
                    this.IsPropertyChanged("IsResultatVisible");
                }
            }
            get { return isResultatVisible; }
        }

        public void IsPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public ICommand Connection { get; private set; }
        public ConnectionViewModel()
        {
            this.resultats = resultatService.GetResultat();
            Connection = new Command(() =>
            {
                if (this.Email == null || string.IsNullOrWhiteSpace(this.Email) || this.Password == null || string.IsNullOrWhiteSpace(this.Password))
                    this.Erreur = "Merci de renseigner tous les champs du formulaire";
                else
                {
                    if (this.Email.Equals("arnaud") && this.Password.Equals("123456"))
                    {
                        this.IsLoginVisible = false;
                        this.IsResultatVisible = true;
                    }
                    else
                        this.Erreur = "Identifiant ou Mot de Passe incorrect.";
                }
            });
        }
    
    }
}
