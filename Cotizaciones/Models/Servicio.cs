/// <summary>
/// Archivo donde se definen las clases del Dominio del problema
/// </summary>
namespace Cotizaciones.Models {

    /// <summary>
    /// Clase que representa los Servicios en el Sistema
    /// </summary>
    /// <remarks>
    /// Esta clase pertenece al modelo del Dominio y posee las siguientes restricciones:
    /// - No permite valores null en sus atributos.
    /// </remarks>
    public class Servicio {
        /// <summary>
        /// Variable Identificador del Servicio
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Variable Descripcion del Servicio
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Variable Cantidad del Servicio
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// Variable del Valor del Servicio
        /// </summary>
        public double ValorUnitario { get; set; }
        /// <summary>
        /// Variable del Total de servicio por su valor unitario por su cantidad
        /// </summary>
        public double TotalValor { get; set; }

    }
}