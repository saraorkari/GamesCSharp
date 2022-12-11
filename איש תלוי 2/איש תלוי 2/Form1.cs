using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace איש_תלוי_2
{
    public partial class Form1 : Form
    {
        string[] strs = { "hello world", "good morning", "how are you?", "good luck!", "very nice" };
        int x;
        Panel p, p1;
        string select;
        public Form1()
        {
            InitializeComponent();
            //מקלדת//
            p = new Panel();
            p.Size = new Size(280, 150);
            p.Location = new Point(40, 250);
            Controls.Add(p);
            p1 = new Panel();
            p1.Size = new Size(500, 50);
            p1.Location = new Point(200, 50);
            Controls.Add(p1);
            int x, y, j;
            x = 0;
            y = 0;
            j = 1;
            for (int i = 0; i < 26; i++)
            {
                j++;
                Button b = new Button();
                b.Text = Convert.ToChar('a' + i).ToString();
                b.Size = new Size(25, 25);
                b.Location = new Point(x + j * 30, y);
                b.Enabled = false;
                b.Click += new EventHandler(button2_Click);
                p.Controls.Add(b);
                if ((i + 1) % 7 == 0)
                {
                    x = 0;
                    y += 40;
                    j = 1;
                }
            }
            Button b1 = new Button();
            Button b2 = new Button();
            b1.Text = ('?').ToString();
            b2.Text = ('!').ToString();
            b1.Size = new Size(25, 25);
            b2.Size = new Size(25, 25);
            b1.Location = new Point(x + 7 * 30, y);
            b2.Location = new Point(x + 8 * 30, y);
            b1.Enabled = false;
            b2.Enabled = false;
            b1.Click += new EventHandler(button2_Click);
            b2.Click += new EventHandler(button2_Click);
            p.Controls.Add(b1);
            p.Controls.Add(b2);
            //התחל משחק//
            Button b3 = new Button();
            b3.Text = "start game";
            b3.Size = new Size(90, 30);
            b3.Location = new Point(700, 10);
            b3.Click += new EventHandler(button1_Click);
            Controls.Add(b3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p1.Controls.Clear();
            x = 0;
            Random r = new Random();
            int o = r.Next(strs.Length);
            select = strs[o];
            Label l = new Label();
            for (int i = 0; i < select.Length; i++)
            {
                l.Size = new Size(30, 30);
                l.Location = new Point(i * 40, 0);
                if (select[i] == ' ')
                {
                    l.Text = " ";
                }
                else
                {
                    l.Text = "__";
                }
                p1.Controls.Add(l);
                l = new Label();
            }
            //הפעלת המקלדת//
            for (int i = 0; i < p.Controls.Count; i++)
            {
                p.Controls[i].Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int index = -1;
            bool flag = false;
            (sender as Button).Enabled = false;
            for (int i = 0; i < select.Length; i++)
            {
                index = select.IndexOf((sender as Button).Text, index + 1);
                if (index > -1)
                {
                    p1.Controls[index].Text = (sender as Button).Text;
                    flag = true;
                }
                else
                {
                    break;
                }
            }
            if (!flag)
            {
                x++;
            }
            if (!IsContinue())
            {
                MessageBox.Show("Victory!!!");
            }
            if (x > 6)
            {
                MessageBox.Show("Lost:-( Try again");
            }
        }

        public bool IsContinue()
        {
            for (int i = 0; i < p1.Controls.Count; i++)
            {
                if (p1.Controls[i].Text == "__")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
