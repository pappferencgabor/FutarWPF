using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfDolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Fuvar> fuvarlista = new List<Fuvar>();
        static List<int> fuvarok = new List<int>();

        public MainWindow()
        {
            InitializeComponent();

            fuvarlista = File.ReadAllLines("Data\\fuvar.csv")
                .Skip(1)
                .Select(x => new Fuvar(
                    int.Parse(x.Split(";")[0]),
                    x.Split(";")[1],
                    int.Parse(x.Split(";")[2]),
                    double.Parse(x.Split(";")[3]),
                    double.Parse(x.Split(";")[4]),
                    double.Parse(x.Split(";")[5]),
                    x.Split(";")[6])
                )
                .ToList();

            foreach (Fuvar fuvar in fuvarlista)
            {
                if (!fuvarok.Contains(fuvar.ID))
                {
                    fuvarok.Add(fuvar.ID);
                }
            }
            fuvarok.Sort();
            cmbFuvarID.ItemsSource = fuvarok;
        }

        private void btnFeladat3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"3. feladat: {fuvarlista.Count} fuvar");
        }

        private void btnFeladat4_Click(object sender, RoutedEventArgs e)
        {
            double bevetel = 0;
            int fuvarokSzama = 0;

            foreach (Fuvar fuvar in fuvarlista)
            {
                if (fuvar.ID == int.Parse(cmbFuvarID.SelectedItem.ToString()))
                {
                    bevetel += fuvar.VitelDij;
                    fuvarokSzama++;
                }
            }
            MessageBox.Show($"4. feladat: {fuvarokSzama} fuvar alatt: {bevetel}$");
        }

        private void btnFeladat5_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> modokDict = new Dictionary<string, int>();

            foreach (Fuvar fuvar in fuvarlista)
            {
                if (!modokDict.ContainsKey(fuvar.FizetesiMod))
                {
                    modokDict.Add(fuvar.FizetesiMod, 1);
                }
                else
                {
                    modokDict[fuvar.FizetesiMod]++;
                }
            }

            foreach (KeyValuePair<string, int> mod in modokDict)
            {
                lbFizetesiModok.Items.Add($"{mod.Key}: {mod.Value} fuvar");
            }
        }

        private void btnFeladat6_Click(object sender, RoutedEventArgs e)
        {
            double osszTav = 0;

            fuvarlista.ForEach(x => osszTav += x.Tavolsag * 1.6);
            MessageBox.Show($"6. feladat: {Math.Round(osszTav, 2)} km");
        }

        private void btnFeladat7_Click(object sender, RoutedEventArgs e)
        {
            int leghosszabb = 0;

            foreach (Fuvar fuvar in fuvarlista)
            {
                if (fuvar.Idotartam > leghosszabb)
                {
                    leghosszabb = fuvar.Idotartam;
                }
            }

            foreach (Fuvar fuvar in fuvarlista)
            {
                if (fuvar.Idotartam == leghosszabb)
                {
                    lbLeghosszabbFuvar.Items.Add($"Fuvar hossza: {fuvar.Idotartam} másodperc");
                    lbLeghosszabbFuvar.Items.Add($"Taxi azonosító: {fuvar.ID}");
                    lbLeghosszabbFuvar.Items.Add($"Megtett távolság: {fuvar.Tavolsag} km");
                    lbLeghosszabbFuvar.Items.Add($"Viteldíj: {fuvar.VitelDij}$");
                }
            }
        }

        private void btnFeladat8_Click(object sender, RoutedEventArgs e)
        {
            /*string[] sorok;
            foreach (Fuvar fuvar in fuvarlista)
            {
                if (fuvar.Idotartam > 0 && fuvar.VitelDij > 0 && fuvar.Tavolsag == 0)
                {
                    sorok.Append("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
                }
            }*/
        }
    }
}
