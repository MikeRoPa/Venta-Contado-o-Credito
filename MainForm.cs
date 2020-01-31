/*
 * Creado por SharpDevelop.
 * Usuario: Propietario
 * Fecha: 25/01/2020
 * Hora: 01:32 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VentaCreditoContado
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void VentaAContadoToolStripMenuItemClick(object sender, EventArgs e)
		{
			VentaContadoForm oForm = new VentaContadoForm();
			oForm.MdiParent = this;
			oForm.Show();
			
		}
		
		void VentaACreditoToolStripMenuItemClick(object sender, EventArgs e)
		{
			VentaCreditoForm oForm = new VentaCreditoForm();
			oForm.MdiParent = this;
			oForm.Show();
		}
		
		void SalirToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void BtnVentaContadoClick(object sender, EventArgs e)
		{
			VentaContadoForm oForm = new VentaContadoForm();
			oForm.MdiParent = this;
			oForm.Show();
		}
		void BtnVentaCreditoClick(object sender, EventArgs e)
		{
			VentaCreditoForm oForm = new VentaCreditoForm();
			oForm.MdiParent = this;
			oForm.Show();
		}
		void AYUDAToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Guia del usuario: \n \n" + "Venta de Producto de Contado y a Credito.","AYUDA:",MessageBoxButtons.OK);
		}

	}
}
