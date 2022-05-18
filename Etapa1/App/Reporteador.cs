using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if (dicObsEsc == null)
                throw new ArgumentNullException(nameof(dicObsEsc));

            _diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion,
                                                 out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
        }

 public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(
                    out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(
            out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;

                dictaRta.Add(asig, evalsAsig);
            }

            return dictaRta;
        }

public Dictionary<string, IEnumerable<object>> GetPromeAlumnPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDicEvaluaXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsAlumn = from eval in asigConEval.Value
                            group eval by new{
                                 eval.Alumno.UniqueId,
                                 eval.Alumno.Nombre}
                            into grupoEvalsAlumno
                            select new AlumnoPromedio
                            { 
                                alumnoid = grupoEvalsAlumno.Key.UniqueId,
                                alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.Nota)
                            };
                 
                 rta.Add(asigConEval.Key, promsAlumn);           
            }

            return rta;
        }

 public Dictionary<string, IEnumerable<Object>> GetTopPromedioPorCadaAsignatura(int top)
        {
            var respuesta = new Dictionary<string, IEnumerable<Object>>();
            var diccionarioEvaluacionesPorAsignatura = GetDicEvaluaXAsig();
            foreach (var asignaturaConEvaluaciones in diccionarioEvaluacionesPorAsignatura)
            {
                var promediosAlumnos = (from evaluacion in asignaturaConEvaluaciones.Value
                                        group evaluacion by new
                                        {
                                            evaluacion.Alumno.UniqueId,
                                            evaluacion.Alumno.Nombre
                                        }
                            into grupoEvaluacionesAlumno
                                        select new AlumnoPromedio
                                        {
                                            alumnoid = grupoEvaluacionesAlumno.Key.UniqueId,
                                            alumnoNombre = grupoEvaluacionesAlumno.Key.Nombre,
                                            promedio = grupoEvaluacionesAlumno.Average(evaluacion => evaluacion.Nota)
                                        }).OrderByDescending(alumno => alumno.promedio).Take(top);
                respuesta.Add(asignaturaConEvaluaciones.Key, promediosAlumnos);
            }
            return respuesta;
        }



    }}