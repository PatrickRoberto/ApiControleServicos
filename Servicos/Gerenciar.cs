using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GerenciarPropriedades
{
    public class Gerenciar
    {
        string StringConexao; //Para alterar o Banco de dados deve-se modificar essa variavel no construtor do metodo.
        MySqlConnection Conectar;
        MySqlCommand Comando;

        public Gerenciar()
        {

            try
            {
                StringConexao = @"Host=localhost;Username=root;Password=@123456;Database=controleservico";
                Conectar = new MySqlConnection(StringConexao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Questão 1
        public Cliente PesquisaClienteOrdem(int idOrdem)
        {

            ConectarBanco(); //Estabelecer conexão com o banco de dados

            //Se o cliente não for encontrato ira retornar o resultado como nulo.
            Cliente Resposta = null; ;
            try
            {
                Comando = Conectar.CreateCommand();
                Comando.CommandText = "SELECT Cli.idCliente, Cli.NomeCliente, Cli.EmailCliente, Cli.DataNascimentoCliente, Cli.TelCelularCliente, Cli.TelResidencialCliente FROM cliente Cli JOIN ordemservico Ord ON Cli.idCliente = Ord.IdCliente WHERE Ord.idOrdemServico = " + idOrdem + ";";
                var leitor = Comando.ExecuteReader();

                if (leitor.Read())
                {
                    int idCliente = int.Parse(leitor.GetString(0));
                    string Nome = leitor.GetString(1);
                    string email = (leitor.GetString(2) != null) ? leitor.GetString(0) : "";
                    DateTime dataNascimento = StringParaData(leitor.GetString(3));
                    string TelCelular = (leitor.GetString(0) != null) ? leitor.GetString(4) : "";
                    string TelResidencial = (leitor.GetString(0) != null) ? leitor.GetString(5) : "";

                    Resposta = new Cliente(idCliente, Nome, email, dataNascimento);
                }
            }
            catch (Exception) { throw; }

            Conectar.Close();
            return Resposta;

        }

        public OrdemServico PesquisaOrdem(int idOrdem)
        {
            ConectarBanco();

            OrdemServico Resposta = null;
            try
            {
                Comando = Conectar.CreateCommand();
                Comando.CommandText = "SELECT * FROM ordemservico WHERE idOrdemServico = " + idOrdem + ";";

                var leitor = Comando.ExecuteReader();

                if (leitor.Read())
                {
                    int idOrdemServico = int.Parse(leitor.GetString(0));
                    int idCliente = int.Parse(leitor.GetString(1));
                    DateTime DataContratacao = StringParaData(leitor.GetString(2));
                    DateTime DataExecucao = StringParaData(leitor.GetString(3));

                    Resposta = new OrdemServico(idOrdemServico, idCliente, DataContratacao, DataExecucao);
                }
            }
            catch (Exception)
            {
                throw;
            }
            Conectar.Close();
            return Resposta;

        }

        public List<Servico> PesquisaServicosOrdem(int idOrdem)
        {
            ConectarBanco();

            List<Servico> Resposta = new List<Servico>();
            try
            {
                Comando = Conectar.CreateCommand();
                Comando.CommandText = "SELECT Serv.idServico, Serv.NomeServico, Serv.ValorFinalServico, Serv.CustoEmpresaServico FROM Servico Serv JOIN servicos_ordem_local ordServ ON Serv.idServico = ordServ.IdServico WHERE ordServ.IdOrdemServico = " + idOrdem + ";";

                var leitor = Comando.ExecuteReader();

                while(leitor.Read())
                {
                    int idServico = int.Parse(leitor.GetString(0));
                    string nomeServico = leitor.GetString(1);
                    double valoServico = double.Parse(leitor.GetString(2));
                    double CustoEmpresa = double.Parse(leitor.GetString(3));

                    Servico Novo = new Servico(idServico, nomeServico, valoServico, CustoEmpresa);
                    Resposta.Add(Novo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            Conectar.Close();
            return Resposta;

        }

        public Endereco PesquisarEnderecoCliente(int idCliente)
        {
            ConectarBanco();
            Endereco Resposta = null;
            try
            {
                Comando = Conectar.CreateCommand();
                Comando.CommandText = "SELECT * FROM endereco WHERE IdCliente = " + idCliente + ";";
                var leitor = Comando.ExecuteReader();

                if (leitor.Read())
                {
                    int idLocal = int.Parse(leitor.GetString(0));
                    int IdClientePesq = int.Parse(leitor.GetString(1));
                    string Rua = leitor.GetString(2);
                    int Numero = int.Parse(leitor.GetString(3));
                    string Bairro = leitor.GetString(3);
                    string Complemento = (leitor.GetString(4) != "" ? leitor.GetString(4) : "");
                    string Cidade = leitor.GetString(5);
                    string Estado = leitor.GetString(6);

                    Resposta = new Endereco(idLocal, idCliente, Numero, Rua, Bairro, Complemento, Cidade, Estado);
                }
            }
            catch (Exception)
            {
                throw;
            }
            Conectar.Close();
            return Resposta;

        }


        //Questão 2
        public List<OrdemServico> PesquisaOrdemDoCliente(int idCliente)
        {

            ConectarBanco();

            List<OrdemServico> Resposta = new List<OrdemServico>();
            try
            {
                Comando = Conectar.CreateCommand();
                Comando.CommandText = "SELECT * FROM ordemservico WHERE idCliente = " + idCliente + ";";

                var leitor = Comando.ExecuteReader();

                while (leitor.Read())
                {
                    int idOrdemServico = int.Parse(leitor.GetString(0));
                    int idClienteOrdem = int.Parse(leitor.GetString(1));
                    DateTime DataContratacao = StringParaData(leitor.GetString(2));
                    DateTime DataExecucao = StringParaData(leitor.GetString(3));

                    OrdemServico Novo = new OrdemServico(idOrdemServico, idClienteOrdem, DataContratacao, DataExecucao);
                    Resposta.Add(Novo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            Conectar.Close();
            return Resposta;

        }

        /// <summary>
        /// Recever uma string no formato Dia/Mes/Ano [Tempo]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DateTime StringParaData(string data)
        {
            //Esse procedimento pode ser feito de maneira melhores, mas com o curto tempo preferir fazer de uma forma simples apesar de mais feia
            string dia, mes, ano;

            try
            {
                dia = data[0] + "" + data[1];
                mes = data[3] + "" + data[4];
                ano = data[7] + "" + data[8] + "" + data[9] + "" + data[10];
                return new DateTime(int.Parse(ano), int.Parse(mes), int.Parse(dia));
            }
            catch
            {
                return new DateTime();
            }

        }

        /// <summary>
        /// Estabele a conexão com o banco a cada nova interação
        /// </summary>
        private void ConectarBanco()
        {
            try
            {
                Conectar.Open();
                Comando = new MySqlCommand();
                Comando = Conectar.CreateCommand();
                Comando.Connection = Conectar;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}


