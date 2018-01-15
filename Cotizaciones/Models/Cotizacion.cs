using System;

/// <summary>
/// Archivo donde se definen las clases del Dominio del problema
/// </summary>
namespace Cotizaciones.Models {

    /// <summary>
    /// Clase que representa a una cotizacion en el Sistema
    /// </summary>
    /// <remarks>
    /// Esta clase pertenece al modelo del Dominio y posee las siguientes restricciones:
    /// - No permite valores null en sus atributos.
    /// </remarks>
    public class Cotizacion {

        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int NReferencia { get; set; }

        public double TotalNeto { get; set; }

        public double Impuesto { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaVencimiento{ get; set; }

        public Cliente Cliente { get; set; }
    }
}