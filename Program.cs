using System;
using Sistema_Bancario.Models;
using Sistema_Bancario.Services;

namespace MySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();

            ContaCorrente corrente = new ContaCorrente("Hatsune Miku", 5000);
            ContaPoupanca poupanca = new ContaPoupanca("Ado", 1000);
            banco.AdicionarConta(corrente);
            banco.AdicionarConta(poupanca);

            try
            {
                corrente.Transferir(1000, poupanca);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            banco.Relatorio();

            Console.WriteLine();
            Console.WriteLine("Contas no banco:\n");
            banco.ExibirTodasAsContas();
        }
    }
}
