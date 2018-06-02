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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    /// 
    public class Person
    {
        public string Imie { get; set; }
        public string Pesel { get; set; }
        public string Email { get; set; }
        public string NrPsa { get; set; }
    }

    public class Dog
    {
        public string Id { get; set; }
        public string Imie { get; set; }
        public string Wiek { get; set; }
        public string Rasa { get; set; }
        public string Cena { get; set; }
        public string DataWyp { get; set; }
        public string Lagodny { get; set; }
    }
    public partial class Window1 : Window
    {
        List<Person> people = new List<Person>();
        List<Dog> dogs = new List<Dog>();

        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlTextReader reader = new XmlTextReader(@"hodowla.xml");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "nabywcy")
                {
                    while (reader.Read())
                    {
                        Person p = new Person();
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "nabywca")
                        {
                            p.NrPsa = reader.GetAttribute("numerPsa");
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "nabywca") break;

                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "imie")
                                {
                                    reader.Read();
                                    p.Imie = reader.Value;
                                }

                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "pesel")
                                {
                                    reader.Read();
                                    p.Pesel = reader.Value;
                                }

                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "email")
                                {
                                    reader.Read();
                                    p.Email = reader.Value;
                                }


                            }
                            Console.WriteLine(p.NrPsa);
                            people.Add(p);
                        }
                    }

                }
            }
            XmlTextReader reader2 = new XmlTextReader(@"hodowla.xml");
            reader2.WhitespaceHandling = WhitespaceHandling.None;
            while (reader2.Read())
            {
                if (reader2.NodeType == XmlNodeType.Element && reader2.Name == "psy")
                {
                    while (reader2.Read())
                    {
                        Dog d = new Dog();
                        if (reader2.NodeType == XmlNodeType.Element && reader2.Name == "pies")
                        {
                            while (reader2.Read())
                            {
                                if (reader2.NodeType == XmlNodeType.EndElement && reader2.Name == "pies") break;

                                if (reader2.NodeType == XmlNodeType.Element && reader2.Name == "id")
                                {
                                    reader2.Read();
                                    d.Id = reader2.Value;
                                }

                                if (reader2.NodeType == XmlNodeType.Element && reader2.Name == "imie")
                                {
                                    reader2.Read();
                                    d.Imie = reader2.Value;
                                }

                                if (reader2.NodeType == XmlNodeType.Element && reader2.Name == "rasa")
                                {
                                    reader2.Read();
                                    d.Rasa = reader2.Value;
                                }


                            }
                            dogs.Add(d);
                        }
                    }

                }
            }
            PersonList.ItemsSource = people;
            DogList.ItemsSource = dogs;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }
    }
}
