using System;
using System.Drawing;
using System.Windows.Forms;

namespace StarWars
{
    class Pillar
    {
        private readonly PictureBox pillar;
        readonly int height = 60;
        readonly int weight = 500;
        readonly int speedPillar = 15;
       
        public Pillar(Form f1, int x, int y)
        {
            pillar = new PictureBox
            {
                BackgroundImage = HelicopterShooting.Properties.Resources.pillar,
                BackColor = Color.Transparent,
                Size = new Size(height, weight),
                Location = new Point(x, y)
            };
            f1.Controls.Add(pillar);
        }
        public void Appearance()
        {
            if (pillar.Left < -100)
            {
                Random rnd = new Random();
                int x = rnd.Next(600, 700);

                pillar.Left = x;
            }
        }

        public void PillarMove()
        {
            pillar.Left -= speedPillar;
        }
        public int GetHeight()
        {
            return pillar.Height;
        }
        public int getWidth()
        {
            return pillar.Width;
        }
        public int GetLeft()
        {
            return pillar.Left;
        }
        public PictureBox getPic()
        {
            return pillar;
        }

        public void Dispose()
        {
            pillar.Dispose();
        }
    }
}