using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leaf_of_Piranha
{
    public partial class Form1 : Form
    {
        private static int limitTime;
        private static bool alreadyInit;
        private int readyTime = 3;

        public Form1()
        {
            InitializeComponent();
            if (!alreadyInit)
            {
                limitTime = LimitBar.Maximum;
                alreadyInit = true;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            LimitBar.Value = limitTime;
            if (--limitTime < 0) GameEnd();
        }

        private void GenerateTimer_Tick(object sender, EventArgs e)
        {
            Leaf leaf = new Leaf();
            this.Controls.Add(leaf);
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
        Form1 form = new Form1();

        public Leaf()
        {
            Name = "Leaf";
            Image = Properties.Resources.LeafResc;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Click += Leaf_Click;
            Size = new Size(40, 30);

            Random random = new Random();
            Location = new Point(random.Next(50, 650), 0);
        }

        private void Leaf_Click(object sender, EventArgs e)
        {
            Visible = false;
            Enabled = false;
            form.ExtensionLimit(30);
        }
    }
}
