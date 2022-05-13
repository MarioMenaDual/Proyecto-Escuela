
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public EscuelaEngine(Escuela escuela) 
        {
            this.Escuela = escuela;
               
        }
                public Escuela Escuela { get; set; }

        public EscuelaEngine(){

        }

        public void Inicializar()
        {

            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");


            //Lista
            CargarCursos();
            CargarAsignaturas();

        
                 
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            Random rnd = new Random();
            foreach(var curso in Escuela.Cursos)
            {
                foreach(var asignatura in curso.Asignaturas)
                {
                    foreach(var alumno in curso.Alumnos)
                    {
                        
                        float nota = (rnd.Next(0, 5) * 1.0f) + (rnd.Next(0, 9) / 10.0f);								
                        var evaluacion = new Evaluaciones($"Evaluacion {asignatura.Nombre}",alumno,asignatura,nota);
                       alumno.Evaluaciones.Add(evaluacion);
                    }
                }
            }


        }

        private void CargarAsignaturas()
        {
           foreach (var curso in Escuela.Cursos)
           {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas"} ,
                            new Asignatura{Nombre="Educación Física"},
                            new Asignatura{Nombre="Castellano"},
                            new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
           }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
           string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos =  from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{ Nombre=$"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al)=>al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
     new Curso(){ Nombre="101",Jornada = TiposJornada.Manana},
    new Curso(){ Nombre="201",Jornada = TiposJornada.Manana},
    new Curso { Nombre="301",Jornada = TiposJornada.Manana},
    new Curso(){ Nombre="401",Jornada = TiposJornada.Tarde},
    new Curso { Nombre="501",Jornada = TiposJornada.Tarde}
};

 Random rnd = new Random();
            foreach(var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }
}