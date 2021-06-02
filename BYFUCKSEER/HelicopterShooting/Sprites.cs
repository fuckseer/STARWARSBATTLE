using System.Drawing;
using System.Windows.Forms;

namespace StarWars
{
    class Sprites
    {
        readonly int speed;
        Image image;
        Rectangle rectangle;
        private PictureBox bullet;
        private int index;
        int healthpoint;

        public Sprites()
        {
            healthpoint = 3;
            image = HelicopterShooting.Properties.Resources.heli1;
            rectangle = new Rectangle(0, 50, 100, 54);
            speed = 10;
            index = 0;
        }
        public void Draw(PaintEventArgs e)
        {
            ++index;
            image = HelicopterShooting.Properties.Resources.heli1;
            Graphics = e.Graphics;
            Graphics.DrawImage(image, rectangle);
        }
        public void SetRecUp()
        {
            rectangle.Y -= speed;
        }
        public void SetRecDown()
        {
            rectangle.Y += speed;
        }
        public void MakeBullet(Form f1)
        {
            bullet = new PictureBox
            {
                BackColor = Color.DarkOrange,
                Height = 5,
                Width = 10,
                Tag = "bullet",
                Location = new Point(rectangle.X + 80, rectangle.Y + 54 / 2)
            };
            f1.Controls.Add(bullet);
        }

        public Rectangle Rectangle => rectangle;
        public PictureBox Getbullet => bullet;

        public int Healpoint()
        {
            return healthpoint;
        }
        public void Healpoint(int a)
        {
            healthpoint -= a;
        }

        public Graphics Graphics { get; private set; }
    }
}