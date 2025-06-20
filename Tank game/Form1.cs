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
        int tankSpeed = 6;
        int bulletSpeed = 17;

        //Components' directions
        string bulletDirection = "";
        string bullet2Direction = "";
        string blueTankDirection = "";
        string redTankDirection = "right";

        //Tanks' health
        int redTankHealthLeft = 5;
        int blueTankHealthLeft = 5;

        Random randGen = new Random();
        int randValue = 0;
        float speedBoostDuration = 0f;
        SoundPlayer player = new SoundPlayer();

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
            player = new SoundPlayer(Properties.Resources.theme_song);
            player.Play();
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
            player.Stop();
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

            //Red tank shooting
            if (shooting2 == true)
            {
                switch (bullet2Direction)
                {
                    case "up":
                        bullet2.Image = Resources.bullet_vertical;
                        bullet2.Top -= bulletSpeed;
                        break;
                    case "down":
                        bullet2.Image = Resources.bullet_vertical;
                        bullet.Top += bulletSpeed;
                        break;
                    case "left":
                        bullet2.Image = Resources.bullet_horizontal;
                        bullet2.Left -= bulletSpeed;
                        break;
                    case "right":
                        bullet2.Image = Resources.bullet_horizontal;
                        bullet2.Left += bulletSpeed;
                        break;
                }
            }

            //Remove when blue tank's bullets go out the screen
            if (bullet.Left > this.Width)
            {
                bulletDirection = "";
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Left < 0)
            {
                bulletDirection = "";
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Top > this.Height)
            {
                bulletDirection = "";
                bullet.Visible = false;
                shooting = false;
            }
            if (bullet.Top < 0)
            {
                bulletDirection = "";
                bullet.Visible = false;
                shooting = false;
            }

            //Remove when red tank's bullets go out the screen
            if (bullet2.Left > this.Width)
            {
                bullet2Direction = "";
                bullet2.Visible = false;
                shooting2 = false;
            }
            if (bullet2.Left < 0)
            {
                bullet2Direction = "";
                bullet2.Visible = false;
                shooting2 = false;
            }
            if (bullet2.Top > this.Height)
            {
                bullet2Direction = "";
                bullet2.Visible = false;
                shooting2 = false;
            }
            if (bullet2.Top < 0)
            {
                bullet2Direction = "";
                bullet2.Visible = false;
                shooting2 = false;
            }

            //Building obstacles inside the map
            //Collision between blue tank and boxes
            switch (blueTankDirection)
            {
                case "up":
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Top += tankSpeed;
                    }
                    break;
                case "down":
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Top -= tankSpeed;
                    }
                    break;
                case "left":
                    if (blueTank.Bounds.IntersectsWith(box1.Bounds) || blueTank.Bounds.IntersectsWith(box2.Bounds) || blueTank.Bounds.IntersectsWith(box3.Bounds)
                    || blueTank.Bounds.IntersectsWith(box4.Bounds) || blueTank.Bounds.IntersectsWith(box5.Bounds) || blueTank.Bounds.IntersectsWith(box6.Bounds)
                    || blueTank.Bounds.IntersectsWith(tripleBox1.Bounds) || blueTank.Bounds.IntersectsWith(tripleBox2.Bounds))
                    {
                        blueTank.Left += tankSpeed;
                    }
                    break;
                case "right":
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
                shooting = false;
            }

            if (bullet2.Bounds.IntersectsWith(box1.Bounds) || bullet2.Bounds.IntersectsWith(box2.Bounds) || bullet2.Bounds.IntersectsWith(box3.Bounds)
            || bullet2.Bounds.IntersectsWith(box4.Bounds) || bullet2.Bounds.IntersectsWith(box5.Bounds) || bullet2.Bounds.IntersectsWith(box6.Bounds)
            || bullet2.Bounds.IntersectsWith(tripleBox1.Bounds) || bullet2.Bounds.IntersectsWith(tripleBox2.Bounds))
            {
                bullet2Direction = "";
                bullet2.Visible = false;
                shooting2 = false;
            }

            //Collision between bullets and tanks
            //Red tank
            if (bullet.Bounds.IntersectsWith(redTank.Bounds))
            {
                redTankHealthLeft--;
                redTankHealth.Text = $"{redTankHealthLeft}";
                blueTank.Location = new Point(70, this.Height / 2 - 34);
                redTank.Location = new Point(820, this.Height / 2 - 34);
                blueTank.Image = Resources.blue_tank_left;
                redTank.Image = Resources.red_tank_right;
                player = new SoundPlayer(Properties.Resources.tank_explosion);
                player.Play();
                bullet.Visible = false;
                shooting = false;
                bullet.Location = new Point(-100, -100);
            }
            //Blue tank
            if (bullet2.Bounds.IntersectsWith(blueTank.Bounds))
            {
                blueTankHealthLeft--;
                blueTankHealth.Text = $"{blueTankHealthLeft}";
                blueTank.Location = new Point(70, this.Height / 2 - 34);
                redTank.Location = new Point(820, this.Height / 2 - 34);
                blueTank.Image = Resources.blue_tank_left;
                redTank.Image = Resources.red_tank_right;
                player = new SoundPlayer(Properties.Resources.tank_explosion);
                player.Play();
                bullet2.Visible = false;
                shooting2 = false;
                bullet2.Location = new Point(-100, -100);
            }

            //Speed boosting power up
            //Blue tank
            if (blueTank.Bounds.IntersectsWith(power_ups.Bounds))
            {
                player = new SoundPlayer(Properties.Resources.power_up_eating);
                player.Play();
                speedBoostDuration += gameTimer.Interval / 1000f;
                if (speedBoostDuration <= 5f)
                {
                    tankSpeed = 10;
                }
                //Move off screen
                power_ups.Location = new Point(-100, -100);
            }
            //Red tank
            if (redTank.Bounds.IntersectsWith(power_ups.Bounds))
            {
                player = new SoundPlayer(Properties.Resources.power_up_eating);
                player.Play();
                speedBoostDuration += gameTimer.Interval / 1000f;
                if (speedBoostDuration <= 5f)
                {
                    tankSpeed = 10;
                }
                //Move off screen
                power_ups.Location = new Point(-100, -100);
            }

            if (redTankHealthLeft == 0 || redTankHealthLeft == 0)
            {
                //player = new SoundPlayer(Properties.Resources.winner);
                player.Play();
                blueTank.Visible = false;
                redTank.Visible = false;
                blueTankHealth.Visible = false;
                redTankHealth.Visible = false;
                blueTankHealthLabel.Visible = false;
                redTankHealthLabel.Visible = false;
                box1.Visible = false;
                box2.Visible = false;
                box3.Visible = false;
                box4.Visible = false;
                box5.Visible = false;
                box6.Visible = false;
                tripleBox1.Visible = false;
                tripleBox2.Visible = false;
                gameTimer.Enabled = false;
                power_ups.Visible = false;
                shooting = false;
                shooting2 = false;
                winTitle.Visible = true;

                if (blueTankHealthLeft == 0)
                {
                    winTitle.Text = "Red tank Wins!!";
                    player = new SoundPlayer(Properties.Resources.winner);
                    player.Play();
                }
                else
                {
                    winTitle.Text = "Blue tank Wins!!";
                    player = new SoundPlayer(Properties.Resources.winner);
                    player.Play();
                }
                winTitle.Location = new Point(this.Width / 2 - winTitle.Width / 2, 130);
            }
            Refresh();
        }


        //Power-ups timer
        private void powerUps_Timer_Tick(object sender, EventArgs e)
        {
            randValue = randGen.Next(1, 100);

            if (randValue <= 25 && randValue >= 1)
            {
                power_ups.Image = Resources.speed_boost;
                power_ups.Location = new Point(250, 200);
                power_ups.Visible = true;
            }
            if (randValue <= 50 && randValue >= 26)
            {
                power_ups.Image = Resources.speed_boost;
                power_ups.Location = new Point(this.Width / 2 - power_ups.Width / 2, 80);
                power_ups.Visible = true;
            }
            if (randValue <= 75 && randValue >= 51)
            {
                power_ups.Image = Resources.speed_boost;
                power_ups.Location = new Point(this.Width / 2 - power_ups.Width / 2, 400);
                power_ups.Visible = true;
            }
            if (randValue <= 100 && randValue >= 76)
            {
                power_ups.Image = Resources.speed_boost;
                power_ups.Location = new Point(this.Width - 300, this.Height - 250);
                power_ups.Visible = true;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    blueTankDirection = "up";
                    wDown = true;
                    break;
                case Keys.S:
                    blueTankDirection = "down";
                    sDown = true;
                    break;
                case Keys.A:
                    blueTankDirection = "left";
                    aDown = true;
                    break;
                case Keys.D:
                    blueTankDirection = "right";
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
                    switch (blueTankDirection)
                    {
                        case "up":
                            bullet.Left = blueTank.Left + (blueTank.Width - bullet.Width) / 2;
                            bullet.Top = blueTank.Top - bullet.Height;
                            break;
                        case "down":
                            bullet.Left = blueTank.Left + (blueTank.Width - bullet.Width) / 2;
                            bullet.Top = blueTank.Bottom;
                            break;
                        case "left":
                            bullet.Left = blueTank.Left - bullet.Width;
                            bullet.Top = blueTank.Top + (blueTank.Height - bullet.Height) / 2;
                            break;
                        case "right":
                            bullet.Left = blueTank.Right;
                            bullet.Top = blueTank.Top + (blueTank.Height - bullet.Height) / 2;
                            break;
                    }
                    if (bulletDirection == "")
                    {
                        bulletDirection = blueTankDirection;
                    }
                    player = new SoundPlayer(Properties.Resources.shooting);
                    player.Play();
                    bullet.Visible = true;
                    shooting = true;
                    break;
                case Keys.P:
                    switch (redTankDirection)
                    {
                        case "up":
                            bullet2.Left = redTank.Width / 2 + (redTank.Width - bullet2.Width) / 2;
                            bullet2.Top = redTank.Top;
                            break;
                        case "down":
                            bullet2.Left = redTank.Width / 2 + (redTank.Width - bullet2.Width) / 2;
                            bullet2.Top = redTank.Bottom;
                            break;
                        case "left":
                            bullet2.Left = redTank.Left - bullet2.Width;
                            bullet2.Top = redTank.Top + (redTank.Height - bullet2.Height) / 2;
                            break;
                        case "right":
                            bullet2.Left = redTank.Right;
                            bullet2.Top = redTank.Top + (redTank.Height - bullet2.Height) / 2;
                            break;
                    }
                    if (bullet2Direction == "")
                    {
                        bullet2Direction = redTankDirection;
                    }
                    player = new SoundPlayer(Properties.Resources.shooting);
                    player.Play();
                    bullet2.Visible = true;
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
                    break;
            }
        }
    }
}