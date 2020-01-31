/*
 * Creado por SharpDevelop.
 * Usuario: Propietario
 * Fecha: 25/01/2020
 * Hora: 01:44 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace VentaCreditoContado
{
	/// <summary>
	/// Description of Contado.
	/// </summary>
	public class Contado:Venta
	{
		public static int n;
		public Contado()
		{
			n++;
		}
		public int getN()
		{
			return n;
		}
		
		//Metodos de la clase contado
		public double calculaDescuento(double subtotal)
		{
			if (subtotal < 1000)
				return 2.0 / 100 * subtotal;
			else if (subtotal >= 1000 && subtotal <= 3000)
				return 5.0 / 100 * subtotal;
			else
				return 12.0 / 100 * subtotal;
		}
		
		public double calculaNeto(double subtotal, double descuento)
		{
			return subtotal - descuento;
		}
	}
}
