using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlogWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Aricles.ItemsSource = collection_Article;
            Db = new ApplicationContext();
        }

        private ApplicationContext _Db;
        public ObservableCollection<Article> collection_Article = new ObservableCollection<Article>() {};
        public User connectedUser;

        public ApplicationContext Db
        {
            get { return _Db; }
            set { _Db = value; }
        }

        private void Inscription_Click(object sender, RoutedEventArgs e)
        {
            Inscription inscr = new Inscription(this);
            inscr.Show();
        }

        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            Connexion connect = new Connexion(this);
            connect.Show();
        }

        private void ajout_article(object sender, RoutedEventArgs e)
        {
            if (connectedUser.droit == droits.User || connectedUser.droit == droits.Admin)
            {
                creation crea = new creation(this);
                crea.Show();
            }
            else
            {
                MessageBox.Show("Vous devez vous inscrire ou vous connecter ");
            }
           
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            collection_Article.Remove((Article)Aricles.SelectedItem);
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            creation create = new creation(this);
            create.nomArticle.Text = ((Article)Aricles.SelectedItem).Titre;
            create.content.Text = ((Article)Aricles.SelectedItem).content;
            collection_Article.Remove((Article)Aricles.SelectedItem);
            create.Show();
        }

        private void Aricles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            contenuart.Text = ((Article)Aricles.SelectedItem).content;
        }
    }
}
