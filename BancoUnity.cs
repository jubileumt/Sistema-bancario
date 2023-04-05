using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Titular
    {
        public string Nome = "";
        public int Idade = 0;
        public int Cpf = 0;
        public Conta conta;
        internal class Conta
        {
            public int saldo = 1000;
            public int sacar;
            public int depositar;

            public static void transferir(Titular[] titulares, Titular.Conta conta, Titular titularSelecionado)
            {
                Console.Write("Digite a quantidade que deseja transferir: ");
                int transferir = int.Parse(Console.ReadLine());

                Console.Write("Digite o CPF da conta para a qual deseja transferir: ");
                int cpfDestino = int.Parse(Console.ReadLine());

                // Find the destination account using the CPF
                Titular.Conta contaDestino = null;
                foreach (var titular in titulares)
                {
                    if (titular != null && titular.conta != null && titular.Cpf == cpfDestino)
                    {
                        contaDestino = titular.conta;
                        break;
                    }
                }

                if (contaDestino == null)
                {
                    Console.WriteLine("Conta destino não encontrada.");
                    return;
                }

                if (transferir > conta.saldo)
                {
                    Console.WriteLine("Saldo insuficiente para realizar a transferência.");
                    return;
                }

                contaDestino.saldo += transferir;
                conta.saldo -= transferir;

                Console.WriteLine("Transferência realizada com sucesso! Novo saldo da conta de origem: " + conta.saldo);
                Console.WriteLine("Novo saldo da conta de destino: " + contaDestino.saldo);

            }
              public static void Depositar(Conta conta)
            {
                Console.Write("Digite a quantidade que deseja depositar ");
                int depositar = int.Parse(Console.ReadLine());
                conta.saldo = conta.saldo + depositar;
                Console.WriteLine("Deposito realizado com sucesso! seu novo saldo é " + conta.saldo);

            }
            public static void Sacar(Conta conta)
            {
                Console.Write("Digite a quantidade que deseja sacar:");
                int sacar = int.Parse(Console.ReadLine());
                if (sacar <= conta.saldo)
                {
                    conta.saldo = conta.saldo - sacar;
                    Console.WriteLine("Saque realizado! novo saldo" + conta.saldo);
                }
                else { Console.WriteLine("Saque nao pode ser maior que o saldo da conta"); }
            }
            public static void Verificar(Conta conta)
            {
                Console.WriteLine("Seu saldo atual é:" + conta.saldo);
            }
            public static int MenuContas(Titular[] titular, Conta conta, Titular titularSelecionado)
            {

              
                while (true)
                {
                    Console.WriteLine("1-para verificar saldo");
                    Console.WriteLine("2-para sacar dinheiro");
                    Console.WriteLine("3-para depositar dinheiro");
                    Console.WriteLine("4-para tranferir entre contas");
                    Console.Write("Escolha:");
                    int opc = int.Parse(Console.ReadLine());
                    if (opc == 1)
                    {
                        Verificar(conta);
                        return 0;
                    }
                    if (opc == 2)
                    {
                        Sacar(conta);
                        return 0;
                    }
                    if (opc == 3)
                    {
                        Depositar(conta);
                        return 0;
                    }
                    if (opc == 4)
                    {
                        transferir(titular,conta,titularSelecionado);
                    }
                }
                return 0;
            }
            public static int FazerConta(Titular[] titular)
            {
                Console.Write("Digite seu nome:");
                string nome = Console.ReadLine();
                Console.Write("Digite sua idade:");
                int idade = int.Parse(Console.ReadLine());
                Console.Write("Digite o seu CPF:");
                int cpf = int.Parse(Console.ReadLine());

                bool cpfregis = false;
                bool numeroregis = false;
                foreach (var verificar in titular)
                {
                    if (verificar != null && verificar.Cpf != 0 && verificar.Cpf == cpf)
                    {
                        Console.WriteLine("CPF já registrado");
                        cpfregis = true;
                        return 0;
                    }
                   // if (verificar != null && verificar.numero_da_conta != 0 && verificar.numero_da_conta == cpf)
                  //  {
                    //    Console.WriteLine("Número da conta já registrado");
                    //    numeroregis = true;
                       // return 0;
                   // }
                }
                if (!cpfregis && !numeroregis)
                {
                    var novoTitular = new Titular { Nome = nome, Idade = idade, Cpf = cpf };
                    int posicao = Array.IndexOf(titular, null);
                    if (posicao != -1)
                    {

                        titular[posicao] = novoTitular;
                        Conta novaConta = new Conta();
                        novoTitular.conta = novaConta;
                        Console.WriteLine("Titular cadastrado");

                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Limite de titulares atingido");
                        return 0;
                    }
                  }
                        return 0;
            }

            public static void Procurar(Titular[] titular)
            {
                Console.Write("Digite o cpf:");
                int cpf = int.Parse(Console.ReadLine());
                bool x = false;
                foreach (var procurar in titular)
                {
                    if (procurar != null && procurar.Cpf == cpf)
                    {
                        x = true;
                        Console.WriteLine("Usuario encontrado");
                      
                    }
                }
                if (x == false) { Console.WriteLine("Usuario não encontrado"); }
               
            }
            static void Main(string[] args)
            {
                Conta conta = new Conta();
                Titular[] titular = new Titular[10];
                int Titularcadastrado = -1;
                while (true)
                {
                    Console.WriteLine("Bem vindo ao Unity Bank! oque deseja fazer?");
                    Console.WriteLine("1-Para realizar cadastro de Titular");
                    Console.WriteLine("2-Para procurar titular");
                    Console.WriteLine("3-Para realizar oprerações da sua conta bancaria");
                    Console.Write("Escolha o que desejar fazer:");
                    int opc = int.Parse(Console.ReadLine());
                    if (opc == 1)
                    {
                       Titularcadastrado = FazerConta(titular);
                    }
                    if (opc == 2)
                    {
                         Procurar(titular);
                    }
                    if (Titularcadastrado == 1 && opc == 3)
                    {
                        Console.Write("Digite o CPF do Titular:");
                        int cpf = int.Parse(Console.ReadLine());
                        Titular titularSelecionado = null;
                        foreach (var verificarCpf in titular)
                        {
                            if (verificarCpf != null && verificarCpf.Cpf == cpf)
                            {
                                titularSelecionado = verificarCpf;
                                break;
                            }
                        }
                        if (titularSelecionado != null)
                        { 
                            MenuContas(titular,conta,titularSelecionado);
                        }
                        else
                        {
                            Console.WriteLine("Usuario nao encontrado!!");

                        }
                    }
                    else if (opc == 3)
                    {
                        Console.WriteLine("Antes de acessar o menu de contas faca o registro de um Titular.");
                    }
                }
            }
        }
    }
}
