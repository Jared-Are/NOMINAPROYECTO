using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels;
using SharedModels.Dto;

namespace Nomina
{
    public partial class EmpleadoForm : Form
    {

        private readonly ApiClient _apiClient;

        public EmpleadoForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void EmpleadoForm_Load(object sender, EventArgs e)
        {
            await LoadEmpleadosAsync();
        }

        private async Task LoadEmpleadosAsync()
        {
            try
            {
                var students = await _apiClient.Empleados.GetAllAsync();
                dgvEmpleado.DataSource = students.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newEmpleado = new EmpleadoCreateDto
            {
                /*aña
                Name = txtName.Text,
                Registered = chkRegistered.Checked*/
            };

            try
            {
                var success = await _apiClient.Empleados.CreateAsync(newEmpleado);

                MessageBox.Show("¡Empleado agregado correctamente!", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
                await LoadEmpleadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar Empleado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            /* txtName.Clear();
             chkRegistered.Checked = false;*/
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmpleado.SelectedRows.Count > 0)
            {
                var selectedEmpleado = (EmpleadoDto)dgvEmpleado.SelectedRows[0].DataBoundItem;
                var updateEmpleado = new EmpleadoDto
                {
                    /*StudentId = selectedStudent.StudentId,
                    Name = txtName.Text,
                    Registered = chkRegistered.Checked*/
                };

                try
                {
                    var success = await _apiClient.Empleados.UpdateAsync(selectedEmpleado.EmpleadoId,
                updateEmpleado);

                    if (success)
                    {
                        MessageBox.Show("¡Empleado actualizado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                        await LoadEmpleadosAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar Empleado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar Empleado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para actualizar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var Empleado = (EmpleadoDto)dgvEmpleado.Rows[e.RowIndex].DataBoundItem;
                //txtName.Text = Empleado.Nombre;
                // chkRegistered.Checked = Empleado.Estado;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmpleado.Rows.Count > 0)
            {
                var selectedEmpleado =
                    (EmpleadoDto)dgvEmpleado.SelectedRows[0].DataBoundItem;
                var result =
                    MessageBox.Show($"¿Está seguro de que desea eliminar el empleado '{selectedEmpleado.Nombre}'?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var sucess =
                    await _apiClient.Empleados.DeleteAsync(selectedEmpleado.EmpleadoId);
                        if (sucess)
                        {//sigue dando error

                            MessageBox.Show("¡Empleado eliminado exitosamente!", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadEmpleadosAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Error al eliminar empleado.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar empleado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para eliminar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
