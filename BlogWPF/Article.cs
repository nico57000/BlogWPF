using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BlogWPF
{
    public class Article : INotifyPropertyChanged
    {

        [Key]
        public int Key { get; set; }
        [Column]
        public User Writer { get; set; }

        private string _Titre;

        [Column]
        public string Titre
        {
            get { return _Titre; }
            set {

                if (this._Titre != value)
                {
                    this._Titre = value;
                    this.NotifyPropertyChanged("Titre");
                }
                _Titre = value;
            }
        }

        
        private string _Content;
        [Column]
        public string content
        {
            get { return _Content; }
            set {
                if (this._Content != value)
                {
                    this._Content = value;
                    this.NotifyPropertyChanged("content");
                }
                _Content = value; }
        }

        [Column]
        public DateTime date_de_parution { get; set; }


        public Article(User writer, string titre, DateTime date_de_parution, string contenu)
        {
            Writer = writer;
            Titre = titre;
            this.date_de_parution = date_de_parution;
            content = contenu;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Titre + " par " + Writer.Pseudo + " le "+date_de_parution;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
