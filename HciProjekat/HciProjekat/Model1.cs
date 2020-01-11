using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;

namespace PrimerCas4.Table
{
    public class Model1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<String> Etikete
        {
            get;
            set;
        }



        private String oznaka;
        private String ime;
        private  String opis;
        private  String tip;
        private  String era;
        private  ImageSource ikonica;
        private  Boolean arhObradjen;
        private  Boolean pripadaUnesko;
        private  Boolean pripadaNaseljenom;
        private  String turistickiStatus;
        private  float prihod;
        private  DateTime datumOtkrivanja;
        private  String tagovani;
        private Point _point;

        public Model1() {
            Point = new Point();
            Etikete = new ObservableCollection<String>();
        }



        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
                if (value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        

        public string Tip
        {
            get
            {
                return tip;
            }
            set
            {
                if (value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public DateTime DatumOtkrivanja
        {
            get
            {
                return datumOtkrivanja;
            }
            set
            {
                if (datumOtkrivanja != value)
                {
                    datumOtkrivanja = value;
                    OnPropertyChanged("DatumOtkrivanja");
                }
            }
        }
        public String Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (opis != value)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public float Prihod
        {
            get
            {
                return prihod;
            }
            set
            {
                if (prihod != value)
                {
                    prihod = value;
                    OnPropertyChanged("Prihod");
                }
            }
        }



        public bool ArhObradjen
        {
            get
            {
                return arhObradjen;
            }
            set
            {
                if (arhObradjen != value)
                {
                    arhObradjen = value;
                    OnPropertyChanged("ArhObradjen");
                }
            }
        }
        public bool PripadaUnesko
        {
            get
            {
                return pripadaUnesko;
            }
            set
            {
                if (pripadaUnesko != value)
                {
                    pripadaUnesko = value;
                    OnPropertyChanged("PripadaUnesko");
                }
            }
        }
        public bool PripadaNaseljenom
        {
            get
            {
                return pripadaNaseljenom;
            }
            set
            {
                if (pripadaNaseljenom != value)
                {
                    pripadaNaseljenom = value;
                    OnPropertyChanged("PripadaNaseljenom");
                }
            }
        }

        public String Era
        {
            get
            {
                return era;
            }
            set
            {
                if (era != value)
                {
                    era = value;
                    OnPropertyChanged("Era");
                }
            }
        }
        public String TuristickiStatus
        {
            get
            {
                return turistickiStatus;
            }
            set
            {
                if (turistickiStatus != value)
                {
                    turistickiStatus = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }
        public String Tagovani
        {
            get
            {
                return tagovani;
            }
            set
            {
                if (tagovani != value)
                {
                    tagovani = value;
                    OnPropertyChanged("Tagovani");
                }
            }
        }
        public ImageSource Ikonica
        {
            get
            {
                return ikonica;
            }
            set
            {
                if (ikonica != value)
                {
                    ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public Point Point
        {
            get
            {
                return _point;
            }
            set
            {
                if (value != _point)
                {
                    _point = value;
                    OnPropertyChanged("Point");
                }
            }
        }

    }
}
