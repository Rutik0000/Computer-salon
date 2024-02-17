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
    public partial class Form_zakaz : Form
    {
        private int id = 0;
        public Form_zakaz(int Id)
        {
            id = Id;
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_nag_Load(object sender, EventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 900, 600);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);
            
            next();
            men_sp();
            teh_sp();
           

        }

        private void next()
        {
            BD bd = new BD();
            List<zakaz> spisok = new List<zakaz>();
            List<zakazs> spisok1 = new List<zakazs>();
            spisok = bd.Fill_zakaz();
            foreach (zakaz z in spisok)
            {
                if (z.Id_klient == id)
                {
                    zakazs p = new zakazs();
                    p.Id = z.Id;
                    p.Men = bd.Get_men_id(z.Id_men.ToString()).Name;
                    p.Klient = bd.Get_klient_id(z.Id_klient.ToString()).Name;
                    p.Teh = bd.Get_teh_Id(z.Id_teh.ToString()).Name;
                    p.Data = z.Data;
                    p.Zena = z.Zena;
                    p.Kol = z.Kol;
                    spisok1.Add(p);
                }

            }


            dataGridView1.DataSource = spisok1;

            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[2].HeaderText = "Клиент";
            dataGridView1.Columns[1].HeaderText = "Менеджера";
            dataGridView1.Columns[3].HeaderText = "Техника";
            dataGridView1.Columns[4].HeaderText = "Дата";
            dataGridView1.Columns[5].HeaderText = "Цена(руб)";
            dataGridView1.Columns[6].HeaderText = "Количество(шт)";

        }

        private void men_sp()
        {
            comboBox_men.Items.Clear();
            comboBox_menn.Items.Clear();
            BD bd = new BD();
            List<men> spisok = new List<men>();
            spisok = bd.Fill_men();

            foreach (men kot in spisok)
            {
                comboBox_men.Items.Add(kot.Name);
                comboBox_menn.Items.Add(kot.Name);
            }

        }

        private void teh_sp()
        {
            comboBox_teh.Items.Clear();
            comboBox_tehh.Items.Clear();
            BD bd = new BD();
            List<teh> spisok = new List<teh>();
            spisok = bd.Fill_teh();

            foreach (teh kot in spisok)
            {
                comboBox_teh.Items.Add(kot.Name);
                comboBox_tehh.Items.Add(kot.Name);
            }

        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            if ( comboBox_men.Text == "" || comboBox_teh.Text == "" || textBox_kol.Text == "" || textBox_zenaa.Text == "" )
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                BD bd = new BD();

                zakaz z = new zakaz();

                z.Id_men = bd.Get_men_name(comboBox_men.Text).Id;
                z.Id_klient =id;
                z.Id_teh = bd.Get_teh_Name(comboBox_teh.Text).Id;

                z.Data = String.Format(dateTimePicker.Value.ToShortDateString());
                z.Zena = textBox_zenaa.Text;
                z.Kol = Convert.ToInt32(textBox_kol.Text);
              
              
                try
                {
                    bd.Inser_zakaz(z);
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
                bd.Delete(textBox_id.Text, "zakaz");
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

                if (radioButton1.Checked == true)
                {

                    BD bd = new BD();
                    men spisok= new men();
                    spisok = bd.Get_men_name(textBox_FIO.Text);

                    List<zakaz> sp = new List<zakaz>();

                    sp = bd.Fill_zakaz_idmen(spisok.Id.ToString());

                    List<zakazs> spisok1 = new List<zakazs>();
                
                    foreach (zakaz z in sp)
                    {
                        if (z.Id_klient == id)
                        {
                            zakazs p = new zakazs();
                            p.Id = z.Id;
                            p.Men = bd.Get_men_id(z.Id_men.ToString()).Name;
                            p.Klient = bd.Get_klient_id(z.Id_klient.ToString()).Name;
                            p.Teh = bd.Get_teh_Id(z.Id_teh.ToString()).Name;
                            p.Data = z.Data;
                            p.Zena = z.Zena;
                            p.Kol = z.Kol;
                            spisok1.Add(p);
                        }

                    }

                    dataGridView1.DataSource = spisok1;
                }
               

                if (radioButton3.Checked == true)
                {

                    BD bd = new BD();
                    teh spisok = new teh();
                    spisok = bd.Get_teh_Name(textBox_FIO.Text);

                    List<zakaz> sp = new List<zakaz>();

                    sp = bd.Fill_zakaz_id_teh(spisok.Id.ToString());

                    List<zakazs> spisok1 = new List<zakazs>();

                    foreach (zakaz z in sp)
                    {
                        if (z.Id_klient == id)
                        {
                            zakazs p = new zakazs();
                            p.Id = z.Id;
                            p.Men = bd.Get_men_id(z.Id_men.ToString()).Name;
                            p.Klient = bd.Get_klient_id(z.Id_klient.ToString()).Name;
                            p.Teh = bd.Get_teh_Id(z.Id_teh.ToString()).Name;
                            p.Data = z.Data;
                            p.Zena = z.Zena;
                            p.Kol = z.Kol;
                            spisok1.Add(p);
                        }

                    }

                    dataGridView1.DataSource = spisok1;
                }

              
                if (radioButton4.Checked == true)
                {

                    BD bd = new BD();

                    List<zakaz> sp = new List<zakaz>();

                    sp = bd.Fill_zakaz_idklient(id.ToString());

                    List<zakazs> spisok1 = new List<zakazs>();

                    foreach (zakaz z in sp)
                    {
                        
                            if (z.Data.IndexOf(textBox_FIO.Text) > -1)
                            {
                                zakazs p = new zakazs();
                                p.Id = z.Id;
                                p.Men = bd.Get_men_id(z.Id_men.ToString()).Name;
                                p.Klient = bd.Get_klient_id(z.Id_klient.ToString()).Name;
                                p.Teh = bd.Get_teh_Id(z.Id_teh.ToString()).Name;
                                p.Data = z.Data;
                                p.Zena = z.Zena;
                                p.Kol = z.Kol;
                                spisok1.Add(p);
                            }


                    }

                    dataGridView1.DataSource = spisok1;

                }

              
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox_id.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_idd.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_iddd.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
           
      
            textBox_dataaa.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_zenaaa.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox_koll.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
            comboBox_menn.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            comboBox_tehh.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_koll.Text=="" || textBox_idd.Text == "" || comboBox_tehh.Text == "" ||  comboBox_menn.Text == "" || textBox_dataaa.Text == ""  || textBox_zenaaa.Text == "")
            {
                MessageBox.Show("Заполните поля данных!!!");
            }
            else
            {
                BD bd = new BD();

                zakaz z = new zakaz();
                zakaz tek = new zakaz();

                z.Id_men = bd.Get_men_name(comboBox_menn.Text).Id;
                z.Id_klient = id;
                z.Id_teh = bd.Get_teh_Name(comboBox_tehh.Text).Id;

                z.Data = textBox_dataaa.Text;
                z.Zena = textBox_zenaaa.Text;
                z.Kol = Convert.ToInt32(textBox_koll.Text);
              
               
                tek.Id = Convert.ToInt32(textBox_idd.Text);

                try
                {
                    bd.Update_zakaz(tek, z);
                    next();
                    MessageBox.Show("Успешно!"); 
                }
                catch (FormatException)
                { MessageBox.Show("Ошибка!"); }

            }
             
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void бДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            next();
        }
       

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox_dataaa.Text = monthCalendar1.SelectionStart.ToShortDateString(); //получить дату
        }

        private void менеджерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_men inf = new Form_men();
            this.Hide();
            inf.ShowDialog();
            this.Show();
            comboBox_men.Items.Clear();
            comboBox_menn.Items.Clear();
            men_sp();
        }

        private void техникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_teh inf = new Form_teh();
            this.Hide();
            inf.ShowDialog();
            this.Show();
            comboBox_teh.Items.Clear();
            comboBox_tehh.Items.Clear();
            teh_sp();
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
                Form_tranzak inf = new Form_tranzak(kt);
                this.Hide();
                inf.ShowDialog();
                this.Show();
                //next();
            }
        }

      

     

    }
}
