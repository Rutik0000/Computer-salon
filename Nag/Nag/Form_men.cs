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
    public partial class Form_men : Form
    {
        public Form_men()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_teacher_Load(object sender, EventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 680, 510);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);
            next();
        }

        private void next()
        {
            BD bd = new BD();
            List<men> spisok = new List<men>();
            spisok = bd.Fill_men();
            spisok.Sort(delegate(men us1, men us2) { return us1.Name.CompareTo(us2.Name); });
            dataGridView1.DataSource = spisok;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Телефон";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            
        }

        private void бДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            next();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text == "" || textBox_tel.Text == "" || textBox_adres.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                men z = new men();
                z.Name = textBox_name.Text;
                z.Tel = textBox_tel.Text;
                z.Adres = textBox_adres.Text;
                
                BD bd = new BD();
                try
                {

                    bd.Inser_men(z);

                   MessageBox.Show("Успешно!!!");
                    textBox_tel.Text = "";
                    textBox_name.Text = "";
                    textBox_adres.Text = "";
                    
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
                bd.Delete(textBox_id.Text, "Men");
                next();
            }
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
                List<men> spisok = new List<men>();
                List<men> spisok1 = new List<men>();
                spisok = bd.Fill_men();
                foreach (men m in spisok)
                {
                    if (m.Name.IndexOf(textBox_FIO.Text) > -1)
                    {
                        spisok1.Add(m);
                    }

                }
              
                dataGridView1.DataSource = spisok1;

            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_namee.Text == "" || textBox_tell.Text == "" || textBox_idd.Text == "" || textBox_adrecc.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                men z = new men();
                men tek = new men();

                z.Name = textBox_namee.Text;
                z.Tel = textBox_tell.Text;
                z.Adres =textBox_adrecc.Text;
                

                tek.Id = Convert.ToInt32(textBox_idd.Text);
                
                try
                {
                    BD bd = new BD();
                    bd.Update_men(tek, z);
                    MessageBox.Show("Успешно!!!");
                    textBox_tell.Text = "";
                    textBox_namee.Text = "";
                    textBox_adrecc.Text = "";
                    
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
            textBox_namee.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_tell.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_adrecc.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
           
        }
    }
}
