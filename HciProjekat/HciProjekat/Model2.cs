using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PrimerCas4.Table
{
    [Serializable]
    public class Model2 :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _oznaka;
        private string _opis;
        private string _boja;


        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public string Boja
        {
            get
            {
                return _boja;
            }
            set
            {
                if (value != _boja)
                {
                    _boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }
    }
}
