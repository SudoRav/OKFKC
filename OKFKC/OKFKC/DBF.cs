using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace OKFKC
{
    class DBF
    {
        static SqlConnection con;
        static SqlCommand cmd;

        static private void Con()
        {
            try
            {
                con = new SqlConnection(@"Data Source=LAPTOP-NK04PI6P;Initial Catalog=Karting;Integrated Security=True");
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { }
        }

        static public void logout(Form frm)
        {
            Stat.Email_C_User = null;
            Stat.Password_C_User = null;
            Stat.FirstName_C_User = null;
            Stat.LastName_C_User = null;
            Stat.Role_C_User = null;

            frm.Hide();
            new Form1().Show();
        }

        static public void login(Form frm, string mail, string pas)
        {
            Con();
            try
            {
                DataTable tbl = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();

                cmd = new SqlCommand($"SELECT * FROM [User] WHERE Email = '{mail}' AND password = '{pas}'", con);
                adapter.SelectCommand = cmd;
                adapter.Fill(tbl);

                if (tbl.Rows.Count > 0)
                {
                    cmd = new SqlCommand($"SELECT Email FROM [User] WHERE Email = '{mail}' AND password = '{pas}'", con);
                    Stat.Email_C_User = cmd.ExecuteScalar().ToString();
                    cmd = new SqlCommand($"SELECT Password FROM [User] WHERE Email = '{mail}' AND password = '{pas}'", con);
                    Stat.Password_C_User = cmd.ExecuteScalar().ToString();
                    cmd = new SqlCommand($"SELECT First_Name FROM [User] WHERE Email = '{mail}' AND password = '{pas}'", con);
                    Stat.FirstName_C_User = cmd.ExecuteScalar().ToString();
                    cmd = new SqlCommand($"SELECT Last_Name FROM [User] WHERE Email = '{mail}' AND password = '{pas}'", con);
                    Stat.LastName_C_User = cmd.ExecuteScalar().ToString();
                    cmd = new SqlCommand($"SELECT ID_Role FROM [User] WHERE Email = '{mail}' AND password = '{pas}'", con);
                    Stat.Role_C_User = cmd.ExecuteScalar().ToString();

                    con.Close();
                    switch (Stat.Role_C_User)
                    {
                        case "R":
                            frm.Hide();
                            new forms._9().Show();
                            break;
                        case "C":
                            frm.Hide();
                            new forms._18().Show();
                            break;
                        case "A":
                            frm.Hide();
                            new forms._19().Show();
                            break;
                    }
                }
                else
                    MessageBox.Show("Не верная электронная почта или пароль");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static public bool crtSponsorship(TextBox name, ComboBox racer, TextBox card, TextBox num_card, TextBox activ_1, TextBox activ_2, TextBox cvc, TextBox sum)
        {
            Con();
            try
            {
                if (name.TextLength == 0)
                {
                    MessageBox.Show("Имя не введено");
                    return false;
                }

                if (racer.Text == "")
                {
                    MessageBox.Show("Выберите гонщика");
                    return false;
                }

                if (card.TextLength == 0)
                {
                    MessageBox.Show("Не верно ввредёна карта");
                    return false;
                }

                if (num_card.TextLength != 16)
                {
                    MessageBox.Show("Не верно ввредён номер карты");
                    return false;
                }

                if (activ_1.TextLength == 0 || activ_2.TextLength == 0)
                {
                    MessageBox.Show("Введите срок действия карты");
                    return false;
                }

                if (Convert.ToInt32(activ_1.Text) < Convert.ToInt32(DateTime.Today.Month) || Convert.ToInt32(activ_2.Text) < Convert.ToInt32(DateTime.Today.Year))
                {
                    MessageBox.Show("Карта просрочена");
                    return false;
                }

                if (cvc.TextLength != 3)
                {
                    MessageBox.Show("Не верно введён CVC");
                    return false;
                }

                if (Convert.ToInt32(sum.Text) == 0)
                {
                    MessageBox.Show("Введите сумму");
                    return false;
                }

                try
                {
                    //racer
                    cmd = new SqlCommand($"INSERT Sponsorship (SponsorName, Amount) VALUES ('{name.Text}', '{sum.Text}')", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        static public void fillGender(ComboBox box)
        {
            Con();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Gender_Name FROM Gender", con);
                DataSet data2 = new DataSet();
                adapter.Fill(data2);
                box.DataSource = data2.Tables[0];
                box.DisplayMember = "Gender_Name";
                box.ValueMember = "Gender_Name";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static public void fillCountry(ComboBox box)
        {
            Con();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Country", con);
                DataSet data = new DataSet();
                adapter.Fill(data);
                box.DataSource = data.Tables[0];
                box.DisplayMember = "Country_Name";
                box.ValueMember = "Country_Name";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static public void fillRacer(ComboBox box)
        {
            Con();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT First_Name + ' ' + Last_Name as 'FI' FROM Racer", con);
                DataSet data = new DataSet();
                adapter.Fill(data);
                box.DataSource = data.Tables[0];
                box.DisplayMember = "FI";
                box.ValueMember = "FI";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static public void fillCharity(ComboBox box)
        {
            Con();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Charity", con);
                DataSet data = new DataSet();
                adapter.Fill(data);
                box.DataSource = data.Tables[0];
                box.DisplayMember = "Charity_Name";
                box.ValueMember = "Charity_Name";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static public bool valid(string mail)
        {
            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            cmd = new SqlCommand($"SELECT * FROM [User] WHERE Email = '{mail}'", con);
            adapter.SelectCommand = cmd;
            adapter.Fill(tbl);

            if (tbl.Rows.Count == 0)
                return true;
            else
                return false;
        }

        static public void crtRacer(TextBox mail, TextBox pas, TextBox repas, TextBox F_name, TextBox l_name, ComboBox gen, DateTimePicker date, PictureBox image, ComboBox count)
        {
            Con();
            try
            {
                if (!valid(mail.Text))
                {
                    MessageBox.Show("Эта электронная почта уже используется");
                    return;
                }

                if (mail.TextLength == 0 && !mail.Text.Contains('@') & !mail.Text.Contains('.'))
                {
                    MessageBox.Show("Введите электронную почту");
                    return;
                }

                if (pas.TextLength < 5)
                {
                    MessageBox.Show("Слишком короткий пароль");
                    return;
                }

                if (!IsNumberContains(pas.Text))
                {
                    MessageBox.Show("Пароль должен содержать хотябы одну цифру");
                    return;
                }

                if (!IsCharContains(pas.Text))
                {
                    MessageBox.Show("Пароль должен содержать хотябы одну букву");
                    return;
                }

                if (!pas.Text.Contains('!') && !pas.Text.Contains('@') && !pas.Text.Contains('#') && !pas.Text.Contains('$') && !pas.Text.Contains('%') && !pas.Text.Contains('^'))
                {
                    MessageBox.Show("Пароль должен содержать хотябы один из следующих символов:\n! @ # $ % ^");
                    return;
                }

                if (pas.Text != repas.Text)
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }

                if (F_name.TextLength == 0)
                {
                    MessageBox.Show("Введите Фамилию");
                    return;
                }

                if (l_name.TextLength == 0)
                {
                    MessageBox.Show("Введите Имя");
                    return;
                }

                if (gen.Text != "")
                {
                    MessageBox.Show("Выберите пол");
                    return;
                }

                if (date.Value > DateTime.Today)
                {
                    MessageBox.Show("Не верная дата");
                    return;
                }

                if (image.Image != null)
                {
                    MessageBox.Show("Выберите фото");
                    return;
                }

                try
                {
                    cmd = new SqlCommand($"INSERT INTO [User] (Email, Password, First_Name, Last_Name, ID_Role) VALUES ('{mail.Text}', '{pas.Text}', '{F_name.Text}', '{l_name.Text}', 'R')", con);
                    cmd.ExecuteNonQuery();

                    MemoryStream ms = new MemoryStream();
                    image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] img = ms.ToArray();
                    cmd = new SqlCommand($"INSERT INTO Racer (First_Name, Last_Name, Gender, DateOfBirth, ID_Country, Photo) VALUES ('{F_name.Text}', '{l_name.Text}', '{gen.Text}', '{date.Value}', '{count.SelectedValue.ToString()}', @img)", con);
                    cmd.Parameters.AddWithValue("@img", (object)img);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exс)
                {
                    MessageBox.Show(exс.Message);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static public void updRacer(string mail, string pas, TextBox repas, TextBox F_name, TextBox l_name, ComboBox gen, DateTimePicker date, PictureBox image, ComboBox count)
        {
            Con();
            try
            {

                if (F_name.TextLength == 0)
                {
                    MessageBox.Show("Введите Фамилию");
                    return;
                }

                if (l_name.TextLength == 0)
                {
                    MessageBox.Show("Введите Имя");
                    return;
                }

                if (gen.Text == "")
                {
                    MessageBox.Show("Выберите пол");
                    return;
                }

                if (date.Value > DateTime.Today)
                {
                    MessageBox.Show("Не верная дата");
                    return;
                }
                if (image.Image != null)
                {
                    if (pas.Length != 0)
                    {
                        if (pas.Length < 5)
                        {
                            MessageBox.Show("Слишком короткий пароль");
                            return;
                        }

                        if (!IsNumberContains(pas))
                        {
                            MessageBox.Show("Пароль должен содержать хотябы одну цифру");
                            return;
                        }

                        if (!IsCharContains(pas))
                        {
                            MessageBox.Show("Пароль должен содержать хотябы одну букву");
                            return;
                        }

                        if (!pas.Contains('!') && !pas.Contains('@') && !pas.Contains('#') && !pas.Contains('$') && !pas.Contains('%') && !pas.Contains('^'))
                        {
                            MessageBox.Show("Пароль должен содержать хотябы один из следующих символов:\n! @ # $ % ^");
                            return;
                        }

                        if (pas != repas.Text)
                        {
                            MessageBox.Show("Пароли не совпадают");
                            return;
                        }

                        cmd = new SqlCommand($"UPDATE [User] SET Password = '{pas}', FirstName = '{F_name.Text}', LastName = '{l_name.Text}' WHERE Email = '{mail}'", con);
                        cmd.ExecuteNonQuery();
                        MemoryStream ms = new MemoryStream();
                        image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] img = ms.ToArray();
                        cmd = new SqlCommand($"UPDATE Racer SET Gender = '{gen.Text}', DateOfBirth = '{date.Text}', ID_Country = '{count.SelectedValue.ToString()}', Photo = @img WHERE Email = '{mail}'", con);
                        cmd.Parameters.AddWithValue("@img", (object)img);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand($"UPDATE [User] SET FirstName = '{F_name.Text}', LastName = '{l_name.Text}' WHERE Email = '{mail}'", con);
                        cmd.ExecuteNonQuery();
                        MemoryStream ms = new MemoryStream();
                        image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] img = ms.ToArray();
                        cmd = new SqlCommand($"UPDATE Racer SET Gender = '{gen.Text}', DateOfBirth = '{date.Value}', CountryCode = '{count.SelectedValue.ToString()}', Photo = @img WHERE Email = '{mail}'", con);
                        cmd.Parameters.AddWithValue("@img", (object)img);
                        cmd.ExecuteNonQuery();
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static public void crtRegistaration(CheckBox m65, CheckBox m40, CheckBox m25, string sum, TextBox targ, ComboBox charity)
        {
            Con();
            try
            {
                if (!m65.Checked && !m40.Checked && !m25.Checked)
                {
                    MessageBox.Show("Выберите минимум 1 вид марафона");
                    return;
                }
                if (Convert.ToInt32(sum) > 0)
                {
                    cmd = new SqlCommand($"SELECT ID_Racer FROM Racer WHERE First_Name = '{Stat.FirstName_C_User}' AND Last_Name = '{Stat.LastName_C_User}'", con);
                    string rid = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand($"INSERT INTO Registration (ID_Racer, Registration_Date, ID_Registration_Status, Cost, ID_Charity, SponsorshipTarget) VALUES ('{rid}', '{DateTime.Today}', '1', '{sum}', '{charity.SelectedValue.ToString()}', '{1}')", con);
                    //cmd = new SqlCommand($"INSERT INTO Registration (ID_Racer, Registration_Date, ID_Registration_Status, Cost, ID_Charity, SponsorshipTarget) VALUES ('{rid}', '{DateTime.Today}', '1', '{sum}', '{charity.SelectedValue.ToString()}', '{targ.ToString()}')", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                else
                    MessageBox.Show("Cумма взноса должна быть действительным положительным числом");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        static public bool IsNumberContains(string input)
        {
            foreach (char c in input)
                if (Char.IsNumber(c))
                    return true;
            return false;
        }


        static public bool IsCharContains(string input)
        {
            foreach (char c in input)
                if (Char.IsLetter(c))
                    return true;
            return false;
        }

        static public void getGender(Label box)
        {
            Con();
            try
            {
                cmd = new SqlCommand($"SELECT Gender FROM Racer WHERE Email = '{Stat.Email_C_User}'", con);
                box.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static public void loadSponsor(DataGridView grid, Label label_sum, Label name, Label des, PictureBox logo)
        {
            Con();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Sponsorship.SponsorName as 'Спонсор', Sponsorship.Amount as 'Взнос' FROM Sponsorship", con);

                DataSet data = new DataSet();
                adapter.Fill(data);
                grid.DataSource = data.Tables[0];

                cmd = new SqlCommand($"SELECT CharityName FROM Racer " +
                                     $"JOIN Registration ON Registration.ID_Racer = Racer.ID_Racer " +
                                     $"JOIN Charity ON Charity.ID_Charity = Registration.ID_Charity " +
                                     $"WHERE User.Email = '{Stat.Email_C_User}'", con);

                if (cmd.ExecuteScalar() != null)
                {
                    name.Text = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand($"SELECT CharityLogo FROM Racer " +
                                         $"JOIN Registration ON Registration.ID_Racer = Racer.ID_Racer " +
                                         $"JOIN Charity ON Charity.ID_Charity = Registration.ID_Charity " +
                                         $"WHERE User.Email = '{Stat.Email_C_User}'", con);

                    string p = @"D:\GoogleDisk\OKFKC\OKFKC\OKFKC\image\charity-data\";
                    logo.Image = new Bitmap(p + cmd.ExecuteScalar().ToString());

                    cmd = new SqlCommand($"SELECT CharityDescription FROM Racer " +
                                         $"JOIN Registration ON Registration.ID_Racer = Racer.ID_Racer " +
                                         $"JOIN Charity ON Charity.ID_Charity = Registration.ID_Charity " +
                                         $"WHERE User.Email = '{Stat.Email_C_User}'", con);
                    des.Text = cmd.ExecuteScalar().ToString();

                    double sum = 0;
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {
                        sum += Convert.ToDouble(grid[1, i].Value);
                    }
                    label_sum.Text = "Всео $" + sum.ToString();
                }
                else
                {
                    label_sum.Text = "Всео $0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    class TTimer
    {
        DateTime endTime = new DateTime(2023, 11, 24, 06, 00, 0);
        Label Ltimer;
        public void Timer(Label ltimer)
        {
            Ltimer = ltimer;
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            TimeSpan ts = endTime.Subtract(DateTime.Now);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = endTime.Subtract(DateTime.Now);
            Ltimer.Text = "До начала события осталось ";
            Ltimer.Text += ts.ToString("d' дней 'h' часов 'm' минут 's' секунд.'");
        }
    }
}
