using System;
using System.Collections.Generic;

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
        /// <summary>
        /// Variable Identificador de la Cotizacion
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Variable Identificador del Cliente de la Cotizacion
        /// </summary>
        public int ClienteId { get; set; }
        /// <summary>
        /// Variable N° Referencia de la Cotizacion
        /// </summary>
        public int NReferencia { get; set; }
        /// <summary>
        /// Variable Total Neto de la suma de los servicios en la Cotizacion
        /// </summary>
        public double TotalNeto { get; set; }
        /// <summary>
        /// Variable Impuesto de la Cotizacion, que es el 19%
        /// </summary>
        public double Impuesto { get; set; }
        /// <summary>
        /// Variable Total de la Cotizacion despues de aplicar el 19%
        /// </summary>
        public double TotalCotizacion { get; set; }
        /// <summary>
        /// Variable Fecha de Emision de la Cotizacion
        /// </summary>
        public DateTime FechaEmision { get; set; }
        /// <summary>
        /// Variable Fecha de Vencimiento de la Cotizacion
        /// </summary>        
        public DateTime FechaVencimiento { get; set; }
        /// <summary>
        /// Variable Cliente de tipo Cliente para referenciar al cliente a la Cotizacion
        /// </summary>
        public Cliente Cliente { get; set; }
        /// <summary>
        /// Coleccion de Servicios
        /// </summary>
        public ICollection<Servicio> Servicios { get; set; }
    }
}