using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HusaMK._3
{
    public partial class Form1 : Form
    {
        public volatile PictureBox obrazok;
        public Size plocha;
        public bool ready = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            plocha = new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height);
            this.TabStop = false;
            this.AllowTransparency = true;
            this.Size = plocha;
            pictureBox1.Image = HusaMK._3.Properties.Resources.smol_brn;
            this.FormBorderStyle = FormBorderStyle.None;
            obrazok = pictureBox1;
            this.ready = true;
        }
    }
}
