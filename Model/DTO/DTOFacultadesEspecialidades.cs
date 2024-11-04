using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refuerzo2024.Model.Conexion;

namespace Refuerzo2024.Model.DTO
{
    internal class DTOFacultadesEspecialidades : dbContext
    {
        //Metodos y atributos para Facultades
        private int idFacultad;
        private string nombreFacultad;


        //Metodos y atributos para Especialidades
        private int idEspecialidad;
        private string nombreEspecialidades;

        public int IdFacultad { get => idFacultad; set => idFacultad = value; }
        public string NombreFacultad { get => nombreFacultad; set => nombreFacultad = value; }

        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public string NombreEspecialidades { get => nombreEspecialidades; set => nombreEspecialidades = value; }
    }
}
