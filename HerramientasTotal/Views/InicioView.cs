using Guna.UI2.Designer;
using Guna.UI2.WinForms;
using Guna.Charts.WinForms;
using HerramientasTotal.Views;
using HerramientasTotal.Views.Productos;
using HerramientasTotal.Extras;

namespace HerramientasTotal
{
    public partial class InicioView : Form
    {




        private readonly Dictionary<Type, UserControl> _views = new();

        private T EnsureView<T>() where T : UserControl, new()
        {
            if (!_views.TryGetValue(typeof(T), out var view))
            {
                view = new T
                {
                    Dock = DockStyle.Fill
                };
                _views.Add(typeof(T), view);
                ViewHost.Controls.Add(view);
            }
            return (T)view;
        }

        private void ShowView<T>() where T : UserControl, new()
        {
            var targetView = EnsureView<T>();
            foreach (Control c in ViewHost.Controls)
            {
                c.Visible = false;
            }

            targetView.Visible = true;
            targetView.BringToFront();
        }

        public InicioView()
        {
            InitializeComponent();
            OcultarPaneles();
            ShowView<InicioUC>();
            BotonSeleccionado(btnInicio);
        }

        private Guna2GradientButton _actBtn;
        private void BotonSeleccionado(Guna2GradientButton btnColor)
        {
            if (_actBtn != null)
            {
                _actBtn.FillColor = Color.FromArgb(29, 27, 52); 
                _actBtn.FillColor2 = Color.FromArgb(26, 18, 39);
            }

            _actBtn = btnColor;
            _actBtn.FillColor = Color.FromArgb(73, 75, 201);
            _actBtn.FillColor2 = Color.FromArgb(73, 75, 201);
        }

        private void AbrircerrarPanel(Panel panel)
        {
            if (panel.Visible)
            {
                panel.Visible = false;
            }
            else if (!panel.Visible)
            {
                panel.Visible = true;
            }

        }


        private void OcultarPaneles()
        {
            PanelInventario.Visible = false;
            PanelVentas.Visible = false;
            PanelClientes.Visible = false;
            PanelPedidosEnvios.Visible = false;
            PanelFinanzas.Visible = false;
            PanelReportes.Visible = false;
            PanelPersonal.Visible = false;
            PanelNotificaciones.Visible = false;
            PanelConfiguraciones.Visible = false;
        }


        private void btnInventario_Click(object sender, EventArgs e)
        {
                AbrircerrarPanel(PanelInventario);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrircerrarPanel(PanelVentas);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrircerrarPanel(PanelClientes);
        }

        private void btnPedidosEnvios_Click(object sender, EventArgs e)
        {
            AbrircerrarPanel(PanelPedidosEnvios);
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            AbrircerrarPanel(PanelFinanzas);
        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            AbrircerrarPanel(PanelReportes);
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            AbrircerrarPanel(PanelPersonal);
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            AbrircerrarPanel(PanelNotificaciones);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            AbrircerrarPanel(PanelConfiguraciones);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            OcultarPaneles();
            ShowView<InicioUC>();
            BotonSeleccionado( btnInicio);

        }

        //INICIO DE INVENTARIO
        // PRODUCTOS    
        private void btnProductos_Click(object sender, EventArgs e)
        {
            ShowView<ProductosUC>();
            BotonSeleccionado(btnProductos);
        }
    }
}
