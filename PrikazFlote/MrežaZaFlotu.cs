// 'MrežaZaFlotu.cs' u projektu 'PrikazFlote'
using PotapanjeBrodova;
using System.Drawing;
using System.Windows.Forms;

namespace PrikazFlote
{
    public partial class MrežaZaFlotu : Control
    {
        public MrežaZaFlotu()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        public void ZadajMrežu(int redaka, int stupaca)
        {
            if (this.redaka == redaka && this.stupaca == stupaca)
                return;
            this.redaka = redaka;
            this.stupaca = stupaca;
            Invalidate();
        }

        public void PostaviFlotu(Flota flota)
        {
            this.flota = flota;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            NacrtajPozadinu(pe);
            NacrtajMrežu(pe);
            if (flota != null)
                NacrtajFlotu(pe);
            base.OnPaint(pe);
        }

        private int ŠirinaPolja
        {
            get { return (ClientRectangle.Width - 1) / redaka; }
        }

        private int VisinaPolja
        {
            get { return (ClientRectangle.Height - 1) / stupaca; }
        }

        private void NacrtajPozadinu(PaintEventArgs pe)
        {
            int širina = ŠirinaPolja * stupaca + 1;
            int visina = VisinaPolja * redaka + 1;
            pe.Graphics.FillRectangle(SystemBrushes.Window, 0, 0, širina, visina);
        }

        private void NacrtajMrežu(PaintEventArgs pe)
        {
            NacrtajHorizontalneLinije(pe);
            NacrtajVertikalneLinije(pe);
        }

        private void NacrtajHorizontalneLinije(PaintEventArgs pe)
        {
            int x1 = 0;
            int x2 = ŠirinaPolja * stupaca;
            int y = 0;
            for (int r = 0; r <= redaka; ++r)
            {
                pe.Graphics.DrawLine(peroLinija, x1, y, x2, y);
                y += VisinaPolja;
            }
        }

        private void NacrtajVertikalneLinije(PaintEventArgs pe)
        {
            int x = 0;
            int y1 = 0;
            int y2 = VisinaPolja * redaka;
            for (int s = 0; s <= stupaca; ++s)
            {
                pe.Graphics.DrawLine(peroLinija, x, y1, x, y2);
                x += ŠirinaPolja;
            }
        }

        private void NacrtajFlotu(PaintEventArgs pe)
        {
            foreach (Brod b in flota.Brodovi)
            {
                foreach (Polje polje in b.Polja)
                    NacrtajPoljeBroda(pe, polje);
            }
        }

        private void NacrtajPoljeBroda(PaintEventArgs pe, Polje polje)
        {
            int redak = polje.Redak;
            int stupac = polje.Stupac;
            int x = redak * ŠirinaPolja;
            int y = stupac * VisinaPolja;
            pe.Graphics.FillRectangle(bojaBroda, x, y, ŠirinaPolja, VisinaPolja);
            pe.Graphics.DrawRectangle(peroLinija, x, y, ŠirinaPolja, VisinaPolja);
        }

        private int redaka = 10;
        private int stupaca = 10;
        private Flota flota;

        private Pen peroLinija = new Pen(SystemColors.ActiveBorder);
        private Brush bojaBroda = new SolidBrush(Color.Navy);
    }
}
