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
/// <summary>
/// Archivo donde se define los controladores
/// </summary>
namespace Cotizaciones.Controllers
{
    /// <summary>
    /// 
    /// </summary>
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
        /// Metodo Correo Valido que verifica si cumple todos los requisitos minimos en un correo
        /// </summary>
        /// <param name="correo">string</param>
        /// <returns>Bool</returns>
        public bool CorreoValido(string correo) {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(correo,expresion))
            {
                if (Regex.Replace(correo, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}