using Projekt;
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
using System.Xml;
using System.Xml.Linq;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy DodajNabywce.xaml
    /// </summary>
    public partial class DodajNabywce : Window
    {
        public DodajNabywce()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Name = name.Text;
            string Pesel = pesel.Text;
            string Email = email.Text;
            string Nr = nrPsa.Text;

            XmlDocument xdoc1 = new XmlDocument();
            xdoc1.Load(@"hodowla.xml");
            XmlNode nabywca = xdoc1.CreateElement("nabywca");

            XmlAttribute atribute = xdoc1.CreateAttribute("numerPsa");
            atribute.Value = Nr;
            nabywca.Attributes.Append(atribute);

            XmlNode imie = xdoc1.CreateElement("imie");
            imie.InnerText = Name;
            nabywca.AppendChild(imie);

            XmlNode nrPesel = xdoc1.CreateElement("pesel");
            nrPesel.InnerText = Pesel;
            nabywca.AppendChild(nrPesel);

            XmlNode adresEmail = xdoc1.CreateElement("email");
            adresEmail.InnerText = Email;
            nabywca.AppendChild(adresEmail);


            XmlNode node = xdoc1.SelectSingleNode("hodowla/nabywcy");
            node.AppendChild(nabywca);
            xdoc1.Save(@"hodowla.xml");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }
    }
}
