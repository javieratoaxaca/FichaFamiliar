using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFichaFamiliar.Vista
{
    public partial class frmPrincipal : Form
    {
        private Form activoFormulario = null; // para activacion de los formularios
        public frmPrincipal()
        {
            InitializeComponent();
            diseñoPersonalizado();
        }

        #region Encabezado frmPrincipal
        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaxFrm_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }
        private void btnMinFrm_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Minimized;
        }

        #endregion
        #region Personalizar Menu Lateral
        private void diseñoPersonalizado()
        {
            /*pnlSubMenuAdmin.Visible = false;
            pnlSubMenuMetas.Visible = false;*/
            subPnlBarraLaretal.Visible = false;
        }
        //metodo para Ocultar el Submenu
        private void ocultarSubMenu()
        {

            if (subPnlBarraLaretal.Visible == true)
                subPnlBarraLaretal.Visible = false;
        }
        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #endregion
        #region Menu Lateral
        private void bntFichaFamiliar_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subPnlBarraLaretal);
        }
        private void btnOpenFrmFichaFamiliar_Click(object sender, EventArgs e)
        {           
            abrirFormularioHijo(new frmFichaFamiliar());
            ocultarSubMenu();
        }

        #endregion
        #region Abrir Formularios
        private void abrirFormularioHijo(Form formHijo)
        {
            if (activoFormulario != null)
                activoFormulario.Close();

            activoFormulario = formHijo;
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            subPnlFrmCuerpo.Controls.Add(formHijo);
            subPnlFrmCuerpo.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }
        #endregion

        
    }
}
