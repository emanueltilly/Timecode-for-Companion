namespace MTC_Timecode_for_Companion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timecode_lbl = new System.Windows.Forms.Label();
            this.tcTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.inputdevice = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.fpsDropdown = new System.Windows.Forms.ToolStripComboBox();
            this.applyTCbutton = new System.Windows.Forms.ToolStripButton();
            this.toggleTimecodeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.warningFlashTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timecode_lbl
            // 
            this.timecode_lbl.AutoSize = true;
            this.timecode_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timecode_lbl.Location = new System.Drawing.Point(12, 37);
            this.timecode_lbl.Name = "timecode_lbl";
            this.timecode_lbl.Size = new System.Drawing.Size(210, 39);
            this.timecode_lbl.TabIndex = 2;
            this.timecode_lbl.Text = "00:00:00:00";
            // 
            // tcTimer
            // 
            this.tcTimer.Interval = 20;
            this.tcTimer.Tick += new System.EventHandler(this.tcTimer_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(12, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(670, 300);
            this.dataGridView1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.inputdevice,
            this.toolStripLabel2,
            this.fpsDropdown,
            this.applyTCbutton,
            this.toggleTimecodeButton,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(694, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "MIDI In:";
            // 
            // inputdevice
            // 
            this.inputdevice.DropDownWidth = 200;
            this.inputdevice.Name = "inputdevice";
            this.inputdevice.Size = new System.Drawing.Size(121, 25);
            this.inputdevice.TextChanged += new System.EventHandler(this.inputdevice_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel2.Text = "FPS:";
            // 
            // fpsDropdown
            // 
            this.fpsDropdown.Items.AddRange(new object[] {
            "24",
            "25",
            "30",
            "50",
            "60"});
            this.fpsDropdown.Name = "fpsDropdown";
            this.fpsDropdown.Size = new System.Drawing.Size(121, 25);
            this.fpsDropdown.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            this.fpsDropdown.TextChanged += new System.EventHandler(this.fpsDropdown_TextChanged);
            // 
            // applyTCbutton
            // 
            this.applyTCbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.applyTCbutton.Image = ((System.Drawing.Image)(resources.GetObject("applyTCbutton.Image")));
            this.applyTCbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.applyTCbutton.Name = "applyTCbutton";
            this.applyTCbutton.Size = new System.Drawing.Size(86, 22);
            this.applyTCbutton.Text = "Apply and run";
            this.applyTCbutton.Click += new System.EventHandler(this.applyTCbutton_Click);
            // 
            // toggleTimecodeButton
            // 
            this.toggleTimecodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toggleTimecodeButton.Enabled = false;
            this.toggleTimecodeButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleTimecodeButton.Image")));
            this.toggleTimecodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleTimecodeButton.Name = "toggleTimecodeButton";
            this.toggleTimecodeButton.Size = new System.Drawing.Size(62, 22);
            this.toggleTimecodeButton.Text = "Toggle TC";
            this.toggleTimecodeButton.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // warningFlashTimer
            // 
            this.warningFlashTimer.Tick += new System.EventHandler(this.warningFlashTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 486);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.timecode_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "MTC Timecode for Companion";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label timecode_lbl;
        private System.Windows.Forms.Timer tcTimer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox inputdevice;
        private System.Windows.Forms.ToolStripButton toggleTimecodeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox fpsDropdown;
        private System.Windows.Forms.ToolStripButton applyTCbutton;
        private System.Windows.Forms.Timer warningFlashTimer;
    }
}

