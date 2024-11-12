namespace Andmebaasi_Sergachev
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.andmebaas2DataSet1 = new Andmebaasi_Sergachev.Andmebaas2DataSet();
            this.button2 = new System.Windows.Forms.Button();
            this.toodeTableAdapter1 = new Andmebaasi_Sergachev.Andmebaas2DataSetTableAdapters.ToodeTableAdapter();
            this.NimetusBx = new System.Windows.Forms.TextBox();
            this.KogusBx = new System.Windows.Forms.TextBox();
            this.HindBx = new System.Windows.Forms.TextBox();
            this.Nimetus = new System.Windows.Forms.Label();
            this.Kogus = new System.Windows.Forms.Label();
            this.Hind = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaas2DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(63, 280);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(712, 177);
            this.dataGridView2.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Toode";
            this.bindingSource1.DataSource = this.andmebaas2DataSet1;
            // 
            // andmebaas2DataSet1
            // 
            this.andmebaas2DataSet1.DataSetName = "Andmebaas2DataSet";
            this.andmebaas2DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(63, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Lisa andmed";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // toodeTableAdapter1
            // 
            this.toodeTableAdapter1.ClearBeforeFill = true;
            // 
            // NimetusBx
            // 
            this.NimetusBx.Location = new System.Drawing.Point(195, 57);
            this.NimetusBx.Name = "NimetusBx";
            this.NimetusBx.Size = new System.Drawing.Size(116, 20);
            this.NimetusBx.TabIndex = 2;
            // 
            // KogusBx
            // 
            this.KogusBx.Location = new System.Drawing.Point(195, 105);
            this.KogusBx.Name = "KogusBx";
            this.KogusBx.Size = new System.Drawing.Size(116, 20);
            this.KogusBx.TabIndex = 3;
            // 
            // HindBx
            // 
            this.HindBx.Location = new System.Drawing.Point(195, 153);
            this.HindBx.Name = "HindBx";
            this.HindBx.Size = new System.Drawing.Size(116, 20);
            this.HindBx.TabIndex = 4;
            // 
            // Nimetus
            // 
            this.Nimetus.AutoSize = true;
            this.Nimetus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Nimetus.Location = new System.Drawing.Point(58, 51);
            this.Nimetus.Name = "Nimetus";
            this.Nimetus.Size = new System.Drawing.Size(93, 26);
            this.Nimetus.TabIndex = 5;
            this.Nimetus.Text = "Nimetus";
            this.Nimetus.Click += new System.EventHandler(this.label4_Click);
            // 
            // Kogus
            // 
            this.Kogus.AutoSize = true;
            this.Kogus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Kogus.Location = new System.Drawing.Point(58, 99);
            this.Kogus.Name = "Kogus";
            this.Kogus.Size = new System.Drawing.Size(74, 26);
            this.Kogus.TabIndex = 6;
            this.Kogus.Text = "Kogus";
            // 
            // Hind
            // 
            this.Hind.AutoSize = true;
            this.Hind.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Hind.Location = new System.Drawing.Point(58, 147);
            this.Hind.Name = "Hind";
            this.Hind.Size = new System.Drawing.Size(57, 26);
            this.Hind.TabIndex = 7;
            this.Hind.Text = "Hind";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(63, 236);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 38);
            this.button3.TabIndex = 8;
            this.button3.Text = "Kustuta andmed";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(218, 188);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 38);
            this.button4.TabIndex = 9;
            this.button4.Text = "Uuenda toode hind";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(844, 480);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Hind);
            this.Controls.Add(this.Kogus);
            this.Controls.Add(this.Nimetus);
            this.Controls.Add(this.HindBx);
            this.Controls.Add(this.KogusBx);
            this.Controls.Add(this.NimetusBx);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaas2DataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NimetusBox;
        private System.Windows.Forms.TextBox KogusBox;
        private System.Windows.Forms.TextBox HindBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Andmebaas2DataSet andmebaas2DataSet;
        private System.Windows.Forms.BindingSource toodeBindingSource;
        private Andmebaas2DataSetTableAdapters.ToodeTableAdapter toodeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nimetusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kogusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private Andmebaas2DataSet andmebaas2DataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Andmebaas2DataSetTableAdapters.ToodeTableAdapter toodeTableAdapter1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox NimetusBx;
        private System.Windows.Forms.TextBox KogusBx;
        private System.Windows.Forms.TextBox HindBx;
        private System.Windows.Forms.Label Nimetus;
        private System.Windows.Forms.Label Kogus;
        private System.Windows.Forms.Label Hind;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

