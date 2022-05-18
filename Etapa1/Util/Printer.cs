using static System.Console;

public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            WriteLine("".PadLeft(tam, '='));
        }

         public static void PresioneENTER()
        {
            WriteLine("Presione ENTER para continuar");
        }

        public static void PintarVerde()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void PintarRojo()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void PintarAzul()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        public static void WriteTitle(string titulo)
        {
            var tamaño =titulo.Length + 4;
            DrawLine(tamaño);
            WriteLine($"| {titulo} |");
            DrawLine(tamaño);
        }

        public static void Menu()
        {
            PintarAzul();
            Printer.WriteTitle("Inicio de programa");
             Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
             Console.WriteLine("1-Listar asignaturas");
            Console.WriteLine("2-Listar evaluaciones por asignatura");
            Console.WriteLine("3-Listar top de promedio por evaluaciones de asignatura");
            Console.WriteLine("4-Listar evaluaciones");
            Console.WriteLine("5-Cerrar programa");
             Console.WriteLine("Ingrese una opción");
        }

        public static void Beep(int hz = 2000, int tiempo=500, int cantidad =1)
        {
            while (cantidad-- > 0)
            {
                System.Console.Beep(hz, tiempo);
            }
        }
    }