namespace LB31
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            allProcBtn = new Button();
            contextMenuStrip2 = new ContextMenuStrip(components);
            huiToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            processListView = new ListView();
            toolTip1 = new ToolTip(components);
            refreshBtn = new Button();
            exportBtn = new Button();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // allProcBtn
            // 
            allProcBtn.Location = new Point(67, 78);
            allProcBtn.Name = "allProcBtn";
            allProcBtn.Size = new Size(100, 41);
            allProcBtn.TabIndex = 0;
            allProcBtn.Text = "allProcess";
            allProcBtn.UseVisualStyleBackColor = true;
            allProcBtn.Click += allProcBtn_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { huiToolStripMenuItem, toolStripMenuItem1, toolStripMenuItem2 });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(212, 76);
            // 
            // huiToolStripMenuItem
            // 
            huiToolStripMenuItem.Name = "huiToolStripMenuItem";
            huiToolStripMenuItem.Size = new Size(211, 24);
            huiToolStripMenuItem.Text = "hui";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(211, 24);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(211, 24);
            toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // processListView
            // 
            processListView.AutoArrange = false;
            processListView.Location = new Point(67, 149);
            processListView.Name = "processListView";
            processListView.Size = new Size(396, 413);
            processListView.TabIndex = 1;
            processListView.UseCompatibleStateImageBehavior = false;
            processListView.SelectedIndexChanged += processListView_SelectedIndexChanged;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(212, 82);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(123, 34);
            refreshBtn.TabIndex = 2;
            refreshBtn.Text = "refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // exportBtn
            // 
            exportBtn.Location = new Point(357, 72);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(137, 47);
            exportBtn.TabIndex = 3;
            exportBtn.Text = "export";
            exportBtn.UseVisualStyleBackColor = true;
            exportBtn.Click += exportBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 671);
            Controls.Add(exportBtn);
            Controls.Add(refreshBtn);
            Controls.Add(processListView);
            Controls.Add(allProcBtn);
            Name = "Form1";
            Text = "Form1";
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button allProcBtn;
        private Label allProcessLabel;
        private Label label1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem huiToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ListView processListView;
        private ToolTip toolTip1;
        private Button refreshBtn;
        private Button exportBtn;
    }
}