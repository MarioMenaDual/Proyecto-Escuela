namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
         public string UniqueId { get; set; }
    public string Nombre { get; set; }

public Alumno Alumno { get; set; }
public Asignatura Asignatura  { get; set; }
    

    public float Nota {get; set;}
     public Evaluaciones()=> UniqueId =  Guid.NewGuid().ToString();


      public Evaluaciones(string nombre,Alumno alumno,Asignatura asignatura,float nota){
      (Nombre,Alumno,Asignatura,Nota)=(nombre,alumno,asignatura,nota);
     
      }
    }

     
}