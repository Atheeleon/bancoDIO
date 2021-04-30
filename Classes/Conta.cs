using System;

namespace BancoDio
{
    public class Conta
    {
        private int idConta {get; set;}
        private TipoConta TipoConta {get; set;}
        private string Nome {get; set;}
        private string CPFCNPJ {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        Random rnd = new Random();

        public Conta (TipoConta tipoConta, string nome, string cpfcnpj, double saldo, double credito)
        {
            this.idConta = rnd.Next(1,9999999);
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.CPFCNPJ = cpfcnpj;
            this.Saldo = saldo;
            this.Credito = credito;
        }
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine($"{this.Nome}, este é o saldo atual da sua conta: {this.Saldo}");
            return true;
        }
        public void Deposito(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"{this.Nome}, este é o saldo atual da sua conta: {this.Saldo}");
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Deposito(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "\nIdentificador da Conta: " + idConta + ".";
            retorno += "\nNome: " + Nome + ".";
            retorno += "\nTipo de Conta: " + TipoConta + ".";

            switch (Convert.ToInt16(TipoConta))
            {
                case 1:
                    retorno += "\nCPF: " + CPFCNPJ + ".";
                    break;
                case 2:
                    retorno += "\nCNPJ: " + CPFCNPJ + ".";
                    break;
            }
            
            retorno += "\nSaldo: " + Saldo + ".";
            retorno += "\nCredito: " + Credito + ".";
            return retorno;
        }
    }
}