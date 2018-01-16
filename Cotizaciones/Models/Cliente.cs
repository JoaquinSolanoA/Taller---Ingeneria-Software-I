/// <summary>
/// Archivo donde se definen las clases del Dominio del problema
/// </summary>
namespace Cotizaciones.Models {

    /// <summary>
    /// Clase que representa a un Cliente en el Sistema
    /// </summary>
    /// <remarks>
    /// Esta clase pertenece al modelo del Dominio y posee las siguientes restricciones:
    /// - No permite valores null en sus atributos.
    /// </remarks>
    public class Cliente {
        /// <summary>
        /// Variable Identificador del cliente
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Variable Rut del cliente
        /// </summary>
        public string Rut { get; set; }
        /// <summary>
        /// Variable Nombre del cliente
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Variable Apellido Paterno del cliente
        /// </summary>
        public string Paterno { get; set; }
        /// <summary>
        /// Variable Apellido Materno del cliente
        /// </summary>
        public string Materno { get; set; }
        /// <summary>
        /// Variable Direccion de la ubicacion del cliente
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Variable Correo del cliente
        /// </summary>
        public string Correo { get; set; }
    }
}