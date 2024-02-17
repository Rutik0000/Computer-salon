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
    public partial class Form_ot3 : Form
    {
        public Form_ot3()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_ot1_Load(object sender, EventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, 900, 500);
            gPath.AddRectangle(rect);
            this.Region = new Region(gPath);
            klient_sp();
        }

        private void klient_sp()
        {
           BD bd = new BD();
            List<teh> spisok = new List<teh>();
            spisok = bd.Fill_teh();

            foreach (teh kot in spisok)
            {
                comboBox1.Items.Add(kot.Name);
            }
            
        }
        private void ot1()
        {
            BD bd = new BD();
            List<zakaz> spisok = new List<zakaz>();
            List<inf> rez = new List<inf>();

            teh im = new teh();
            im = bd.Get_teh_Name(comboBox1.Text);

            spisok = bd.Fill_zakaz_id_teh(im.Id.ToString());

            int i = 0;
            foreach (zakaz m in spisok)
            {
                inf p = new inf();

                i++;
                p.Id = i;

                klient kl = new klient();
                kl = bd.Get_klient_id(m.Id_klient.ToString());
                p.Name_klient = kl.Name;
                p.Tel_klient = kl.Tel;

                men pr = new men();
                pr = bd.Get_men_id(m.Id_men.ToString());
                p.Name_Men = pr.Name;

                teh v = new teh();
                v = bd.Get_teh_Id(m.Id_teh.ToString());
                p.Name = v.Name;
                p.Avtor = v.Opis;
                p.God = v.God;



                p.Data = m.Data;
                p.Zena = m.Zena;
                p.Kol = m.Kol;

                rez.Add(p);

            }

            dataGridView1.DataSource = rez;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Имя клиента";
            dataGridView1.Columns[2].HeaderText = "Телефон клиента";
            dataGridView1.Columns[3].HeaderText = "Имя менеджера";
            dataGridView1.Columns[4].HeaderText = "Техника";
            dataGridView1.Columns[5].HeaderText = "Страна производитель";

            dataGridView1.Columns[6].HeaderText = "Год";
            dataGridView1.Columns[7].HeaderText = "Дата";
            dataGridView1.Columns[8].HeaderText = "Цена(руб)";
            dataGridView1.Columns[9].HeaderText = "Количество";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Заполните поля поиска!!!");
            }
            else
            {
                ot1();
            }
        }




    }
}
