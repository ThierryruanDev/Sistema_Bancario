using System;
using System.Collections.Generic;
using System.Linq;
using Sistema_Bancario.Models;

namespace Sistema_Bancario.Services
{
    class Banco
    {
        List<Conta> contas = new List<Conta>();

        public void AdicionarConta(Conta conta)
        {
            contas.Add(conta);
        }

        public void ExibirTodasAsContas()
        {
            foreach (Conta conta in contas)
            {
                conta.ExibirInfo();
            }
        }

        public Conta BuscarPorTitular(string titular)
        {
            foreach (Conta conta in contas)
            {
                if (conta.Titular == titular)
                    return conta;
            }
            return null;
        }

        public void Relatorio()
        {
            double saldoTotal = contas.Sum(c => c.GetSaldo());
            Console.WriteLine($"Saldo Total: R${saldoTotal}");

            var contasOrdenadas = contas.OrderByDescending(c => c.GetSaldo()).First();
            Console.WriteLine($"Conta com maior saldo: {contasOrdenadas.Titular} - R${contasOrdenadas.GetSaldo()}");

            int contasAcima = contas.Count(c => c.GetSaldo() > 500);
            Console.WriteLine($"Quantidade de contas com saldo acima de R$500: {contasAcima}");

        }
    }
}