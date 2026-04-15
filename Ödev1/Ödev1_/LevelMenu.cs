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

namespace Ödev1_
{
    public partial class LevelMenu : Form
    {
        public LevelMenu()
        {
            InitializeComponent();
            GenerateLevelButtons();
        }

        private void GenerateLevelButtons()
        {
            int levelCount = 50;
            int unlockedLevel = InstallationGuard.GetSavedLevel(); // Kayıtlı Seviyeyi Oku

            flowLayoutPanel1.Controls.Clear();

            for (int i = 1; i <= levelCount; i++)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Width = 50;
                btn.Height = 50;
                btn.Tag = i;

                if (i <= unlockedLevel)
                {
                    btn.BackColor = Color.LightGreen;
                    btn.Enabled = true;
                    btn.Click += Btn_Click;
                }
                else
                {
                    btn.BackColor = Color.Gray;
                    btn.Text = "🔒";
                    btn.Enabled = false;
                }
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            GenerateLevelButtons();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int selectedLevel = (int)((Button)sender).Tag;
            Form1 game = new Form1(selectedLevel);
            game.Show();
            this.Hide();
        }

        private void LevelMenu_Load(object sender, EventArgs e)
        {

        }

        private void LevelMenu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
