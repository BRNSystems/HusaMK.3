using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HusaMK._3
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        public static volatile Form1 form;

        public const int smoothingx = 10;

        static void runform(object data)
        {

            Application.Run((Form1) data);
            
        }


        static void movechar(object data)
        {
            Form1 formx = (Form1)data;
            int xdif;
            int ydif;
            int xpos = 0;
            int ypos = 0;
            int steps = 1;
            while (true)
            {
                xdif = formx.obrazok.Location.X - Cursor.Position.X;
                ydif = formx.obrazok.Location.Y - Cursor.Position.Y;


                if (xdif > 0 && xdif > 5)
                {
                    xpos = formx.obrazok.Location.X - steps;
                }
                else if (xdif < 0 && xdif < -5)
                {
                    xpos = formx.obrazok.Location.X + steps;
                }
                if (ydif > 0 && xdif > 5)
                {
                    ypos = formx.obrazok.Location.Y - steps;
                }
                else if (ydif < 0 && ydif < -5)
                {
                    ypos = formx.obrazok.Location.Y + steps;
                }
                formx.obrazok.Location = new Point(xpos, ypos);
                Thread.Sleep(1);
            }

        }

        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Control.CheckForIllegalCrossThreadCalls = false; // daj sa vypchat c#
            
            form = new Form1();
            Thread thread = new Thread(runform);
            Thread movchr = new Thread(movechar);
            thread.Start(form);
           

            while (!form.ready) {
                Thread.Sleep(10);
            }
            movchr.Start(form);

        }
    }
}
