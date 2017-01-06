using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarPropriedades
{
    public class Endereco
    {
        //Atributos do endereço (classe criada a partir da modificação feita na estrutura
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int Numero { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        //Construtor Completo
        public Endereco(int id, int idCliente, int numero, string rua, string complemento, string bairro, string cidade, string estado)
        {
            this.Id = id;
            this.IdCliente = idCliente;
            this.Numero = numero;
            this.Rua = rua;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
        }

        //Construtor sem complemento
        public Endereco(int id, int idCliente, int numero, string rua, string bairro, string cidade, string estado)
        {
            this.Id = id;
            this.IdCliente = idCliente;
            this.Numero = numero;
            this.Rua = rua;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
        }
    }
}


