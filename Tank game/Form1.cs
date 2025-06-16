using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tank_game.Properties;

namespace Tank_game
{
    public partial class Form1 : Form
    {
        //Components' speeds
        int tankSpeed = 4;
        int bulletSpeed = 10;
        string bulletDirection = "right";    // Set to "up"
        string blueTankDirection = "right";

        //Player scores
        int redTankScore = 0;
        int blueTankScore = 0;

        //List of bullets
        List<Rectangle> bulletList = new List<Rectangle>();

        //Declaring moving options
        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool shooting = false;
        bool shooting2 = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        Pen whitePen = new Pen(Color.White, 5);


        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(960, 553);
        }

        //Start button
        private void startButton_Click(object sender, EventArgs e)
        {
            menu_box.Visible = false;
            startButton.Visible = false;
            quitButton.Visible = false;
            this.BackgroundImage = Properties.Resources.background;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            box1.Visible = true;
            box2.Visible = true;
            box3.Visible = true;
            box4.Visible = true;
            box5.Visible = true;
            box6.Visible = true;
            tripleBox1.Visible = true;
            tripleBox2.Visible = true;
            blueTank.Visible = true;
            redTank.Visible = true;
            blueTank.Location = new Point(70, this.Height / 2 - 36);
            redTank.Location = new Point(820, this.Height / 2 - 36);
            gameTimer.Start();
            this.Focus();
        }


        //Quit button
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle box1_hitbox = new Rectangle(342,85, 15, 3);
            
        }

        ///Game logic
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Move blue tank and set boundaries
            if (wDown == true && blueTank.Top > 10)
            {
                blueTank.Top -= tankSpeed;
                blueTank.Image = Resources.blue_tank_up;
            }

            if (sDown == true && blueTank.Top < this.Height - 106)
            {
                blueTank.Top += tankSpeed;
                blueTank.Image = Resources.blue_tank_down;
            }

            if (aDown == true && blueTank.Left > 10)
            {
                blueTank.Left -= tankSpeed;
                blueTank.Image = Resources.blue_tank_left;
            }

            if (dDown == true && blueTank.Left < this.Width - 80)
            {
                blueTank.Left += tankSpeed;
                blueTank.Image = Resources.blue_tank_right;
            }
            //Move red tank and set boundaries
            if (upArrowDown == true && redTank.Top > 10)
            {
                redTank.Top -= tankSpeed;
                redTank.Image = Resources.red_tank_up;
            }

            if (downArrowDown == true && redTank.Top < this.Height - 106)
            {
                redTank.Top += tankSpeed;
                redTank.Image = Resources.red_tank_down;
            }

            if (leftArrowDown == true && redTank.Left > 10)
            {
                redTank.Left -= tankSpeed;
                redTank.Image = Resources.red_tank_left;
            }

            if (rightArrowDown == true && redTank.Left < this.Width - 80)
            {
                redTank.Left += tankSpeed;
                redTank.Image = Resources.red_tank_right;
            }

            //Blue tank shooting
            if (shooting == true)
            {
                switch (bulletDirection)
                {
                    case "up":
                        bullet.Image = Resources.bullet_vertical;
                        bullet.Top -= bulletSpeed;
                        break;
                    case "down":
                        bullet.Image = Resources.bullet_vertical;
                        bullet.Top += bulletSpeed;
                        break;
                    case "left":
                        bullet.Image = Resources.bullet_horizontal;
                        bullet.Left -= bulletSpeed;
                        break;
                    case "right":
                        bullet.Image = Resources.bullet_horizontal;
                        bullet.Left += bulletSpeed;
                        break;
                }
            }

            switch (blueTankDirection)
            {
                case "up":
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Top += 8;
                    }
                    break;
                case "down":
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Top -= 8;
                    }
                    break;
                case "left":
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Left += 8;
                    }
                    break;
                case "right":
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Left -= 8;
                    }
                    break;
            }
            //Remove when bullets go out the screen
            if (bullet.Left > this.Width)
            {

                bullet.Location = new Point(blueTank.Left + bullet.Width, blueTank.Top + bullet.Height);
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Left < 0)
            {
                bullet.Location = new Point(blueTank.Left, blueTank.Top);
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Top > this.Height)
            {
                bullet.Location = new Point(blueTank.Left, blueTank.Top);
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Top < 0)
            {
                bullet.Location = new Point(blueTank.Left, blueTank.Top);
                bullet.Visible = false;
                shooting = false;
            }

            int dx = 0, dy = 0;

            if (wDown) dy -= 1;
            if (sDown) dy += 1;
            if (aDown) dx -= 1;
            if (dDown) dx += 1;

            // Normalize diagonal movement so it isn't faster
            if (dx != 0 && dy != 0)
            {
                double diagonal = 1 / Math.Sqrt(2);
                dx = (int)(dx * diagonal * tankSpeed);
                dy = (int)(dy * diagonal * tankSpeed);
            }
            else
            {
                dx *= tankSpeed;
                dy *= tankSpeed;
            }

            // Move the tank
            blueTank.Left += dx;
            blueTank.Top += dy;
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    blueTankDirection = "up";
                    bulletDirection = "up";
                    wDown = true;
                    break;
                case Keys.S:
                    blueTankDirection = "down";
                    bulletDirection = "down";
                    sDown = true;
                    break;
                case Keys.A:
                    blueTankDirection = "left";
                    bulletDirection = "left";
                    aDown = true;
                    break;
                case Keys.D:
                    blueTankDirection = "right";
                    bulletDirection = "right";
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.F:
                    bullet.Visible = true;
                    shooting = true;
                    
                    break;
                case Keys.P:
                    shooting2 = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.F:
                  //  shooting = false;
                    break;
                case Keys.P:
                   //  shooting2 = false;
                    break;
            }
        }
        
    }
}
