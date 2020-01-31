/*
 * Creado por SharpDevelop.
 * Usuario: Propietario
 * Fecha: 25/01/2020
 * Hora: 12:44 a. m.
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
	/// Description of VentaContadoForm.
	/// </summary>
	public partial class VentaContadoForm : Form
	{
					//Inicialización del arreglo de productos
			static string[] productos = { "Lavadora","Refrigeradora","Licuadora","Extractora","Radiograbadora","DVD","BluRay"};
			
			//Creando el objeto de la clase ArrayList
			ArrayList aProductos = new ArrayList(productos);
			
			//Variable acumuladora de totales
			double tSubtotal = 0;
			
		public VentaContadoForm()
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			
			// TODO: Add constructor code after the InitializeComponent() call.

		}
		
		void VentaContadoFormLoad(object sender, EventArgs e)
		{
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
		}
		
		void mostrarFecha()
		{
			lblFecha.Text = DateTime.Now.ToShortDateString();
		}
		
		void mostrarHora()
		{
			lblHora.Text = DateTime.Now.ToShortTimeString();
		}
		
		void listado(Contado objC)
		{
			tSubtotal += objC.calculaSubtotal();
			lstResumen.Items.Clear();
			lstResumen.Items.Add("** RESUMEN DE VENTA **");
			lstResumen.Items.Add("-------------------------------------");
			lstResumen.Items.Add("CLIENTE: " + objC.cliente);
			lstResumen.Items.Add("RFC: " + objC.rfc);
			lstResumen.Items.Add("FECHA: " + objC.fecha);
			lstResumen.Items.Add("HORA: " + objC.hora);
			lstResumen.Items.Add("-------------------------------------");
			lstResumen.Items.Add("SUBTOTAL: " + tSubtotal.ToString("C"));
			double descuento = objC.calculaDescuento(tSubtotal);
			double neto = objC.calculaNeto(tSubtotal, descuento);
			lstResumen.Items.Add("DESCUENTO: " + descuento.ToString("C"));
			lstResumen.Items.Add("NETO: " + neto.ToString("C"));
			//Hallar el monto total sin descuento
			lblNeto.Text = neto.ToString("C");
		}
		
		void BtnAdquirirClick(object sender, EventArgs e)
		{
			//Objeto de la clase Contado
			Contado objC = new Contado();
			
			//Datos del cliente
			objC.cliente = txtCliente.Text;
			objC.rfc = mskTxtRFC.Text;
			objC.fecha =DateTime.Parse(lblFecha.Text);
			objC.hora = DateTime.Parse(lblHora.Text);
			
			//Datos del producto
			objC.producto = cboProducto.Text;
			objC.cantidad = (int) numericUpDownCantidad.Value;
			
			//Imprimiendo en la lista
			ListViewItem fila = new ListViewItem(objC.getN().ToString());
			fila.SubItems.Add(objC.producto);
			fila.SubItems.Add(objC.cantidad.ToString());
			fila.SubItems.Add(objC.asignaPrecio().ToString("C"));
			fila.SubItems.Add(objC.calculaSubtotal().ToString());
			lvVenta.Items.Add(fila);
			
			listado(objC);
		}

	}
}
