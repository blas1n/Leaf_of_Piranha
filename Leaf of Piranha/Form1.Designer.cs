namespace Leaf_of_Piranha
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ReadyText = new System.Windows.Forms.Label();
            this.GameSetText = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.GenerateTimer = new System.Windows.Forms.Timer(this.components);
            this.ReadyTimer = new System.Windows.Forms.Timer(this.components);
            this.LimitBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ReadyText
            // 
            this.ReadyText.AccessibleDescription = "ReadyText";
            this.ReadyText.AutoSize = true;
            this.ReadyText.Font = new System.Drawing.Font("굴림", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ReadyText.Location = new System.Drawing.Point(320, 200);
            this.ReadyText.Name = "ReadyText";
            this.ReadyText.Size = new System.Drawing.Size(119, 120);
            this.ReadyText.TabIndex = 0;
            this.ReadyText.Text = "0";
            this.ReadyText.Visible = false;
            // 
            // GameSetText
            // 
            this.GameSetText.AccessibleDescription = "GameSetText";
            this.GameSetText.AutoSize = true;
            this.GameSetText.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GameSetText.Location = new System.Drawing.Point(184, 220);
            this.GameSetText.Name = "GameSetText";
            this.GameSetText.Size = new System.Drawing.Size(438, 80);
            this.GameSetText.TabIndex = 1;
            this.GameSetText.Text = "GAME SET";
            this.GameSetText.Visible = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 10;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // GenerateTimer
            // 
            this.GenerateTimer.Interval = 500;
            this.GenerateTimer.Tick += new System.EventHandler(this.GenerateTimer_Tick);
            // 
            // ReadyTimer
            // 
            this.ReadyTimer.Enabled = true;
            this.ReadyTimer.Interval = 500;
            this.ReadyTimer.Tick += new System.EventHandler(this.ReadyTimer_Tick);
            // 
            // LimitBar
            // 
            this.LimitBar.Location = new System.Drawing.Point(28, 24);
            this.LimitBar.Maximum = 500;
            this.LimitBar.Name = "LimitBar";
            this.LimitBar.Size = new System.Drawing.Size(724, 38);
            this.LimitBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.LimitBar.TabIndex = 2;
            this.LimitBar.Value = 500;
            this.LimitBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.LimitBar);
            this.Controls.Add(this.GameSetText);
            this.Controls.Add(this.ReadyText);
            this.Name = "Form1";
            this.Text = "Leaf of Piranha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ReadyText;
        private System.Windows.Forms.Label GameSetText;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer GenerateTimer;
        private System.Windows.Forms.Timer ReadyTimer;
        private System.Windows.Forms.ProgressBar LimitBar;
    }
}

