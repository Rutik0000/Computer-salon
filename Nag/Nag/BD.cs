using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nag
{
    internal class BD
    {
        private SqlConnection connection;

        private SqlCommand command;

        private void ConnectTo()
        {
            string sp = "Data Source=loculhost;Initial Catalog=tehnika;Integrated Security=true;";
            connection = new SqlConnection(sp);
            command = connection.CreateCommand();
        }

        public BD()
        {
            ConnectTo();
        }

        public void Delete(string Id, string tab)                                  //Удаление!!!!!!!!!!!!!!!!!!!!
        {
            try
            {
                command.CommandText = "DELETE FROM " + tab + " WHERE ID= " + Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

                                                                                               //teh
        public void Inser_teh(teh zad)
        {
            try
            {
                command.CommandText = "INSERT INTO Teh (Name,Opis,Id_post,God) VALUES('" + zad.Name + "', '" + zad.Opis + "', '" + zad.Id_post + "', '" + zad.God + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public void Update_teh(teh st, teh now)
        {
            try
            {
                command.CommandText = "UPDATE Teh SET Name = '" + now.Name + "',Opis= '" + now.Opis + "',Id_post= '" + now.Id_post + "',God= '" + now.God + "' WHERE ID =" + st.Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }



        public List<teh> Fill_teh()
        {
            List<teh> spisok = new List<teh>();

            try
            {
                command.CommandText = "SELECT * FROM  Teh";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teh zad = new teh();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Opis = reader["Opis"].ToString();
                    zad.Id_post = Convert.ToInt32(reader["Id_post"].ToString());
                    zad.God = reader["God"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

    
        public teh Get_teh_Id(String tab)
        {
             teh zad = new teh();

            try
            {

                command.CommandText = "SELECT * FROM Teh WHERE Id = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Opis = reader["Opis"].ToString();
                    zad.Id_post = Convert.ToInt32(reader["Id_post"].ToString());
                    zad.God = reader["God"].ToString();
                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public teh Get_teh_Name(String tab)
        {
            teh zad = new teh();

            try
            {

                command.CommandText = "SELECT * FROM Teh WHERE Name = '" + tab + "'";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Opis = reader["Opis"].ToString();
                    zad.Id_post = Convert.ToInt32(reader["Id_post"].ToString());
                    zad.God = reader["God"].ToString();

                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


      

        public List<teh> Fill_teh_god(String tab)
        {
            List<teh> spisok = new List<teh>();

            try
            {

                command.CommandText = "SELECT * FROM Teh WHERE God = '" + tab + "'";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teh zad = new teh();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Opis = reader["Opis"].ToString();
                    zad.Id_post = Convert.ToInt32(reader["Id_post"].ToString());
                    zad.God = reader["God"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public List<teh> Fill_teh_id_post(String tab)
        {
            List<teh> spisok = new List<teh>();

            try
            {

                command.CommandText = "SELECT * FROM Teh WHERE Id_post = " + tab ;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teh zad = new teh();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Opis = reader["Opis"].ToString();
                    zad.Id_post = Convert.ToInt32(reader["Id_post"].ToString());
                    zad.God = reader["God"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


                                                          
                                                                                                  // Men

        public void Inser_men(men zad)
        {
            try
            {
                command.CommandText = "INSERT INTO Men (Name,Tel,Adres) VALUES('" + zad.Name + "', '" + zad.Tel + "', '" + zad.Adres + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public List<men> Fill_men()
        {
            List<men> spisok = new List<men>();

            try
            {
                command.CommandText = "SELECT * FROM  Men";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    men zad = new men();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel =reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        public men Get_men_name(String id)
        {

            men zad = new men();

            try
            {

                command.CommandText = "SELECT * FROM Men WHERE Name = '" + id + "'";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel = reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();
                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public void Update_men(men st, men now)
        {
            try
            {
                command.CommandText = "UPDATE Men SET Name = '" + now.Name + "',Tel ='" + now.Tel + "',Adres ='" + now.Adres + "' WHERE ID =" + st.Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public men Get_men_id(String id)
        {

            men zad = new men();

            try
            {

                command.CommandText = "SELECT * FROM Men WHERE Id = " + id;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel = reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();

                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }



                                                                               //Klient

        public void Inser_klient(klient zad)
        {
            try
            {
                command.CommandText = "INSERT INTO Klient (Name,Tel,Adres) VALUES('" + zad.Name + "', '" + zad.Tel + "', '" + zad.Adres + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }

        public List<klient> Fill_klient()
        {
            List<klient> spisok = new List<klient>();

            try
            {
                command.CommandText = "SELECT * FROM  Klient";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    klient zad = new klient();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel = reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        public klient Get_klient_name(String id)
        {

            klient zad = new klient();

            try
            {

                command.CommandText = "SELECT * FROM Klient WHERE Name = '" + id + "'";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel = reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();
                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }
        
        public void Update_klient(klient st, klient now)
        {
            try
            {
                command.CommandText = "UPDATE Klient SET Name = '" + now.Name + "',Tel ='" + now.Tel + "',Adres ='" + now.Adres + "' WHERE ID =" + st.Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public klient Get_klient_id(String id)
        {

            klient zad = new klient();

            try
            {

                command.CommandText = "SELECT * FROM Klient WHERE Id = " + id;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel = reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();

                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }
                                                                                                            

                                                                       //zakaz
        public void Inser_zakaz(zakaz zad)
        {
            int k = 0;
            try
            {
                command.CommandText = "INSERT INTO zakaz (Id_men,Id_klient,Id_teh,Data,Zena,Kol) VALUES('" + zad.Id_men + "', '" + zad.Id_klient + "', '" + zad.Id_teh + "', '" + zad.Data + "', '" + zad.Zena + "', '" + zad.Kol + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public void Update_zakaz(zakaz st,zakaz now)
        {
            try
            {
                command.CommandText = "UPDATE zakaz SET Id_men = '" + now.Id_men + "',Id_klient ='" + now.Id_klient + "',Id_teh ='" + now.Id_teh + "',Data='" + now.Data + "',Zena ='" + now.Zena + "',Kol ='" + now.Kol + "' WHERE ID =" + st.Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public List<zakaz> Fill_zakaz()
        {
            List<zakaz> spisok = new List<zakaz>();

            try
            {
                command.CommandText = "SELECT * FROM  zakaz";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    zakaz zad = new zakaz();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_men = Convert.ToInt32(reader["Id_men"].ToString());
                    zad.Id_klient = Convert.ToInt32(reader["Id_klient"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Data= reader["Data"].ToString();
                    zad.Zena= reader["Zena"].ToString();
                    zad.Kol = Convert.ToInt32(reader["Kol"].ToString());
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        public List<zakaz> Fill_zakaz_idmen(String tab)
        {
            List<zakaz> spisok = new List<zakaz>();

            try
            {

                command.CommandText = "SELECT * FROM zakaz WHERE Id_men = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   zakaz zad = new zakaz();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_men = Convert.ToInt32(reader["Id_men"].ToString());
                    zad.Id_klient = Convert.ToInt32(reader["Id_klient"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Data = reader["Data"].ToString();
                    zad.Zena = reader["Zena"].ToString();
                    zad.Kol = Convert.ToInt32(reader["Kol"].ToString());
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public List<zakaz> Fill_zakaz_idklient(String tab)
        {
            List<zakaz> spisok = new List<zakaz>();

            try
            {

                command.CommandText = "SELECT * FROM zakaz WHERE Id_klient = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    zakaz zad = new zakaz();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_men = Convert.ToInt32(reader["Id_men"].ToString());
                    zad.Id_klient = Convert.ToInt32(reader["Id_klient"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Data = reader["Data"].ToString();
                    zad.Zena = reader["Zena"].ToString();
                    zad.Kol = Convert.ToInt32(reader["Kol"].ToString());
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public List<zakaz> Fill_zakaz_id_teh(String tab)
        {
            List<zakaz> spisok = new List<zakaz>();

            try
            {

                command.CommandText = "SELECT * FROM zakaz WHERE Id_teh = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    zakaz zad = new zakaz();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_men = Convert.ToInt32(reader["Id_men"].ToString());
                    zad.Id_klient = Convert.ToInt32(reader["Id_klient"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Data = reader["Data"].ToString();
                    zad.Zena = reader["Zena"].ToString();
                    zad.Kol = Convert.ToInt32(reader["Kol"].ToString());
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


        public zakaz Get_zakaz_Id(String tab)
        {
            zakaz zad = new zakaz();

            try
            {

                command.CommandText = "SELECT * FROM zakaz WHERE Id = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_men = Convert.ToInt32(reader["Id_men"].ToString());
                    zad.Id_klient = Convert.ToInt32(reader["Id_klient"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Data = reader["Data"].ToString();
                    zad.Zena = reader["Zena"].ToString();
                    zad.Kol = Convert.ToInt32(reader["Kol"].ToString());
                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public List<zakaz> Fill_zakaz_data(String tab)
        {
            List<zakaz> spisok = new List<zakaz>();

            try
            {

                command.CommandText = "SELECT * FROM zakaz WHERE Data = '" + tab+"'";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    zakaz zad = new zakaz();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_men = Convert.ToInt32(reader["Id_men"].ToString());
                    zad.Id_klient = Convert.ToInt32(reader["Id_klient"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Data= reader["Data"].ToString();
                    zad.Zena= reader["Zena"].ToString();
                    zad.Kol = Convert.ToInt32(reader["Kol"].ToString());
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


                                                                //post
        public void Inser_post(post zad)
        {
            try
            {
                command.CommandText = "INSERT INTO Post (Name,Tel,Adres) VALUES('" + zad.Name + "', '" + zad.Tel + "', '" + zad.Adres + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public void Update_post(post st, post now)
        {
            try
            {
                command.CommandText = "UPDATE Post SET Name = '" + now.Name + "',Tel ='" + now.Tel+ "',Adres ='" + now.Adres+ "' WHERE ID =" + st.Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }

        public List<post> Fill_post()
        {
            List<post> spisok = new List<post>();

            try
            {
                command.CommandText = "SELECT * FROM  Post";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    post zad = new post();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel = reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        } 
        
        public post Get_post_Id(String tab)
        {
            post zad = new post();

            try
            {

                command.CommandText = "SELECT * FROM Post WHERE Id = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel = reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();
                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public post Get_post_name(String tab)
        {
            post zad = new post();

            try
            {

                command.CommandText = "SELECT * FROM Post WHERE Name = '" + tab+"'";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    zad.Tel = reader["Tel"].ToString();
                    zad.Adres = reader["Adres"].ToString();
                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


        //vid

        public void Inser_vid(vid zad)//Добавления вида 
        {
            try
            {
                command.CommandText = "INSERT INTO vid (Name) VALUES('" + zad.Name + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public void Update_vid(vid st, vid now)//обновления вида
        {
            try
            {
                command.CommandText = "UPDATE vid SET Name = '" + now.Name + "' WHERE ID =" + st.Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public List<vid> Fill_vid()//Получения всех видов
        {
            List<vid> spisok = new List<vid>();

            try
            {
                command.CommandText = "SELECT * FROM  vid";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    vid zad = new vid();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    

        public vid Get_vid_Id(String tab)//Получение вида по уникальному номеру
        {
            vid zad = new vid();

            try
            {

                command.CommandText = "SELECT * FROM vid WHERE Id = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();
                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public vid Get_vid_Name(String tab)//Получения вида по имени
        {
            vid zad = new vid();

            try
            {

                command.CommandText = "SELECT * FROM vid WHERE Name = '" + tab + "'";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Name = reader["Name"].ToString();

                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        // tranzak
        public void Inser_tranzak(tranzak zad)//Добавление записи
        {
            int k = 0;
            try
            {
                command.CommandText = "INSERT INTO tranzak (Id_zakaz,Id_vid,Data,Summa,Shet) VALUES('" + zad.Id_zakaz + "', '"+zad.Id_vid + "', '" + zad.Data + "', '" + zad.Summa + "', '" + zad.Shet + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public void Update_tranzak(tranzak st, tranzak now)    //Обновление записи
        {
            try
            {
                command.CommandText = "UPDATE tranzak SET Id_vid = '" + now.Id_vid + "',Id_zakaz ='" + now.Id_zakaz + "',Summa ='" + now.Summa + "',Data='" + now.Data + "',Shet ='" + now.Shet + "' WHERE ID =" + st.Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }



        public List<tranzak> Fill_tranzak()          //Получение всех записей по движению
        {
            List<tranzak> spisok = new List<tranzak>();

            try
            {
                command.CommandText = "SELECT * FROM  tranzak";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tranzak zad = new tranzak();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_zakaz = Convert.ToInt32(reader["Id_zakaz"].ToString());
                    zad.Id_vid = Convert.ToInt32(reader["Id_vid"].ToString());
                    zad.Summa = Convert.ToInt32(reader["Summa"].ToString());
                    zad.Data = reader["Data"].ToString();
                    zad.Shet = reader["Shet"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }



        public List<tranzak> Fill_tranzak_Id_vid(String tab)//Получение записей по секретарю
        {
            List<tranzak> spisok = new List<tranzak>();

            try
            {

                command.CommandText = "SELECT * FROM tranzak WHERE Id_vid = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tranzak zad = new tranzak();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_zakaz = Convert.ToInt32(reader["Id_zakaz"].ToString());
                    zad.Id_vid = Convert.ToInt32(reader["Id_vid"].ToString());
                    zad.Summa = Convert.ToInt32(reader["Summa"].ToString());
                    zad.Data = reader["Data"].ToString();
                    zad.Shet = reader["Shet"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public List<tranzak> Fill_tranzak_data(String tab)//Получение записей по секретарю
        {
            List<tranzak> spisok = new List<tranzak>();

            try
            {

                command.CommandText = "SELECT * FROM tranzak WHERE Data = '" + tab + "'";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tranzak zad = new tranzak();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_zakaz = Convert.ToInt32(reader["Id_zakaz"].ToString());
                    zad.Id_vid = Convert.ToInt32(reader["Id_vid"].ToString());
                    zad.Summa = Convert.ToInt32(reader["Summa"].ToString());
                    zad.Data = reader["Data"].ToString();
                    zad.Shet = reader["Shet"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

    
        public tranzak Get_tranzak_id(String tab)//Получение записи по персоналу
        {
            tranzak zad = new tranzak();

            try
            {

                command.CommandText = "SELECT * FROM tranzak WHERE Id = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_zakaz = Convert.ToInt32(reader["Id_zakaz"].ToString());
                    zad.Id_vid = Convert.ToInt32(reader["Id_vid"].ToString());
                    zad.Summa = Convert.ToInt32(reader["Summa"].ToString());
                    zad.Data = reader["Data"].ToString();
                    zad.Shet = reader["Shet"].ToString();
                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


        //sklad

        public void Inser_sklad(sklad zad)
        {
            try
            {
                command.CommandText = "INSERT INTO sklad (Id_teh,Kol,Ed_izm) VALUES('" + zad.Id_teh + "', '" + zad.Koll + "', '" + zad.Ed_izm + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }


        public void Update_sklad(sklad st, sklad now)
        {
            try
            {
                command.CommandText = "UPDATE sklad SET Id_teh = '" + now.Id_teh + "',Ed_izm ='" + now.Ed_izm + "',Kol ='" + now.Koll + "' WHERE ID =" + st.Id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

        }



        public List<sklad> Fill_sklad()
        {
            List<sklad> spisok = new List<sklad>();

            try
            {
                command.CommandText = "SELECT * FROM sklad";
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sklad zad = new sklad();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Ed_izm = reader["Ed_izm"].ToString();
                    zad.Koll = reader["Kol"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }


        public List<sklad> Fill_sklad_id(String tab)
        {
            List<sklad> spisok = new List<sklad>();

            try
            {

                command.CommandText = "SELECT * FROM sklad WHERE Id = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sklad zad = new sklad();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Ed_izm = reader["Ed_izm"].ToString();
                    zad.Koll = reader["Kol"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


        public List<sklad> Fill_sklad_Id_teh(String tab)
        {
            List<sklad> spisok = new List<sklad>();

            try
            {

                command.CommandText = "SELECT * FROM sklad WHERE Id_teh = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sklad zad = new sklad();
                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Ed_izm = reader["Ed_izm"].ToString();
                    zad.Koll = reader["Kol"].ToString();
                    spisok.Add(zad);
                }
                return spisok;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public sklad Get_sklad_id(String tab)
        {
            sklad zad = new sklad();

            try
            {

                command.CommandText = "SELECT * FROM sklad WHERE Id = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {


                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Ed_izm = reader["Ed_izm"].ToString();
                    zad.Koll = reader["Kol"].ToString();

                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public sklad Get_sklad_Id_teh(String tab)
        {
            sklad zad = new sklad();

            try
            {

                command.CommandText = "SELECT * FROM sklad WHERE Id_teh = " + tab;
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {


                    zad.Id = Convert.ToInt32(reader["Id"].ToString());
                    zad.Id_teh = Convert.ToInt32(reader["Id_teh"].ToString());
                    zad.Ed_izm = reader["Ed_izm"].ToString();
                    zad.Koll = reader["Kol"].ToString();

                }
                return zad;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }
      

    }
}
