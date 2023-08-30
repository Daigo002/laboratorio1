// See https://aka.ms/new-console-template for more information
using laboratorio1;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese su PIN de seguridad: ");
        int pinIngresado;

        if (int.TryParse(Console.ReadLine(), out pinIngresado))
        {
            if (AutenticarUsuario(pinIngresado))
            {
                EjecutarCajeroAutomatico();
            }
            else
            {
                Console.WriteLine("PIN incorrecto. El programa se cerrará.");
            }
        }
        else
        {
            Console.WriteLine("PIN inválido. El programa se cerrará.");
        }
    }

    static bool AutenticarUsuario(int pin)
    {
        // Aquí podrías comparar el PIN ingresado con el PIN correcto
        // y devolver true si coinciden, o false si no coinciden.
        // Por ejemplo:
        int pinCorrecto = 1234;
        return pin == pinCorrecto;
    }

    static void EjecutarCajeroAutomatico()
    {
        CajeroAutomatico cajero = new CajeroAutomatico
        {
            NumeroCuenta = 123456,
            TitularCuenta = "Nombre del Titular",
            Saldo = 1000,
            PinSeguridad = 1234
        };

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Bienvenido al Cajero Automático");
            Console.WriteLine("1. Consultar Saldo");
            Console.WriteLine("2. Depositar Fondos");
            Console.WriteLine("3. Retirar Efectivo");
            Console.WriteLine("4. Cambiar PIN");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        cajero.ConsultarSaldo();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Ingrese el monto a depositar: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal montoDeposito))
                        {
                            cajero.DepositarFondos(montoDeposito);
                        }
                        else
                        {
                            Console.WriteLine("Monto inválido.");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Ingrese el monto a retirar: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal montoRetiro))
                        {
                            cajero.RetirarEfectivo(montoRetiro);
                        }
                        else
                        {
                            Console.WriteLine("Monto inválido.");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Ingrese el nuevo PIN: ");
                        if (int.TryParse(Console.ReadLine(), out int nuevoPin))
                        {
                            cajero.CambiarPin(nuevoPin);
                        }
                        else
                        {
                            Console.WriteLine("PIN inválido.");
                        }
                        break;
                    case 5:
                        salir = true;
                        Console.Clear();
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opción inválida.");
            }

            Console.WriteLine();
        }
    }
}