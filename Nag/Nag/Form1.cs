using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            text_password.PasswordChar = '*';
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 540, 500);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);
            //Делаем таймер доступным
            timer_time.Enabled = true;
            //Запускаем таймер
            timer_time.Start();
            textBox_time.Text = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
        }

        private void timer_time_Tick(object sender, EventArgs e)
        {
            textBox_time.Text = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string login;
            string parol;

            login = textBox_login.Text;
            parol = text_password.Text;

            if ((login == "") || (parol == ""))
            {
                MessageBox.Show("Заполните поля логин и пароль!!!");
            }
            else
            {
              
                if ((login == "1") && (parol == "1"))
                {
                    Form_klient inf = new Form_klient();
                    this.Hide();
                    inf.ShowDialog();
                    this.Show();
                   
                }
                
            }

            textBox_login.Text = "";
            text_password.Text = "";
        }

        private void textBox_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                text_password.Select();
            }
        }

        private void text_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_ok.PerformClick();
            }
        }

       

     
    }
}
