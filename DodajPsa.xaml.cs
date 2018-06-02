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

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy DodajPsa.xaml
    /// </summary>
    public partial class DodajPsa : Window
    {
        public DodajPsa()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Id = id.Text;
            string Imie = imie.Text;
            string Rasa = rasa.Text;
            string Wiek = wiek.Text;
            string Cena = cena.Text;
            string Data = data.Text;
            string Lagodny = lagodny.Text;

            XmlDocument xdoc1 = new XmlDocument();
            xdoc1.Load(@"hodowla.xml");
            XmlNode pies = xdoc1.CreateElement("pies");

            XmlNode idIn = xdoc1.CreateElement("id");
            idIn.InnerText = Id;
            pies.AppendChild(idIn);

            XmlNode imieIn = xdoc1.CreateElement("imie");
            imieIn.InnerText = Imie;
            pies.AppendChild(imieIn);

            XmlNode rasaIn = xdoc1.CreateElement("rasa");
            rasaIn.InnerText = Rasa;
            pies.AppendChild(rasaIn);

            XmlNode wiekIn = xdoc1.CreateElement("wiek");
            wiekIn.InnerText = Wiek;
            pies.AppendChild(wiekIn);

            XmlNode cenaIn = xdoc1.CreateElement("cena");
            cenaIn.InnerText = Cena;
            pies.AppendChild(cenaIn);

            XmlNode dataIn = xdoc1.CreateElement("data");
            dataIn.InnerText = Data;
            pies.AppendChild(imieIn);

            XmlNode lagodnyIn = xdoc1.CreateElement("lagodny");
            lagodnyIn.InnerText = Lagodny;
            pies.AppendChild(lagodnyIn);

            XmlNode node = xdoc1.SelectSingleNode("hodowla/psy");
            node.AppendChild(pies);
            xdoc1.Save(@"hodowla.xml");
        }
    }
}
