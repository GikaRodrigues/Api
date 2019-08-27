using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=Localhost; Initial catalog=M_BookStore; User Id=sa; Pwd=132";

        public List<GeneroDomain> Listar()
        {

            List<GeneroDomain> autores = new List<GeneroDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Generos ORDER BY IdGenero ASC";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))

                    rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    GeneroDomain autor = new GeneroDomain
                    {
                        IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                        Descricao = rdr["Descricao"].ToString(),
                        
                    };
                    autores.Add(autor);
                }
            }
            return autores;
        }

        public void Cadastrar(GeneroDomain autor)
        {
            string Query = "INSERT INTO Autores (Nome, Email, Ativo, DataNascimento) VALUES (@Nome, @Email, @Ativo, @DataNascimento)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Descricao", autor.Descricao);

                con.Open();
                cmd.ExecuteNonQuery();
            } 
        }
    }
}
