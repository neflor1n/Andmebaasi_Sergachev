using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Andmebaasi_Sergachev
{
    public partial class Kassa : Form
    {
        DataGridView toodeid;
        Label text, kogusLb, ToodeLb;
        ComboBox ToodeCb;
        NumericUpDown kogusNum;
        Button OtsiBtn;
        SqlConnection conn = new SqlConnection(@"Data Source=
        (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Andmebaasi_Sergachev\Andmebaass.mdf;
        Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        public Kassa()
        {
            this.Text = "Kassa";
            this.Width = 900;
            this.Height = 700;

            Font = new System.Drawing.Font("Microsoft Sans Serif", 20, FontStyle.Bold);

            Label text = new Label()
            {
                Text = "Toode otsimine",
                Location = new System.Drawing.Point(350, 20),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Black,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 20, FontStyle.Underline)
            };
            Controls.Add(text);

            Label ToodeLb = new Label()
            {
                Text = "Toode:",
                Location = new System.Drawing.Point(40, 100),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Black,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 18, FontStyle.Underline)
            };
            this.Controls.Add(ToodeLb);

            Label KogusLb = new Label()
            {
                Text = "Kogus:",
                Location = new System.Drawing.Point(40, 160),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Black,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 18, FontStyle.Underline)
            };
            this.Controls.Add(KogusLb);

            ToodeCb = new ComboBox()
            {
                Location = new System.Drawing.Point(140, 100),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 16, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(ToodeCb);

            toodeid = new DataGridView()
            {
                Location = new System.Drawing.Point(40, 300),
                Width = 500,
                Height = 300,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            };
            this.Controls.Add(toodeid);

            kogusNum = new NumericUpDown()
            {
                Location = new System.Drawing.Point(140, 160),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            };
            this.Controls.Add(kogusNum);

            OtsiBtn = new Button();
            OtsiBtn.Text = "Osta";
            OtsiBtn.Width = 100;
            OtsiBtn.Height = 50;
            OtsiBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18, FontStyle.Underline);
            OtsiBtn.Location = new System.Drawing.Point(40, 200);
            Controls.Add(OtsiBtn);
            OtsiBtn.Click += OtsiBtn_Click;

            NaitaAndmed();
        }

        private void OtsiBtn_Click(object sender, EventArgs e)
        {
            // Получаем выбранный товар и количество
            string selectedProduct = ToodeCb.SelectedItem?.ToString();
            int quantity = (int)kogusNum.Value;

            if (string.IsNullOrEmpty(selectedProduct) || quantity == 0)
            {
                MessageBox.Show("Valige toode ja sisestage kogus.");
                return;
            }

            // Находим информацию о выбранном товаре
            decimal price = 0;
            DataRow[] rows = ((DataTable)toodeid.DataSource).Select($"Nimetus = '{selectedProduct}'");

            if (rows.Length > 0)
            {
                price = Convert.ToDecimal(rows[0]["Hind"]);
            }

            decimal total = price * quantity;

            // Проверяем, достаточно ли товара на складе
            int availableQuantity = Convert.ToInt32(rows[0]["Kogus"]);
            if (availableQuantity < quantity)
            {
                MessageBox.Show("Kogus on liiga väike. Palun valige väiksem kogus.");
                return;
            }

            // Обновляем количество товара в базе данных
            UpdateProductQuantity(selectedProduct, availableQuantity - quantity);

            // Генерация чека в PDF
            GenerateReceipt(selectedProduct, price, quantity, total);
        }

        private void UpdateProductQuantity(string productName, int newQuantity)
        {
            try
            {
                conn.Open();
                SqlCommand updateCmd = new SqlCommand("UPDATE Toode SET Kogus = @newQuantity WHERE Nimetus = @productName", conn);
                updateCmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                updateCmd.Parameters.AddWithValue("@productName", productName);
                updateCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga andmebaasis: " + ex.Message);
            }

            // После обновления базы данных снова отображаем актуальные данные
            NaitaAndmed();
        }

        private void GenerateReceipt(string product, decimal price, int quantity, decimal total)
        {
            // Создаем новый документ PDF
            Document pdfDocument = new Document();

            // Добавляем страницу
            Page page = pdfDocument.Pages.Add();

            TextFragment title = new TextFragment("Kassa KVIIT");
            title.TextState.FontSize = 18;
            title.TextState.FontStyle = FontStyles.Bold;
            title.Position = new Position(200, 750);
            page.Paragraphs.Add(title);

            // Добавляем информацию о товаре
            TextFragment productLine = new TextFragment($"Toode: {product}");
            productLine.TextState.FontSize = 12;
            productLine.Position = new Position(100, 700);
            page.Paragraphs.Add(productLine);

            TextFragment priceLine = new TextFragment($"Hind: {price} EUR");
            priceLine.TextState.FontSize = 12;
            priceLine.Position = new Position(100, 670);
            page.Paragraphs.Add(priceLine);

            TextFragment quantityLine = new TextFragment($"Kogus: {quantity}");
            quantityLine.TextState.FontSize = 12;
            quantityLine.Position = new Position(100, 640);
            page.Paragraphs.Add(quantityLine);

            TextFragment totalLine = new TextFragment($"Kogus kokku: {total} EUR");
            totalLine.TextState.FontSize = 12;
            totalLine.Position = new Position(100, 610);
            page.Paragraphs.Add(totalLine);

            // Сохранить PDF документ
            string filePath = @"..\..\Arved\Receipt_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";
            pdfDocument.Save(filePath);

            MessageBox.Show("Kviitung on genereeritud: " + filePath);
        }

        private void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select Nimetus, Hind, Kogus, pilt from Toode", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            toodeid.DataSource = dt;

            ToodeCb.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ToodeCb.Items.Add(row["Nimetus"].ToString());
            }

            conn.Close();
        }
    }
}
