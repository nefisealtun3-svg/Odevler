using Ödev1_.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ödev1_.Models;

namespace Ödev1_
{
    public partial class Form1 : Form
    {
        private GameEngine engine;
        public Form1(int selectedLevel = 1)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Kenarlıkları kaldır
            this.WindowState = FormWindowState.Maximized; // Ekranı kapla
            this.TopMost = true; // Hep üstte kalsın (Opsiyonel)

            this.DoubleBuffered = true;
            engine = new GameEngine();

            for (int i = 1; i < selectedLevel; i++)
            {
                engine.NextLevel();
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            engine.UpdateGame(); // Mantıksal hesaplamalar
            this.Invalidate();   // Ekranı tazele (OnPaint'i tetikler)
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            int step = 10;
            switch (e.KeyCode)
            {
                // UpdatePlayer yerine doğrudan Player koordinatlarını güncelleyebiliriz 
                // ya da GameEngine içine UpdatePlayer metodunu geri ekleyebiliriz.
                case Keys.Up: engine.Player.Y -= step; break;
                case Keys.Down: engine.Player.Y += step; break;
                case Keys.Left: engine.Player.X -= step; break;
                case Keys.Right: engine.Player.X += step; break;
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Arka planı resim yerine düz bir renkle temizle (Çim yeşili gibi)
            g.Clear(Color.ForestGreen);

            // Nesneleri çiz
            engine.Player.Draw(g);
            foreach (var obj in engine.GameObjects)
            {
                obj.Draw(g);
            }

            // Skor Tablosu
            g.DrawString($"Level: {engine.CurrentLevel}  Skor: {engine.Player.Score}",
                         new Font("Arial", 14, FontStyle.Bold), Brushes.White, 10, 10);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Oyun penceresi kapandığında gizli olan ana menüyü (LevelMenu) bul ve göster
            foreach (Form f in Application.OpenForms)
            {
                if (f is LevelMenu)
                {
                    f.Show();
                    break; // Menüyü bulduk, döngüden çıkabiliriz
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
