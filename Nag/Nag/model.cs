using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Nag
{
    class zakaz                  //1 model
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        int id_men;

        public int Id_men
        {
            get { return id_men; }
            set { id_men = value; }
        }

        int id_klient;

        public int Id_klient
        {
            get { return id_klient; }
            set { id_klient = value; }
        }

        int id_teh;

        public int Id_teh
        {
            get { return id_teh; }
            set { id_teh = value; }
        }
      
        string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
      
        string zena;

        public string Zena
        {
            get { return zena; }
            set { zena = value; }
        }

        int kol;

        public int Kol
        {
            get { return kol; }
            set { kol = value; }
        }
    }

    class zakazs                  //1 model
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string men;

        public string Men
        {
            get { return men; }
            set { men = value; }
        }


        string klient;

        public string Klient
        {
            get { return klient; }
            set { klient = value; }
        }

        string teh;

        public string Teh
        {
            get { return teh; }
            set { teh = value; }
        }

        string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        string zena;

        public string Zena
        {
            get { return zena; }
            set { zena = value; }
        }

        int kol;

        public int Kol
        {
            get { return kol; }
            set { kol = value; }
        }

    }

    

    class teh                     //4 model
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        int id_post;

        public int Id_post
        {
            get { return id_post; }
            set { id_post = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

       private string god;

        public string God
        {
            get { return god; }
            set { god = value; }
        }

       
    }

    class tehs                     //4 model
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string post;

        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private string god;

        public string God
        {
            get { return god; }
            set { god = value; }
        }

       
    }


    class men            //2 model
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

         string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

         string  tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        string adres;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

    }

     class klient            //3 model
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        string adres;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

    }

    class inf
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string name_klient;

        public string Name_klient
        {
            get { return name_klient; }
            set { name_klient = value; }
        }

        string tel_klient;

        public string Tel_klient
        {
            get { return tel_klient; }
            set {tel_klient = value; }
        }

        string name_men;

        public string Name_Men
        {
            get { return name_men; }
            set { name_men = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name= value; }
        }

        private string avtor;

        public string Avtor
        {
            get { return avtor; }
            set { avtor = value; }
        }

        private string god;

        public string God
        {
            get { return god; }
            set { god = value; }
        }
      
        string data;

        public string Data
        {
            get { return data; }
            set { data= value; }
        }

        string zena;

        public string Zena
        {
            get { return zena; }
            set { zena = value; }
        }

        int kol;

        public int Kol
        {
            get { return kol; }
            set { kol = value; }
        }

       }

    class post
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        string adres;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

    }

    internal class vid //6 model
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    class sklads                     //13 model
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string teh;

        public string Teh
        {
            get { return teh; }
            set { teh = value; }
        }

        private string koll;

        public string Koll
        {
            get { return koll; }
            set { koll = value; }
        }

        private string ed_izm;

        public string Ed_izm
        {
            get { return ed_izm; }
            set { ed_izm = value; }
        }
    }

    class sklad                   //13 model
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        int id_teh;

        public int Id_teh
        {
            get { return id_teh; }
            set { id_teh = value; }
        }

        private string koll;

        public string Koll
        {
            get { return koll; }
            set { koll = value; }
        }

        private string ed_izm;

        public string Ed_izm
        {
            get { return ed_izm; }
            set { ed_izm = value; }
        }
    }

    class tranzak           //6 model
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        int id_zakaz;

        public int Id_zakaz
        {
            get { return id_zakaz; }
            set { id_zakaz = value; }
        }

        int id_vid;

        public int Id_vid
        {
            get { return id_vid; }
            set { id_vid = value; }
        }

        string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        string shet;

        public string Shet
        {
            get { return shet; }
            set { shet = value; }
        }

        int summa;

        public int Summa
        {
            get { return summa; }
            set { summa = value; }
        }

    }

    class tranzaks           //6 model
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        int zakaz;

        public int Zakaz
        {
            get { return zakaz; }
            set { zakaz = value; }
        }

        string vid;

        public string Vid
        {
            get { return vid; }
            set { vid = value; }
        }

        string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        string shet;

        public string Shet
        {
            get { return shet; }
            set { shet = value; }
        }

        int summa;

        public int Summa
        {
            get { return summa; }
            set { summa = value; }
        }

    }





}
