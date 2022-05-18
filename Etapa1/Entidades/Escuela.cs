namespace CoreEscuela.Entidades
{
   public class Escuela:ObjetoEscuelaBase, ILugar
    {
 public int AnioDeCreacion { get; set; }
  public string Pais { get; set; }
  public string Ciudad { get; set; }
  public string Direccion { get; set;}

  

  public TiposEscuela TipoEscuela { get; set; }

  public List<Curso> Cursos{get; set;}

    public Escuela(string nombre,int anio)=>(Nombre,AnioDeCreacion)=(nombre,anio);
  public Escuela(string nombre,int anio,TiposEscuela tipo, string pais ="",string ciudad = ""){
      (Nombre,AnioDeCreacion)=(nombre,anio);
      Pais = pais;
      Ciudad = ciudad;
      }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela}\nPais: {Pais}, Ciudad: {Ciudad}";
        }

         public void LimpiarLugar(){
       Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela..");
            
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            
            Printer.WriteTitle($"Escuela {Nombre} Limpia");
            Printer.Beep(1000, cantidad:3);
   }
    }
}
