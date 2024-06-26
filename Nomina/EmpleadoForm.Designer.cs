namespace Nomina
{
    partial class EmpleadoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvEmpleado = new DataGridView();
            btnAdd = new Button();
            checkEmpleado = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleado).BeginInit();
            SuspendLayout();
            // 
            // dgvEmpleado
            // 
            dgvEmpleado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleado.Dock = DockStyle.Bottom;
            dgvEmpleado.Location = new Point(0, 188);
            dgvEmpleado.Name = "dgvEmpleado";
            dgvEmpleado.Size = new Size(532, 200);
            dgvEmpleado.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(71, 126);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // checkEmpleado
            // 
            checkEmpleado.AutoSize = true;
            checkEmpleado.Location = new Point(385, 47);
            checkEmpleado.Name = "checkEmpleado";
            checkEmpleado.Size = new Size(60, 19);
            checkEmpleado.TabIndex = 2;
            checkEmpleado.Text = "Activo";
            checkEmpleado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(170, 22);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 3;
            label1.Text = "DATOS DEL EMPLEADO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 79);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(131, 76);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(215, 23);
            txtNombre.TabIndex = 5;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(190, 126);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(318, 126);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // EmpleadoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 388);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkEmpleado);
            Controls.Add(btnAdd);
            Controls.Add(dgvEmpleado);
            Name = "EmpleadoForm";
            Text = "EmpleadoForm";
            ((System.ComponentModel.ISupportInitialize)dgvEmpleado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmpleado;
        private Button btnAdd;
        private CheckBox checkEmpleado;
        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private Button btnUpdate;
        private Button b;
        private Button btnDelete;
    }
}