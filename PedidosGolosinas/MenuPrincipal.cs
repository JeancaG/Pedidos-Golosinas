using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PedidosGolosinas
{
    public partial class MenuPrincipal : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        FrmProducto frmProducto = null;

        private void ListarProductosToolStripButton1_Click(object sender, EventArgs e)
        {
            if (frmProducto == null)
            {
                frmProducto = new FrmProducto();
                frmProducto.MdiParent = this;
                frmProducto.FormClosed += FrmProducto_FormClosed;
                frmProducto.Show();
            }
            else
            {
                frmProducto.Activate();
            }
        }

        private void FrmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducto = null;
        }
    }
}
