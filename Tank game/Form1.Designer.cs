namespace Tank_game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu_box = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.bullet = new System.Windows.Forms.PictureBox();
            this.redTank = new System.Windows.Forms.PictureBox();
            this.blueTank = new System.Windows.Forms.PictureBox();
            this.box6 = new System.Windows.Forms.PictureBox();
            this.box5 = new System.Windows.Forms.PictureBox();
            this.box3 = new System.Windows.Forms.PictureBox();
            this.box4 = new System.Windows.Forms.PictureBox();
            this.box1 = new System.Windows.Forms.PictureBox();
            this.tripleBox2 = new System.Windows.Forms.PictureBox();
            this.box2 = new System.Windows.Forms.PictureBox();
            this.tripleBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripleBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripleBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu_box
            // 
            this.menu_box.AutoSize = true;
            this.menu_box.BackColor = System.Drawing.Color.MediumTurquoise;
            this.menu_box.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_box.Location = new System.Drawing.Point(316, 154);
            this.menu_box.Name = "menu_box";
            this.menu_box.Size = new System.Drawing.Size(594, 324);
            this.menu_box.TabIndex = 0;
            this.menu_box.Text = "             Tank Game             \r\n\r\n\r\n  \r\n\r\n\r\n";
            // 
            // startButton
            // 
            this.startButton.AutoEllipsis = true;
            this.startButton.BackColor = System.Drawing.Color.Orange;
            this.startButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(550, 270);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(185, 68);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.AutoEllipsis = true;
            this.quitButton.BackColor = System.Drawing.Color.Orange;
            this.quitButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Location = new System.Drawing.Point(550, 372);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(185, 66);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "QUIT";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // bullet
            // 
            this.bullet.Image = global::Tank_game.Properties.Resources.bullet_horizontal;
            this.bullet.Location = new System.Drawing.Point(102, 314);
            this.bullet.Name = "bullet";
            this.bullet.Size = new System.Drawing.Size(29, 8);
            this.bullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bullet.TabIndex = 14;
            this.bullet.TabStop = false;
            this.bullet.Visible = false;
            // 
            // redTank
            // 
            this.redTank.Image = ((System.Drawing.Image)(resources.GetObject("redTank.Image")));
            this.redTank.Location = new System.Drawing.Point(1159, 296);
            this.redTank.Name = "redTank";
            this.redTank.Size = new System.Drawing.Size(53, 42);
            this.redTank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.redTank.TabIndex = 13;
            this.redTank.TabStop = false;
            // 
            // blueTank
            // 
            this.blueTank.Image = ((System.Drawing.Image)(resources.GetObject("blueTank.Image")));
            this.blueTank.Location = new System.Drawing.Point(30, 296);
            this.blueTank.Name = "blueTank";
            this.blueTank.Size = new System.Drawing.Size(54, 42);
            this.blueTank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.blueTank.TabIndex = 12;
            this.blueTank.TabStop = false;
            // 
            // box6
            // 
            this.box6.Image = global::Tank_game.Properties.Resources.box;
            this.box6.Location = new System.Drawing.Point(730, 459);
            this.box6.Name = "box6";
            this.box6.Size = new System.Drawing.Size(65, 64);
            this.box6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.box6.TabIndex = 11;
            this.box6.TabStop = false;
            this.box6.Visible = false;
            // 
            // box5
            // 
            this.box5.Image = global::Tank_game.Properties.Resources.box;
            this.box5.Location = new System.Drawing.Point(399, 540);
            this.box5.Name = "box5";
            this.box5.Size = new System.Drawing.Size(65, 64);
            this.box5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.box5.TabIndex = 10;
            this.box5.TabStop = false;
            this.box5.Visible = false;
            // 
            // box3
            // 
            this.box3.Image = global::Tank_game.Properties.Resources.box;
            this.box3.Location = new System.Drawing.Point(572, 239);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(65, 64);
            this.box3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.box3.TabIndex = 9;
            this.box3.TabStop = false;
            this.box3.Visible = false;
            // 
            // box4
            // 
            this.box4.Image = global::Tank_game.Properties.Resources.box;
            this.box4.Location = new System.Drawing.Point(634, 296);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(67, 69);
            this.box4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.box4.TabIndex = 8;
            this.box4.TabStop = false;
            this.box4.Visible = false;
            // 
            // box1
            // 
            this.box1.Image = global::Tank_game.Properties.Resources.box;
            this.box1.Location = new System.Drawing.Point(343, 85);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(67, 69);
            this.box1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.box1.TabIndex = 7;
            this.box1.TabStop = false;
            this.box1.Visible = false;
            // 
            // tripleBox2
            // 
            this.tripleBox2.Image = global::Tank_game.Properties.Resources._3_boxes;
            this.tripleBox2.Location = new System.Drawing.Point(949, 217);
            this.tripleBox2.Name = "tripleBox2";
            this.tripleBox2.Size = new System.Drawing.Size(67, 204);
            this.tripleBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tripleBox2.TabIndex = 6;
            this.tripleBox2.TabStop = false;
            this.tripleBox2.Visible = false;
            // 
            // box2
            // 
            this.box2.Image = global::Tank_game.Properties.Resources.box;
            this.box2.Location = new System.Drawing.Point(730, 75);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(67, 69);
            this.box2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.box2.TabIndex = 5;
            this.box2.TabStop = false;
            this.box2.Visible = false;
            // 
            // tripleBox1
            // 
            this.tripleBox1.Image = global::Tank_game.Properties.Resources._3_boxes;
            this.tripleBox1.Location = new System.Drawing.Point(236, 217);
            this.tripleBox1.Name = "tripleBox1";
            this.tripleBox1.Size = new System.Drawing.Size(67, 204);
            this.tripleBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tripleBox1.TabIndex = 4;
            this.tripleBox1.TabStop = false;
            this.tripleBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(1284, 653);
            this.Controls.Add(this.bullet);
            this.Controls.Add(this.redTank);
            this.Controls.Add(this.blueTank);
            this.Controls.Add(this.box6);
            this.Controls.Add(this.box5);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.tripleBox2);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.tripleBox1);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.menu_box);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tank Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripleBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripleBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menu_box;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.PictureBox tripleBox1;
        private System.Windows.Forms.PictureBox tripleBox2;
        private System.Windows.Forms.PictureBox box2;
        private System.Windows.Forms.PictureBox box1;
        private System.Windows.Forms.PictureBox box4;
        private System.Windows.Forms.PictureBox box3;
        private System.Windows.Forms.PictureBox box5;
        private System.Windows.Forms.PictureBox box6;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox blueTank;
        private System.Windows.Forms.PictureBox redTank;
        private System.Windows.Forms.PictureBox bullet;
    }
}

