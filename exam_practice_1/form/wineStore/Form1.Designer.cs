namespace wineStore
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
            dgvWines = new DataGridView();
            saveButton = new Button();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvWines).BeginInit();
            SuspendLayout();
            // 
            // dgvWines
            // 
            dgvWines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWines.Location = new Point(693, 53);
            dgvWines.Name = "dgvWines";
            dgvWines.RowHeadersWidth = 51;
            dgvWines.Size = new Size(584, 290);
            dgvWines.TabIndex = 1;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(515, 409);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(116, 100);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 104);
            listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 450);
            Controls.Add(listBox1);
            Controls.Add(saveButton);
            Controls.Add(dgvWines);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWines).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvWines;
        private Button saveButton;
        private ListBox listBox1;
    }
}
