using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GerenciarPropriedades;

namespace ApiControleServicos.Controllers
{

    public class OrdemServicoController : ApiController
    {
        public struct RespQ1
        {
            public Cliente Cli;
            public OrdemServico Ord;
            public List<Servico> serv;
            public Endereco End;
        }

        Gerenciar Gerenciar;

        public RespQ1 GetOrdemSerico(int idOrdem)
        {
            Gerenciar = new Gerenciar();
            RespQ1 resposta = new RespQ1();


            resposta.Cli = Gerenciar.PesquisaClienteOrdem(idOrdem);
            resposta.Ord = Gerenciar.PesquisaOrdem(idOrdem);
            resposta.serv = Gerenciar.PesquisaServicosOrdem(idOrdem);
            resposta.End = Gerenciar.PesquisarEnderecoCliente(resposta.Cli.IdCliente);


            return resposta;
        }

        public List<OrdemServico> GetCliente(int idCliente)
        {
            Gerenciar = new Gerenciar();
            return Gerenciar.PesquisaOrdemDoCliente(idCliente);
        }
    }
}
