namespace HerramientasTotal.Views.Productos
{
    partial class ProductosUC
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            errorInicio = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorInicio).BeginInit();
            SuspendLayout();
            // 
            // errorInicio
            // 
            errorInicio.ContainerControl = this;
            // 
            // ProductosUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            Name = "ProductosUC";
            Size = new Size(656, 492);
            ((System.ComponentModel.ISupportInitialize)errorInicio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ErrorProvider errorInicio;
    }
}
