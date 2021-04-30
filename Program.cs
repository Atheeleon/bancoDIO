using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoDio
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string selection = Menu();

            while(selection!="0")
            {
                switch(selection)
                {
                    case "1":
                        CriarConta();
                        break;
                    case "2":
                        ListarContas();
                        break;
                    case "3":
                        Deposito();
                        break;
                    case "4":
                        Saque();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "9":
                        Cancelar();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                selection = Menu();
            }

            Console.WriteLine("\nObrigado por escolher o banco mais topper de todos.");
        }
        private static string Menu()
        {
            Console.WriteLine("\nBanco Jerycleiquissom - O Banco Mais Topper");

            Console.WriteLine("1 - Criar Conta");
            Console.WriteLine("2 - Listar Contas");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Transferir");
            Console.WriteLine("9 - Cancelamento de Conta");
            Console.WriteLine("0 - Sair");
            Console.Write("\nDigite a opção desejada: ");

            string selection = Console.ReadLine();
            return selection;
        }
        private static void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("Criação de contas");

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Selecione 1 para Pessoa Fisica, 2 para Jurídica: ");
            int entradaTipo = int.Parse(Console.ReadLine());

            string entradaCPFCNPJ = "";
            switch (entradaTipo)
            {
                case 1:
                    Console.Write("Digite o CPF do cliente: ");
                    entradaCPFCNPJ  = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Digite o CNPJ do cliente: ");
                    entradaCPFCNPJ = Console.ReadLine();
                    break;
            }

            Console.Write("Digite o saldo da conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o crédito pré-aprovado: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipo,
                                        nome: entradaNome,
                                        cpfcnpj: entradaCPFCNPJ,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito);

            listContas.Add(novaConta);
            Console.Clear();
        }
        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("Lista de contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine(conta);
            }
        }
        private static void Deposito()
        {
            Console.Clear();
            Console.WriteLine("Depósito de saldo");

            Console.Write("Digite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.Write("Agora, digite o valor que deseja depositar: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            Console.Clear();

            listContas[numConta].Deposito(valorDeposito);
        }
        private static void Saque()
        {
            Console.Clear();
            Console.WriteLine("Saque de saldo");

            Console.Write("Digite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.Write("Agora, digite o valor que deseja sacar: ");
            double valorSaque = double.Parse(Console.ReadLine());
            Console.Clear();

            listContas[numConta].Sacar(valorSaque);
        }
        private static void Transferir()
        {
            Console.Clear();
            Console.WriteLine("Transferência");

            Console.Write("Qual o número da conta de origem? ");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.Write("E o número da conta de destino? ");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.Write("Qual o valor a ser transferido? ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            Console.Clear();

            listContas[contaOrigem].Transferir(valorTransferencia, listContas[contaDestino]);
        }
        private static void Cancelar()
        {
            Console.WriteLine("CANCELAMENTO DE CONTA\nTEM CERTEZA QUE DESEJA EFETUAR UM CANCELAMENTO?");
            Console.WriteLine("Digite SIM ou NAO");
            string confirma = Console.ReadLine().ToUpper();

            switch(confirma)
            {

                //identificador random
                    //index
                // pf ou pj
                // cpf ou cnpj

                case "SIM":
                    Console.Write("Por favor, informe o identificador da conta: ");
                    int idConta = int.Parse(Console.ReadLine());

                    for (int i = 0; i < listContas.Count; i++)
                    {
                        if(listContas[i].ToString().Contains(Convert.ToString("Identificador da Conta: " + idConta)))
                        {
                            Console.Write("Conta encontrada.\nAgora, informe o tipo de conta. PF ou PJ? ");
                            string tipoConta = Console.ReadLine().ToUpper();

                            if(listContas[i].ToString().Contains("Tipo de Conta: " + tipoConta))
                            {
                                if(tipoConta=="PF")
                                {
                                    Console.Write("Perfeito, agora só precisamos que você confirme o CPF: ");
                                    string cpfcnpj = Console.ReadLine();

                                    if(listContas[i].ToString().Contains("CPF: " + cpfcnpj))
                                    {
                                        Console.WriteLine($"CANCELAMENTO DE CONTA\nTEM CERTEZA QUE DESEJA CANCELAR A CONTA {idConta}?");
                                        Console.WriteLine("Digite SIM ou NAO");
                                        confirma = Console.ReadLine().ToUpper();

                                        switch(confirma)
                                        {
                                            case "SIM":
                                                Console.Clear();
                                                Console.WriteLine($"Conta {idConta} foi removida.");
                                                listContas.RemoveAt(i);
                                                break;
                                            case "NAO":
                                                break;
                                            default:
                                                throw new ArgumentOutOfRangeException("Opção inválida.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Os dados da conta não conferem.");
                                    }
                                }
                                else if (tipoConta=="PJ")
                                {
                                    Console.Write("Perfeito, agora só precisamos que você confirme o CNPJ: ");
                                    string cpfcnpj = Console.ReadLine();

                                    if(listContas[i].ToString().Contains("CNPJ: " + cpfcnpj))
                                    {
                                        Console.WriteLine($"CANCELAMENTO DE CONTA\nTEM CERTEZA QUE DESEJA CANCELAR A CONTA {idConta}?");
                                        Console.WriteLine("Digite SIM ou NAO");
                                        confirma = Console.ReadLine().ToUpper();
                                        
                                        switch(confirma)
                                        {
                                            case "SIM":
                                                Console.Clear();
                                                Console.WriteLine($"Conta {idConta} foi removida.");
                                                listContas.RemoveAt(i);
                                                break;
                                            case "NAO":
                                                break;
                                            default:
                                                throw new ArgumentOutOfRangeException("Opção inválida.");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Os dados da conta não conferem.");
                                    }
                                }
                                else
                                {
                                    throw new ArgumentOutOfRangeException("Opção inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Os dados da conta não conferem.");
                                break;
                            }
                            break;
                        }
                        else if (i == listContas.Count)
                        {
                            Console.WriteLine("A conta especificada não existe.");
                        }
                    }
                    break;

                case "NAO":
                    break;
            }
        }

    }
}