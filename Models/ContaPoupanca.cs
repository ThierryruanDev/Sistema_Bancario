using System;

namespace Sistema_Bancario.Models
{
    class ContaPoupanca : Conta
    {
        public double TaxaRendimento { get; private set; }
        public ContaPoupanca(string titular, double depositoInicial, double taxaRendimento = 0.5) : base(titular)
        {
            TaxaRendimento = taxaRendimento;
            Depositar(depositoInicial);
            if (depositoInicial > 0)
                AplicarRendimento();
        }
        public override void ExibirInfo()
        {
            Console.WriteLine($"[Poupança] {Titular} | Saldo: {GetSaldo()} | Taxa: {TaxaRendimento}%");
        }

        public void AplicarRendimento()
        {
            double rendimento = GetSaldo() * TaxaRendimento;
            Depositar(rendimento);
            Console.WriteLine($"Rendimento de {rendimento} aplicado na conta de {Titular}.");
        }
    }
}