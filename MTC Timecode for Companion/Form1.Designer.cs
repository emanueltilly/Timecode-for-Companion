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
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectedItemInListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.inputdevice = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.fpsDropdown = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.companionIPbox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.companionPortTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.applyTCbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleTimecodeButton = new System.Windows.Forms.ToolStripButton();
            this.warningFlashTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.rowColorButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timecode_lbl
            // 
            this.timecode_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.timecode_lbl.AutoSize = true;
            this.timecode_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timecode_lbl.Location = new System.Drawing.Point(296, 3);
            this.timecode_lbl.Name = "timecode_lbl";
            this.timecode_lbl.Size = new System.Drawing.Size(210, 39);
            this.timecode_lbl.TabIndex = 2;
            this.timecode_lbl.Text = "00:00:00:00";
            // 
            // tcTimer
            // 
            this.tcTimer.Interval = 20;
            this.tcTimer.Tick += new System.EventHandler(this.TcTimer_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(801, 264);
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
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.companionIPbox,
            this.toolStripLabel4,
            this.companionPortTextbox,
            this.toolStripSeparator3,
            this.applyTCbutton,
            this.toolStripSeparator4,
            this.toggleTimecodeButton,
            this.toolStripSeparator6,
            this.rowColorButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(801, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.toolStripSeparator5,
            this.deleteSelectedItemInListToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.OpenProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(208, 6);
            // 
            // deleteSelectedItemInListToolStripMenuItem
            // 
            this.deleteSelectedItemInListToolStripMenuItem.Name = "deleteSelectedItemInListToolStripMenuItem";
            this.deleteSelectedItemInListToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.deleteSelectedItemInListToolStripMenuItem.Text = "Delete selected item in list";
            this.deleteSelectedItemInListToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedItemInListToolStripMenuItem_Click);
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
            this.inputdevice.TextChanged += new System.EventHandler(this.Inputdevice_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel2.Text = "FPS:";
            // 
            // fpsDropdown
            // 
            this.fpsDropdown.AutoSize = false;
            this.fpsDropdown.DropDownWidth = 80;
            this.fpsDropdown.Items.AddRange(new object[] {
            "23.976ND",
            "24",
            "25",
            "29.97DF",
            "29.97ND",
            "30"});
            this.fpsDropdown.Name = "fpsDropdown";
            this.fpsDropdown.Size = new System.Drawing.Size(70, 23);
            this.fpsDropdown.Click += new System.EventHandler(this.ToolStripButton1_Click_1);
            this.fpsDropdown.TextChanged += new System.EventHandler(this.FpsDropdown_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel3.Text = "Companion IP:";
            // 
            // companionIPbox
            // 
            this.companionIPbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.companionIPbox.Name = "companionIPbox";
            this.companionIPbox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel4.Text = "Port:";
            // 
            // companionPortTextbox
            // 
            this.companionPortTextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.companionPortTextbox.MaxLength = 10;
            this.companionPortTextbox.Name = "companionPortTextbox";
            this.companionPortTextbox.Size = new System.Drawing.Size(65, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // applyTCbutton
            // 
            this.applyTCbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.applyTCbutton.Image = ((System.Drawing.Image)(resources.GetObject("applyTCbutton.Image")));
            this.applyTCbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.applyTCbutton.Name = "applyTCbutton";
            this.applyTCbutton.Size = new System.Drawing.Size(90, 22);
            this.applyTCbutton.Text = "Apply and lock";
            this.applyTCbutton.Click += new System.EventHandler(this.ApplyTCbutton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleTimecodeButton
            // 
            this.toggleTimecodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toggleTimecodeButton.Enabled = false;
            this.toggleTimecodeButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleTimecodeButton.Image")));
            this.toggleTimecodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleTimecodeButton.Name = "toggleTimecodeButton";
            this.toggleTimecodeButton.Size = new System.Drawing.Size(46, 22);
            this.toggleTimecodeButton.Text = "Toggle";
            this.toggleTimecodeButton.Click += new System.EventHandler(this.ToolStripButton1_Click_1);
            // 
            // warningFlashTimer
            // 
            this.warningFlashTimer.Tick += new System.EventHandler(this.WarningFlashTimer_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.timecode_lbl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(801, 536);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 8;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // rowColorButton
            // 
            this.rowColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rowColorButton.Image = ((System.Drawing.Image)(resources.GetObject("rowColorButton.Image")));
            this.rowColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rowColorButton.Name = "rowColorButton";
            this.rowColorButton.Size = new System.Drawing.Size(23, 22);
            this.rowColorButton.Text = "Change color of selected";
            this.rowColorButton.Click += new System.EventHandler(this.rowColorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(670, 600);
            this.Name = "Form1";
            this.Text = "MTC Timecode for Companion";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox companionIPbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedItemInListToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox companionPortTextbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton rowColorButton;
    }
}

