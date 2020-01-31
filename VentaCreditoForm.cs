/*
 * Creado por SharpDevelop.
 * Usuario: Propietario
 * Fecha: 25/01/2020
 * Hora: 12:43 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace VentaCreditoContado
{
	/// <summary>
	/// Description of VentaCreditoForm.
	/// </summary>
	public partial class VentaCreditoForm : Form
	{
		static int[] letras = { 3,6,9,12 };
		static string[] productos = { "Lavadora","Refrigeradora","Licuadora",
			"Extractora","Radiograbadora","DVD","BluRay"};
		
		//Declaración de los ArrayList
		ArrayList aProductos = new ArrayList(productos);
		ArrayList aLetras = new ArrayList(letras);
		double tSubtotal = 0;

		public VentaCreditoForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void VentaCreditoFormLoad(object sender, EventArgs e)
		{
			cboLetras.DataSource = aLetras;
			cboProducto.DataSource = aProductos;
			mostrarFecha();
			mostrarHora();
			
			lvVenta.View = View.Details;
			lvVenta.GridLines = true;
			
			lvVenta.Columns.Add("ITEM", 80, HorizontalAlignment.Left);
			lvVenta.Columns.Add("DESCRIPCION DEL PRODUCTO.", 200, HorizontalAlignment.Left);
			lvVenta.Columns.Add("CANTIDAD", 83, HorizontalAlignment.Left);
			lvVenta.Columns.Add("PRECIO", 150, HorizontalAlignment.Left);
			lvVenta.Columns.Add("SUBTOTAL", 150, HorizontalAlignment.Left);
			
			lvResumen.View = View.Details;
			lvResumen.GridLines = true;
			
			lvResumen.Columns.Add("No. Letra", 80, HorizontalAlignment.Left);
			lvResumen.Columns.Add("Monto.", 200, HorizontalAlignment.Left);
		}
		
		void mostrarFecha()
		{
			lblFecha.Text = DateTime.Now.ToShortDateString();
		}
		
		void mostrarHora()
		{
			lblHora.Text = DateTime.Now.ToShortTimeString();
		}
		void BtnAdquirirClick(object sender, EventArgs e)
		{
			//Objeto de la clase Crédito
			Credito objCr = new Credito();
			
			//Datos del cliente
			objCr.cliente = txtCliente.Text;
			objCr.rfc = mskTxtRFC.Text;
			objCr.fecha = DateTime.Parse(lblFecha.Text);
			objCr.hora = DateTime.Parse(lblHora.Text);
			
			//Datos del producto
			objCr.producto = cboProducto.Text;
			objCr.cantidad = (int) numericUpDownCantidad.Value;
			
			//Imprimiendo en la lista
			ListViewItem fila = new ListViewItem(objCr.getX().ToString());
			fila.SubItems.Add(objCr.producto);
			fila.SubItems.Add(objCr.cantidad.ToString());
			fila.SubItems.Add(objCr.asignaPrecio().ToString("C"));
			fila.SubItems.Add(objCr.calculaSubtotal().ToString());
			lvVenta.Items.Add(fila);
			tSubtotal += objCr.calculaSubtotal();
			lblMonto.Text = tSubtotal.ToString("C");
		}
		
		void montoLetras(int le)
		{
//			double montoMensual = double.Parse(lblMonto.Text) / le;
			double montoMensual = tSubtotal / le;
			lvResumen.Items.Clear();
			for(int i=1;i<=le; i++)
			{
				ListViewItem fila = new ListViewItem(i.ToString());
				fila.SubItems.Add(montoMensual.ToString("C"));
				lvResumen.Items.Add(fila);
			}
		}
		
		void BtnResumenClick(object sender, EventArgs e)
		{
			int letras = int.Parse(cboLetras.Text);
			switch (letras)
			{
					case 3: montoLetras(3); break;
					case 6: montoLetras(6); break;
					case 9: montoLetras(9); break;
					case 12: montoLetras(12); break;
			}
		}
	}
}
