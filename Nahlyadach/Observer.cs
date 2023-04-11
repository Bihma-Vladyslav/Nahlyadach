using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nahlyadach
{
   public class Observer
    {
        List<Button> btns = new List<Button>();
        public bool IsIn(Button b)
        {
            return btns.Contains(b);
        }
        public void AddSubscriber(Button b)
        {
            btns.Add(b);
        }
        public void RemSubscriber(Button b)
        {
            btns.Remove(b);
        }
        public void sendNotify()
        {
            foreach (Button b in btns)
            {
                b.Text = (Convert.ToInt32(b.Text) + 1).ToString();
            }
        }
    }
    public class Hero
    {
        List<Control> enemy = new List<Control>();
        public PictureBox pic;
        public int R = 200;
        public Hero(PictureBox p)
        {
            pic = p;
        }
        public bool IsIn(Control b)
        {
            return enemy.Contains(b);
        }

        public void AddSubscriber(Control b)
        {
            enemy.Add(b);
        }
        public void RemSubscriber(Control b)
        {
            enemy.Remove(b);
        }
        public void sendNotify()
        {
            foreach (Control b in enemy)
            {
                if (b.Left < pic.Left)
                    b.Left++;
                else
                    b.Left--;
            }
        }
    }
}
