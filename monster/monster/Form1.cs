using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace monster
{
    public partial class Form1 : Form
    {
        DayNight dn = new DayNight();
        Monster m = new Monster();
        public delegate void UpdateText(string message);

        public Form1()
        {
            InitializeComponent();
            dn.TimeChange += dn_TimeChange;
        }

        void dn_TimeChange(object sender, EventArgs e)
        {
            this.Invoke(new UpdateText(Updatelbl), new object[] { m.age.ToString() });
            this.Invoke(new UpdateText(Updatelbl2), new object[] { m.shape.ToString() });
            this.Invoke(new UpdateText(Updatelbl3), new object[] { m.hunger.ToString() });
            this.Invoke(new UpdateText(Updatelbl4), new object[] { m.sleep.ToString() });
            this.Invoke(new UpdateText(Updatelbl5), new object[] { m.toilet.ToString() });
            this.Invoke(new UpdateText(Updatelbl6), new object[] { m.hp.ToString() });


            this.Invoke(new UpdateText(Updatelbl7), new object[] { m.isEat.ToString() });
            this.Invoke(new UpdateText(Updatelbl8), new object[] { m.isSleep.ToString() });
            this.Invoke(new UpdateText(Updatelbl9), new object[] { m.isLaze.ToString() });
            this.Invoke(new UpdateText(Updatelbl10), new object[] { m.isPlay.ToString() });
            this.Invoke(new UpdateText(Updatelbl11), new object[] { m.isSick.ToString() });
            this.Invoke(new UpdateText(Updatelbl12), new object[] { m.isToilet.ToString() });
            if (m.hp == 1)
            {
            }
            else if (((DayNight)sender).isDayNight==false)
            {
                m.sleeping();
            }
            else if (m.toilet == 1)
            {
                m.toileting();
            }
            else
            {
                m.game();
            }

            if (((DayNight)sender).partDay == 2 || ((DayNight)sender).partDay == 4)
            {
                m.ill();
            }

            if (((DayNight)sender).partNight == 4)
            {
                m.ageAdd();
            }
       

        }

        private void Form1_Load(object sender, EventArgs e)
        {
  
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(dn.startDayNigth);
            newThread.Start();

        }

        private void Updatelbl(string message)
        {
            label1.Text = message;
        }

        private void Updatelbl2(string message)
        {
            label2.Text = message;
        }

        private void Updatelbl3(string message)
        {
            label3.Text = message;
        }

        private void Updatelbl4(string message)
        {
            label4.Text = message;
        }

        private void Updatelbl5(string message)
        {
            label5.Text = message;
        }

        private void Updatelbl6(string message)
        {
            label6.Text = message;
        }

        private void Updatelbl7(string message)
        {
            label7.Text = message;
        }

        private void Updatelbl8(string message)
        {
            label8.Text = message;
        }

        private void Updatelbl9(string message)
        {
            label9.Text = message;
        }

        private void Updatelbl10(string message)
        {
            label10.Text = message;
        }
        private void Updatelbl11(string message)
        {
            label11.Text = message;
        }
        private void Updatelbl12(string message)
        {
            label12.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.giveFood();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m.giveDrug();
        }
    }
}
