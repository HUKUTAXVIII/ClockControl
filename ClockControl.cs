using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockControl
{
    public class ClockControl:Control
    {
        private Timer timer;
        private double SecTickCount;
        private double MinTickCount;
        private int counter;
        public ClockControl(): base()
        {
            this.Size = new System.Drawing.Size(300,300);
            this.Paint += ClockControl_Paint;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            timer.Start();
            SecTickCount = 4.71239;
            MinTickCount = 4.71239;
            counter = 0;
           
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SecTickCount += (0.0174533 * 6);
            MinTickCount += (0.0174533 * 6)/60;
            counter++;
            this.Invalidate();
        }

        private void ClockControl_Paint(object sender, PaintEventArgs e)
        {
            var Graphics = this.CreateGraphics();




            Graphics.FillEllipse(Brushes.BurlyWood,new Rectangle(new Point(0,0),this.Size));
            
            var first =  this.Width/2 + Math.Cos(MinTickCount) * this.Width/2.5;
            var second = this.Width/2 + Math.Sin(MinTickCount) * this.Height/2.5;
            Graphics.DrawLine(Pens.Black,new Point(this.Width/2,this.Height/2),new Point( (int)(this.Width / 2 + Math.Cos(SecTickCount) * this.Width / 2),(int)(this.Width / 2 + Math.Sin(SecTickCount) * this.Height / 2) ));
            Graphics.DrawLine(Pens.BlueViolet,new Point(this.Width/2,this.Height/2),new Point( (int)first,(int)second ));

            Graphics.DrawString((counter/60).ToString(),new Font("Arial",12,FontStyle.Regular),Brushes.Red,this.Width/2-12,this.Height/2-20);

        }
    }
}
