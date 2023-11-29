using MySql.Data.MySqlClient;

namespace CRUDAgoraVai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtNome.Text.Equals("") && !txtEmail.Text.Equals("") && !txtCpf.Text.Equals("") && !txtEndereco.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Nome = txtNome.Text;
                    cadFuncionarios.Email = txtEmail.Text;
                    cadFuncionarios.Cpf = txtCpf.Text;
                    cadFuncionarios.Endereco = txtEndereco.Text;

                    if (cadFuncionarios.cadastrarFuncionarios())
                    {
                        MessageBox.Show($"O funcionario {cadFuncionarios.Nome} foi cadastrado com sucesso");
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtNome.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel cadastrar o funcionario");
                    }
                }
                else
                {
                    MessageBox.Show("Favor cadastrar todos os campos corretamente");
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    txtNome.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionario: " + ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Cpf = txtCpf.Text;

                    MySqlDataReader reader = cadFuncionarios.localizarFuncionario();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            lblId.Text = reader["id"].ToString();
                            txtNome.Text = reader["nome"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtEndereco.Text = reader["endereco"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("Funcionario não encontrado");
                            txtCpf.Clear();
                            txtEndereco.Clear();
                            txtNome.Clear();
                            txtEmail.Clear();
                            txtCpf.Focus();
                            lblId.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Funcionario não encontrado");
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtCpf.Focus();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CPF para realizar a pesquisa");
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtCpf.Focus();
                    lblId.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao encontrar funcionario: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCpf.Clear();
            txtEndereco.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            lblId.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblId.Text);
                    cadFuncionarios.Email = txtEmail.Text;
                    cadFuncionarios.Endereco = txtEndereco.Text;

                    if (cadFuncionarios.atualizarFuncionario())
                    {
                        MessageBox.Show("Os dados foram atualizados com sucesso");
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        lblId.Text = "";
                        txtCpf.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel atualizar os dados do funcionario");
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        lblId.Text = "";
                        txtCpf.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Favor localizar o funcionario que deseja atualizar as informações");
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    txtNome.Clear();
                    txtEmail.Clear();
                    lblId.Text = "";
                    txtCpf.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar os dados do funcionario: " + ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblId.Text);

                    if(cadFuncionarios.deletarFuncionario())
                    {
                        MessageBox.Show("O funcionario foi deletado com sucesso");
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor pesquisar qual funcionario deseja excluir");
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    txtNome.Clear();
                    txtEmail.Clear();
                    lblId.Text = "";
                    txtCpf.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar o funcionario: "+ ex.Message);
            }
        }
    }
}
