/*
 * Creado por SharpDevelop.
 * Usuario: Propietario
 * Fecha: 25/01/2020
 * Hora: 01:46 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace VentaCreditoContado
{
	/// <summary>
	/// Description of Credito.
	/// </summary>
	public class Credito:Venta
	{
		public static int x;
		public Credito()
		{
			x++;
		}
		public int getX()
		{
			return x;
		}
		
		//Atributos de la clase Crédito
		public int letras { get; set; }
		
		//Metodos de la clase Crédito
		public double calculaMontoInteres()
		{
			switch (letras)
			{
					case 3: return 5.0 / 100 * calculaSubtotal();
					case 6: return 10.0 / 100 * calculaSubtotal();
					case 9: return 15.0 / 100 * calculaSubtotal();
					case 12: return 25.0 / 100 * calculaSubtotal();
			}
			return 0;
		}
		
		public double calculaMontoMensual()
		{
			return (calculaSubtotal()+calculaMontoInteres())/letras;
		}
	}
}
