using PotapanjeBrodova;
using System;
using System.Windows.Forms;

namespace PrikazFlote
{
    public partial class FormFlota : Form
    {
        public FormFlota()
        {
            InitializeComponent();
            mrežaZaFlotu.ZadajMrežu(redaka, stupaca);
        }

        private void botunSloži_Click(object sender, EventArgs e)
        {
            int[] duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Brodograditelj b = new Brodograditelj();
            var flota = b.SložiFlotu(redaka, stupaca, duljineBrodova);
            mrežaZaFlotu.PostaviFlotu(flota);
        }

        int redaka = 10;
        int stupaca = 10;
    }
}
