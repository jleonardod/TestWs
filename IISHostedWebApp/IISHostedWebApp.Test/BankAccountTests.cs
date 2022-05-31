using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace IISHostedWebAppTest
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debito_ConMontoValido_ActualizaSaldo()
        {
            // Arrange
            double saldoInicial = 11.99;
            double montoADebitar = 4.55;
            double saldoEsperado = 7.44;
            BankAccount cuenta = new BankAccount("Mr. Bryan Walton", saldoInicial);

            // Act
            cuenta.Debito(montoADebitar);

            // Assert
            double actual = cuenta.Saldo;
            Assert.AreEqual(saldoEsperado, actual, 0.001, "cuenta no debitada correctamente");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double saldoInicial = 11.99;
            double montoADebitar = -100.00;
            BankAccount cuenta = new BankAccount("Mr. Bryan Walton", saldoInicial);

            // Act
            try
            {
                cuenta.Debito(montoADebitar);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.mensajeMontoDebitoMenorACero);
            }
           
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double saldoInicial = 11.99;
            double montoADebitar = 20.0;
            BankAccount cuenta = new BankAccount("Mr. Bryan Walton", saldoInicial);

            // Act
            try
            {
                cuenta.Debito(montoADebitar);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.mensajeMontoDebitoSuperaSaldo);
            }
         
        }
    }
}
