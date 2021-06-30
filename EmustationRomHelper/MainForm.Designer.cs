namespace EmustationRomHelper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFileZipper = new System.Windows.Forms.TabPage();
            this.checkBoxDeleteAfterExtract = new System.Windows.Forms.CheckBox();
            this.buttonUnZip = new System.Windows.Forms.Button();
            this.buttonZip = new System.Windows.Forms.Button();
            this.tabPageFileShortener = new System.Windows.Forms.TabPage();
            this.listViewMatches = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPageAlphaFolders = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAlphaProcess = new System.Windows.Forms.Button();
            this.textBoxAlphaFolder = new System.Windows.Forms.TextBox();
            this.buttonAlphaBrowse = new System.Windows.Forms.Button();
            this.checkBoxDifferentFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteSource = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageFileZipper.SuspendLayout();
            this.tabPageFileShortener.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPageAlphaFolders.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder:";
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(57, 9);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(167, 20);
            this.textBoxFolderPath.TabIndex = 1;
            this.textBoxFolderPath.TextChanged += new System.EventHandler(this.TextBoxFolderPathTextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(230, 8);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(25, 24);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowseClick);
            // 
            // buttonProcess
            // 
            this.buttonProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcess.Location = new System.Drawing.Point(522, 6);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 4;
            this.buttonProcess.Text = "&Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.ButtonProcessClick);
            // 
            // buttonValidate
            // 
            this.buttonValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonValidate.Location = new System.Drawing.Point(441, 6);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(75, 23);
            this.buttonValidate.TabIndex = 5;
            this.buttonValidate.Text = "&Validate";
            this.buttonValidate.UseVisualStyleBackColor = true;
            this.buttonValidate.Click += new System.EventHandler(this.ButtonValidateClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFileZipper);
            this.tabControl1.Controls.Add(this.tabPageFileShortener);
            this.tabControl1.Controls.Add(this.tabPageAlphaFolders);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 336);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageFileZipper
            // 
            this.tabPageFileZipper.Controls.Add(this.checkBoxDeleteAfterExtract);
            this.tabPageFileZipper.Controls.Add(this.buttonUnZip);
            this.tabPageFileZipper.Controls.Add(this.buttonZip);
            this.tabPageFileZipper.Location = new System.Drawing.Point(4, 22);
            this.tabPageFileZipper.Name = "tabPageFileZipper";
            this.tabPageFileZipper.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFileZipper.Size = new System.Drawing.Size(616, 310);
            this.tabPageFileZipper.TabIndex = 0;
            this.tabPageFileZipper.Text = "File Zipper";
            this.tabPageFileZipper.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeleteAfterExtract
            // 
            this.checkBoxDeleteAfterExtract.AutoSize = true;
            this.checkBoxDeleteAfterExtract.Location = new System.Drawing.Point(89, 39);
            this.checkBoxDeleteAfterExtract.Name = "checkBoxDeleteAfterExtract";
            this.checkBoxDeleteAfterExtract.Size = new System.Drawing.Size(154, 17);
            this.checkBoxDeleteAfterExtract.TabIndex = 3;
            this.checkBoxDeleteAfterExtract.Text = "Delete zip file after extract?";
            this.checkBoxDeleteAfterExtract.UseVisualStyleBackColor = true;
            this.checkBoxDeleteAfterExtract.CheckedChanged += new System.EventHandler(this.CheckBoxDeleteAfterExtract_CheckedChanged);
            // 
            // buttonUnZip
            // 
            this.buttonUnZip.Location = new System.Drawing.Point(8, 35);
            this.buttonUnZip.Name = "buttonUnZip";
            this.buttonUnZip.Size = new System.Drawing.Size(75, 23);
            this.buttonUnZip.TabIndex = 2;
            this.buttonUnZip.Text = "&UnZip Files!";
            this.buttonUnZip.UseVisualStyleBackColor = true;
            this.buttonUnZip.Click += new System.EventHandler(this.ButtonUnZipClick);
            // 
            // buttonZip
            // 
            this.buttonZip.Location = new System.Drawing.Point(8, 6);
            this.buttonZip.Name = "buttonZip";
            this.buttonZip.Size = new System.Drawing.Size(75, 23);
            this.buttonZip.TabIndex = 1;
            this.buttonZip.Text = "&Zip Files!";
            this.buttonZip.UseVisualStyleBackColor = true;
            this.buttonZip.Click += new System.EventHandler(this.ButtonZipClick);
            // 
            // tabPageFileShortener
            // 
            this.tabPageFileShortener.Controls.Add(this.listViewMatches);
            this.tabPageFileShortener.Controls.Add(this.panel1);
            this.tabPageFileShortener.Location = new System.Drawing.Point(4, 22);
            this.tabPageFileShortener.Name = "tabPageFileShortener";
            this.tabPageFileShortener.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFileShortener.Size = new System.Drawing.Size(616, 310);
            this.tabPageFileShortener.TabIndex = 1;
            this.tabPageFileShortener.Text = "File Shortener";
            this.tabPageFileShortener.UseVisualStyleBackColor = true;
            // 
            // listViewMatches
            // 
            this.listViewMatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMatches.GridLines = true;
            this.listViewMatches.HideSelection = false;
            this.listViewMatches.Location = new System.Drawing.Point(3, 42);
            this.listViewMatches.Name = "listViewMatches";
            this.listViewMatches.Size = new System.Drawing.Size(610, 265);
            this.listViewMatches.TabIndex = 5;
            this.listViewMatches.UseCompatibleStateImageBehavior = false;
            this.listViewMatches.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Items";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Length";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "New Name";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Extension";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonValidate);
            this.panel1.Controls.Add(this.buttonProcess);
            this.panel1.Controls.Add(this.textBoxFolderPath);
            this.panel1.Controls.Add(this.buttonBrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 39);
            this.panel1.TabIndex = 4;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(624, 149);
            this.textBoxOutput.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 149);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(624, 18);
            this.progressBar.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxOutput);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar);
            this.splitContainer1.Size = new System.Drawing.Size(624, 507);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 7;
            // 
            // tabPageAlphaFolders
            // 
            this.tabPageAlphaFolders.Controls.Add(this.panel2);
            this.tabPageAlphaFolders.Location = new System.Drawing.Point(4, 22);
            this.tabPageAlphaFolders.Name = "tabPageAlphaFolders";
            this.tabPageAlphaFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlphaFolders.Size = new System.Drawing.Size(616, 310);
            this.tabPageAlphaFolders.TabIndex = 2;
            this.tabPageAlphaFolders.Text = "Alpha Folders";
            this.tabPageAlphaFolders.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxDeleteSource);
            this.panel2.Controls.Add(this.checkBoxDifferentFolder);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonAlphaProcess);
            this.panel2.Controls.Add(this.textBoxAlphaFolder);
            this.panel2.Controls.Add(this.buttonAlphaBrowse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 39);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Folder:";
            // 
            // buttonAlphaProcess
            // 
            this.buttonAlphaProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAlphaProcess.Location = new System.Drawing.Point(522, 6);
            this.buttonAlphaProcess.Name = "buttonAlphaProcess";
            this.buttonAlphaProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonAlphaProcess.TabIndex = 4;
            this.buttonAlphaProcess.Text = "&Process";
            this.buttonAlphaProcess.UseVisualStyleBackColor = true;
            this.buttonAlphaProcess.Click += new System.EventHandler(this.ButtonAlphaProcessClick);
            // 
            // textBoxAlphaFolder
            // 
            this.textBoxAlphaFolder.Location = new System.Drawing.Point(57, 9);
            this.textBoxAlphaFolder.Name = "textBoxAlphaFolder";
            this.textBoxAlphaFolder.Size = new System.Drawing.Size(167, 20);
            this.textBoxAlphaFolder.TabIndex = 1;
            // 
            // buttonAlphaBrowse
            // 
            this.buttonAlphaBrowse.Location = new System.Drawing.Point(230, 8);
            this.buttonAlphaBrowse.Name = "buttonAlphaBrowse";
            this.buttonAlphaBrowse.Size = new System.Drawing.Size(25, 24);
            this.buttonAlphaBrowse.TabIndex = 2;
            this.buttonAlphaBrowse.Text = "...";
            this.buttonAlphaBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAlphaBrowse.UseVisualStyleBackColor = true;
            this.buttonAlphaBrowse.Click += new System.EventHandler(this.ButtonAlphaBrowseClick);
            // 
            // checkBoxDifferentFolder
            // 
            this.checkBoxDifferentFolder.AutoSize = true;
            this.checkBoxDifferentFolder.Location = new System.Drawing.Point(261, 11);
            this.checkBoxDifferentFolder.Name = "checkBoxDifferentFolder";
            this.checkBoxDifferentFolder.Size = new System.Drawing.Size(107, 17);
            this.checkBoxDifferentFolder.TabIndex = 5;
            this.checkBoxDifferentFolder.Text = "Different Output?";
            this.checkBoxDifferentFolder.UseVisualStyleBackColor = true;
            this.checkBoxDifferentFolder.CheckedChanged += new System.EventHandler(this.CheckBoxDifferentFolderCheckedChanged);
            // 
            // checkBoxDeleteSource
            // 
            this.checkBoxDeleteSource.AutoSize = true;
            this.checkBoxDeleteSource.Location = new System.Drawing.Point(374, 11);
            this.checkBoxDeleteSource.Name = "checkBoxDeleteSource";
            this.checkBoxDeleteSource.Size = new System.Drawing.Size(119, 17);
            this.checkBoxDeleteSource.TabIndex = 5;
            this.checkBoxDeleteSource.Text = "Delete Source File?";
            this.checkBoxDeleteSource.UseVisualStyleBackColor = true;
            this.checkBoxDeleteSource.CheckedChanged += new System.EventHandler(this.CheckBoxDeleteSourceCheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 507);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emustation Rom Helper";
            this.tabControl1.ResumeLayout(false);
            this.tabPageFileZipper.ResumeLayout(false);
            this.tabPageFileZipper.PerformLayout();
            this.tabPageFileShortener.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPageAlphaFolders.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFileZipper;
        private System.Windows.Forms.Button buttonZip;
        private System.Windows.Forms.TabPage tabPageFileShortener;
        private System.Windows.Forms.ListView listViewMatches;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonUnZip;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBoxDeleteAfterExtract;
        private System.Windows.Forms.TabPage tabPageAlphaFolders;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAlphaProcess;
        private System.Windows.Forms.TextBox textBoxAlphaFolder;
        private System.Windows.Forms.Button buttonAlphaBrowse;
        private System.Windows.Forms.CheckBox checkBoxDeleteSource;
        private System.Windows.Forms.CheckBox checkBoxDifferentFolder;
    }
}

