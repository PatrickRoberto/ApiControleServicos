using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarPropriedades
{
    public class Cliente
    {
        //Atributos Cliente
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string eMail { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
        public string TelResidencial { get; set; }

        //Construtor completo
        public Cliente(int idCliente, string nome, string email, DateTime dataNascimento, string celular, string telResidencial)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.eMail = email;
            this.DataNascimento = dataNascimento;
            this.Celular = celular;
            this.TelResidencial = telResidencial;
        }

        //Construtor serm telefone residencial
        public Cliente(int idCliente, string nome, string email, DateTime dataNascimento, string celular)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.eMail = email;
            this.DataNascimento = dataNascimento;
            this.Celular = celular;
            this.TelResidencial = "";
        }

        //Construtor sem celular e telefone residencial
        public Cliente(int idCliente, string nome, string email, DateTime dataNascimento)
        {
            this.IdCliente = idCliente;
            this.Nome = nome;
            this.eMail = email;
            this.DataNascimento = dataNascimento;
            this.Celular = "";
            this.TelResidencial = "";
        }
    }
}
