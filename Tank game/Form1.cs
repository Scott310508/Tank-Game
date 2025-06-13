using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        int bulletSpeed = 10;
        string bulletDirection = "up";

        //Player scores
        int redTankScore = 0;
        int blueTankScore = 0;

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
                        bullet.Location = new Point(blueTank.Left + bullet.Width + 10, blueTank.Top + bullet.Height + 9);
                        bullet.Left += bulletSpeed;
                        break;
                }
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

            }

            Rectangle box1Bounds = new Rectangle(box1.Bounds.X, box1.Bounds.Y, box1.Width, box1.Height);
            Rectangle box2Bounds = new Rectangle(box2.Bounds.X, box2.Bounds.Y, box2.Width, box2.Height);
            Rectangle box3Bounds = new Rectangle(box3.Bounds.X, box3.Bounds.Y, box3.Width, box3.Height);
            Rectangle box4Bounds = new Rectangle(box4.Bounds.X, box4.Bounds.Y, box4.Width, box4.Height);
            Rectangle box5Bounds = new Rectangle(box5.Bounds.X, box5.Bounds.Y, box5.Width, box5.Height);
            Rectangle box6Bounds = new Rectangle(box6.Bounds.X, box6.Bounds.Y, box6.Width, box6.Height);
            Rectangle tripleBox1Bounds = new Rectangle(tripleBox1.Bounds.X, tripleBox1.Bounds.Y, tripleBox1.Width, tripleBox1.Height);
            Rectangle tripleBox2Bounds = new Rectangle(tripleBox2.Bounds.X, tripleBox2.Bounds.Y, tripleBox2.Width, tripleBox2.Height);
            Rectangle blueTankBounds = new Rectangle(blueTank.Bounds.X, blueTank.Bounds.Y, blueTank.Width, blueTank.Height);
            Rectangle redTankBounds = new Rectangle(redTank.Bounds.X, redTank.Bounds.Y, redTank.Width, redTank.Height);

            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
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
                    if (!shooting)
                    {
                        if (dDown == true)
                        {
                            bullet.Visible = true;
                            shooting = true;
                            bulletDirection = "right";
                        }
                        if (sDown == true)
                        {
                            bullet.Visible = true;
                            shooting = true;
                            bulletDirection = "down";
                        }
                        if (aDown == true)
                        {
                            bullet.Visible = true;
                            shooting = true;
                            bulletDirection = "left";
                        }
                        if (wDown == true)
                        {
                            bullet.Visible = true;
                            shooting = true;
                            bulletDirection = "up";
                        }
                    }
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
