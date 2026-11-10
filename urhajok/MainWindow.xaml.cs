using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace urhajok
{
    public class Urhajo
    {
        public string Nev { get; set; }
        public int Legenyseg { get; set; }
        public int MaxHatotav { get; set; }
        public int UzemenyagSzint { get; set; }
        public string Gyarto { get; set; }
        public string KuldetesStatusz { get; set; }
        public int InditasEve { get; set; }
        public Urhajo(string nev, int legenyseg, int maxHatotav, int uzemenyagSzint, string gyarto, string kuldetesStatusz, int inditasEve)
        {
            Nev = nev;
            Legenyseg = legenyseg;
            MaxHatotav = maxHatotav;
            UzemenyagSzint = uzemenyagSzint;
            Gyarto = gyarto;
            KuldetesStatusz = kuldetesStatusz;
            InditasEve = inditasEve;
        }
    }

    public partial class MainWindow : Window
    {
        List<Urhajo> urhajok = new List<Urhajo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void betolt(object sender, RoutedEventArgs e)
        {
            urhajok.Clear();
            urhajok.Add(new Urhajo("Falcon-9", 7, 550000, 87, "SpaceX", "Sikeres", 2020));
            urhajok.Add(new Urhajo("Orion-X1", 4, 820000, 73, "NASA", "Folyamatban", 2023));
            urhajok.Add(new Urhajo("StarRider", 12, 910000, 66, "Boeing", "Sikeres", 2019));
            urhajok.Add(new Urhajo("SolarWind", 3, 300000, 92, "ESA", "Sikertelen", 2018));
            urhajok.Add(new Urhajo("Galaxy-Cruiser", 18, 1200000, 54, "Blue Origin", "Sikeres", 2022));
            urhajok.Add(new Urhajo("Nova-Prime", 10, 760000, 80, "Roscosmos", "Sikeres", 2017));
            urhajok.Add(new Urhajo("Pioneer-VII", 6, 640000, 70, "NASA", "Folyamatban", 2024));
            urhajok.Add(new Urhajo("Titan-Hawk", 14, 1050000, 48, "SpaceX", "Sikeres", 2021));
            urhajok.Add(new Urhajo("CosmoJet", 5, 430000, 93, "JAXA", "Sikertelen", 2016));
            urhajok.Add(new Urhajo("Nebula-FX", 11, 870000, 60, "ESA", "Sikeres", 2020));
            dgrid.ItemsSource = urhajok;
            dgrid.Items.Refresh();
        }

        private void hanyurhajo(object sender, RoutedEventArgs e)
        {
            if (!urhajok.Any())
            {
                MessageBox.Show("Nincs betöltve űrhajó lista!");
            }
            else
            {
                MessageBox.Show($"{urhajok.Count()} db űrhajó van");
            }
        }

        private void legnagyobbhatotav(object sender, RoutedEventArgs e)
        {
            if (!urhajok.Any())
            {
                MessageBox.Show("Nincs betöltve űrhajó lista!");
            }
            else
            {
                var legnagyobb = urhajok.OrderByDescending(u => u.MaxHatotav).Take(1).ToList();
                dgrid.ItemsSource = legnagyobb;
            }
        }

        private void sikeres(object sender, RoutedEventArgs e)
        {
            if (!urhajok.Any())
            {
                MessageBox.Show("Nincs betöltve űrhajó lista!");
            }
            else
            {
                var sikeresek = urhajok.Where(u => u.KuldetesStatusz == "Sikeres").ToList();
                dgrid.ItemsSource = sikeresek;
            }
        }

        private void atlag(object sender, RoutedEventArgs e)
        {
            if (!urhajok.Any())
            {
                MessageBox.Show("Nincs betöltve űrhajó lista!");
            }
            else
            {
                var atlag = urhajok.Average(u => u.Legenyseg);
                MessageBox.Show($"Az űrhajók átlagos legénységszáma: {atlag}");
            }
        }

        private void gyartok(object sender, RoutedEventArgs e)
        {
            if (!urhajok.Any())
            {
                MessageBox.Show("Nincs betöltve űrhajó lista!");
            }
            else
            {
                List<string> gyartok = new List<string>();
                foreach (var u in urhajok)
                {
                    if (!gyartok.Contains(u.Gyarto))
                    {
                        gyartok.Add(u.Gyarto);
                    }
                }
                var sorok = gyartok.Select(gy =>
                {
                    var nevek = urhajok.Where(u => u.Gyarto == gy).Select(u => u.Nev).ToList();
                    return $"{gy} ({nevek.Count()} db): {string.Join(", ", nevek)}";
                }).ToList();

                MessageBox.Show(string.Join("\n", sorok));
            }
        }

    }
}

