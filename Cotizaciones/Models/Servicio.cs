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

        public int Id { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public double ValorUnitario { get; set; }

        public double TotalValor { get; set; }

    }
}