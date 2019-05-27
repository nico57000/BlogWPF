using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BlogWPF
{
    /// <summary>
    /// Logique d'interaction pour creation.xaml
    /// </summary>
    public partial class creation : Window
    {
        public creation(MainWindow w)
        {
            InitializeComponent();
            mw = w;
        }
        private MainWindow mw;
        private void sauver(object sender, RoutedEventArgs e)
        {
            Article art = new Article(mw.connectedUser, nomArticle.Text, DateTime.Now, content.Text);
            mw.Db.Liste_Db_Articles.Add(art);
            mw.collection_Article.Add(art);
            mw.Db.SaveChanges();
            MessageBox.Show("Création réussie", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void effacer(object sender, RoutedEventArgs e)
        {

        }
    }
}
