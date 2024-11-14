using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocios
{
    public class NegImagenes
    {
        public static int InsertarImagen(EntImagenes obj)
        {
            return DOAImagenes.GuardarImagenes(obj); //DAOPersona.GuardarPersona(obj);//Nombres,Apellidos,CI,Direccion,Telefonos,TelfReferencia,Email,imgLicConducir,AntFelcn,AntRejap);
        }

        public static SqlDataReader ObtenerListaPersona()
        {
            return DOAImagenes.ObtenerListaPersona();
        }
        public static SqlDataReader ObtenerListaPersonaAndres()
        {
            return DOAImagenes.ObtenerListaPersonaAndres();
        }
        public static bool EnviarMensaje(string mensaje)
        {
            return DOAImagenes.EnviarCorreo(mensaje);
        }
        public static bool EnviarMensajeJefe(string Mensaje)
        {
            return DOAImagenes.EnviarCorreoJefe(Mensaje);
        }
        public static bool EnviarMensajeLuisHernan(string Mensaje)
        {
            return DOAImagenes.EnviarCorreoLuisHernan(Mensaje);
        }
        public static bool EnviarMensajeNatyMichelle(string Mensaje)
        {
            return DOAImagenes.EnviarCorreoNatalie(Mensaje);
        }
        public static bool EnviarMensajeVillamontes(string Mensaje)
        {
            return DOAImagenes.EnviarCorreoVillamontes(Mensaje);
        }
        public static bool EnviarMensajeAndres(string Mensaje)
        {
            return DOAImagenes.EnviarCorreoAndres(Mensaje);
        }
        public static EntImagenes ConsultaImagen(int CodEnte, int TipoImg)
        {
            return DOAImagenes.ConsultaImagen(CodEnte, TipoImg);
        }
        public static EntImagenes Download(int CodEnte, int TipoImg)
        {
            return DOAImagenes.Download(CodEnte, TipoImg);
        } 
        public static EntImagenes BuscarImagenes(int Cod_Ente, int Tipo_Imagen)
        {
            return DOAImagenes.ConsultaImagenes(Cod_Ente, Tipo_Imagen); //DAOPersona.GuardarPersona(obj);//Nombres,Apellidos,CI,Direccion,Telefonos,TelfReferencia,Email,imgLicConducir,AntFelcn,AntRejap);
        }
        public static EntImagenes BuscarImagenes1(int Cod_Ente)
        {
            return DOAImagenes.ConsultaImagenes1(Cod_Ente); //DAOPersona.GuardarPersona(obj);//Nombres,Apellidos,CI,Direccion,Telefonos,TelfReferencia,Email,imgLicConducir,AntFelcn,AntRejap);
        }
    }
}