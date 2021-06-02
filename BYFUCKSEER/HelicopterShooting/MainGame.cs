using System;
using System.Drawing;
using System.Windows.Forms;

namespace StarWars
{
    public partial class MainGame : Form
    {
        Game game;
        public MainGame()
        {
            InitializeComponent();
            this.Size = new Size(800, 500);
            timer1.Start();
            game = new Game(this);
            this.BackgroundImage = HelicopterShooting.Properties.Resources.background;

        }

        public void EnableSound(bool x)
        {
            game.SetSound(x);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Vẽ
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            game.Draw(e);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            game.NewGame(this, label1, label2, timer1);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    game.SetDown(true);
                    break;
                case Keys.Up:
                    game.SetUp(true);
                    break;
                case Keys.Space:
                    game.SetShoot(true);
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    game.SetDown(false);
                    break;
                case Keys.Up:
                    game.SetUp(false);
                    break;
                case Keys.Space:
                    game.SetShoot(false);
                    break;
                default:
                    break;
            }
        }

        private void MainGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }

        private void MainGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if(MessageBox.Show("Действительно хотите закрыть? Крутая игра же(","Задумайся",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                e.Cancel = true;
                timer1.Start();
            }
            else
            {
                FormMain fm = new FormMain();
                fm.Show();
            }
        }
    }
}
