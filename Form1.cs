﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
        SqlConnection conn = new SqlConnection(@"Data Source=
            (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Andmebaasi_Sergachev\Andmebaass.mdf;
            Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable laoTable, kategooriaTable;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            NaitaLaod();
            NaitaKategooria();
            this.button2.Click += new System.EventHandler(this.lisa_vtb_click);
            this.button3.Click += new System.EventHandler(this.kustuta_btn_click);
            this.button4.Click += new System.EventHandler(this.uuenda_btn_click);
            this.button5.Click += new System.EventHandler(this.otsipilt_btn_Click);

            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            dataGridView2.CellMouseEnter += new DataGridViewCellEventHandler(dataGridView2_CellMouseEnter);
            dataGridView2.CellMouseLeave += new DataGridViewCellEventHandler(dataGridView2_CellMouseLeave);

        }

        private void NaitaLaod()
        {
            conn.Open();
            cmd = new SqlCommand("SELECT Id, LaoNimetus from Ladu", conn);
            adapter = new SqlDataAdapter(cmd);
            laoTable = new DataTable();
            adapter.Fill(laoTable);
            foreach (DataRow i in laoTable.Rows)
            {
                LaduCb.Items.Add(i["LaoNimetus"]);

            }


            conn.Close();


        }

        private void NaitaKategooria()
        {
            conn.Open();
            cmd = new SqlCommand("Select Id, Kategooria from Kategooria", conn);
            adapter = new SqlDataAdapter(cmd);
            kategooriaTable = new DataTable();
            adapter.Fill(kategooriaTable);
            foreach (DataRow i in kategooriaTable.Rows)
            {
                kategooriaBx.Items.Add(i["Kategooria"]);
            }
            conn.Close();
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
            if (NimetusBx.Text.Trim() != string.Empty && HindBx.Text.Trim() != string.Empty && KogusBx.Text.Trim() != string.Empty && kategooriaBx.Text.Trim() != string.Empty && LaduCb.Text.Trim() != string.Empty)
            {
                try
                {

                    if (Convert.ToDecimal(HindBx.Text) < 0)
                    {
                        MessageBox.Show("Hind ei saa olla negatiivne!");
                        return;
                    }

                    if (Convert.ToInt32(KogusBx.Text) < 0)
                    {
                        MessageBox.Show("Kogus ei saa olla negatiivne!");
                        return;
                    }


                    conn.Open();

                    cmd = new SqlCommand("Select Id from Ladu where LaoNimetus = @ladu", conn);
                    cmd.Parameters.AddWithValue("@ladu", LaduCb.Text);
                    int laduID = Convert.ToInt32(cmd.ExecuteScalar());


                    cmd = new SqlCommand("select Id from Kategooria where Kategooria = @kat", conn);
                    cmd.Parameters.AddWithValue("@kat", kategooriaBx.Text);
                    int kategooriaID = Convert.ToInt32(cmd.ExecuteScalar());

                    byte[] imageBytes = null;
                    if (pictureBox1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                            imageBytes = ms.ToArray();
                        }
                    }
                    cmd = new SqlCommand("INSERT INTO Toode(Nimetus, Hind, Kogus, Kategooria, pilt, LaoID) VALUES (@nimetus, @hind, @kogus, @kategooria,@pilt, @ladu)", conn);
                    cmd.Parameters.AddWithValue("@nimetus", NimetusBx.Text);
                    cmd.Parameters.AddWithValue("@hind", HindBx.Text);  // Значение для поля Hind
                    cmd.Parameters.AddWithValue("@kogus", KogusBx.Text); // Значение для поля Kogus
                    cmd.Parameters.AddWithValue("@kategooria", kategooriaID);
                    cmd.Parameters.AddWithValue("@pilt", NimetusBx.Text + extension);
                    cmd.Parameters.AddWithValue("@ladu", laduID);

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

        private void kustutaFile(string file)
        {
            try
            {
                string filePath = Path.Combine(Path.GetFullPath(@"..\..\img"), file + extension);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);

                }
                else
                {
                    MessageBox.Show("Fail ei leidnud");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failiga probleemid {ex.Message}");
            }
        }


        public void kustuta_btn_click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    // Получаем ID выбранной строки
                    int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);
                    string file = NimetusBx.Text;
                    kustutaFile(file);



                    // Удаление записи из базы данных
                    try
                    {
                        conn.Open();
                        cmd = new SqlCommand("DELETE FROM Toode WHERE ID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", selectedID);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        // Обновляем данные в DataGridView
                        NaitaAndmed();
                        eemaldamine();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Viga kirje kustutamisel andmebaasis: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Viga kogu protsessis: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Valige kustutamiseks kirje.");
            }
        }





        private void eemaldamine()
        {
            NimetusBx.Text = "";
            KogusBx.Text = "";
            HindBx.Text = "";
            pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\img"), "pilt.jpg"));
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
                else if (selectedOption == "Uuenda toode pilt")
                {
                    if (dataGridView2.SelectedRows.Count > 0)
                    {
                        // Проверка, выбрано ли изображение в PictureBox
                        if (pictureBox1.Image != null)
                        {
                            // Открыть диалог выбора файла изображения
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                            openFileDialog.Title = "Valige uus pilt";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                // Получить выбранный файл
                                string newImagePath = openFileDialog.FileName;

                                // Получить ID выбранной строки
                                int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                                // Путь для сохранения изображения
                                string savePath = Path.Combine(Path.GetFullPath(@"..\..\img"), selectedID + Path.GetExtension(newImagePath));

                                try
                                {
                                    // Копировать новое изображение в папку
                                    File.Copy(newImagePath, savePath, true);  // Флаг "true" перезаписывает файл, если он уже существует

                                    // Обновить путь к изображению в базе данных
                                    conn.Open();
                                    cmd = new SqlCommand("UPDATE Toode SET pilt = @pilt WHERE ID = @id", conn);
                                    cmd.Parameters.AddWithValue("@pilt", selectedID + Path.GetExtension(newImagePath));  // Сохраняем только имя файла
                                    cmd.Parameters.AddWithValue("@id", selectedID);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    // Обновить отображение изображения
                                    pictureBox1.Image = Image.FromFile(savePath);
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                                    MessageBox.Show("Pilt uuendatud edukalt!");
                                    NaitaAndmed();  // Обновить данные в DataGridView
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Viga pildi uuendamisel: " + ex.Message);
                                }
                            }
                        }

                        else
                        {
                            MessageBox.Show("Valige pilt!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valige kategooria.");
                    }
                }
            
            
                else if (comboBox1.SelectedItem != null)
                {
                    selectedOption = comboBox1.SelectedItem.ToString().Trim();
                    if (selectedOption == "Uuenda toode kategooria")
                    {
                        if (dataGridView2.SelectedRows.Count > 0)
                        {
                            if (kategooriaBx.SelectedItem != null && kategooriaBx.SelectedItem.ToString().Trim() != string.Empty)
                            {
                                try
                                {
                                    string selectedKategooria = kategooriaBx.SelectedItem.ToString();
                                    conn.Open();
                                    cmd = new SqlCommand("select Id from Kategooria where Kategooria = @kat", conn);
                                    cmd.Parameters.AddWithValue("@kat", selectedKategooria);
                                    object result = cmd.ExecuteScalar();
                                    conn.Close();

                                    if (result != null)
                                    {
                                        int kategooriaId = Convert.ToInt32(result);
                                        int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                                        conn.Open();
                                        cmd = new SqlCommand("UPDATE Toode SET Kategooria = @katId WHERE ID = @id", conn);
                                        cmd.Parameters.AddWithValue("@katId", kategooriaId);
                                        cmd.Parameters.AddWithValue("@id", selectedID);
                                        cmd.ExecuteNonQuery();
                                        conn.Close();

                                        NaitaAndmed();
                                        MessageBox.Show("Toode ladu on edukalt uuendatud!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Valitud ladu ei eksisteeri andmebaasis!");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Viga andmete värskendamisel: " + ex.Message);
                                }

                            }
                        }
                    }
                }

                else if (comboBox1.SelectedItem != null)
                {

                    selectedOption = comboBox1.SelectedItem.ToString().Trim();

                    // Обработка "Uuenda toode ladu"
                    if (selectedOption == "Uuenda toode ladu")
                    {
                        if (dataGridView2.SelectedRows.Count > 0)
                        {
                            if (LaduCb.SelectedItem != null && LaduCb.SelectedItem.ToString().Trim() != string.Empty)
                            {
                                try
                                {
                                    // Получаем ID выбранного элемента из комбобокса
                                    string selectedLadu = LaduCb.SelectedItem.ToString();

                                    // Проверка, существует ли выбранное значение в таблице Ladu
                                    conn.Open();
                                    cmd = new SqlCommand("SELECT Id FROM Ladu WHERE LaoNimetus = @ladu", conn);
                                    cmd.Parameters.AddWithValue("@ladu", selectedLadu);
                                    object result = cmd.ExecuteScalar();
                                    conn.Close();

                                    if (result != null)
                                    {
                                        int laduId = Convert.ToInt32(result);

                                        // Получаем ID выбранной строки из DataGridView
                                        int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                                        // Обновляем запись в таблице Toode
                                        conn.Open();
                                        cmd = new SqlCommand("UPDATE Toode SET LaoID = @laduId WHERE ID = @id", conn);
                                        cmd.Parameters.AddWithValue("@laduId", laduId); // новое значение для LaoID
                                        cmd.Parameters.AddWithValue("@id", selectedID);  // ID записи
                                        cmd.ExecuteNonQuery();
                                        conn.Close();

                                        NaitaAndmed();
                                        MessageBox.Show("Toode ladu on edukalt uuendatud!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Valitud ladu ei eksisteeri andmebaasis!");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Viga andmete värskendamisel: " + ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Valige ladu.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Valige värskendamiseks kirje.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valige operatsioon!");

                    }
                }
                
            }
            else
            {
                MessageBox.Show("Valige operatsioon!"); // Сообщение о том, что операция не выбрана
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
                save.InitialDirectory = Path.GetFullPath(@"..\..\img");
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



        int ID = 0;
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Получаем ID выбранной строки
                int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                // Заполняем текстовые поля значениями из базы данных
                NimetusBx.Text = dataGridView2.SelectedRows[0].Cells["Nimetus"].Value.ToString();
                KogusBx.Text = dataGridView2.SelectedRows[0].Cells["Kogus"].Value.ToString();
                HindBx.Text = dataGridView2.SelectedRows[0].Cells["Hind"].Value.ToString();
                kategooriaBx.Text = dataGridView2.SelectedRows[0].Cells["Kategooria"].Value.ToString();
                LaduCb.Text = dataGridView2.SelectedRows[0].Cells["LaoID"].Value.ToString();
                try
                {
                    // Попытка загрузить картинку
                    string imagePath = Path.Combine(Path.GetFullPath(@"..\..\img"), dataGridView2.SelectedRows[0].Cells["pilt"].Value.ToString());

                    // Проверка, существует ли файл
                    if (File.Exists(imagePath))
                    {
                        pictureBox1.Image = Image.FromFile(imagePath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        // Если картинка не найдена, выводим дефолтное изображение 
                        pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\img"), "pilt.jpg"));
                    }
                }
                catch (Exception)
                {
                    // В случае ошибки показываем дефолтное изображение
                    pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\img"), "pilt.jpg"));
                }
            }
        }


        // Событие наведения мышки на ячейку (CellMouseEnter)
        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["pilt"].Index && e.RowIndex >= 0)
            {
                var imageFileName = dataGridView2.Rows[e.RowIndex].Cells["pilt"].Value?.ToString();

                if (!string.IsNullOrEmpty(imageFileName))
                {
                    string imagePath = Path.Combine(Path.GetFullPath(@"..\..\img"), imageFileName);

                    if (File.Exists(imagePath))
                    {
                        pictureBox1.Image = Image.FromFile(imagePath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    
                }
            }
        }

        // Событие ухода мышки с ячейки (CellMouseLeave)
        private void dataGridView2_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Убираем изображение из PictureBox при уходе мышки
            pictureBox1.Image = null;
        }







        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'andmebaas2DataSet1.Toode' table. You can move, or remove it, as needed.

        }

        
    }
}
