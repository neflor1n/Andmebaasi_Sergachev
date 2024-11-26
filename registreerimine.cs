using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Andmebaasi_Sergachev
{
    public partial class registreerimine : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Andmebaasi_Sergachev\Andmebaass.mdf;Integrated Security=True");

        Label UsernameLabel, PasswordLabel, RoleLabel;
        TextBox UsernameTextBox, PasswordTextBox;
        ComboBox RoleComboBox;
        Button RegisterButton, BackButton;

        public registreerimine()
        {
            this.Text = "Registreeri Kasutaja";
            this.Width = 400;
            this.Height = 300;

            Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            UsernameLabel = new Label()
            {
                Text = "Kasutajanimi:",
                Location = new System.Drawing.Point(20, 30),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12)
            };
            this.Controls.Add(UsernameLabel);

            UsernameTextBox = new TextBox()
            {
                Location = new System.Drawing.Point(150, 30),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12)
            };
            this.Controls.Add(UsernameTextBox);

            PasswordLabel = new Label()
            {
                Text = "Parool:",
                Location = new System.Drawing.Point(20, 70),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12)
            };
            this.Controls.Add(PasswordLabel);

            PasswordTextBox = new TextBox()
            {
                Location = new System.Drawing.Point(150, 70),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12),
                UseSystemPasswordChar = true
            };
            this.Controls.Add(PasswordTextBox);

            RoleLabel = new Label()
            {
                Text = "Roll:",
                Location = new System.Drawing.Point(20, 110),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12)
            };
            this.Controls.Add(RoleLabel);

            RoleComboBox = new ComboBox()
            {
                Location = new System.Drawing.Point(150, 110),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            RoleComboBox.Items.Add("Müüja");
            RoleComboBox.Items.Add("Omanik");
            this.Controls.Add(RoleComboBox);

            RegisterButton = new Button()
            {
                Text = "Registreeri",
                Location = new System.Drawing.Point(150, 150),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                Width = 100,
                Height = 40
            };
            RegisterButton.Click += RegisterButton_Click;
            this.Controls.Add(RegisterButton);

            BackButton = new Button()
            {
                Text = "Tagasi",
                Location = new System.Drawing.Point(150, 200),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                Width = 100,
                Height = 40
            };
            BackButton.Click += BackButton_Click;
            this.Controls.Add(BackButton);
        }

        // Обработчик нажатия кнопки "Registreeri"
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string role = RoleComboBox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Palun täitke kõik väljad!");
                return;
            }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Kasutaja registreeritud edukalt!");
                this.Close();
                LoginForm LoginForm = new LoginForm();
                LoginForm.Show(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga: " + ex.Message);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();
        }
    }
}
