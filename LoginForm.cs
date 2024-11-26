using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Andmebaasi_Sergachev
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Andmebaasi_Sergachev\Andmebaass.mdf;Integrated Security=True");

        Label UsernameLbl, PasswordLbl;
        TextBox UsernameTxtBox, PasswordTxtBox;
        Button LoginBtn, RegisterBtn;

        public LoginForm()
        {
            this.Text = "Sisene";
            this.Width = 400;
            this.Height = 300;

            Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            UsernameLbl = new Label()
            {
                Text = "Kasutajanimi:",
                Location = new System.Drawing.Point(20, 30),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12)
            };
            this.Controls.Add(UsernameLbl);

            UsernameTxtBox = new TextBox()
            {
                Location = new System.Drawing.Point(150, 30),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12)
            };
            this.Controls.Add(UsernameTxtBox);

            PasswordLbl = new Label()
            {
                Text = "Parool:",
                Location = new System.Drawing.Point(20, 70),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12)
            };
            this.Controls.Add(PasswordLbl);

            PasswordTxtBox = new TextBox()
            {
                Location = new System.Drawing.Point(150, 70),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12),
                UseSystemPasswordChar = true
            };
            this.Controls.Add(PasswordTxtBox);

            LoginBtn = new Button()
            {
                Text = "Sisene",
                Location = new System.Drawing.Point(150, 120),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                Width = 100,
                Height = 40
            };
            LoginBtn.Click += LoginButton_Click;
            this.Controls.Add(LoginBtn);

            RegisterBtn = new Button()
            {
                Text = "Registreeri",
                Location = new System.Drawing.Point(150, 170),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                Width = 100,
                Height = 40
            };
            RegisterBtn.Click += RegisterButton_Click;
            this.Controls.Add(RegisterBtn);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTxtBox.Text;
            string password = PasswordTxtBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Palun täitke kõik väljad!");
                return;
            }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Role FROM Users WHERE Username = @Username AND Password = @Password", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string role = reader["Role"].ToString();

                    MessageBox.Show("Sisenemine õnnestus! Tere tulemast, " + role);

                    if (role == "Müüja")
                    {
                        Kassa kassaForm = new Kassa();
                        kassaForm.Show();
                    }
                    else if (role == "Omanik")
                    {
                        Form1 toodedForm = new Form1();
                        toodedForm.Show();
                    }

                    this.Hide();  
                }
                else
                {
                    MessageBox.Show("Vale kasutajanimi või parool!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga: " + ex.Message);
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            registreerimine registerForm = new registreerimine();
            registerForm.Show();
            this.Hide();  
        }
    }
}
