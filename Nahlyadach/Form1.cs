using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nahlyadach
{
    Hero h;
    PictureBox[] enemies;
    void radius_enemy()
    {
        foreach (PictureBox p in enemies)
        {
            double d = Math.Pow(p.Left - h.pic.Left, 2) + Math.Pow(p.Top - h.pic.Top, 2);
            Text = d.ToString();
            if (Math.Pow(p.Left - h.pic.Left, 2) + Math.Pow(p.Top - h.pic.Top, 2) < h.R * h.R)//(x-x0)^2+(y-y0)^2<R
                if (!h.IsIn(p))
                    h.AddSubscriber(p);
                else
                    h.RemSubscriber(p);
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            h = new Hero(pictureBox3);
            enemies = new PictureBox[] { pictureBox1, pictureBox2, pictureBox4, pictureBox5 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radius_enemy();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            radius_enemy();
            h.pic.Left += dir;
            h.sendNotify();
        }
    }
}
