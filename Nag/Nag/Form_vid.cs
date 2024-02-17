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
    public partial class Form_vid : Form
    {
        public Form_vid()
        {
            InitializeComponent();
        }

        private void Form_vid_Load(object sender, EventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 600, 510);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);
            next();
        }
        private void next()
        {
            BD bd = new BD();
            List<vid> spisok = new List<vid>();
            spisok = bd.Fill_vid();
            spisok.Sort(delegate(vid us1, vid us2) { return us1.Name.CompareTo(us2.Name); });
            dataGridView1.DataSource = spisok;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Товар";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                vid z = new vid();
                z.Name = textBox_name.Text;

                BD bd = new BD();
                try
                {

                    bd.Inser_vid(z);
                    MessageBox.Show("Успешно!!!");
                    textBox_name.Text = "";
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
            //textBox_iddd.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_nam.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
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
                bd.Delete(textBox_id.Text, "vid");
                next();
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_nam.Text == "" || textBox_idd.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                vid z = new vid();
                vid tek = new vid();
                z.Name = textBox_nam.Text;
                tek.Id = Convert.ToInt32(textBox_idd.Text);

                try
                {
                    BD bd = new BD();
                    bd.Update_vid(tek, z);
                    MessageBox.Show("Успешно!!!");
                    textBox_name.Text = "";
                    textBox_idd.Text = "";
                    next();
                }
                catch (FormatException)
                { MessageBox.Show("Ошибка!"); }

            }
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
