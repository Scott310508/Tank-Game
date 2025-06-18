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
        int tankSpeed = 3;
        int tankboostedSpeed = 10;
        int bulletSpeed = 17;

        //Components' directions
        string bulletDirection = "";
        string blueTankDirection = "";
        string redTankDirection = "right";

        //Player scores
        int redTankScore = 0;
        int blueTankScore = 0;

        Random randGen = new Random();
        Random randGen2 = new Random();
        int randValue = 0;
        int randValue2 = 0;
        float speedBoostDuration = 0f;

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
            blueTankHealthLabel.Visible = true;
            blueTankHealth.Visible = true;
            redTankHealthLabel.Visible = true;
            redTankHealth.Visible = true;
            blueTank.Location = new Point(70, this.Height / 2 - 34);
            redTank.Location = new Point(820, this.Height / 2 - 34);
            gameTimer.Start();
            powerUps_Timer.Start();
            this.Focus();
        }


        //Quit button
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

            if (sDown == true && blueTank.Top < this.Height - 95)
            {
                blueTank.Top += tankSpeed;
                blueTank.Image = Resources.blue_tank_down;
            }

            if (aDown == true && blueTank.Left > 10)
            {
                blueTank.Left -= tankSpeed;
                blueTank.Image = Resources.blue_tank_left;
            }

            if (dDown == true && blueTank.Left < this.Width - 70)
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

            if (downArrowDown == true && redTank.Top < this.Height - 95)
            {
                redTank.Top += tankSpeed;
                redTank.Image = Resources.red_tank_down;
            }

            if (leftArrowDown == true && redTank.Left > 10)
            {
                redTank.Left -= tankSpeed;
                redTank.Image = Resources.red_tank_left;
            }

            if (rightArrowDown == true && redTank.Left < this.Width - 65)
            {
                redTank.Left += tankSpeed;
                redTank.Image = Resources.red_tank_right;
            }

            // Normalize diagonal movement so it isn't faster
            int blue_dx = 0, blue_dy = 0;
            int red_dx = 0, red_dy = 0;
            if (blue_dx != 0 && blue_dy != 0)
            {
                double diagonal = 1 / Math.Sqrt(2);
                blue_dx = (int)(blue_dx * diagonal * tankSpeed);
                blue_dy = (int)(blue_dy * diagonal * tankSpeed);
            }
            else
            {
                blue_dx *= tankSpeed;
                blue_dy *= tankSpeed;
            }

            if (red_dx != 0 && red_dy != 0)
            {
                double diagonal = 1 / Math.Sqrt(2);
                red_dx = (int)(red_dx * diagonal * tankSpeed);
                red_dy = (int)(red_dy * diagonal * tankSpeed);
            }
            else
            {
                red_dx *= tankSpeed;
                red_dy *= tankSpeed;
            }

            // Move the tank
            blueTank.Left += blue_dx;
            blueTank.Top += blue_dy;
            //redTank.Left += red_dx;
            //redTank.Top += red_dy;

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

            //Remove when bullets go out the screen
            if (bullet.Left > this.Width)
            {
                bulletDirection = "";
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Left < 0)
            {
                bulletDirection = "";
                bullet.Location = new Point(blueTank.Left, blueTank.Top);
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Top > this.Height)
            {
                bulletDirection = "";
                bullet.Location = new Point(blueTank.Left, blueTank.Top);
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Top < 0)
            {
                bulletDirection = "";
                bullet.Location = new Point(blueTank.Left, blueTank.Top);
                bullet.Visible = false;
                shooting = false;
            }

            //Building obstacles inside the map
            //Collision between blue tank and boxes
            switch (blueTankDirection)
            {
                case "up":
                    bullet.Left = blueTank.Left + (blueTank.Width - bullet.Width) / 2;
                    bullet.Top = blueTank.Top - bullet.Height;
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Top += tankSpeed;
                    }
                    break;
                case "down":
                    bullet.Left = blueTank.Left + (blueTank.Width - bullet.Width) / 2;
                    bullet.Top = blueTank.Bottom;
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Top -= tankSpeed;
                    }
                    break;
                case "left":
                    bullet.Left = blueTank.Left - bullet.Width;
                    bullet.Top = blueTank.Top + (blueTank.Height - bullet.Height) / 2;
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Left += tankSpeed;
                    }
                    break;
                case "right":
                    //bullet.Left = blueTank.Right;
                    //bullet.Top = blueTank.Top + (blueTank.Height - bullet.Height) / 2;
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Left -= tankSpeed;
                    }
                    break;
            }

            //Collision between red tank and boxes
            switch (redTankDirection)
            {
                case "up":
                    if (redTank.Bounds.IntersectsWith(box1.Bounds) || redTank.Bounds.IntersectsWith(box2.Bounds) || redTank.Bounds.IntersectsWith(box3.Bounds)
                    || redTank.Bounds.IntersectsWith(box4.Bounds) || redTank.Bounds.IntersectsWith(box5.Bounds) || redTank.Bounds.IntersectsWith(box6.Bounds)
                    || redTank.Bounds.IntersectsWith(tripleBox1.Bounds) || redTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        redTank.Top += tankSpeed;
                    }
                    break;
                case "down":
                    if (redTank.Bounds.IntersectsWith(box1.Bounds) || redTank.Bounds.IntersectsWith(box2.Bounds) || redTank.Bounds.IntersectsWith(box3.Bounds)
                    || redTank.Bounds.IntersectsWith(box4.Bounds) || redTank.Bounds.IntersectsWith(box5.Bounds) || redTank.Bounds.IntersectsWith(box6.Bounds)
                    || redTank.Bounds.IntersectsWith(tripleBox1.Bounds) || redTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        redTank.Top -= tankSpeed;
                    }
                    break;
                case "left":
                    if (redTank.Bounds.IntersectsWith(box1.Bounds) || redTank.Bounds.IntersectsWith(box2.Bounds) || redTank.Bounds.IntersectsWith(box3.Bounds)
                    || redTank.Bounds.IntersectsWith(box4.Bounds) || redTank.Bounds.IntersectsWith(box5.Bounds) || redTank.Bounds.IntersectsWith(box6.Bounds)
                    || redTank.Bounds.IntersectsWith(tripleBox1.Bounds) || redTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        redTank.Left += tankSpeed;
                    }
                    break;
                case "right":
                    if (redTank.Bounds.IntersectsWith(box1.Bounds) || redTank.Bounds.IntersectsWith(box2.Bounds) || redTank.Bounds.IntersectsWith(box3.Bounds)
                    || redTank.Bounds.IntersectsWith(box4.Bounds) || redTank.Bounds.IntersectsWith(box5.Bounds) || redTank.Bounds.IntersectsWith(box6.Bounds)
                    || redTank.Bounds.IntersectsWith(tripleBox1.Bounds) || redTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        redTank.Left -= tankSpeed;
                    }
                    break;
            }

            //Collision between bullets and boxes
            if (bullet.Bounds.IntersectsWith(box1.Bounds) || bullet.Bounds.IntersectsWith(box2.Bounds) || bullet.Bounds.IntersectsWith(box3.Bounds)
            || bullet.Bounds.IntersectsWith(box4.Bounds) || bullet.Bounds.IntersectsWith(box5.Bounds) || bullet.Bounds.IntersectsWith(box6.Bounds)
            || bullet.Bounds.IntersectsWith(tripleBox1.Bounds) || bullet.Bounds.IntersectsWith(tripleBox2.Bounds))
            {
                bulletDirection = "";
                bullet.Visible = false;
               // shooting = false;
            }

            //Collision between bullets and tanks
            for (int i = 0; i <= 5; i++)
            {
                //if (bullet.Bounds.IntersectsWith(redTank.Bounds))
                //{
                //    redTankHealth.Image = Resources.
                //    //bullet.Visible = false;
                   
                //}

                if (bullet.Bounds.IntersectsWith(blueTank.Bounds))
                {
                    bullet.Visible = false;
             //       shooting = false;
                }
            }

            //Power-up features
            //Speed boosting
            if (blueTank.Bounds.IntersectsWith(power_ups.Bounds))
            {
                speedBoostDuration += gameTimer.Interval / 1000f;
                if (speedBoostDuration <= 5f)
                {
                    tankSpeed = 10;
                }
                power_ups.Visible = false;
            }
            Refresh();
        }


        //Power-ups timer
        private void powerUps_Timer_Tick(object sender, EventArgs e)
        {
            randValue = randGen.Next(1, 100);
            randValue2 = randGen2.Next(1, 30);

            if ( randValue <= 25 && randValue >= 1)
            {
                power_ups.Location = new Point(250, 200);
                power_ups.Visible = true;
            }
            if (randValue <= 50 && randValue >= 26)
            {
                power_ups.Location = new Point(this.Width / 2 - power_ups.Width / 2, 80);
                power_ups.Visible = true;
            }
            if (randValue <= 75 && randValue >= 51)
            {
                power_ups.Location = new Point(this.Width / 2 - power_ups.Width / 2, 400);
                power_ups.Visible = true;
            }
            if (randValue <= 100 && randValue >= 76)
            {
                power_ups.Location = new Point(this.Width - 300, this.Height - 250);
                power_ups.Visible = true;
            }

            if (randValue2 <= 10 && randValue2 >= 1)
            {
                power_ups.Image = Resources.shield;
            }
            if (randValue2 <= 20 && randValue2 >= 11)
            {
                power_ups.Image = Resources.speed_boost;
            }
            if (randValue2 <= 30 && randValue2 >= 21)
            {
                power_ups.Image = Resources.fast_shooting_rate;
            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    blueTankDirection = "up";
                   // bulletDirection = "up";
                    wDown = true;
                    break;
                case Keys.S:
                    blueTankDirection = "down";
                  //  bulletDirection = "down";
                    sDown = true;
                    break;
                case Keys.A:
                    blueTankDirection = "left";
                  //  bulletDirection = "left";
                    aDown = true;
                    break;
                case Keys.D:
                    blueTankDirection = "right";
                  //  bulletDirection = "right";
                    dDown = true;
                    break;
                case Keys.Up:
                    redTankDirection = "up";
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    redTankDirection = "down";
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    redTankDirection = "left";
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    redTankDirection = "right";
                    rightArrowDown = true;
                    break;
                case Keys.F:
                    if (bulletDirection == "")
                    {
                        bulletDirection = blueTankDirection;
                    }
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
                    break;
                case Keys.P:
                    //  shooting2 = false;
                    break;
            }
        }
    }
}