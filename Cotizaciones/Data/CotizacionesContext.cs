using Microsoft.EntityFrameworkCore;
using Cotizaciones.Models;

/// <summary>
/// Archivo donde se definen el Context del problema
/// </summary>
namespace Cotizaciones.Data {
    /// <summary>
    /// Clase que representa el Context en el Sistema
    /// </summary>
    public class CotizacionesContext : DbContext {

        public CotizacionesContext(DbContextOptions<CotizacionesContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Utilizacion de SQLite como backend
            optionsBuilder.UseSqlite("Data Source=cotizaciones.db");
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Cotizacion> Cotizaciones { get; set; }

        public DbSet<Servicio> Servicios { get; set; }
    }
}