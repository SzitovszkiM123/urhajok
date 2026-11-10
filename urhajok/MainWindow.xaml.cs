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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
}