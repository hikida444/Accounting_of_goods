using WinFormsApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string login = txtLogin.Text;
			string password = txtPassword.Text;

			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				var user = db.Users
							 .Include(u => u.Role)
							 .FirstOrDefault(u => u.Login == login && u.PasswordHash == password);

				if (user != null)
				{
					MainForm mainForm = new MainForm(user);
					mainForm.Show();
					this.Hide();
				}
				else
				{
					MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RegisterForm regForm = new RegisterForm();
			regForm.ShowDialog();
		}

		private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
		{
			txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
		}
	}
}
