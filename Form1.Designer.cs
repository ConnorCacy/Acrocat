
namespace Acrocat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prevPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPdfToolStripMenuItem,
            this.newFieldToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.prevPageToolStripMenuItem,
            this.nextPageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 45);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openPdfToolStripMenuItem
            // 
            this.openPdfToolStripMenuItem.Image = global::Acrocat.Properties.Resources.open;
            this.openPdfToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openPdfToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openPdfToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.openPdfToolStripMenuItem.Name = "openPdfToolStripMenuItem";
            this.openPdfToolStripMenuItem.Size = new System.Drawing.Size(99, 41);
            this.openPdfToolStripMenuItem.Text = "Open Pdf";
            this.openPdfToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openPdfToolStripMenuItem.Click += new System.EventHandler(this.OpenPdfToolStripMenuItem_Click);
            // 
            // newFieldToolStripMenuItem
            // 
            this.newFieldToolStripMenuItem.Image = global::Acrocat.Properties.Resources.newfield;
            this.newFieldToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newFieldToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newFieldToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.newFieldToolStripMenuItem.Name = "newFieldToolStripMenuItem";
            this.newFieldToolStripMenuItem.Size = new System.Drawing.Size(101, 41);
            this.newFieldToolStripMenuItem.Text = "New Field";
            this.newFieldToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newFieldToolStripMenuItem.Click += new System.EventHandler(this.NewFieldToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Acrocat.Properties.Resources.save;
            this.saveToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(73, 41);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // prevPageToolStripMenuItem
            // 
            this.prevPageToolStripMenuItem.Image = global::Acrocat.Properties.Resources.left;
            this.prevPageToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prevPageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.prevPageToolStripMenuItem.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.prevPageToolStripMenuItem.Name = "prevPageToolStripMenuItem";
            this.prevPageToolStripMenuItem.Size = new System.Drawing.Size(101, 41);
            this.prevPageToolStripMenuItem.Text = "Prev Page";
            this.prevPageToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prevPageToolStripMenuItem.Click += new System.EventHandler(this.PrevPageToolStripMenuItem_Click);
            // 
            // nextPageToolStripMenuItem
            // 
            this.nextPageToolStripMenuItem.Image = global::Acrocat.Properties.Resources.right;
            this.nextPageToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nextPageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nextPageToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.nextPageToolStripMenuItem.Name = "nextPageToolStripMenuItem";
            this.nextPageToolStripMenuItem.Size = new System.Drawing.Size(103, 41);
            this.nextPageToolStripMenuItem.Text = "Next Page";
            this.nextPageToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.nextPageToolStripMenuItem.Click += new System.EventHandler(this.NextPageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::Acrocat.Properties.Resources.help;
            this.helpToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.helpToolStripMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 10, 0);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(74, 41);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 405);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 405);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(530, 405);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGrid1_PropertyValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Pdf Files|*.pdf";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Pdf File|*.pdf";
            this.saveFileDialog1.Title = "Save PDF";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Acrocat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openPdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prevPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextPageToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

