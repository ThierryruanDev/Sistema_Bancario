using System;

namespace Sistema_Bancario.Models
{
    abstract class Conta
    {
        public string Titular { get; private set; }
        protected double Saldo { get; private set; }

        public Conta(string titular)
        {
            Titular = titular;
        }
        public void Depositar(double valor)
        {
            if (valor > 0)
                Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor de saque deve ser maior que zero!");
            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente para saque!");

            Saldo -= valor;
        }

        public double GetSaldo()
        {
            return Saldo;
        }

        public abstract void ExibirInfo();
    }
}