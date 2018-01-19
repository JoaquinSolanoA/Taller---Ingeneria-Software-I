using System;
using Xunit;
using Cotizaciones.Models;
using Cotizaciones.Controllers; 
/// <summary>
/// Archivo que se esta usando para las pruebas testing.
/// </summary>
namespace CotizacionesTes {

    /// <summary>
    /// Clase que realiza distintaas pruebas para la verificaciones de metodos.
    /// </summary>
    public class CotizacionTest {

        /// <summary>
        /// Pruebas unitaria que demuestra si el rut esta correcto
        /// </summary>
        [Fact]
        public void excepcionDeRutValido() {

            var logic = new ControllerLogic();
            var rut = "17564233-3";
            Exception valido = Assert.Throws<ArgumentException>(() => logic.probarRut(rut));
            Assert.Equal("RUT no valido", valido.Message);
        }

        /// <summary>
        /// Prueba unitaria de dstintos casos en el metodo validar rut
        /// </summary>
        [Theory]
        [InlineData("19907154-4")]
        [InlineData("12.907.154-4")]
        [InlineData("12.907.abc-4")]
        [InlineData("12.907.abc4")]
        [InlineData("12.907.1234")]
        public void excepcionDeRutValidoConOtrosCasos(string rut) {
            
            var logic = new ControllerLogic();
            Exception valido = Assert.Throws<ArgumentException>(() => logic.probarRut(rut));
            Assert.Equal("RUT no valido", valido.Message);
        }

        /// <summary>
        /// Pruebas unitaria que demuestra si el correo esta correcto
        /// </summary>
        [Fact]
        public void excepcionDeCorreoValido() {

            var logic = new ControllerLogic();
            var correo = "david.jones@proseware.com";
            Exception valido = Assert.Throws<ArgumentException>(() => logic.probarCorreo(correo));
            Assert.Equal("CORREO no valido", valido.Message);
        }

        /// <summary>
        /// Prueba unitaria de dstintos casos en el metodo validar rut
        /// </summary>
        [Theory]
        [InlineData("jones@ms1.proseware.com")]
        [InlineData("j@proseware.com9")]
        [InlineData("j.s@server1.proseware.com")]
        [InlineData("j.@server1.proseware.com")]
        [InlineData("j..s@proseware.com")]
        public void excepcionDeCorreoValidoConOtrosCasos(string correo) {
            
            var logic = new ControllerLogic();
            Exception valido = Assert.Throws<ArgumentException>(() => logic.probarCorreo(correo));
            Assert.Equal("CORREO no valido", valido.Message);
        }
    }
}
