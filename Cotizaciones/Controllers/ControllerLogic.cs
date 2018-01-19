using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cotizaciones.Data;
using Cotizaciones.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Cotizaciones.Controllers
{
    public class ControllerLogic : Controller{

        /// <summary>
        /// Metodo para probar rut en el metodo validar rut
        /// </summary>
        /// <param name="rut">string</param>
        /// <returns>Cliente</returns>
        public Cliente probarRut(string rut){
            var cliente = new Cliente();
            cliente.Rut = rut;
            if(!validarRut(cliente.Rut)){
                throw new ArgumentException("RUT no valido");
            }
            return cliente;
        }

         /// <summary>
        /// Metodo para probar el correo en el validar correo
        /// </summary>
        /// <param name="correo">string</param>
        /// <returns>Cliente</returns>
        public Cliente probarCorreo(string correo){
            var cliente = new Cliente();
            cliente.Correo = correo;
            if(!CorreoValido(cliente.Correo)){
                throw new ArgumentException("CORREO no valido");
            }
            return cliente;
        }

        /// <summary>
        /// Metodo Validar rut de los clientes
        /// </summary>
        /// <param name="rut">string</param>
        /// <returns>boolean</returns>
        public bool validarRut(string rut ) {
                    
            bool validacion = false;
            try {
                rut =  rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
        
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));
        
                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10) {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char) (s != 0 ? s + 47 : 75)) {
                validacion = true;
                }
            } catch (Exception) {
            }
            return validacion;
        }

        /// <summary>
        /// Un variable global para declararlo en los metodos para validar el correo
        /// </summary>
        bool invalid = false;

        /// <summary>
        /// Metodo Correo Valido que verifica si cumple todos los requisitos minimos en un correo
        /// </summary>
        /// <param name="correo">string</param>
        /// <returns>Bool</returns>
        public bool CorreoValido(string correo)
        {
            invalid = false;
            if (String.IsNullOrEmpty(correo))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try {
                correo = Regex.Replace(correo, @"(@)(.+)$", this.DomainMapper,
                                        RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException) {
                return false;
            }

                if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try {
                return Regex.IsMatch(correo,
                        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException) {
                return false;
            }
        }

        /// <summary>
        /// Metodo dominio mapper usado para validar un correo
        /// </summary>
        /// <param name="match">Match</param>
        /// <returns>string</returns>
        private string DomainMapper(Match match)
        {
            // IdnMapping cque ya viene con unidades por defecto.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException) {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}