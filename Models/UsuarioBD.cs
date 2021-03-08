
using System;
using MySqlConnector;
namespace KlSolutions.Models
{
    public class UsuarioBD
    {
        private const string DadosConexao = "Database=klsolutions; Data Source=localhost; User Id=root;";

        public Usuario FazerLogin(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM login WHERE login = @Login AND @Senha";

            MySqlCommand ComandoQuery = new MySqlCommand(Query, Conexao);
            ComandoQuery.Parameters.AddWithValue("@Login", usuario.Login);
            ComandoQuery.Parameters.AddWithValue("@Senha", usuario.Senha);
            MySqlDataReader DadosEncontrados = ComandoQuery.ExecuteReader();

            Usuario User = null;

            if (DadosEncontrados.Read())
            {
                User = new Usuario();
                User.Id = DadosEncontrados.GetInt32("Id");
                if (!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Nome")))
                    User.Nome = DadosEncontrados.GetString("Nome");
                if (!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Login")))
                    User.Login = DadosEncontrados.GetString("Login");
                if (!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Senha")))
                    User.Senha = DadosEncontrados.GetString("Senha");
                Console.WriteLine("LOGADO!!");
            }
            Conexao.Close();

            return User;
        }


        public void Cadastrar(Usuario user){


            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();
            string Query = "INSERT INTO login(nome, login, senha) values (@Nome, @Login, @Senha); ";

            MySqlCommand comandoQuery = new MySqlCommand(Query, conexao);

            comandoQuery.Parameters.AddWithValue("@Nome", user.Nome);
            comandoQuery.Parameters.AddWithValue("@Login", user.Login);
            comandoQuery.Parameters.AddWithValue("@Senha", user.Senha);

            comandoQuery.ExecuteNonQuery();
            conexao.Close();
        }



        public static void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados Funcionando.");
            Conexao.Close();
        }


    }
}