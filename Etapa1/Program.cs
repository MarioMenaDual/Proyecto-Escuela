// See https://aka.ms/new-console-template for more information
using CoreEscuela;
using CoreEscuela.Entidades;
using static System.Console;
   

var engine = new EscuelaEngine();
engine.Inicializar();
//escuela.Cursos.Remove(tmp);
    Printer.WriteTitle("Bienvenidos a la escuela");
    ImprimirCursosEscuela(engine.Escuela);
    Printer.Beep(10000,cantidad: 10);
   


void ImprimirCursosEscuela(Escuela escuela)
{
   
    Printer.WriteTitle("Cursos de la Escuela");
   

    if (escuela ?.Cursos != null)
    {
        foreach (var curso in escuela.Cursos)
        {
          Console.WriteLine($"Nombre: {curso.Nombre}, ID: {curso.UniqueId}");  
        }
        
    }}