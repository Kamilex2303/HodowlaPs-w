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
    /// Logika interakcji dla klasy Usun.xaml
    /// </summary>
    public partial class Usun : Window
    {
        public Usun()
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
            bool checkPies = false;
            bool checkNabywca = false;

            if (pies.IsChecked.Value)
            {
                checkPies = true;
            }

            if (nabywca.IsChecked.Value)
            {
                checkNabywca = true;
            }


            if (checkPies == true)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"hodowla.xml");
                XmlNode node = doc.SelectSingleNode("hodowla/psy/pies[id='"+id.Text+"']");
                if (node == null)
                {

                }
                else
                {
                    node.ParentNode.RemoveChild(node);
                    doc.Save(@"hodowla.xml");
                }
            }
            if(checkNabywca == true)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"hodowla.xml");
                XmlNode node = doc.SelectSingleNode("hodowla/nabywcy/nabywca[@numerPsa='" + id.Text + "']");
                if (node == null)
                {

                }
                else
                {
                    node.ParentNode.RemoveChild(node);
                    doc.Save(@"hodowla.xml");
                }
            }


        }
    }
}
