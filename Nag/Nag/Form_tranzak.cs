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
    public partial class Form_tranzak : Form
    {
        private int id = 0;
        public Form_tranzak(int Id)
        {
            id = Id;
            InitializeComponent();
        }

        private void Form_tranzak_Load(object sender, EventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 900, 650);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);

            next();
            vid_sp();
        }


        private void next()
        {
            BD bd = new BD();
            List<tranzak> spisok = new List<tranzak>();
            List<tranzaks> spisok1 = new List<tranzaks>();
            spisok = bd.Fill_tranzak();
            foreach (tranzak z in spisok)
            {

                if (z.Id_zakaz == id)
                {
                    tranzaks t=new tranzaks();
                    t.Id = z.Id;
                    t.Zakaz = z.Id_zakaz;
                    t.Vid = bd.Get_vid_Id(z.Id_vid.ToString()).Name;
                    t.Data = z.Data;
                    t.Shet = z.Shet;
                    t.Summa = z.Summa;
                    spisok1.Add(t);
                }

            }
            
            dataGridView1.DataSource = spisok1;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Номер заказа";
            dataGridView1.Columns[2].HeaderText = "Вид оплаты";
            dataGridView1.Columns[3].HeaderText = "Дата";
            dataGridView1.Columns[4].HeaderText = "Счет";
            dataGridView1.Columns[5].HeaderText = "Сумма(Руб)";
        }

        private void vid_sp()
        {
            comboBox_vid.Items.Clear();
            comboBox_vidd.Items.Clear();
            BD bd = new BD();
            List<vid> spisok = new List<vid>();
            spisok = bd.Fill_vid();

            foreach (vid kot in spisok)
            {
             
                    comboBox_vid.Items.Add(kot.Name);
                    comboBox_vidd.Items.Add(kot.Name);
                    comboBox_vid.Text = kot.Name.ToString();
                    comboBox_vidd.Text = kot.Name.ToString();
              
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox_vid.Text == "" ||  textBox_shett.Text == "" || textBox_summa.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                BD bd = new BD();

                tranzak z = new tranzak();
                z.Id_zakaz = id;
                z.Id_vid = bd.Get_vid_Name(comboBox_vid.Text).Id;
                z.Summa = Convert.ToInt32(textBox_summa.Text);
                z.Data = String.Format(dateTimePicker.Value.ToShortDateString()); ;
                z.Shet = textBox_shett.Text;

                try
                {
                    bd.Inser_tranzak(z);
                    
                    next();

                    MessageBox.Show("Успешно!!!");
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
                bd.Delete(textBox_id.Text, "tranzak");
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
                List<tranzak> spisok = new List<tranzak>();
                List<tranzaks> spisok1 = new List<tranzaks>();
                spisok = bd.Fill_tranzak();
                foreach (tranzak z in spisok)
                {
                    if ((z.Data.IndexOf(textBox_FIO.Text) > -1)&&(z.Id_zakaz==id))
                    {
                        tranzaks t = new tranzaks();
                        t.Id = z.Id;
                        t.Zakaz = z.Id_zakaz;
                        t.Vid = bd.Get_vid_Id(z.Id_vid.ToString()).Name;
                        t.Data = z.Data;
                        t.Shet = z.Shet;
                        t.Summa = z.Summa;
                        spisok1.Add(t);
                       
                    }

                }
                dataGridView1.DataSource = spisok1;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox_id.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_idd.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            BD bd = new BD();

            textBox_shettt.Text = (dataGridView1[4, dataGridView1.CurrentRow.Index]).Value.ToString();
            textBox_dataaa.Text = (dataGridView1[3, dataGridView1.CurrentRow.Index]).Value.ToString();
            textBox_summaa.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            comboBox_vidd.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_idd.Text == "" || textBox_summaa.Text == "" || textBox_dataaa.Text == "" || textBox_shettt.Text == "" || textBox_summaa.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                BD bd = new BD();

                tranzak z = new tranzak();
                tranzak tek = new tranzak();
                z.Id_zakaz = id;
                z.Id_vid = bd.Get_vid_Name(comboBox_vidd.Text).Id;
                z.Summa = Convert.ToInt32(textBox_summaa.Text);
                z.Data = textBox_dataaa.Text;
                z.Shet = textBox_shettt.Text;
                tek.Id = Convert.ToInt32(textBox_idd.Text);


            

                try
                {

                    bd.Update_tranzak(tek, z);
                    next();

                    MessageBox.Show("Успешно!");
                }
                catch (FormatException)
                { MessageBox.Show("Ошибка!"); }

            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void бДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            next();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox_dataaa.Text = monthCalendar1.SelectionStart.ToShortDateString(); //получить дату
        }

        private void видОплатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_vid inf = new Form_vid();
            this.Hide();
            inf.ShowDialog();
            this.Show();
            vid_sp();
        }
    }
}
