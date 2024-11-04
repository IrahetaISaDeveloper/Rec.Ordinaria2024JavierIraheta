using Refuerzo2024.Controller.Facultades_y_Especialidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.View.Facultades_y_Especialidades
{
    public partial class ViewFacultadesEspecialidades : Form
    {
        public ViewFacultadesEspecialidades()
        {
            InitializeComponent();
            ControllerEspecialidadesYFacultades control = new ControllerEspecialidadesYFacultades(this);
        }
    }
}
