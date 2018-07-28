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
        int limitTime;
        int readyTime = 3;

        public Form1()
        {
            InitializeComponent();
            limitTime = LimitBar.Maximum;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            LimitBar.Value = limitTime;
            if (--limitTime < 0) GameEnd();
        }

        private void GenerateTimer_Tick(object sender, EventArgs e)
        {
            // 나뭇잎 생성
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
            LimitBar.Visible = false;
            GameSetText.Visible = true;
        }
    }
}
