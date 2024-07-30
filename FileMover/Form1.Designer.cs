namespace FileMoverApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Button btnSelectDestination;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnLoadGrid;
        private System.Windows.Forms.Button btnMoveFiles;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnSelectSource = new System.Windows.Forms.Button();
            btnSelectDestination = new System.Windows.Forms.Button();
            txtSourceFolder = new System.Windows.Forms.TextBox();
            txtDestinationFolder = new System.Windows.Forms.TextBox();
            dataGridView = new System.Windows.Forms.DataGridView();
            Origem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnLoadGrid = new System.Windows.Forms.Button();
            btnMoveFiles = new System.Windows.Forms.Button();
            progressBar = new System.Windows.Forms.ProgressBar();
            textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            radioButton3 = new System.Windows.Forms.RadioButton();
            radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectSource
            // 
            btnSelectSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectSource.Location = new System.Drawing.Point(1057, 14);
            btnSelectSource.Name = "btnSelectSource";
            btnSelectSource.Size = new System.Drawing.Size(160, 31);
            btnSelectSource.TabIndex = 0;
            btnSelectSource.Text = "Escolher pasta";
            btnSelectSource.UseVisualStyleBackColor = true;
            btnSelectSource.Click += btnSelectSource_Click;
            // 
            // btnSelectDestination
            // 
            btnSelectDestination.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectDestination.Location = new System.Drawing.Point(1057, 51);
            btnSelectDestination.Name = "btnSelectDestination";
            btnSelectDestination.Size = new System.Drawing.Size(160, 32);
            btnSelectDestination.TabIndex = 1;
            btnSelectDestination.Text = "Escolher pasta";
            btnSelectDestination.UseVisualStyleBackColor = true;
            btnSelectDestination.Click += btnSelectDestination_Click;
            // 
            // txtSourceFolder
            // 
            txtSourceFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSourceFolder.Location = new System.Drawing.Point(85, 14);
            txtSourceFolder.Name = "txtSourceFolder";
            txtSourceFolder.Size = new System.Drawing.Size(966, 31);
            txtSourceFolder.TabIndex = 2;
            // 
            // txtDestinationFolder
            // 
            txtDestinationFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDestinationFolder.Location = new System.Drawing.Point(85, 51);
            txtDestinationFolder.Name = "txtDestinationFolder";
            txtDestinationFolder.Size = new System.Drawing.Size(966, 31);
            txtDestinationFolder.TabIndex = 3;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Origem, Destino, Size });
            dataGridView.Location = new System.Drawing.Point(12, 88);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new System.Drawing.Size(1763, 636);
            dataGridView.TabIndex = 4;
            // 
            // Origem
            // 
            Origem.Frozen = true;
            Origem.HeaderText = "Source";
            Origem.MinimumWidth = 8;
            Origem.Name = "Origem";
            Origem.Width = 102;
            // 
            // Destino
            // 
            Destino.HeaderText = "Destination";
            Destino.MinimumWidth = 8;
            Destino.Name = "Destino";
            Destino.Width = 138;
            // 
            // Size
            // 
            Size.HeaderText = "Size";
            Size.MinimumWidth = 8;
            Size.Name = "Size";
            Size.Width = 79;
            // 
            // btnLoadGrid
            // 
            btnLoadGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLoadGrid.Location = new System.Drawing.Point(12, 730);
            btnLoadGrid.Name = "btnLoadGrid";
            btnLoadGrid.Size = new System.Drawing.Size(104, 34);
            btnLoadGrid.TabIndex = 5;
            btnLoadGrid.Text = "Carregar";
            btnLoadGrid.UseVisualStyleBackColor = true;
            btnLoadGrid.Click += btnLoadGrid_Click;
            // 
            // btnMoveFiles
            // 
            btnMoveFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnMoveFiles.Location = new System.Drawing.Point(122, 730);
            btnMoveFiles.Name = "btnMoveFiles";
            btnMoveFiles.Size = new System.Drawing.Size(111, 34);
            btnMoveFiles.TabIndex = 6;
            btnMoveFiles.Text = "Iniciar";
            btnMoveFiles.UseVisualStyleBackColor = true;
            btnMoveFiles.Click += btnMoveFiles_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(239, 730);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(1536, 34);
            progressBar.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(153, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(54, 31);
            textBox1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 25);
            label1.TabIndex = 10;
            label1.Text = "Origem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 59);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 25);
            label2.TabIndex = 11;
            label2.Text = "Destino";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 30);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(140, 25);
            label3.TabIndex = 12;
            label3.Text = "Limite de pastas";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(1223, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(552, 65);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new System.Drawing.Point(428, 24);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new System.Drawing.Size(113, 29);
            radioButton3.TabIndex = 15;
            radioButton3.Text = "Copiados";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new System.Drawing.Point(304, 26);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(118, 29);
            radioButton2.TabIndex = 14;
            radioButton2.Text = "Pendentes";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new System.Drawing.Point(213, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(85, 29);
            radioButton1.TabIndex = 13;
            radioButton1.TabStop = true;
            radioButton1.Text = "Todos";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(1787, 784);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar);
            Controls.Add(btnMoveFiles);
            Controls.Add(btnLoadGrid);
            Controls.Add(dataGridView);
            Controls.Add(txtDestinationFolder);
            Controls.Add(txtSourceFolder);
            Controls.Add(btnSelectDestination);
            Controls.Add(btnSelectSource);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Rumo - Cópia de arquivos";
            Load += Form1_Load;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn Origem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}
