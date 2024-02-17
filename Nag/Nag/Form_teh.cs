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
    public partial class Form_teh : Form
    {
        public Form_teh()
        {
            InitializeComponent();
        }

        private void Form_god_Load(object sender, EventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 800, 530);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);
            next();
            spisok();
        }

        private void spisok()
        {
            comboBox_post.Items.Clear();
            comboBox_postt.Items.Clear();

            BD bd = new BD();
            List<post> spisok = new List<post>();
            spisok = bd.Fill_post();

            foreach (post kot in spisok)
            {
                comboBox_post.Items.Add(kot.Name);
                comboBox_postt.Items.Add(kot.Name);
            }

        }

        private void next()
        {
            BD bd = new BD();
            List<teh> spisok = new List<teh>();
            List<tehs> spisok1 = new List<tehs>();
            spisok = bd.Fill_teh();
            foreach (teh t in spisok)
            {
                tehs p=new tehs();
                p.Id = t.Id;
                p.Post = bd.Get_post_Id(t.Id_post.ToString()).Name;
                p.Name = t.Name;
                p.God = t.God;
                p.Opis = t.Opis;
                
                spisok1.Add(p);
            }
            spisok1.Sort(delegate(tehs us1, tehs us2) { return us1.Name.CompareTo(us2.Name); });
            dataGridView1.DataSource = spisok1;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[2].HeaderText = "Название";
            dataGridView1.Columns[3].HeaderText = "Описание";
            dataGridView1.Columns[1].HeaderText = "Поставщик";
            dataGridView1.Columns[4].HeaderText = "Год";
           
           }
        

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text == "" || textBox_opis.Text == "" || comboBox_post.Text == "" || textBox_god.Text == "" )
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {

                BD bd = new BD();

                teh z = new teh();
                z.Name = textBox_name.Text;
                z.Opis = textBox_opis.Text;
                z.Id_post = bd.Get_post_name(comboBox_post.Text).Id;
                z.God = textBox_god.Text;
            
                try
                {

                    bd.Inser_teh(z);
                    MessageBox.Show("Успешно!!!");
                    next();

                }
                catch (FormatException)
                { MessageBox.Show("Ошибка!"); }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           BD bd = new BD();

            textBox_id.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_idd.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_iddd.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            textBox_namee.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
           
            comboBox_postt.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_opiss.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
           
            textBox_godd.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
           

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
                bd.Delete(textBox_id.Text, "teh");
                next();
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_namee.Text == "" || textBox_opiss.Text == "" || comboBox_postt.Text == "" || textBox_godd.Text == "" )
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {  BD bd = new BD();
                teh z = new teh();
                teh tek = new teh();
                
                tek.Id = Convert.ToInt32(textBox_idd.Text);

                z.Name = textBox_namee.Text;
                z.Opis = textBox_opiss.Text;
                z.Id_post = bd.Get_post_name(comboBox_postt.Text).Id;
                z.God = textBox_godd.Text;
              
              
                try
                {
                  
                    bd.Update_teh(tek, z);
                    MessageBox.Show("Успешно!!!");
                  
                    next();
                }
                catch (FormatException)
                { MessageBox.Show("Ошибка!"); }

            }
        }

        private void бДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            next();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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
                if (radioButton1.Checked == true)
                {

                   

                    List<teh> spisok = new List<teh>();
                    List<tehs> spisok1 = new List<tehs>();
                    spisok = bd.Fill_teh();
                    foreach (teh t in spisok)
                    {
                        if (t.Name.IndexOf(textBox_FIO.Text) > -1)
                        {
                            tehs p = new tehs();
                            p.Id = t.Id;
                            p.Post = bd.Get_post_Id(t.Id_post.ToString()).Name;
                            p.Name = t.Name;
                            p.God = t.God;
                            p.Opis = t.Opis;
                           
                            spisok1.Add(p);
                        }
                    }
                    spisok1.Sort(delegate(tehs us1, tehs us2) { return us1.Name.CompareTo(us2.Name); });
                    dataGridView1.DataSource = spisok1;
                }


              

                if (radioButton3.Checked == true)
                {

                    List<teh> sp = new List<teh>();

                    sp = bd.Fill_teh_god(textBox_FIO.Text);

                    dataGridView1.DataSource = sp;
                }

               


            }
        }

        private void издательствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_post inf = new Form_post();
            this.Hide();
            inf.ShowDialog();
            this.Show(); 
            spisok();
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
                Form_ost inf = new Form_ost(kt);
                this.Hide();
                inf.ShowDialog();
                this.Show();
                //next();
            }
        }
    }
}
