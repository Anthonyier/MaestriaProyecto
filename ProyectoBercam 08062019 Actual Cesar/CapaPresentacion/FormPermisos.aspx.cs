using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormPermisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];

            if (usuario.Id_Usuario != 1)
            {

                MultiView1.Visible = false;
                BtnBuscar.Visible = false;
                BtnBuscar.Enabled = false;
            }
        }
        protected void ButtonPersona_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void ButtPersona_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ButtCamion_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void ButCamion_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void ButtonRuta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void BtnPersConc_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 8;
        }
        

        

        protected void BuGuardar_Click(object sender, EventArgs e)
        {
            EntPermisoRutas Permiso = new EntPermisoRutas();

            if (CheckRuta.Checked)
            {
                Permiso.CrearRuta = 1;

            }
            if (CheckModificarRutas.Checked)
            {
                Permiso.ModificarRutas = 1;
            }
            if (CheckListaRut.Checked)
            {
                Permiso.ListaRutas = 1;
            }
            if (CheckProgram.Checked)
            {
                Permiso.ProgramaRutas = 1;
            }
            if (CheckAnular.Checked)
            {
                Permiso.AnularRutas = 1;
            }
            if (CheckEditar.Checked)
            {
                Permiso.ModificarProgramacion = 1;
            }
            //if (CheckConciliacion.Checked)
            //{
            //    Permiso.ConciliacionCobrar = 1;
            //}

            if (CheckListaProgram.Checked)
            {
                Permiso.ListaProgram = 1;
            }
            if (CheckConfirmar.Checked)
            {
                Permiso.ConfirmarRuta = 1;
            }
            if (CheckNoDespachar.Checked)
            {
                Permiso.NoDespachado = 1;
            }
            if (CheckAplicacion.Checked)
            {
                Permiso.Aplicacion = 1;
            }
            if (CheckDim.Checked)
            {
                Permiso.Dim = 1;
            }
            if (CheckConfDescarga.Checked)
            {
                Permiso.ConfDescarga = 1;
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permiso.Cod_Usua = us.Id_Usuario;
            Permiso.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permiso.Cod_UsuaReg != 0)
            {
                if (NegPermisoRutas.InsertarPermisos(Permiso) == 1)
                {
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Text = "Permisos denegados";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }

        }

        protected void ButGuardar_Click1(object sender, EventArgs e)
        {
            EntPermisoCamiones Permiso = new EntPermisoCamiones();

            if (CheckCamion.Checked)
            {
                Permiso.CrearCamion = 1;

            }
            if (CheckModCam.Checked)
            {
                Permiso.ModificarCamiones = 1;
            }
            if (CheckDocumCamion.Checked)
            {
                Permiso.DocumentoCamion = 1;
            }
            if (CheckLista.Checked)
            {
                Permiso.ListaCamion = 1;
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permiso.Cod_Usua = us.Id_Usuario;
            Permiso.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permiso.Cod_UsuaReg != 0)
            {
                if (NegPermisoCamiones.InsertarPermisos(Permiso) == 1)
                {
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Text = "Permisos denegados";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }
        }

        protected void BttnGuardar_Click(object sender, EventArgs e)
        {
            EntPermisoPersona Permiso = new EntPermisoPersona();

            if (chkInsertar.Checked)
            {
                Permiso.CrearPersona = 1;

            }
            if (ChkModificar.Checked)
            {
                Permiso.ModificarUsuario = 1;
            }
            if (ChkDeshab.Checked)
            {
                Permiso.Deshabilitar = 1;
            }
            if (ChkUsuario.Checked)
            {
                Permiso.CrearUsuario = 1;
            }
            if (ChkDocument.Checked)
            {
                Permiso.AgregarDocumentos = 1;
            }
            if (ChkLista.Checked)
            {
                Permiso.ListaPersona = 1;
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permiso.Cod_Usua = us.Id_Usuario;
            Permiso.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permiso.Cod_UsuaReg != 0)
            {
                EntPermisoPersona PerPer = NegPermisoPersona.BuscarPermiso(Permiso.Cod_UsuaReg);
                if (PerPer != null)
                {
                    NegPermisoPersona.ModificarPermiso(Permiso);
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    if (NegPermisoPersona.InsertarPermisos(Permiso) == 1)
                    {
                        lblError.Text = "Permisos Concedido";
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Permisos denegados";
                        lblError.Visible = true;
                    }
                }
                
            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void BConcRuta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void BttonConcCarro_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void BtBConci_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void BCarPersona_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
        }

        protected void BttonConcGuardar_Click(object sender, EventArgs e)
        {
            EntPermisosConciliaciones  Permiso = new EntPermisosConciliaciones();

            if (CheckListaConcCobrarRef.Checked)
            {
                Permiso.ListCobrRef = 1;

            }
            if (CheckListaConcCobrarCorp.Checked)
            {
                Permiso.ListCobrCorp = 1;
            }
            if (CheckListaConcCobrarAlcohol.Checked)
            {
                Permiso.ListCobrAlc = 1;
            }
            if (CheckListaConcCobrarAceite.Checked)
            {
                Permiso.ListCobrAceite = 1;
            }
            if (CheckListaConcPagarRef.Checked)
            {
                Permiso.ListPagarRef = 1;
            }
            if (CheckListaConcPagarCorp.Checked)
            {
                Permiso.ListPagarCorp = 1;
            }
            if (CheckListaConcPagarAlcohol.Checked)
            {
                Permiso.ListPagarAlc = 1;
            }
            if (CheckListaConcPagarAceite.Checked)
            {
                Permiso.ListPagarAcei = 1;
            }
            if (CheckAprobarRef.Checked)
            {
                Permiso.AsegRef = 1;
            }
            if (CheckAprobarCorp.Checked)
            {
                Permiso.AsegCorp = 1;
            }
            if (CheckAprobarAlcohol.Checked)
            {
                Permiso.AsegAlc = 1;
            }
            if (CheckAprobarAceite.Checked)
            {
                Permiso.AsegAceite = 1;
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permiso.Cod_Usua = us.Id_Usuario;
            Permiso.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permiso.Cod_UsuaReg != 0)
            {
                EntPermisosConciliaciones PermConci = NegPermisosConciliaciones.BuscarPermiso(Permiso.Cod_UsuaReg);
                if (NegPermisosConciliaciones.InsertarPermisos(Permiso) == 1)
                {
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Text = "Permisos denegados";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }
        }

        protected void BCaroGuia_Click(object sender, EventArgs e)
        {
            EntPermisosCarroGuias Permiso = new EntPermisosCarroGuias();
            if (CheckCarroGuia.Checked)
            {
                Permiso.CrearCarroGuia = 1;
            }
            if (CheckDetCarroGuia.Checked)
            {
                Permiso.CrearDetCarGuia = 1;
            }
            if (CheckConCarroGuia.Checked)
            {
                Permiso.CrearConcCarGuia = 1;
            }
            if (CheckListaDetCarroGuia.Checked)
            {
                Permiso.ListDetCarroGuia = 1;
            }
            if (CheckListConcCarroGuia.Checked)
            {
                Permiso.ListConcCarrroGuia = 1;
            }
            if (CheckAsegCarroGuia.Checked)
            {
                Permiso.AsegCarroGuia = 1;
            }
            if (CheckAprobCarroGuia.Checked)
            {
                Permiso.AprobCarroGuia = 1;
            }

            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permiso.Cod_Usua = us.Id_Usuario;
            Permiso.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permiso.Cod_UsuaReg != 0)
            {
                EntPermisosCarroGuias PerCamGuia = NegPermisosCarroGuia.BuscarPermiso(Permiso.Cod_UsuaReg);
                if (PerCamGuia != null)
                {
                    NegPermisosCarroGuia.ModificarPermiso(Permiso);
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    if (NegPermisosCarroGuia.InsertarPermisos(Permiso) == 1)
                    {
                        lblError.Text = "Permisos Concedido";
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Permisos denegados";
                        lblError.Visible = true;
                    }
                }
               
            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }
        }

        protected void ButVolCarroGuia_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void ButIrPersona_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 6;
        }

        protected void ButtGuardarPermAnticip_Click(object sender, EventArgs e)
        {
            EntPermisoAnticipos Permiso = new EntPermisoAnticipos();

            if (CheckPagarAnticipo.Checked)
            {
                Permiso.PagarAnticipo = 1;
            }
            if (CheckVerAnticipo.Checked)
            {
                Permiso.VerAnticipo = 1;
            }
            if (CheckModAnticipo.Checked)
            {
                Permiso.ModAnticipo = 1;
            }
            if (CheckEliminarAnticipo.Checked)
            {
                Permiso.EliminarAnticipo = 1;
            }
          

            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permiso.Cod_Usua = us.Id_Usuario;
            Permiso.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permiso.Cod_UsuaReg != 0)
            {
                EntPermisoAnticipos PerAnticipos = NegPermisoAnticipos .BuscarPermiso(Permiso.Cod_UsuaReg);
                if (PerAnticipos != null)
                {
                    NegPermisoAnticipos.ModificarPermiso(Permiso);
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    if (NegPermisoAnticipos.InsertarPermisos(Permiso) == 1)
                    {
                        lblError.Text = "Permisos Concedido";
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Permisos denegados";
                        lblError.Visible = true;
                    }
                }

            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ButVolPagAdelant_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 7;
        }

        protected void ButtonAServicios_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 8;
        }

        protected void ButVolPagados_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 6;
        }

        protected void ButAnticVolver_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
        }

        protected void ButAdelantoDePagoVol_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 7;
        }

        protected void ButGuardarPago_Click(object sender, EventArgs e)
        {
            EntPermisosPagos Permiso = new EntPermisosPagos();

            if (CheckPagarLiquidacion.Checked)
            {
                Permiso.ImagenesPagadas = 1;
            }
            if (CheckPagarliquidacionAceite.Checked)
            {
                Permiso.ImagenesPagadasAceite = 1;
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permiso.Cod_Usuario = us.Id_Usuario;
            Permiso.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permiso.Cod_UsuaReg != 0)
            {
                EntPermisosPagos PerPagos = NegPermisosPagos.BuscarPermiso(Permiso.Cod_UsuaReg);
                if (PerPagos != null)
                {
                    NegPermisosPagos.ModificarPermisos(Permiso);
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    if (NegPermisosPagos.InsertarPermisos(Permiso) == 1)
                    {
                        lblError.Text = "Permisos Concedido";
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Permisos denegados";
                        lblError.Visible = true;
                    }
                }

            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }
        }

        protected void ButtonGuardarPermAdelanto_Click(object sender, EventArgs e)
        {
            EntPermisosAdelantosDePago Permiso = new EntPermisosAdelantosDePago();
            if (CheckPagarAdelantoDePago.Checked)
            {
                Permiso.PagarAdelantoDePago = 1;
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permiso.Cod_Usuario = us.Id_Usuario;
            Permiso.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permiso.Cod_UsuaReg != 0)
            {
                EntPermisosAdelantosDePago PerAdel = NegPermisosAdelantosDePago.BuscarPermiso(Permiso.Cod_UsuaReg);
                if (PerAdel != null)
                {
                    NegPermisosAdelantosDePago.ModificarPermiso(Permiso);
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    if (NegPermisosAdelantosDePago.InsertarPermisos(Permiso) == 1)
                    {
                        lblError.Text = "Permisos Concedido";
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Permisos denegados";
                        lblError.Visible = true;
                    }
                }

            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }
        }

        protected void ButonGuardarServicios_Click(object sender, EventArgs e)
        {
            EntPermisosServicios Permisos = new EntPermisosServicios();
            if (CheckGuardarTelefono.Checked)
            {
                Permisos.GuardarTelefono = 1;
            }
            if(CheckModificarTelefono.Checked)
            {
                Permisos.ModificarTelefono = 1;
            }
            if (CheckEliminarTelefono.Checked)
            {
                Permisos.EliminarTelefono = 1;
            }
            if (CheckGuardarRastreo.Checked)
            {
                Permisos.GuardarRastreo = 1;
            }
            if (CheckModificarRastreo.Checked)
            {
                Permisos.ModificarRastreo = 1;
            }
            if (CheckEliminarRastreo.Checked)
            {
                Permisos.EliminarRastreo = 1;
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            Permisos.Cod_Usuario = us.Id_Usuario;
            Permisos.Cod_UsuaReg = NegUsuario.Usua(txtBuscar.Text);
            if (Permisos.Cod_UsuaReg != 0)
            {
                EntPermisosServicios PerServicios = NegPermisosServicios.BuscarPermiso(Permisos.Cod_UsuaReg);
                if (PerServicios != null)
                {
                    NegPermisosServicios.ModificarPermisos(Permisos);
                    lblError.Text = "Permisos Concedido";
                    lblError.Visible = true;
                }
                else
                {
                    if (NegPermisosServicios.InsertarPermisos(Permisos) == 1)
                    {
                        lblError.Text = "Permisos Concedido";
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Permisos denegados";
                        lblError.Visible = true;
                    }
                }

            }
            else
            {
                lblError.Text = "Permisos denegados";
                lblError.Visible = true;
            }
        }

        
    }
}