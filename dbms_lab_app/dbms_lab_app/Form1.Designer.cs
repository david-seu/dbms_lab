
namespace WindowsForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridProjects = new DataGridView();
            dataGridResources = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            buttonUpdateDB = new Button();
            buttonRefreshDB = new Button();
            buttonDeleteDB = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridResources).BeginInit();
            SuspendLayout();
            // 
            // dataGridProjects
            // 
            dataGridProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProjects.Location = new Point(47, 54);
            dataGridProjects.Margin = new Padding(4, 5, 4, 5);
            dataGridProjects.Name = "dataGridProjects";
            dataGridProjects.RowHeadersWidth = 51;
            dataGridProjects.RowTemplate.Height = 25;
            dataGridProjects.Size = new Size(620, 268);
            dataGridProjects.TabIndex = 0;
            // 
            // dataGridResources
            // 
            dataGridResources.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridResources.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridResources.Location = new Point(47, 383);
            dataGridResources.Margin = new Padding(4, 5, 4, 5);
            dataGridResources.Name = "dataGridResources";
            dataGridResources.RowHeadersWidth = 51;
            dataGridResources.RowTemplate.Height = 25;
            dataGridResources.Size = new Size(620, 257);
            dataGridResources.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 345);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 2;
            label1.Text = "Projects";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 3;
            label2.Text = "Resources";
            // 
            // buttonUpdateDB
            // 
            buttonUpdateDB.Location = new Point(772, 235);
            buttonUpdateDB.Margin = new Padding(4, 5, 4, 5);
            buttonUpdateDB.Name = "buttonUpdateDB";
            buttonUpdateDB.Size = new Size(116, 45);
            buttonUpdateDB.TabIndex = 4;
            buttonUpdateDB.Text = "Update DB";
            buttonUpdateDB.UseVisualStyleBackColor = true;
            buttonUpdateDB.Click += buttonUpdateDB_Click;
            // 
            // buttonRefreshDB
            // 
            buttonRefreshDB.Location = new Point(772, 383);
            buttonRefreshDB.Margin = new Padding(4, 5, 4, 5);
            buttonRefreshDB.Name = "buttonRefreshDB";
            buttonRefreshDB.Size = new Size(116, 45);
            buttonRefreshDB.TabIndex = 5;
            buttonRefreshDB.Text = "Refresh DB";
            buttonRefreshDB.UseVisualStyleBackColor = true;
            buttonRefreshDB.Click += buttonRefreshDB_Click;
            // 
            // buttonDeleteDB
            // 
            buttonDeleteDB.Location = new Point(772, 538);
            buttonDeleteDB.Margin = new Padding(4, 5, 4, 5);
            buttonDeleteDB.Name = "buttonDeleteDB";
            buttonDeleteDB.Size = new Size(116, 45);
            buttonDeleteDB.TabIndex = 5;
            buttonDeleteDB.Text = "Delete DB";
            buttonDeleteDB.UseVisualStyleBackColor = true;
            buttonDeleteDB.Click += buttonDeleteDB_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 777);
            Controls.Add(buttonRefreshDB);
            Controls.Add(buttonUpdateDB);
            Controls.Add(buttonDeleteDB);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridResources);
            Controls.Add(dataGridProjects);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridResources).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridProjects;
        private System.Windows.Forms.DataGridView dataGridResources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUpdateDB;
        private System.Windows.Forms.Button buttonRefreshDB;
        private System.Windows.Forms.Button buttonDeleteDB;
    }
}