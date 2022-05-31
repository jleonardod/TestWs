using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        public const string mensajeMontoDebitoSuperaSaldo = "el monto a debitar supera el saldo restante";
        public const string mensajeMontoDebitoMenorACero = "el monto a debitar es menor a cero";
        private readonly string m_nombreCliente;
        private double m_saldo;

        private BankAccount() { }

        public BankAccount(string nombreCliente, double saldo)
        {
            m_nombreCliente = nombreCliente;
            m_saldo = saldo;
        }

        public string NombreCliente
        {
            get { return m_nombreCliente; }
        }

        public double Saldo
        {
            get { return m_saldo; }
        }

        public void Debito(double monto)
        {
            if (monto > m_saldo)
            {
                throw new System.ArgumentOutOfRangeException("monto", monto, mensajeMontoDebitoSuperaSaldo);
            }

            if (monto < 0)
            {
                throw new System.ArgumentOutOfRangeException("monto", monto, mensajeMontoDebitoMenorACero);
            }

            //m_saldo += monto; // intentionally incorrect code
            m_saldo -= monto; // corret code
        }

        public void Credito(double monto)
        {
            if (monto < 0)
            {
                throw new ArgumentOutOfRangeException("monto");
            }

            m_saldo += monto;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credito(5.77);
            ba.Debito(11.22);
            Console.WriteLine("Monto disponible ${0}", ba.Saldo);
        }
    }
}