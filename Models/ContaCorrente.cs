using System;
using Sistema_Bancario.Interfaces;

namespace Sistema_Bancario.Models
{
    class ContaCorrente : Conta, INotificavel, ITransferivel
    {
        public ContaCorrente(string titular, double depositoInicial) : base(titular)
        {
            Depositar(depositoInicial);
            if (depositoInicial > 0)
                EnviarNotificacao($"Depósito de R${GetSaldo()} realizado.");
        }
        public override void ExibirInfo()
        {
            Console.WriteLine($"[Corrente] {Titular} | Saldo: R${GetSaldo()}");
        }

        public void EnviarNotificacao(string mensagem)
        {
            Console.WriteLine($"Notificação para {Titular}: {mensagem}");
        }

        public void Transferir(double valor, Conta destino)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor de transferência deve ser maior que zero!");
            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente para transferência!");

            Sacar(valor);
            destino.Depositar(valor);
            Console.WriteLine($"Transferência para {destino.Titular} realizado com sucesso.");

        }
    }
}