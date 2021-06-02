using System;
using System.Media;
using System.Windows.Forms;

namespace StarWars
{
    class Game
    {
        readonly SoundPlayer pl;
        bool sound;
        int score;
        readonly Sprites player;
        Pillar pillar1;
        Pillar pillar2;
        bool enable;
        readonly Random rnd;
        Enemy enemy;
        readonly int DoChenhLech = 80;
        bool up;
        bool down;
        bool shoot;
  
        public Game()
        {

        }
        public Game(Form f1)
        {
            pl = new SoundPlayer();
            sound = false;
            rnd = new Random();
            player = new Sprites();
            enable = true;
            TaoPillar(f1);
            TaoEnemy();
        }
        void TaoPillar(Form f1)
        {

            int y = rnd.Next(-470, -150);
            int x = 700;
            pillar1 = new Pillar(f1, x, y);
            pillar2 = new Pillar(f1, x, pillar1.GetHeight() + y + DoChenhLech);
            enable = true;

        }

        void TaoEnemy()
        {
            enemy = new Enemy(pillar1.GetLeft() + pillar1.getWidth() + rnd.Next(200, 400), rnd.Next(100, 350) - 48);
        }
        public void Draw(PaintEventArgs e)
        {
            player.Draw(e);
            if (enable == true) enemy.Draw(e);
        }
        public void NewGame(Form f1, Label label1, Label label2, Timer timer1)
        {
            if (up)
            {
                if (player.Rectangle.Y >= 0)
                    player.SetRecUp();
            }
            if (down)
            {
                if ((player.Rectangle.Y + player.Rectangle.Height) <= f1.Size.Height - player.Rectangle.Height)
                    player.SetRecDown();
            }

            if (shoot)
                player.MakeBullet(f1);
            enemy.Move();
            f1.Invalidate();
            foreach (Control temp in f1.Controls)
            {
                if (temp is PictureBox && temp.Tag == "bullet")
                {
                    temp.Left += 10;
                    if (temp.Left >= 800)
                    {
                        f1.Controls.Remove(temp);
                        temp.Dispose();
                    }
                    if ((temp.Left + temp.Width) >= enemy.GetLeft() && temp.Location.Y >= enemy.Rectangle().Y && temp.Location.Y <= enemy.Rectangle().Y + enemy.Rectangle().Height)
                    {
                        score++;
                        if (sound == true) PlaySound("ding_sound.wav");
                        player.Healpoint(-1);
                        enemy.SetLeft(-120);
                        f1.Controls.Remove(temp);
                        temp.Dispose();
                    }

                }
            }

            pillar1.PillarMove();
            pillar2.PillarMove();

            if (enemy.GetLeft() < -100)
            {
                player.Healpoint(1);
                enemy.graphics().Dispose();
                if (enable == false) enable = true;
                TaoEnemy();
            }

            if (pillar1.GetLeft() < -100)
            {
                f1.Controls.Remove(pillar1.getPic());
                f1.Controls.Remove(pillar2.getPic());
                pillar1.getPic().Dispose();
                pillar2.getPic().Dispose();
                enable = false;
                TaoPillar(f1);
            }

            label1.Text = "MISS : " + player.Healpoint();
            label2.Text = "SCORE : " + score.ToString();

            if (CheckVaCham() == true || player.Healpoint() == 0)
            {
                if (sound == true) PlaySound("crash_sound.wav");
                timer1.Stop();
                MessageBox.Show("Конец игры! Ваш счёт " + score);
                FormMain fm = new FormMain();
                fm.Show();
                EndGame(f1);
            }
        }

        public void EndGame(Form f1)
        {
            f1.Dispose();
        }


        private bool CheckVaCham()
        {
            int x1 = 0;
            int x2 = x1 + player.Rectangle.Width;
            int y1 = player.Rectangle.Location.Y;
            int y2 = y1 + player.Rectangle.Height;
            if (player.Rectangle.IntersectsWith(enemy.Rectangle()) && (player.Rectangle.Left + player.Rectangle.Width) >= (enemy.Rectangle().Left + 20)
                && ((player.Rectangle.Location.Y <= enemy.Rectangle().Location.Y + enemy.Rectangle().Height - 10) 
                || (player.Rectangle.Location.Y + player.Rectangle.Height >= enemy.Rectangle().Location.Y - 20))) return true;
            if (x2 - 15 == pillar1.getPic().Location.X)
            {
                if (y1 <= pillar1.getPic().Location.Y + pillar1.getPic().Height || y2 >= pillar2.getPic().Location.Y)
                    return true;
            }
            if (x2 - 15 > pillar1.getPic().Location.X && x2 - 15 <= pillar1.getPic().Location.X + pillar1.getPic().Width)
            {
                if (y1 <= pillar1.getPic().Location.Y + pillar1.getPic().Height || y2 >= pillar2.getPic().Location.Y)
                    return true;
            }
            if (x2 - 15 > pillar1.getPic().Location.X + pillar1.getPic().Width)
            {
                if (x1 <= pillar1.getPic().Location.X + pillar1.getPic().Width)
                {
                    if (y1 <= pillar1.getPic().Location.Y + pillar1.getPic().Height || y2 - 10 >= pillar2.getPic().Location.Y)
                        return true;
                }
            }
            return false;
        }
        public void SetUp(bool x)
        {
            up = x;
        }
        public void SetDown(bool x)
        {
            down = x;
        }
        public void SetShoot(bool x)
        {
            shoot = x;
        }

        public void SetSound(bool x)
        {
            sound = x;
        }

        void PlaySound(string s)
        {
            pl.SoundLocation = Application.StartupPath + @"\Sounds\" + s;
            pl.Play();
        }
    }
}