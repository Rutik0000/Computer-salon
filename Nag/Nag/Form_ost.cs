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
    public partial class Form_ost : Form
    {
        private int id;
        public Form_ost(int Id)
        {
            id = Id;
            InitializeComponent();
        }

        private void Form_ost_Load(object sender, EventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 680, 510);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);

            BD bd = new BD();
            teh p = new teh();
            p = bd.Get_teh_Id(id.ToString());

            textBox_teh.Text = p.Name;
            textBox_tehh.Text = p.Name;

            next();
        }

        private void next()
        {
            BD bd = new BD();
            List<sklad> spisok = new List<sklad>();
            List<sklads> spisok1 = new List<sklads>();
            spisok = bd.Fill_sklad();
            foreach (sklad s in spisok)
            {
                if (s.Id_teh == id)
                {
                    sklads p=new sklads();
                    p.Id = s.Id;
                    p.Teh = bd.Get_teh_Id(s.Id_teh.ToString()).Name;
                    p.Koll = s.Koll;
                    p.Ed_izm = s.Ed_izm;
                    spisok1.Add(p);
                }
            }
            dataGridView1.DataSource = spisok1;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Предмет";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[3].HeaderText = "Единица измерения";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_teh.Text == "" || textBox_ed.Text == "" || textBox_kol.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                sklad z = new sklad();
                BD bd = new BD();
                z.Id_teh = bd.Get_teh_Name(textBox_teh.Text).Id;
                z.Ed_izm = textBox_ed.Text;
                z.Koll = textBox_kol.Text;
                try
                {

                    bd.Inser_sklad(z);

                    MessageBox.Show("Успешно!!!");
                    textBox_ed.Text = "";
                    textBox_teh.Text = "";
                    textBox_kol.Text = "";

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
                bd.Delete(textBox_id.Text, "sklad");
                next();
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_tehh.Text == "" || textBox_edd.Text == "" || textBox_idd.Text == "" || textBox_koll.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                BD bd = new BD();
                sklad z = new sklad();
                sklad tek = new sklad();
                z.Id_teh = bd.Get_teh_Id(textBox_tehh.Text).Id;
                z.Ed_izm = textBox_edd.Text;
                z.Koll = textBox_koll.Text;

                tek.Id = Convert.ToInt32(textBox_idd.Text);

                try
                {

                    bd.Update_sklad(tek, z);
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
            textBox_tehh.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_edd.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_koll.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
