using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormCuentaContable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                TextIdPadre.Text = Convert.ToString(Request.QueryString["Id"]);
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                EntCuentaContable obj = NegCuentaContable.BuscarCuenta(id);
                EntCuentaContable cu = NegCuentaContable.BuscarCuenta(id);
                
                string n = Convert.ToString(obj.Id1Nivel); ;
                TextNumeroOrden.Text = obj.NumerodeOrden;
                
                    if (obj.Id2Nivel == 0)
                    {
                        
                            if (NegCuentaContable.cant(id) == 0)
                            {
                                obj.Id2Nivel++;
                            }
                            else 
                            { 
                                obj.Id2Nivel =1 + NegCuentaContable.cant(id); 
                            }
                           
                        
                        n = n + "." + Convert.ToString(obj.Id2Nivel);
                        
                    }
                    else
                    {
                        if (obj.Id3Nivel == 0)
                        {
                            if (NegCuentaContable.cant(id) == 0)
                            {
                                obj.Id3Nivel++;
                            }
                            else
                            {
                                obj.Id3Nivel = 1 + NegCuentaContable.cant(id);
                            }

                            n = n + "." +Convert.ToString(obj.Id2Nivel)+"."+ Convert.ToString(obj.Id3Nivel);
                        }
                        else
                        {
                            if (obj.Id4Nivel == 0)
                            {
                                if (NegCuentaContable.cant(id) == 0)
                                {
                                    obj.Id4Nivel++;
                                }
                                else
                                {
                                    obj.Id4Nivel = 1 + NegCuentaContable.cant(id);
                                }
                                n = n + "." +Convert.ToString(obj.Id2Nivel)+"."+ Convert.ToString(obj.Id3Nivel)+"." + Convert.ToString(obj.Id4Nivel);
                            }
                            else
                            {
                                if (obj.Id5Nivel == 0)
                                {
                                    if (NegCuentaContable.cant(id) == 0)
                                    {
                                        obj.Id5Nivel++;
                                    }
                                    else
                                    {
                                        obj.Id5Nivel = 1 + NegCuentaContable.cant(id);
                                    }
                                    n = n + "." + Convert.ToString(obj.Id2Nivel) + "." + Convert.ToString(obj.Id3Nivel) + "." + Convert.ToString(obj.Id4Nivel) + "." + Convert.ToString(obj.Id5Nivel);
                                }

                            }
                        }
                    }

                TextNumeroOrden.Text = n;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TextNombredelaAccion.Text != "" && TextNumeroOrden.Text!="")
            {
                EntCuentaContable c = new EntCuentaContable();
                EntCuentaContable cu = new EntCuentaContable();
                cu.NombredelaAccion = TextNombredelaAccion.Text;
                cu.NumerodeOrden = TextNumeroOrden.Text;
                cu.Idpadre = int.Parse(TextIdPadre.Text);
                
                SqlDataReader d = NegCuentaContable.Nivel(cu.Idpadre);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        cu.Id1Nivel = Convert.ToInt32(d["N1"].ToString());
                        cu.Id2Nivel = Convert.ToInt32(d["N2"].ToString());
                        cu.Id3Nivel = Convert.ToInt32(d["N3"].ToString());
                        cu.Id4Nivel = Convert.ToInt32(d["N4"].ToString());
                        cu.Id5Nivel = Convert.ToInt32(d["N5"].ToString());
                        try
                        {
                            if (cu.Id2Nivel == 0)
                            {

                                if (NegCuentaContable.cant(cu.Idpadre) == 0)
                                {
                                    cu.Id2Nivel++;
                                }
                                else
                                {
                                    cu.Id2Nivel = 1 + NegCuentaContable.cant(cu.Idpadre);
                                }

                            }
                            else
                            {
                                if (cu.Id3Nivel == 0)
                                {
                                    if (NegCuentaContable.cant(cu.Idpadre) == 0)
                                    {
                                        cu.Id3Nivel++;
                                    }
                                    else
                                    {
                                        cu.Id3Nivel = 1 + NegCuentaContable.cant(cu.Idpadre);
                                    }

                                    
                                }
                                else
                                {
                                    if (cu.Id4Nivel == 0)
                                    {
                                        if (NegCuentaContable.cant(cu.Idpadre) == 0)
                                        {
                                            cu.Id4Nivel++;
                                        }
                                        else
                                        {
                                            cu.Id4Nivel = 1 + NegCuentaContable.cant(cu.Idpadre);
                                        }
                                    }
                                    else
                                    {
                                        if (cu.Id5Nivel == 0)
                                        {
                                            if (NegCuentaContable.cant(cu.Idpadre) == 0)
                                            {
                                                cu.Id5Nivel++;
                                            }
                                            else
                                            {
                                                cu.Id5Nivel = 1 + NegCuentaContable.cant(cu.Idpadre);
                                            }
                                        }

                                    }
                                }
                            }
                            
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

              
                if (NegCuentaContable.InsertarCuenta(cu)==1)
                {
                    lblError.Text = "Registro de Cuenta guardado satisfactoriamente";
                    lblError.Visible = true;
                    Response.Write("<script languaje =javascript>alert ('Registro de Cuenta guardado satisfactoriamente');</script>");
                    TextNumeroOrden.Text = "";
                    TextNombredelaAccion.Text = "";
                    TextIdPadre.Text = "";

                }
                else
                {
                    lblError.Text = "No se pudo Insertar la cuenta por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;

                }
            }

        }
    }
}