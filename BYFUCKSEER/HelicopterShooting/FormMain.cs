using System;
using System.Windows.Forms;

namespace StarWars
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            pictureBox1.Image = HelicopterShooting.Properties.Resources.StarWars;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainGame g = new MainGame();
            g.Show();
            
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
