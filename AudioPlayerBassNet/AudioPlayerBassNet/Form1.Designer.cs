namespace AudioPlayerBassNet
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listPlay = new System.Windows.Forms.ListBox();
            this.btPlay = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.musicProgress = new System.Windows.Forms.TrackBar();
            this.btNext = new System.Windows.Forms.Button();
            this.btPrev = new System.Windows.Forms.Button();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.timerForChange = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.balanceBar = new System.Windows.Forms.TrackBar();
            this.balanceBox = new System.Windows.Forms.TextBox();
            this.bakanceCenter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.musicProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // listPlay
            // 
            this.listPlay.FormattingEnabled = true;
            this.listPlay.Location = new System.Drawing.Point(12, 184);
            this.listPlay.Name = "listPlay";
            this.listPlay.Size = new System.Drawing.Size(307, 108);
            this.listPlay.TabIndex = 1;
            this.listPlay.SelectedIndexChanged += new System.EventHandler(this.listPlay_SelectedIndexChanged);
            this.listPlay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPlay_MouseDoubleClick);
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(70, 46);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(52, 23);
            this.btPlay.TabIndex = 2;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(12, 12);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(106, 23);
            this.btOpen.TabIndex = 3;
            this.btOpen.Text = "Open...";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click_1);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(124, 12);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(114, 23);
            this.btStop.TabIndex = 4;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(128, 46);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(52, 23);
            this.btPause.TabIndex = 5;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // musicProgress
            // 
            this.musicProgress.Location = new System.Drawing.Point(12, 126);
            this.musicProgress.Maximum = 100;
            this.musicProgress.Name = "musicProgress";
            this.musicProgress.Size = new System.Drawing.Size(307, 45);
            this.musicProgress.TabIndex = 6;
            this.musicProgress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.musicProgress_MouseDown);
            this.musicProgress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.musicProgress_MouseUp);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(186, 46);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(52, 23);
            this.btNext.TabIndex = 7;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btPrev
            // 
            this.btPrev.Location = new System.Drawing.Point(12, 46);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(52, 23);
            this.btPrev.TabIndex = 8;
            this.btPrev.Text = "Prev";
            this.btPrev.UseVisualStyleBackColor = true;
            this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
            // 
            // volumeBar
            // 
            this.volumeBar.Location = new System.Drawing.Point(274, 12);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeBar.Size = new System.Drawing.Size(45, 104);
            this.volumeBar.TabIndex = 12;
            this.volumeBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.volumeBar_MouseDown);
            this.volumeBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.volumeBar_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Volume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Right";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Balance:";
            // 
            // balanceBar
            // 
            this.balanceBar.AutoSize = false;
            this.balanceBar.Location = new System.Drawing.Point(109, 75);
            this.balanceBar.Maximum = 100;
            this.balanceBar.Minimum = -100;
            this.balanceBar.Name = "balanceBar";
            this.balanceBar.Size = new System.Drawing.Size(104, 41);
            this.balanceBar.SmallChange = 5;
            this.balanceBar.TabIndex = 20;
            this.balanceBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.balanceBar_MouseUp);
            // 
            // balanceBox
            // 
            this.balanceBox.Location = new System.Drawing.Point(15, 92);
            this.balanceBox.Name = "balanceBox";
            this.balanceBox.ReadOnly = true;
            this.balanceBox.Size = new System.Drawing.Size(46, 20);
            this.balanceBox.TabIndex = 21;
            // 
            // bakanceCenter
            // 
            this.bakanceCenter.Location = new System.Drawing.Point(70, 92);
            this.bakanceCenter.Name = "bakanceCenter";
            this.bakanceCenter.Size = new System.Drawing.Size(32, 20);
            this.bakanceCenter.TabIndex = 22;
            this.bakanceCenter.Text = "Mid";
            this.bakanceCenter.UseVisualStyleBackColor = true;
            this.bakanceCenter.Click += new System.EventHandler(this.bakanceCenter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 304);
            this.Controls.Add(this.bakanceCenter);
            this.Controls.Add(this.balanceBox);
            this.Controls.Add(this.balanceBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.btPrev);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.musicProgress);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.listPlay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.musicProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listPlay;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        public System.Windows.Forms.TrackBar musicProgress;
        public System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btPrev;
        public System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Timer timerForChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TrackBar balanceBar;
        public System.Windows.Forms.TextBox balanceBox;
        private System.Windows.Forms.Button bakanceCenter;
    }
}

