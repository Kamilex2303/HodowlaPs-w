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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Xml.Schema;
using WpfApp3;

namespace Projekt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", "hodowla.xsd");
            Console.WriteLine("Attempting to validate");
            XDocument xml = XDocument.Load("hodowla.xml");
            bool errors = false;
            xml.Validate(schema, (o, err) =>
            {
                Console.WriteLine("{0}", err.Message);
                errors = true;
            });
            if(errors == true)
            {
                MessageBox.Show("Nie udało się zwalidować!");
            }
            else
            {
                MessageBox.Show("Validacja zakończona pomyślnie");
            }

            //Console.WriteLine();
            //// Modify the source document so that it will not validate.  
            //xml.Root.Element("psy").Element("pies").Element("id").Value = "AAAAA";
            //Console.WriteLine("Attempting to validate after modification");
            //errors = false;
            //xml.Validate(schema, (o, err) =>
            //{
            //    errors = true;
            //});
            //if (errors == true)
            //{
            //    MessageBox.Show("Nie udało się zwalidować!");
            //}
            //else
            //{
            //    MessageBox.Show("Validacja zakończona pomyślnie");
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win2 = new Window1();
            win2.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Usun win2 = new Usun();
            win2.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
            this.Close();
        }
    }
}
