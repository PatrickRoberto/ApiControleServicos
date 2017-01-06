using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarPropriedades
{
    public class OrdemServico
    {
        //Simplificação de serviço
        struct Servico
        {
            public int IdServico;
            public int IdEndereco;

            public Servico(int idServico, int idEndereco)
            {
                this.IdServico = idServico; this.IdEndereco = idEndereco;
            }
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataContratacao { get; set; }
        public DateTime DataExecucao { get; set; }

        //Construtor
        public OrdemServico(int id, int idCli, DateTime dataCont, DateTime dataExec)
        {
            this.Id = id;
            this.IdCliente = idCli;
            this.DataContratacao = dataCont;
            this.DataExecucao = dataExec;

        }

       

    }
}
