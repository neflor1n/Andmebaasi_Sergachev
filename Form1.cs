using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andmebaasi_Sergachev
{
    public partial class Form1 : Form
    {
        //SqlConnection conn = new SqlConnection (@"Data Source=(localdb)\MSSQLLocalDB;
        //    Initial Catalog=Andmebaas2");
        SqlConnection conn = new SqlConnection (@"Data Source=
            (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Andmebaasi_Sergachev\Andmebaass.mdf;
            Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            this.button2.Click += new System.EventHandler(this.lisa_vtb_click);
            this.button3.Click += new System.EventHandler(this.kustuta_btn_click);
            this.button4.Click += new System.EventHandler(this.uuenda_btn_click);
            this.button5.Click += new System.EventHandler(this.otsipilt_btn_Click);
        }



        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("Select * from Toode", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }


        public void lisa_vtb_click(object sender, EventArgs e)
        {
            if (NimetusBx.Text.Trim() != string.Empty && HindBx.Text.Trim() != string.Empty && KogusBx.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("INSERT INTO Toode(Nimetus, Hind, Kogus, Pilt) VALUES (@nimetus, @hind, @kogus, @pilt)", conn);
                    cmd.Parameters.AddWithValue("@nimetus", NimetusBx.Text);
                    cmd.Parameters.AddWithValue("@hind", HindBx.Text);  // Значение для поля Hind
                    cmd.Parameters.AddWithValue("@kogus", KogusBx.Text); // Значение для поля Kogus
                    cmd.Parameters.AddWithValue("@pilt", NimetusBx.Text + extension);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    NaitaAndmed();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasiga viga!");

                }
            }
            else
            {
                MessageBox.Show("Sisesta andmeid!");
            }
        }



        public void kustuta_btn_click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в DataGridView -- Kontrollimine, kas DataGridView-s on rida valitud
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    // Получаем ID выбранной строки - Hankige valitud rea ID
                    int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                    conn.Open();

                    
                    cmd = new SqlCommand("DELETE FROM Toode WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedID);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    NaitaAndmed();

                    MessageBox.Show("Kirje kustutamine õnnestus!");
                }
                catch
                {
                    MessageBox.Show("Viga kirje kustutamisel: ");
                }
            }
            else
            {
                MessageBox.Show("Valige kustutamiseks kirje.");
            }
        }


        public void uuenda_btn_click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedOption = comboBox1.SelectedItem.ToString().Trim(); 

                // Обработка "Uuenda toode hind"
                if (selectedOption == "Uuenda toode hind")
                {
                    if (dataGridView2.SelectedRows.Count > 0)
                    {
                        if (HindBx.Text.Trim() != string.Empty)
                        {
                            try
                            {
                                int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);
                                conn.Open();

                                cmd = new SqlCommand("UPDATE Toode SET Hind = @hind WHERE ID = @id", conn);
                                cmd.Parameters.AddWithValue("@hind", Convert.ToDecimal(HindBx.Text));  // Делаем текстовое поле в decimal
                                cmd.Parameters.AddWithValue("@id", selectedID);  // ID записи

                                cmd.ExecuteNonQuery();
                                conn.Close();

                                NaitaAndmed();

                                MessageBox.Show("Kirje värskendamine õnnestus!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Viga andmete värskendamisel: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sisestage värskendamiseks väärtus!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valige värskendamiseks kirje.");
                    }
                }
                // Обработка "Uuenda toode nimetus"
                else if (selectedOption == "Uuenda toode nimetus")
                {
                    if (dataGridView2.SelectedRows.Count > 0)
                    {
                        if (NimetusBx.Text.Trim() != string.Empty)
                        {
                            try
                            {
                                int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);
                                conn.Open();

                                cmd = new SqlCommand("UPDATE Toode SET Nimetus = @nimetus WHERE ID = @id", conn);
                                cmd.Parameters.AddWithValue("@nimetus", NimetusBx.Text);  
                                cmd.Parameters.AddWithValue("@id", selectedID);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                NaitaAndmed();

                                MessageBox.Show("Kirje värskendamine õnnestus!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Viga andmete värskendamisel: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sisestage värskendamiseks väärtus!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valige värskendamiseks kirje.");
                    }
                }
                // Обработка "Uuenda toode kogus"
                else if (selectedOption == "Uuenda toode kogus")
                {
                    if (dataGridView2.SelectedRows.Count > 0)
                    {
                        if (KogusBx.Text.Trim() != string.Empty)
                        {
                            try
                            {
                                int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);
                                conn.Open();

                                cmd = new SqlCommand("UPDATE Toode SET Kogus = @kogus WHERE ID = @id", conn);
                                cmd.Parameters.AddWithValue("@kogus", Convert.ToInt32(KogusBx.Text));  
                                cmd.Parameters.AddWithValue("@id", selectedID);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                NaitaAndmed();

                                MessageBox.Show("Kirje värskendamine õnnestus!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Viga andmete värskendamisel: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sisestage värskendamiseks väärtus!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valige värskendamiseks kirje.");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите что хотите изменить!");
                }
            }
            else
            {
                MessageBox.Show("Valige operatsioon!");
            }
        }



        OpenFileDialog open;
        SaveFileDialog save;
        string extension;
        public void otsipilt_btn_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\Pictures\";
            open.Multiselect = false;
            open.Filter = "Images Files(*.jpeg; *.png; *.jpg; *.bmp) |*.jpeg; *.png; *.jpg; *.bmp";
            FileInfo openfile = new FileInfo(@"C:\Users\opilane\Pictures\" + open.FileName);
            if (open.ShowDialog() == DialogResult.OK && NimetusBx.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\..\img");
                extension = Path.GetExtension(open.FileName);
                save.FileName = NimetusBx.Text + extension;
                save.Filter = "Images" + Path.GetExtension(open.FileName) + "|" + Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK && NimetusBx.Text != null) 
                {
                    File.Copy(open.FileName, save.FileName);
                    pictureBox1.Image = Image.FromFile(save.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või ole Cancel vajutatud");
            }
        }







       














        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'andmebaas2DataSet1.Toode' table. You can move, or remove it, as needed.

        }

        
    }
}
