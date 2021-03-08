using System.Collections.Generic;
using MySqlConnector;

namespace KlSolutions.Models
{
    public class ContatoBD
    {
        
        private const string DadosConexao = "Database=klsolutions; Data Source=localhost; User Id=root;";
        public void Cadastrar(Contato contato){

            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();
            string Query = "INSERT INTO contato(nome, email, assunto, mensagem) values (@Nome, @Email, @Assunto, @Mensagem); ";

            MySqlCommand comandoQuery = new MySqlCommand(Query, conexao);

            comandoQuery.Parameters.AddWithValue("@Nome", contato.nome);
            comandoQuery.Parameters.AddWithValue("@Email", contato.email);
            comandoQuery.Parameters.AddWithValue("@Assunto", contato.assunto);
            comandoQuery.Parameters.AddWithValue("@Mensagem", contato.mensagem);

            comandoQuery.ExecuteNonQuery();
            conexao.Close();
        }

        public List<Contato> Listar(){
            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();
            string Query = "Select * from contato;";

            MySqlCommand comandoQuery = new MySqlCommand(Query, conexao);
            MySqlDataReader dadosEncontrados = comandoQuery.ExecuteReader();

            List<Contato> lista = new List<Contato>();

            while(dadosEncontrados.Read()){
                Contato contatoEncontrado = new Contato();
                contatoEncontrado.id = dadosEncontrados.GetInt32("Id");

                if(!dadosEncontrados.IsDBNull(dadosEncontrados.GetOrdinal("Nome")))
                contatoEncontrado.nome =  dadosEncontrados.GetString("Nome");

                if(!dadosEncontrados.IsDBNull(dadosEncontrados.GetOrdinal("Email")))
                contatoEncontrado.email =  dadosEncontrados.GetString("Email");
               
               if(!dadosEncontrados.IsDBNull(dadosEncontrados.GetOrdinal("Assunto")))
                contatoEncontrado.assunto =  dadosEncontrados.GetString("Assunto");
                
                if(!dadosEncontrados.IsDBNull(dadosEncontrados.GetOrdinal("Mensagem")))
                contatoEncontrado.mensagem =  dadosEncontrados.GetString("Mensagem");

                lista.Add(contatoEncontrado);
            }
            conexao.Close();
            return lista;
            
        }
    }

}