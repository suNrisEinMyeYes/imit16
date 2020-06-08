using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Specialized;
using System.Collections;

namespace laba4
{
    

    public partial class Form1 : Form
    {
        
        
        
        float dt = 0.001f;

        double Mu = 0.1d, Xi = 0.01d, W = 0, S = 0, MT = 2, DT = 2;
        NormalRV tm;
        Random rnd;
        float c, i = 0;
        
        double  _money = 200;
        int days, _possessions = 0;
        public Form1()
        {
            InitializeComponent();
            
            timer1.Interval = 1000;
            Money.Text = _money + "$";
            rnd = new Random();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;

            chart1.Series[0].Points.Clear();
            

            c = (float)inputPrice.Value;

            days = (int)inputDays.Value;

            chart1.Series[0].Points.AddXY(0, c);

            S = c;
            
            tm = new NormalRV(MT, DT);
            
            timer1.Start();


        }

        private void Buy_Click(object sender, EventArgs e)
        {
            if (_money>= c)
            {
                noMoney.Visible = false;
                _money -= c;
                Money.Text = _money + "$";
                _possessions ++;
                Possessions.Text = _possessions.ToString();
            }
            else
            {
                noMoney.Visible = true;
            }
        }

        private void Sell_Click(object sender, EventArgs e)
        {
            if (_possessions>0)
            {
                _money += c;
                _possessions--;
                Money.Text = _money + "$";
                Possessions.Text = _possessions.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Minimum = c - 2;
            i =0f;
            //Console.WriteLine(tm.getNum());
            W += Math.Sqrt(dt) * tm.getNum();
            S *= Math.Exp((Mu - Xi * Xi * 0.5) * dt + Xi * W);
            chart1.Series[0].Points.AddXY(i, S);
            c = (float)S;
            i+=dt;
            
            
        }
    }
}
