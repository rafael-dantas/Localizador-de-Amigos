using LocalizaAmigos.Domain.Entities;
using LocalizaAmigos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocalizaAmigos.Infra.Data.Repositories
{
    public class AmigoRepositorio : IRepositorioBase<Amigo>
    {
        public List<Amigo> Listar()
        {
            try
            {
                List<Amigo> lstAmigo = new List<Amigo>();
                using (var conn = Data.ADO.ADO.GetConnection())
                {
                    using (var comm = Data.ADO.ADO.GetCommand("LocalizaAmigos_Select", conn))
                    {
                        conn.Open();
                        comm.Connection = conn;
                        comm.CommandType = CommandType.StoredProcedure;
                        var dr = comm.ExecuteReader();
                        while (dr.Read())
                        {
                            Amigo a = new Amigo();
                            a.Id = Convert.ToInt32(dr["Id"].ToString());
                            a.Nome = dr["Nome"].ToString();
                            a.Login = dr["Login"].ToString();
                            a.Latitude = Convert.ToDouble(dr["Latitude"].ToString());
                            a.Longitude = Convert.ToDouble(dr["Longitude"].ToString());
                            lstAmigo.Add(a);
                        }
                    }
                    conn.Close();
                }

                return lstAmigo;
            }
            catch (Exception ex)
            {
                return new List<Amigo>();
            }

        }

        public void CalculoHistoricoLog_Insert(string login, List<Amigo> lstAmigo)
        {
            try
            {
                foreach (Amigo A in lstAmigo)
                {
                    using (var con = Data.ADO.ADO.GetConnection())
                    {
                        using (var comm = Data.ADO.ADO.GetCommand("CalculoHistoricoLog_Insert", con))
                        {
                            con.Open();

                            comm.CommandType = CommandType.StoredProcedure;
                            comm.Parameters.AddWithValue("@Login", login);
                            comm.Parameters.AddWithValue("@AmigoNome", A.Nome);
                            comm.Parameters.AddWithValue("@AmigoLogin", A.Login);
                            comm.Parameters.AddWithValue("@DataPesquisada", DateTime.Now);
                            comm.Parameters.AddWithValue("@Distancia", A.Distancia);

                            comm.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
