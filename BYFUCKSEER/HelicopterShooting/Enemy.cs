using System;
using System.Drawing;
using System.Windows.Forms;

namespace StarWars
{
    class Enemy
    {
        Image image;
        Graphics g;
        Rectangle rect;
        private int index;
        readonly int speed = 15;
        readonly int type;

        public Enemy(int x, int y)
        {
            Random rnd = new Random();
            type = rnd.Next(1, 4);
            rect = new Rectangle(x, y, 100, 60);
            index = 0;
        }

        public void Draw(PaintEventArgs e)
        {
            ++index;
            image = HelicopterShooting.Properties.Resources.alien1_1;
            g = e.Graphics;
            g.DrawImage(image, rect);

        }

        public void Move()
        {
            rect.X -= speed;
        }

        public int GetHeigth()
        {
            return rect.Height;
        }


        public int GetLeft()
        {
            return rect.Left;
        }
        public Image Image()
        {
            return image;
        }

        public Rectangle Rectangle()
        {
            return rect;
        }
        public void SetLeft(int x)
        {
            rect.Location = new Point(x, 0);
        }
        public Graphics graphics()
        {
            return g;
        }
    }
}