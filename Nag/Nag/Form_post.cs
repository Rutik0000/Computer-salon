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
    public partial class Form_post : Form
    {
        public Form_post()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_izd_Load(object sender, EventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 715, 510);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);
            next();
        }

        private void next()
        {
            BD bd = new BD();
            List<post> spisok = new List<post>();
            spisok = bd.Fill_post();
            dataGridView1.DataSource = spisok;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Телефон";
            dataGridView1.Columns[3].HeaderText = "Адрес";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                post z = new post();
                z.Name = textBox_name.Text;
                z.Tel = textBox_tel.Text;
                z.Adres = textBox_adres.Text;

                BD bd = new BD();
                try
                {

                    bd.Inser_post(z);
                    MessageBox.Show("Успешно!!!");
                    textBox_name.Text = "";
                    next();

                }
                catch (FormatException)
                { MessageBox.Show("Ошибка!"); }

            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "")
            {
                MessageBox.Show("Заполните поля!!!");
            }
            else
            {
                BD bd = new BD();
                bd.Delete(textBox_id.Text, "Post");
                next();
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_nam.Text == "" || textBox_idd.Text == "" || textBox_tell.Text == "" || textBox_adrecc.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                post z = new post();
                post tek = new post();
                z.Name = textBox_nam.Text;
                z.Tel = textBox_tell.Text;
                z.Adres = textBox_adrecc.Text;

                tek.Id = Convert.ToInt32(textBox_idd.Text);

                try
                {
                    BD bd = new BD();
                    bd.Update_post(tek, z);
                    MessageBox.Show("Успешно!!!");
                    next();
                }
                catch (FormatException)
                { MessageBox.Show("Ошибка!"); }

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox_id.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_idd.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_nam.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_tell.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_adrecc.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void бДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            next();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_FIO.Text == "")
            {
                MessageBox.Show("Заполните поля поиска!!!");
            }
            else
            {

                BD bd = new BD();
                List<post> spisok = new List<post>();
                List<post> spisok1 = new List<post>();
                spisok = bd.Fill_post();
                foreach (post p in spisok)
                {
                    if (p.Name.IndexOf(textBox_FIO.Text) > -1)
                    {
                        spisok1.Add(p);
                    }

                }
                dataGridView1.DataSource = spisok1;

            }
        }
    }
}
