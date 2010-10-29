//this code is based on the bug example from: http://www.publicjoe.f9.co.uk/csharp/cs03c.html

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BugZap
{
    class Bug
    {
        // position in window
  protected Point location;
  // radius of bug
  protected int radius;
  // horizontal change in bug position in one cycle
  protected double changeInX = 0.0;
  // vertical change in bug position in one cycle
  protected double changeInY = 0.0;
  
  
  private Image myImage;

        private bool isDead;

  // constructor for new bug
  public Bug( Point p,int r)
  {
      radius = r;
    location = p;
 //image from: http://www.thepcmanwebsite.com/free_clipart/cartoons/index.htm
      myImage = Image.FromFile("bug.gif");
     
  }

  // methods that set attributes of bug
 
  public void setLocation( Point p ) { location = p; }
  public void setMotion( double dx, double dy )
  {
    changeInX = dx;
    changeInY = dy;
  }


  public Point getLocation() { return location; }
 

  // methods to move the bug
  public void reflectVert() { changeInX = -changeInX; }
  public void reflectHorz() { changeInY = -changeInY; }
  public void moveTo( int x, int y )
  {
    location.X = x;
    location.Y = y;
  }
  public void move() { 
      if(!isDead)
        location.Offset((int)changeInX, (int)changeInY);
  }

  public bool detectMouse(Point p)
  {

      bool val=false;
      if (p.X <= location.X + radius && p.X >=location.X - radius&&
          p.Y <= location.Y + radius && p.Y >=location.Y-radius) 
          val = true;
      
      return val;
  }

  // method to display bug
  public void paint( Graphics g )
  {

     g.DrawImage(myImage, location);
      
    /**g.FillEllipse( new SolidBrush( colour ),
                  location.X - radius,
                  location.Y - radius,
                2*radius,
                 2*radius );*/
  }
        public void kill()
        {
            if (!isDead)
            {
                isDead = true;
                myImage = Image.FromFile("green200vx3.png");
                PlayWav.PlayWav.Play("splat.wav");
            }
        }
        public bool getIsDead()
        {
            return isDead;
        }
    }
}
