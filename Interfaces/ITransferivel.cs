using Sistema_Bancario.Models;

namespace Sistema_Bancario.Interfaces
{
    interface ITransferivel
    {
        void Transferir(double valor, Conta destino);
    }
}