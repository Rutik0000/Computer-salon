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
    public partial class Form_klient : Form
    {
       

        public Form_klient()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_klient_Load(object sender, EventArgs e)
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
            List<klient> spisok = new List<klient>();
            spisok = bd.Fill_klient();
            spisok.Sort(delegate(klient us1, klient us2) { return us1.Name.CompareTo(us2.Name); });
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
                klient z = new klient();
                z.Name = textBox_name.Text;
                z.Tel = textBox_tel.Text;
                z.Adres = textBox_adres.Text;
               
                BD bd = new BD();
                try
                {

                    bd.Inser_klient(z);

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
                bd.Delete(textBox_id.Text, "Klient");
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
                List<klient> spisok = new List<klient>();
                List<klient> spisok1 = new List<klient>();
                spisok = bd.Fill_klient();
                foreach (klient p in spisok)
                {
                    if (p.Name.IndexOf(textBox_FIO.Text) > -1)
                    {
                        spisok1.Add(p);
                    }

                }
                dataGridView1.DataSource = spisok1;

            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_namee.Text == "" || textBox_tell.Text == "" || textBox_idd.Text == "" || textBox_adrecc.Text == "" )
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                klient z = new klient();
                klient tek = new klient();

                z.Name = textBox_namee.Text;
                z.Tel = textBox_tell.Text;
                z.Adres = textBox_adrecc.Text;
               

                tek.Id = Convert.ToInt32(textBox_idd.Text);
                
                try
                {
                    BD bd = new BD();
                    bd.Update_klient(tek, z);
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
            textBox_iddd.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_namee.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_tell.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_adrecc.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox_iddd.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                int kt = Convert.ToInt32(textBox_iddd.Text);
                Form_zakaz inf = new Form_zakaz(kt);
                this.Hide();
                inf.ShowDialog();
                this.Show();
                //next();
            }
        }

        private void техникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_teh inf = new Form_teh();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поПреподавателюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ot1 inf = new Form_ot1();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }

        private void поПредметуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ot2 inf = new Form_ot2();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }

        private void поГруппеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ot3 inf = new Form_ot3();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }

        private void поДатеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ot5 inf = new Form_ot5();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }

        private void поНазваниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ot4 inf = new Form_ot4();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }

        private void поТипуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ot6 inf = new Form_ot6();
            this.Hide();
            inf.ShowDialog();
            this.Show();
        }
    }
}
