using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace GUIgame
{
    public partial class game : Form
    {
        public List<PictureBox> fireBullet = new List<PictureBox>();
        PictureBox enemy = new PictureBox();
        string enemyDirection = "MovingRight";
        public game()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enemy = makeEnemy(Properties.Resources.monster);
            this.Controls.Add(enemy);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void enemy_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
                player.Left += 25;
            }
            if(Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                player.Left -= 25;
            }
            if(Keyboard.IsKeyPressed(Key.Space))
            {
                Image img = Properties.Resources.fire;
                PictureBox fire = createFire(img, player);
                fireBullet.Add(fire);
                this.Controls.Add(fire);
            }
            foreach(PictureBox bullet in fireBullet)
            {
                bullet.Top = bullet.Top - 20;
            }
            for(int idx = 0;idx < fireBullet.Count; idx++)
            {
                if(fireBullet[idx].Bottom < 0)
                {
                    fireBullet.Remove(fireBullet[idx]);
                }
            }
            moveEnemy(enemy, ref enemyDirection);
        }
        Random rand = new Random();
        private PictureBox makeEnemy(Image img)
        {
            PictureBox enemy = new PictureBox();
            int left = rand.Next(30, this.Width);
            int top = rand.Next(5, img.Height + 20);

            enemy.Left = left;
            enemy.Top = top;
            enemy.Height = img.Height;
            enemy.Width = img.Width;
            enemy.BackColor = Color.Transparent;
            enemy.Image = img;
            return enemy;
        }
        private void moveEnemy(PictureBox enemy, ref string enemyDirection)
        {
            if(enemyDirection == "MovingRight")
            {
                enemy.Left = enemy.Left + 10;
            }
            if (enemyDirection == "MovingLeft")
            {
                enemy.Left = enemy.Left - 10;
            }
            if((enemy.Left + enemy.Width) > this.Width)
            {
                enemyDirection = "MovingLeft";
            }
            if(enemy.Left <= 2)
            {
                enemyDirection = "MovingRight";
            }
        }
        private PictureBox createFire(Image fireImage, PictureBox source)
        {
            PictureBox fire = new PictureBox();
            fire.Image = fireImage;
            fire.Height = fireImage.Height;
            fire.Width = fireImage.Width;
            fire.BackColor = Color.Transparent;
            System.Drawing.Point location;
            location = new System.Drawing.Point();
            location.X = source.Left + (source.Width / 2) - 5;
            location.Y = source.Top;
            fire.Location = location;
            return fire;

        }
    }
}
