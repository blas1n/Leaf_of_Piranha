using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Leaf_of_Piranha
{
    public partial class Form1 : Form
    {
        private Leaf[] leaves = null;
        private static int limitTime;
        private static bool alreadyInit;
        private const int numOfPullLeaf = 30;
        private int readyTime = 3;

        public Form1()
        {
            InitializeComponent();
            if (!alreadyInit)
            {
                limitTime = LimitBar.Maximum;
                alreadyInit = true;

                leaves = new Leaf[numOfPullLeaf];

                for (int i = 0; i < numOfPullLeaf; i++)
                {
                    leaves[i] = new Leaf();
                    Controls.Add(leaves[i]);
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            LimitBar.Value = limitTime;
            if (--limitTime < 0) GameEnd();
        }

        private void GenerateTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < numOfPullLeaf; i++)
            {
                if (!leaves[i].Visible)
                {
                    leaves[i].PoolLeaf();
                    break;
                }
            }
        }

        private void ReadyTimer_Tick(object sender, EventArgs e)
        {
            ReadyText.Visible = !ReadyText.Visible;

            if (ReadyText.Visible)
                ReadyText.Text = (readyTime--).ToString();

            if (readyTime < 0) GameStart();
        }

        private void GameStart()
        {
            ReadyTimer.Stop();
            ReadyText.Visible = false;
            LimitBar.Visible = true;
            GameTimer.Start();
            GenerateTimer.Start();
        }

        private void GameEnd()
        {
            GameTimer.Stop();
            GenerateTimer.Stop();
            GameSetText.Visible = true;
        }

        public void ExtensionLimit(int extenstionTime)
        {
            if (limitTime + extenstionTime > LimitBar.Maximum)
                limitTime = LimitBar.Maximum;
            else limitTime += extenstionTime;
        }
    }

    public class Leaf : PictureBox {
        private Form1 form = new Form1();
        private Timer timer = new Timer();
        private static Random random = new Random();
        private int[] spawnPoint = { 30, 110, 190, 270, 350, 430, 510, 590 };

        public Leaf()
        {
            Name = "Leaf";
            Image = Properties.Resources.LeafResc;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Click += Leaf_Click;
            Size = new Size(50, 40);
            LeafActive = false;
            timer.Interval = 10;
            timer.Tick += Timer_Tick;  
        }

        public void PoolLeaf()
        {
            Location = new Point(spawnPoint[random.Next(0, 8)], -20);
            LeafActive = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Point point = Location;
            point.Y += 2;
            Location = point;

            if (Location.Y > 300)
            {
                point.Y = -20;
                Location = point;
                LeafActive = false;
            }
        }

        private void Leaf_Click(object sender, EventArgs e)
        {
            LeafActive = false;
            form.ExtensionLimit(30);
        }
   
        private bool LeafActive
        {
            set {
                Visible = value;
                Enabled = value;

                if (value) timer.Start();
                else timer.Stop();
            }
        }
    }
}