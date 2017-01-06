using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarPropriedades
{
    public class Servico
    {
        //Atributos de servico
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorFinal { get; set; }
        public double CustoEmpresa { get; set; }

        //Construtor completo de serviço
        public Servico(int id, string nome, double valorFinal, double custoEmpresa)
        {
            this.Id = id;
            this.Nome = nome;
            this.ValorFinal = valorFinal;
            this.CustoEmpresa = custoEmpresa;
        }

    }
}
