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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Kategooria = new System.Windows.Forms.Label();
            this.kategooriaBx = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaas2DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.button2.Location = new System.Drawing.Point(562, 25);
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
            this.NimetusBx.Size = new System.Drawing.Size(127, 20);
            this.NimetusBx.TabIndex = 2;
            this.NimetusBx.Tag = "";
            // 
            // KogusBx
            // 
            this.KogusBx.Location = new System.Drawing.Point(195, 105);
            this.KogusBx.Name = "KogusBx";
            this.KogusBx.Size = new System.Drawing.Size(127, 20);
            this.KogusBx.TabIndex = 3;
            // 
            // HindBx
            // 
            this.HindBx.Location = new System.Drawing.Point(195, 153);
            this.HindBx.Name = "HindBx";
            this.HindBx.Size = new System.Drawing.Size(127, 20);
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
            this.button3.Location = new System.Drawing.Point(562, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 38);
            this.button3.TabIndex = 8;
            this.button3.Text = "Kustuta andmed";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(562, 157);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 38);
            this.button4.TabIndex = 9;
            this.button4.Text = "Uuenda toode andmed";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Uuenda toode hind",
            "Uuenda toode nimetus",
            "Uuenda toode kogus",
            "Uuenda toode pilt",
            "Uuenda toode kategooria"});
            this.comboBox1.Location = new System.Drawing.Point(702, 157);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(562, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(134, 38);
            this.button5.TabIndex = 11;
            this.button5.Text = "Pildi otsing";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(361, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 141);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Kategooria
            // 
            this.Kategooria.AutoSize = true;
            this.Kategooria.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Kategooria.Location = new System.Drawing.Point(58, 194);
            this.Kategooria.Name = "Kategooria";
            this.Kategooria.Size = new System.Drawing.Size(117, 26);
            this.Kategooria.TabIndex = 13;
            this.Kategooria.Text = "Kategooria";
            // 
            // kategooriaBx
            // 
            this.kategooriaBx.FormattingEnabled = true;
            this.kategooriaBx.Items.AddRange(new object[] {
            "Lihatooted",
            "Kalatooted",
            "Piimatooted",
            "Pagaritooted",
            "Köögiviljad",
            "Puuviljad",
            "Marjad",
            "Pasta"});
            this.kategooriaBx.Location = new System.Drawing.Point(195, 200);
            this.kategooriaBx.Name = "kategooriaBx";
            this.kategooriaBx.Size = new System.Drawing.Size(127, 21);
            this.kategooriaBx.TabIndex = 14;
            this.kategooriaBx.Text = "Vali toode kategooria";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(844, 480);
            this.Controls.Add(this.kategooriaBx);
            this.Controls.Add(this.Kategooria);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.comboBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaas2DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Kategooria;
        private System.Windows.Forms.ComboBox kategooriaBx;
    }
}

