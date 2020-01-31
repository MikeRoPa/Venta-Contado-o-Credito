/*
 * Creado por SharpDevelop.
 * Usuario: Propietario
 * Fecha: 25/01/2020
 * Hora: 01:41 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace VentaCreditoContado
{
	/// <summary>
	/// Description of Venta.
	/// </summary>
	public class Venta
	{
		//Atributos
		public string cliente { get; set; }
		public string rfc { get; set; }
		public DateTime fecha { get; set; }
		public DateTime hora { get; set; }
		public string producto { get; set; }
		public int cantidad { get; set; }
		
		//Metodos de la clase Venta
		public double asignaPrecio()
		{
			switch (producto)
			{
					case "Lavadora": return 1500;
					case "Refrigeradora": return 3500;
					case "Licuadora": return 500;
					case "Extractora": return 150;
					case "Radiograbadora": return 750;
					case "DVD": return 100;
					case "BluRay": return 250;
			}
			return 0;
		}
		
		//Método que calcula el subtotal
		public double calculaSubtotal()
		{
			return asignaPrecio() *cantidad;
		}

	}
}
