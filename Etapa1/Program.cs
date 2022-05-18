// See https://aka.ms/new-console-template for more information
using CoreEscuela;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using static System.Console;
   

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
           // AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (s,o) => Printer.Beep(2000,1000,1);
            //Printer.Beep(10000, cantidad: 10);
          //  ImpimirCursosEscuela(engine.Escuela);

            
     /*       
            var listaAsg = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDicEvaluaXAsig();
            var listaPromXAsig = reporteador.GetPromeAlumnPorAsignatura();
            var listaTop = reporteador.GetTopPromedio(10);
*/
            AppMenu();
                }
        
public static void AppMenu(){
var engine = new EscuelaEngine();
            engine.Inicializar();
var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
               Printer.Menu();   
                try
                {
                    string texto;
                    int option;
                   option = Convert.ToInt32(Console.ReadLine());
                    switch(option){
                    case 1:
                    Console.WriteLine("Asignaturas");
                        var listaAsignaturas = reporteador.GetListaAsignaturas();
                        int conteoLineas = 1;
                        foreach (var objeto in listaAsignaturas)
                        {
                            Printer.PintarRojo();
                            Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                            conteoLineas++;
                        }
                    
                    //LLamar metodo 
                    break;
                    case 2:
                    
                        Printer.WriteTitle("Mostrando Evaluaciones por asignatura");
                        int conteo = 1;
                        var listaEvaluacionesPorAsignatura = reporteador.GetDicEvaluaXAsig();
                        foreach (var asignatura in listaEvaluacionesPorAsignatura)
                        {
                            Printer.WriteTitle($"Evaluaciones de la Asignatura: {asignatura.Key.ToString()}");
                            foreach (var objeto in asignatura.Value)
                            {
                                Console.WriteLine($"{conteo}) {objeto.ToString()}");
                                
                                conteo++;
                            }
                        }
                        
                    break;
                    
                    case 3:
                      
                        int con = 1;
                        try
                        {
                            int top =10;
                           
                            var diccionarioTopPromedioPorCadaAsignatura = reporteador.GetTopPromedioPorCadaAsignatura(top);
                            foreach (var topAsignatura in diccionarioTopPromedioPorCadaAsignatura)
                            {
                                Printer.WriteTitle($"Promedios de la Asignatura: {topAsignatura.Key.ToString()}");
                                foreach (var ag in topAsignatura.Value)
                                {
                                    Console.WriteLine($"{con}) {ag.ToString()}");
                                    
                                    con++;
                                }
                                con = 1;
                                Console.WriteLine("\n");
                            }
                            
                            
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Printer.WriteTitle("No se ingresó un numero valido");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        finally
                        {
                         WriteLine("f");
                        }
                        break;




                    //LLamar metodo 
                    case 4:
                    Console.WriteLine("Lista de Evaluaciones");
                        var listaEv = reporteador.GetListaEvaluaciones();
                        int conte = 1;
                        foreach (var objeto in listaEv)
                        {
                            Printer.PintarVerde();
                            Console.WriteLine($"Numero: {conte} Datos: {objeto.ToString()}");
                            
                            conte++;
                        }
                    //LLamar metodo 
                    break;



                    default:
                    Console.WriteLine("Ingrese una opción correcta");
                    break;

                    case 5:
                    FinalizarPrograma();
                    break;
                }
                
                
                
                }
                catch (Exception error)
                {
                   WriteLine(error.Message);
                }   
}

     public static void FinalizarPrograma()
        {
            ConsoleKeyInfo tecla;
            WriteLine("\nPresione ENTER para volver al menú, presione ESC para finalizar el programa...");
            tecla = Console.ReadKey();
            while (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Escape)
            {
                WriteLine("\nPresione ENTER para volver al menú, presione ESC para finalizar el programa...");
                tecla = Console.ReadKey();
            };
            if (tecla.Key == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Printer.WriteTitle("PROGRAMA FINALIZADO");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(1);
            }
            Console.Clear();
            AppMenu();
        }


/*
        
 Printer.WriteTitle("Captura de una Evaluación por Consola");
            var newEval = new Evaluacion();
            string nombre, notastring;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneENTER();
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluacion ha sido ingresado correctamente");
            }


            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            notastring = Console.ReadLine();


            try
            {
                newEval.Nota = float.Parse(notastring);
                if (newEval.Nota < 0 || newEval.Nota > 5)
                {
                    throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                }
                WriteLine("La nota de la evaluacion ha sido ingresada correctamente");
                return;
            }
            catch (ArgumentOutOfRangeException arge)
            {
                Printer.WriteTitle(arge.Message);
                WriteLine("Saliendo del programa");
            }
            finally
            {
                Printer.WriteTitle("FINALLY");
                Printer.Beep(2500, 500, 3);

            }
        }


        private static void AccionDelEvento(object? sender, EventArgs e)
        {
           Printer.WriteTitle("SALIENDO");
           Printer.Beep(10000,1000,3);
           Printer.WriteTitle("SALIO");
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la Escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre  }, Id:  {curso.UniqueId}");
                }
            }
        }*/
    }
}