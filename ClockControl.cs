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
        private double TickCount;
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
            TickCount = 4.71239;
            counter = 0;
           
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TickCount += (0.0174533 * 6);
            counter++;
            this.Invalidate();
        }

        private void ClockControl_Paint(object sender, PaintEventArgs e)
        {
            var Graphics = this.CreateGraphics();




            Graphics.FillEllipse(Brushes.BurlyWood,new Rectangle(new Point(0,0),this.Size));
            
            var first =  this.Width/2 + Math.Cos(TickCount) * this.Width/2;
            var second = this.Width/2 + Math.Sin(TickCount) * this.Height/2;
            Graphics.DrawLine(Pens.Black,new Point(this.Width/2,this.Height/2),new Point( (int)first,(int)second ));

            Graphics.DrawString((counter).ToString(),new Font("Arial",12,FontStyle.Regular),Brushes.Red,this.Width/2-12,this.Height/2-20);

        }
    }
}
