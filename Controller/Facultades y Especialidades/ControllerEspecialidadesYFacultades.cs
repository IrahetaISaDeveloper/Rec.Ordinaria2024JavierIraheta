using Refuerzo2024.Model.DAO;
using Refuerzo2024.View.Facultades_y_Especialidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.Controller.Facultades_y_Especialidades
{
    internal class ControllerEspecialidadesYFacultades
    {
        ViewFacultadesEspecialidades objEspeFacus;

        public ControllerEspecialidadesYFacultades(ViewFacultadesEspecialidades vista)
        {
            this.objEspeFacus = vista;
            objEspeFacus.Load += new EventHandler(CargaInicial);
            objEspeFacus.btnAgregarFacu.Click += new EventHandler(RegistrarFacu);
            objEspeFacus.dgvFacultades.CellClick += new DataGridViewCellEventHandler(SeleccionarDatoFacu);
            objEspeFacus.btnActualizarFacu.Click += new EventHandler(ActualizarFacu);
            objEspeFacus.btnEliminarFacu.Click += new EventHandler(EliminarFacu);
            objEspeFacus.btnBuscarFacu.Click += new EventHandler(BuscarFacu);

            //Especialidades
            objEspeFacus.btnAgregarEspe.Click += new EventHandler(RegistrarEspe);
            objEspeFacus.dgvEspecialidades.CellClick += new DataGridViewCellEventHandler(SeleccionarDatoEspe);
            objEspeFacus.btnActualizarEspe.Click += new EventHandler(ActualizarEspe);
            objEspeFacus.btnEliminarEspe.Click += new EventHandler(EliminarEspe);
            objEspeFacus.btnBuscarEspecialidad.Click += new EventHandler(BuscarEspe);
        }

        public void SeleccionarDatoFacu(object sender, DataGridViewCellEventArgs e)
        {
            //Capturar la fila a la que se le dió click
            int pos = objEspeFacus.dgvFacultades.CurrentRow.Index;
            //Enviar los datos del DataGridView hacia los controles
            objEspeFacus.txtIDFacultad.Text = objEspeFacus.dgvFacultades[0, pos].Value.ToString();
            objEspeFacus.txtNombreFacultad.Text = objEspeFacus.dgvFacultades[1, pos].Value.ToString();
        }

        public void SeleccionarDatoEspe(object sender, DataGridViewCellEventArgs e)
        {
            //Capturar la fila a la que se le dió click
            int pos = objEspeFacus.dgvEspecialidades.CurrentRow.Index;
            //Enviar los datos del DataGridView hacia los controles
            objEspeFacus.txtIdEspecialidad.Text = objEspeFacus.dgvEspecialidades[0, pos].Value.ToString();
            objEspeFacus.txtNombreEspecialidad.Text = objEspeFacus.dgvEspecialidades[1, pos].Value.ToString();
            objEspeFacus.txtIDFacultad.Text = objEspeFacus.dgvEspecialidades[2, pos].Value.ToString();
        }

        public void CargaInicial(object sender, EventArgs e)
        {
            LlenarComboFacultades();
            LlenarDataGridViewFacu();
            LlenarDataGridViewEspe();
        }

        private void LlenarComboFacultades()
        {
            //Se crea objeto del DAOEstudiantes para accesar a todos los metodos contenidos en la clase.
            DAOFacultadesEspecialidades obj = new DAOFacultadesEspecialidades();
            //Se crea un DataSet que almacenará los valores que retorne el metodo.
            DataSet ds = obj.ObtenerFacultades();
            //Llenamos el combobox
            objEspeFacus.cmbFacultad.DataSource = ds.Tables["Facultades"];
            //Se indica que campo se mostrará al usuario
            objEspeFacus.cmbFacultad.DisplayMember = "nombreFacultad";
            //Se indica que valor será seleccionado dependiendo de lo que elija el usuario
            objEspeFacus.cmbFacultad.ValueMember = "idFacultad";
        }

        private void LlenarDataGridViewFacu()
        {
            //Se crea objeto del DAOEstudiantes para accesar a todos los metodos contenidos en la clase.
            DAOFacultadesEspecialidades obj = new DAOFacultadesEspecialidades();
            //Se crea un DataSet que almacenará los valores que retorne el metodo.
            DataSet ds = obj.ObtenerFacultades();
            //Llenamos el combobox
            objEspeFacus.dgvFacultades.DataSource = ds.Tables["Facultades"];
        }

        private void LlenarDataGridViewEspe()
        {
            //Se crea objeto del DAOEstudiantes para accesar a todos los metodos contenidos en la clase.
            DAOFacultadesEspecialidades obj = new DAOFacultadesEspecialidades();
            //Se crea un DataSet que almacenará los valores que retorne el metodo.
            DataSet ds = obj.ObtenerEspecialidades();
            //Llenamos el combobox
            objEspeFacus.dgvEspecialidades.DataSource = ds.Tables["Especialidades"];
        }

        public void RegistrarFacu(object sender, EventArgs e)
        {
            DAOFacultadesEspecialidades data = new DAOFacultadesEspecialidades();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.NombreFacultad = objEspeFacus.txtNombreFacultad.Text.Trim();
            //Se invoca al metodo RegistrarEstudiante y se verifica si su retorno es TRUE, de ser así significa que los datos pudieron ser
            //registrados correctamente,
            //de lo contrario, no se pudo registrar los valores.
            if (data.RegistrarFacultad() == true)
            {
                MessageBox.Show("Datos registrados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RegistrarEspe(object sender, EventArgs e)
        {
            DAOFacultadesEspecialidades data = new DAOFacultadesEspecialidades();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.NombreEspecialidades = objEspeFacus.txtNombreEspecialidad.Text.Trim();
            data.IdFacultad = (int)objEspeFacus.cmbFacultad.SelectedValue;
            //Se invoca al metodo RegistrarEstudiante y se verifica si su retorno es TRUE, de ser así significa que los datos pudieron
            //ser registrados correctamente, de lo contrario, no se pudo registrar los valores.
            if (data.RegistrarEspecialidad() == true)
            {
                MessageBox.Show("Datos registrados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarFacu(object sender, EventArgs e)
        {
            DAOFacultadesEspecialidades data = new DAOFacultadesEspecialidades();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.IdFacultad = int.Parse(objEspeFacus.txtIDFacultad.Text.Trim().ToString());
            data.NombreFacultad = objEspeFacus.txtNombreFacultad.Text.Trim();
            if (data.ActualizarFacultad() == true)
            {
                MessageBox.Show("Los datos fueron actualizados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDataGridViewFacu();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados.", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarEspe(object sender, EventArgs e)
        {
            DAOFacultadesEspecialidades data = new DAOFacultadesEspecialidades();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.IdEspecialidad = int.Parse(objEspeFacus.txtIdEspecialidad.Text.Trim().ToString());
            data.NombreEspecialidades = objEspeFacus.txtNombreEspecialidad.Text.Trim();
            data.IdFacultad = (int)objEspeFacus.cmbFacultad.SelectedValue;
            if (data.ActualizarEspecialidad() == true)
            {
                MessageBox.Show("Los datos fueron actualizados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDataGridViewEspe();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados.", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarFacu(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(objEspeFacus.txtIDFacultad.Text.Trim()))
            {
                MessageBox.Show("Seleccione un registro", "Seleccione un valor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOFacultadesEspecialidades data = new DAOFacultadesEspecialidades();
                data.IdFacultad = int.Parse(objEspeFacus.txtIDFacultad.Text);
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (data.EliminarFacu() == true)
                    {
                        MessageBox.Show("El dato fue eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDataGridViewFacu();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser eliminado", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void EliminarEspe(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(objEspeFacus.txtIdEspecialidad.Text.Trim()))
            {
                MessageBox.Show("Seleccione un registro", "Seleccione un valor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOFacultadesEspecialidades data = new DAOFacultadesEspecialidades();
                data.IdEspecialidad = int.Parse(objEspeFacus.txtIdEspecialidad.Text);
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (data.EliminarEspecialidad() == true)
                    {
                        MessageBox.Show("El dato fue eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDataGridViewFacu();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser eliminado", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void BuscarEspe(object sender, EventArgs e)
        {
            DAOFacultadesEspecialidades data = new DAOFacultadesEspecialidades();
            DataSet ds = data.BuscarEspecialidad(objEspeFacus.txtBuscarEspecialidad.Text.Trim());
            objEspeFacus.dgvEspecialidades.DataSource = ds.Tables["Especialidades"];
        }

        public void BuscarFacu(object sender, EventArgs e)
        {
            DAOFacultadesEspecialidades data = new DAOFacultadesEspecialidades();
            DataSet ds = data.BuscarFacultad(objEspeFacus.txtBuscarFacu.Text.Trim());
            objEspeFacus.dgvFacultades.DataSource = ds.Tables["Facultades"];
        }
    }
}
