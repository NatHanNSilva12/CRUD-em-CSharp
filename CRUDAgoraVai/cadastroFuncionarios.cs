using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAgoraVai
{
    internal class cadastroFuncionarios
    {
        private int id;
        private string nome;
        private string email;
        private string cpf;
        private string endereco;

        public int Id
        {
            get { return id; }
            set { id = value;}

        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }

        }

        public string Email
        {
            get { return email; }
            set { email = value; }

        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }

        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }

        }

        public bool cadastrarFuncionarios()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string insert = $" insert into funcionarios (nome,email,cpf,endereco) values ('{Nome}','{Email}','{Cpf}','{Endereco}')";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = insert;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método cadastrarFuncionarios: " + ex.Message);
                return false;
            }
        }

        public MySqlDataReader localizarFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string select = $"select id, nome, email, cpf, endereco from funcionarios where cpf = '{Cpf}';";
                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = select;

                MySqlDataReader reader = comandoSql.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método localizarFuncionario: " + ex.Message);
                return null;
            }
        }

        public bool atualizarFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string update = $"update funcionarios set email = '{Email}', endereco = '{Endereco}' where id = '{Id}';";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = update;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método atualizarFuncionario: " + ex.Message);
                return false;
            }
        }

        public bool deletarFuncionario()
        {
                try
                {
                    MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                    MysqlConexaoBanco.Open();

                    string delete = $"delete from funcionarios where id = '{Id}';";

                    MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                    comandoSql.CommandText = delete;

                    comandoSql.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no banco de dados - método detelarFuncionario: " + ex.Message);
                    return false;
                }
            }

        }
    }
