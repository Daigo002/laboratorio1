using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio1
{
    using System;

    using System;

    public class CajeroAutomatico : CuentaBancaria
    {
        private const decimal LimiteDiarioRetiro = 500; // Ejemplo de límite diario de retiro

        public void ConsultarSaldo()
        {
            Console.WriteLine($"Saldo actual de la cuenta {NumeroCuenta}: {Saldo:C}");
        }

        public void DepositarFondos(decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("El monto a depositar debe ser mayor que cero.");
            }
            else
            {
                Saldo += monto;
                Console.WriteLine($"Se depositó {monto:C} en la cuenta {NumeroCuenta}. Nuevo saldo: {Saldo:C}");
            }
        }

        public void RetirarEfectivo(decimal monto)
        {
            try
            {
                if (monto <= 0)
                {
                    throw new InvalidOperationException("El monto a retirar debe ser mayor que cero.");
                }
                if (monto > Saldo)
                {
                    throw new InvalidOperationException("Saldo insuficiente para realizar el retiro.");
                }
                if (monto > LimiteDiarioRetiro)
                {
                    throw new InvalidOperationException($"El monto de retiro excede el límite diario de {LimiteDiarioRetiro:C}.");
                }

                Saldo -= monto;
                Console.WriteLine($"Se retiró {monto:C} de la cuenta {NumeroCuenta}. Nuevo saldo: {Saldo:C}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public bool CambiarPin(int nuevoPin)
        {
            try
            {
                if (nuevoPin == PinSeguridad)
                {
                    throw new InvalidOperationException("El nuevo PIN no puede ser igual al PIN actual.");
                }

                PinSeguridad = nuevoPin;
                Console.WriteLine("PIN actualizado exitosamente.");
                return true;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Métodos públicos para acceder a los datos necesarios de manera segura
        public int ObtenerNumeroCuenta()
        {
            return NumeroCuenta;
        }

        public string ObtenerTitularCuenta()
        {
            return TitularCuenta;
        }

        public decimal ObtenerSaldo()
        {
            return Saldo;
        }
    }
}