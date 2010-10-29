using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//sun clip art from: http://www.antarousa.com/tarif.htm
//grass clip art from: http://www.teacherfiles.com/clipart/backgrounds/grass.jpg

namespace BugZap
{
    public partial class mainForm : Form
    {

        const int NUM_BUGS = 8;
        const int GAME_SECS = 60;
        int level = 1;
        Bug[] bugs = new Bug[NUM_BUGS];
        Random random = new Random();
        
        int counter = 0;
        int showCounter = 0;
        int killCount = 0;
        int score = 0;
        int SPEED_FLOOR = 5;
        int SPEED_CEILING = 20;
        private long PLAY_TIME = GAME_SECS * 1000;
        Point normalEndPoint;
        int norm_x;
        int norm_y;
        MagGlass magGlass;
        Mirror mirror;
        Point sun;
       
        Brush b;
        Pen p ;
       
        public mainForm()
        {
            InitializeComponent();
           
            sdgButton1.Text = "Restart";
            sdgButton2.Text = "Exit Game";
            
            this.Location = new Point(0, 0);
            
            SetStyle(ControlStyles.UserPaint, true);

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            SetStyle(ControlStyles.DoubleBuffer, true);
            magGlass = new MagGlass();
            magGlass.Show();
            mirror = new Mirror();
            mirror.Show();
           

            b = new SolidBrush(Color.FromArgb(90, Color.Yellow));
            p =  new Pen(b, 30);
           
           

            sdgManager1.Mice[0].Visible = false;
            sdgManager1.Mice[1].Visible = false;
            sdgButton1.Visible = false;
            sdgButton2.Visible = false;
            sun = new Point(panel2.Location.X + 150, panel2.Location.Y + 110);

            initializeBugs();
            levelLabel.Text = level.ToString();
            timer1.Start();
            
            
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(Bug bug in bugs)
                bug.paint(g);


            bool rightOfSun = true;

            if (mirror.Location.X + 150 < sun.X)
                rightOfSun = false;
           
           


            //sun ray
            g.DrawLine(p,new Point(mirror.Location.X+150,mirror.Location.Y+150),sun);
         

            int start_x =mirror.Location.X + 150;
            int start_y =mirror.Location.Y + 150;

            //calculate the length that the reflected light beam should be
            //the light varies so that it is easier for me to find out if there
            //is the mag. glass over the light
            double length = Math.Pow((magGlass.Location.X - start_x), 2) + Math.Pow((magGlass.Location.Y - start_y), 2);
            length = Math.Sqrt(length);
            
             normalEndPoint = mirror.calculateNormal(rightOfSun,(int)length);

           norm_x = normalEndPoint.X+mirror.Location.X+150;
            norm_y = ((-normalEndPoint.Y)+mirror.Location.Y+150);

            if (norm_y < 0)
                norm_y = 0;
                       
            //normalLine 
            //the normal line is actually used as the reflection line

            
            g.DrawLine(p, new Point(start_x,start_y ), new Point(norm_x,norm_y));

           
            
          
        }


        private void sdgManager1_MouseMove(object sender, Sdgt.SdgMouseEventArgs e)
        {
           
            if (e.ID == 0)
            {
                magGlass.Location = new Point(sdgManager1.Mice[e.ID].Xabs, sdgManager1.Mice[e.ID].Yabs);
               
                
              
            }
            else
                mirror.Location = new Point(sdgManager1.Mice[e.ID].Xabs, sdgManager1.Mice[e.ID].Yabs);


            
           
            if(magGlass.Location.X<=norm_x&&norm_x<=magGlass.Location.X+50&&
                magGlass.Location.Y<+norm_y&&norm_y<=magGlass.Location.Y+110)
            {
            //magnfiying glass
             if(e.ID == 0){
                 attemptKill();
            }
            } 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            PLAY_TIME -= timer1.Interval;
            if (label3.Visible == true && showCounter>=15)
                label3.Visible = false;
            showCounter++;
            if (PLAY_TIME > 0)
            {
                timeLabel.Text = convertToTime(PLAY_TIME / 1000);
                for (int i = 0; i < bugs.Length; i++)
                {
                    if (killCount == NUM_BUGS)
                    {
                        label3.Visible = true;
                        killCount = 0;
                        SPEED_CEILING += 2;
                        SPEED_FLOOR += 2;
                        level++;
                        levelLabel.Text = level.ToString();
                        initializeBugs();
                        showCounter = 0;
                    }

                    bugs[i].move();
                    if (bugs[i].getLocation().Y > this.Height)
                        bugs[i].setLocation(new Point(random.Next(0, this.Width), -15));

                }

                Invalidate();
            }
            else
            {
                timer1.Enabled = false;
                mirror.Close();
                magGlass.Close();
                foreach (Bug bug in bugs)
                {
                    bug.kill();
                    
                }
                Invalidate();
                if (label3.Visible)
                    label3.Visible = false;

                sdgButton1.Visible = true;
                sdgButton2.Visible = true;
                
                gameOverPanel.Visible = true;
                
                sdgManager1.Mice[0].Visible = true;
                sdgManager1.Mice[1].Visible = true;
            }
        }

        private void sdgManager1_KeyDown(object sender, Sdgt.SdgKeyEventArgs e)
        {
           

        }

        private void sdgManager1_MouseWheel(object sender, Sdgt.SdgMouseEventArgs e)
        {
            if (e.ID == 0)
                magGlass.setPicture(Utilities.RotateImage(magGlass.getPicture().Image, 90));
            else
            {
                if (e.Delta > 0)
                    counter += 5;
                else
                    counter -= 5;
                counter = mirror.rotate(counter);
            }
            


            if (magGlass.Location.X <= norm_x && norm_x <= magGlass.Location.X + 50 &&
                  magGlass.Location.Y < +norm_y && norm_y <= magGlass.Location.Y + 110)
            {
                attemptKill();
            }
            
        
        }

       

        private void attemptKill()
        {
            foreach (Bug bug in bugs)
            {
                if (bug.detectMouse(magGlass.Location) && !bug.getIsDead())
                {
                    bug.kill();
                    killCount++;
                    score++;
                    score_label.Text = score.ToString();
                }
            
           }
           
        }
        private void initializeBugs()
        {
            for (int i = 0; i < bugs.Length; i++)
            {
                bugs[i] = new Bug(new Point(random.Next(0, this.Width - 10), -10), 50);
                bugs[i].setMotion(0, random.Next(SPEED_FLOOR, SPEED_CEILING));
            }
        }
        // code from http://www.c-sharpcorner.com/Code/2003/Aug/EggTimer.asp
        public string convertToTime(long tickCount)
        {
            // tickcount is in seconds, convert to a minutes: seconds string
            long seconds = tickCount;
            string val = (seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");

            return val;
            
        }

       

        private void sdgButton1_sdgClick(object sender, int userID)
        {
            
            SPEED_FLOOR = 5;
            SPEED_CEILING = 20;
            initializeBugs();
            killCount = 1;
            score = 0;
            level = 0;
            PLAY_TIME = GAME_SECS * 1000;
            gameOverPanel.Visible = false;
            magGlass = new MagGlass();
            magGlass.Show();
            mirror = new Mirror();
            mirror.Show();
            sdgManager1.Mice[0].Visible = false;
            sdgManager1.Mice[1].Visible = false;
            sdgButton1.Visible = false;
            sdgButton2.Visible = false;
            score = 0;
            level = 1;
            score_label.Text = score.ToString();
            levelLabel.Text = level.ToString();
            timer1.Start();
        }

        private void sdgButton2_sdgClick(object sender, int userID)
        {
            this.Close();
        }

       

       
    }
}

