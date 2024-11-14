using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaDatos;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormCreacionDim : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstado();
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas PerRutas = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);
            if (PerRutas.Dim != 1)
            {
                GridView1.Visible = false;
                GridView1.Enabled = false;
                Button1.Visible = false;
                Button1.Enabled = false;
            }
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }
        public void CargarEstado()
        {
            DdlEstado.Items.Clear();
            DdlEstado.Items.Add(new ListItem("Abierto", "0"));
            DdlEstado.Items.Add(new ListItem("Cerrado", "1"));
            DdlEstado.AppendDataBoundItems = true;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Id_Detalle");
            //dt.Columns.Add("FechaCarga");
            //dt.Columns.Add("Placa_Camion");
            //dt.Columns.Add("NoCrt");
            //dt.Columns.Add("VolumenCrt");
            //dt.Columns.Add("PesoCrt");
            //dt.Columns.Add("VolumenMic");
            //dt.Columns.Add("PesoMic");
            //dt.Columns.Add("NoMic");

            //foreach (GridViewRow Rows in GridView1.Rows)
            //{
            //    var checkboxselect = Rows.FindControl("Input") as CheckBox;
            //    if (checkboxselect.Checked)
            //    {
            //        string Id_Detalle = (Rows.FindControl("Label1") as Label).Text;
            //        string FechaCarga = (Rows.FindControl("Label2") as Label).Text;
            //        string Placa_Camion = (Rows.FindControl("Label3") as Label).Text;
            //        string NoCrt = (Rows.FindControl("Label4") as Label).Text;
            //        string VolumenCrt = (Rows.FindControl("Label5") as Label).Text;
            //        string PesoCrt = (Rows.FindControl("Label6") as Label).Text;
            //        string VolumenMic = (Rows.FindControl("Label7") as Label).Text;
            //        string PesoMic = (Rows.FindControl("Label8") as Label).Text;
            //        string NoMic = (Rows.FindControl("Label9") as Label).Text;
            //        dt.Rows.Add(Id_Detalle, FechaCarga, Placa_Camion, NoCrt, VolumenCrt, PesoCrt, VolumenMic, PesoMic,NoMic);

            //    }
            //    GridView2.DataSource = dt;
            //    GridView2.DataBind();
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;

            //this.GridView2.DataSource = null;
            //this.GridView2.DataBind();

        }

        protected void BGuardar_Click(object sender, EventArgs e)
        {
            int Resultado = 0;
            if (TextAduanFront.Text != "" && TextDim.Text != "" && TextProducto.Text != "" && TextProveedor.Text != "")
            {

                string AduanaFrontera = TextAduanFront.Text;
                AduanaFrontera = AduanaFrontera.ToUpper();
                string TDim = TextDim.Text;
                string LDim = LabelDim.Text;
                string Dim = LDim + TDim;
                string Producto = TextProducto.Text;
                Producto = Producto.ToUpper();
                string Proveedor = TextProveedor.Text;
                Proveedor = Proveedor.ToUpper();

                int DimExist = NegDim.BuscarDimExistente(Dim);
                if (DimExist == 1)
                {
                    Response.Write("<script languaje=javaScript>alert('El DIM esta Repetido');</script>");
                }
                else
                {
                    Resultado = NegDim.AddDim(Dim, Producto, Proveedor, AduanaFrontera);
                }
                
                if (Resultado == 1)
                {
                    TextAduanFront.Text = "";
                    TextDim.Text = "";
                    TextProveedor.Text = "";
                    TextProducto.Text = "";
                     Response.Write("<script languaje=javaScript>alert('Regristro de Dim creado satisfactoriamente');</script>");
                    Response.Redirect("FormCreacionDim.aspx");
                }
                else
                {
                    Response.Write("<script languaje=javaScript>alert('No se Pudo Registrar el Dim');</script>");
                }
                //bool Verif = DatosCorrectos();
                //List<EntDetalleDim> Lista = new List<EntDetalleDim>();
                //if (Verif == true)
                //{
                //    for (int i = 0; i < GridView2.Rows.Count; i++)
                //    {
                //        Label labelIdDetalle = (GridView2.Rows[i].Cells[0].FindControl("Label1") as Label);
                //        int IdDetalle = Convert.ToInt32(labelIdDetalle.Text);
                //        TextBox TextFechaPrm = (GridView2.Rows[i].Cells[0].FindControl("FechaPRM") as TextBox);
                //        DateTime FechaPrm = Convert.ToDateTime(TextFechaPrm.Text);
                //        TextBox TextPrmNo = (GridView2.Rows[i].Cells[0].FindControl("TextPRM") as TextBox);
                //        string PrmNo = TextPrmNo.Text;
                //        EntDetalleDim DetalleDim = new EntDetalleDim();
                //        DetalleDim.FechaPRM=FechaPrm;
                //        DetalleDim.PRMno=PrmNo;
                //        DetalleDim.IdDetalle = IdDetalle;
                //        Lista.Add(DetalleDim);
                //    }
                //    string aduanFront= TextAduanFront.Text;
                //    string proveedor=TextProveedor.Text;
                //    string Dim=TextDim.Text;
                //    string Producto=TextProducto.Text;
                //    Resultado = NegDim.InsertarDim(Dim, Producto, proveedor, aduanFront, Lista);
                //    if (Resultado == 1)
                //    {
                //        Response.Write("<script languaje=javaScript>alert('Regristro de Dim y Sus Detalle creados satisfactoriamente');</script>");
                //        Response.Redirect("FormCreacionDim.aspx");
                //    }
                //}
               
            }
        }

        protected void DtgGridViewListDim_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntUsuario Usuario = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + ' ' + us.Apellidos;
            bit.Accion = "El usuario esta intentando Cerrar un DIM";
            bit.IdUsuario = us.Id_Usuario;
            int bi = NegBitacora.GuardarBitacora(bit);
            EntPermisoRutas Perm = NegPermisoRutas.BuscarPermiso(Usuario.Id_Usuario);
            if (e.CommandName == "CerrarDim")
            {
                string IdDim = e.CommandArgument.ToString();
                int DimId = int.Parse(IdDim);
                int NumDim = NegDim.EncontrarEstadoDim(DimId);
                if (NumDim == 0)
                {
                    bool Valor=NegDim.CerrarDim(DimId);
                    if (Valor == true)
                    {
                        Response.Write("<script languaje=javaScript>alert('El Dim Ha Sido cerrado satisfactoriamente');</script>");
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("<script languaje=javaScript>alert('El Dim No Ha podido Ser cerrado');</script>");
                    }
                   
                }
                else
                {
                    Response.Write("<script languaje=javaScript>alert('El Dim Ya Ha Sido Cerrado Anteriormente');</script>");
                }

            }
            if (e.CommandName == "EliminarDim")
            {
                string IdDim = e.CommandArgument.ToString();
                int DimId = Convert.ToInt32(IdDim);
                int NumDim = NegDim.EncontrarEstadoDim(DimId);
                if (NumDim == 0)
                {
                    int ValorCerrado = NegDim.DesactivarDim(DimId);
                    if (ValorCerrado == 1)
                    {
                        Response.Write("<script languaje=javaScript>alert('El Dim Ha Sido Desactivado satisfactoriamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script languaje=javaScript>alert('El Dim No Ha podido Ser Desactivado');</script>");
                    }
                }
                else
                {
                    Response.Write("<script languaje=javaScript>alert('El Dim Ya Ha Sido Cerrado por lo tanto no puede Desactivarse');</script>");
                }
            }
            if (e.CommandName == "ModificarDim")
            {
                string IdDIm = e.CommandArgument.ToString();
                int DimId = Convert.ToInt32(IdDIm);
                int NumDim = NegDim.EncontrarEstadoDim(DimId);
                if (NumDim == 0)
                {
                    string IDim = e.CommandArgument.ToString();
                    Response.Redirect("FormModificarDim.aspx?Id=" + IDim);
                }
                else
                {
                    Response.Write("<script languaje=javaScript>alert('El Dim Ya Ha Sido Cerrado por lo tanto no se puede Modificar');</script>");
                }
            }
            if (e.CommandName == "VisualizarDim")
            {
                string IDim = e.CommandArgument.ToString();
                Response.Redirect("FormVisualizarDim.aspx?Id=" + IDim);
            }
            if (e.CommandName == "ReporteDim")
            {
                string IdDim = e.CommandArgument.ToString();
                Response.Redirect("FormReportDim.aspx?Id=" + IdDim);
            }
            if (e.CommandName == "Excel")
            {
                MemoryStream archivoExcel = GenerarArchivoExcel();
                // Establece el tipo de contenido
                Response.ContentType =
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                // Establece el encabezado Content-Disposition y especifica un nombre de archivo
                Response.Headers.Add("Content-Disposition", "attachment;filename=plantilla_excel.xlsx");
                // Escribe los datos en el cuerpo de la respuesta
                Response.OutputStream.Write(archivoExcel.ToArray(), 0,
                (int)archivoExcel.Length);
                // Finaliza la respuesta para evitar que se procese más contenido
                  Response.End();
            }
        }
        private MemoryStream GenerarArchivoExcel()
        {
            MemoryStream memStream = new MemoryStream();
            using (ExcelPackage package = new ExcelPackage(memStream))
            {
                ExcelWorksheet hojaTrabajo =
                package.Workbook.Worksheets["DI-2023-621-2250086"];
                if (hojaTrabajo != null)
                {
                    hojaTrabajo.Cells.Clear();
                }
                else
                {
                    hojaTrabajo = package.Workbook.Worksheets.Add("DI-2023-621-2250086");
                 }
                    // Unir las celdas de B2 a M2
                    hojaTrabajo.Cells["B2:M2"].Merge = true;
                    // Agregar el título en la celda unida
                    ExcelRange tituloCelda = hojaTrabajo.Cells["B2"];
                    tituloCelda.Value = "TRANS BERCAM S.R.L.";
                    tituloCelda.Style.Font.Size = 20;
                    tituloCelda.Style.Font.Bold = true;
                    tituloCelda.Style.Font.Name = "Calibri";
                    tituloCelda.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    tituloCelda.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    hojaTrabajo.Cells["B4:M4"].Merge = true;
                    ExcelRange segundoTitulo = hojaTrabajo.Cells["B4"];
                    segundoTitulo.Value = "PLANILLA MOVIMIENTO VOLUMEN PESO";
                    segundoTitulo.Style.Font.Size = 16;
                    segundoTitulo.Style.Font.Bold = true;
                    segundoTitulo.Style.Font.Name = "Calibri";
                    segundoTitulo.Style.Font.UnderLine = true;
                    segundoTitulo.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    segundoTitulo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    hojaTrabajo.Cells["B6:D6"].Merge = true;
                    hojaTrabajo.Cells["B7:D7"].Merge = true;
                    hojaTrabajo.Cells["B8:D8"].Merge = true;
                    hojaTrabajo.Cells["B9:C9"].Merge = true;
                    var richText = hojaTrabajo.Cells["B6"].RichText.Add("ADUANA FRONTERA: ");
                    richText.Bold = true; // Establecer el texto en negrita
                    richText = hojaTrabajo.Cells["B6"].RichText.Add("YACUIBA");
                    richText.Bold = false; // Establecer el texto normal
                    hojaTrabajo.Cells["B6"].Style.Font.Size = 10;
                    richText = hojaTrabajo.Cells["B7"].RichText.Add("DIM: ");
                    richText.Bold = true; // Establecer el texto en negrita
                    richText = hojaTrabajo.Cells["B7"].RichText.Add("DI-2023-621-2250086");
                    richText.Bold = false; // Establecer el texto normal
                    hojaTrabajo.Cells["B7"].Style.Font.Size = 10;
                    richText = hojaTrabajo.Cells["B8"].RichText.Add("PRODUCTO: ");
                    richText.Bold = true; // Establecer el texto en negrita
                    richText = hojaTrabajo.Cells["B8"].RichText.Add("GASOLINA");
                    richText.Bold = false; // Establecer el texto normal
                    hojaTrabajo.Cells["B8"].Style.Font.Size = 10;
                    richText = hojaTrabajo.Cells["B9"].RichText.Add("PROVEEDOR: ");
                    richText.Bold = true; // Establecer el texto en negrita
                    richText = hojaTrabajo.Cells["B9"].RichText.Add("VITOL");
                    richText.Bold = false; // Establecer el texto normal
                    hojaTrabajo.Cells["B9"].Style.Font.Size = 10;
                    hojaTrabajo.Cells["B11:M11"].Style.Fill.PatternType =
                    OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    hojaTrabajo.Cells["B11:M11"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(191, 191, 191));
                    hojaTrabajo.Cells["B11:M14"].Style.VerticalAlignment =
                    ExcelVerticalAlignment.Center;
                    hojaTrabajo.Cells["B11:M14"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                    hojaTrabajo.Cells["B11:M14"].Style.Font.Size = 11;
                    hojaTrabajo.Cells["B11:M14"].Style.Font.Name = "Calibri";
                    ExcelRange range = hojaTrabajo.Cells["B11:M11"];
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thick);
                    range.Style.VerticalAlignment =
                    OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
                    range.Style.Font.Bold = true;
                    range.Style.WrapText = true;
                    hojaTrabajo.Column(2).Width = 8;
                    hojaTrabajo.Column(3).Width = 11;
                    hojaTrabajo.Column(4).Width = 21;
                    hojaTrabajo.Column(5).Width = 19;
                    hojaTrabajo.Column(6).Width = 11;
                    hojaTrabajo.Column(7).Width = 15;
                    hojaTrabajo.Column(8).Width = 11;
                    hojaTrabajo.Column(9).Width = 11;
                    hojaTrabajo.Column(10).Width = 12;
                    hojaTrabajo.Column(11).Width = 24;
                    hojaTrabajo.Column(12).Width = 12;
                    hojaTrabajo.Column(13).Width = 12;
                    hojaTrabajo.Cells["B11"].Value = "ITEM";
                    hojaTrabajo.Cells["C11"].Value = "FECHA DE\nCARGA";
                    hojaTrabajo.Cells["D11"].Value = "EMPRESA";
                    hojaTrabajo.Cells["E11"].Value = "No. CRT";
                    hojaTrabajo.Cells["F11"].Value = "No. PLACA";
                    hojaTrabajo.Cells["G11"].Value = "No. MIC";
                    hojaTrabajo.Cells["H11"].Value = "VOLUMEN\nMIC m3";
                    hojaTrabajo.Cells["I11"].Value = "PESO k\ns/g MIC";
                    hojaTrabajo.Cells["J11"].Value = "FECHA\nP.R.M.";
                    hojaTrabajo.Cells["K11"].Value = "No. P.R.M.";
                    hojaTrabajo.Cells["L11"].Value = "VOLUMEN\nP.R.M. m3";
                    hojaTrabajo.Cells["M11"].Value = "PESO k\ns/g P.R.M.";
                    ExcelRange borde = hojaTrabajo.Cells["B12:M13"];
                    //borde.Style.Border.BorderAround(ExcelBorderStyle.Hair);
                    borde.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    borde.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    borde.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    borde.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    ExcelRange bord1 = hojaTrabajo.Cells["G14:I14"];
                    bord1.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                    bord1.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                    bord1.Style.Border.Right.Style = ExcelBorderStyle.Thick;
                    bord1.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                    ExcelRange bord2 = hojaTrabajo.Cells["L14:M14"];
                    bord2.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                    bord2.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                    bord2.Style.Border.Right.Style = ExcelBorderStyle.Thick;
                    bord2.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                    hojaTrabajo.Cells["B12"].Value = "1";
                    hojaTrabajo.Cells["B13"].Value = "2";
                    hojaTrabajo.Cells["C12"].Value = "21/7/2023";
                    hojaTrabajo.Cells["C13"].Value = "21/7/2023";
                    hojaTrabajo.Cells["D12"].Value = "TRANS BERCAM SRL";
                    hojaTrabajo.Cells["D13"].Value = "TRANS BERCAM SRL";
                    hojaTrabajo.Cells["E12"].Value = "008BER2023/074";
                    hojaTrabajo.Cells["E13"].Value = "008BER2023/074";
                    hojaTrabajo.Cells["F12"].Value = "4712PHF";
                    hojaTrabajo.Cells["F13"].Value = "4094XAU";
                    hojaTrabajo.Cells["G12"].Value = "23YPFB18972";
                    hojaTrabajo.Cells["G13"].Value = "23YPFB18973";
                    hojaTrabajo.Cells["G14"].Value = "TOTAL";
                    hojaTrabajo.Cells["G14"].Style.Font.Bold = true;
                    hojaTrabajo.Cells["H12"].Value = 34060;
                    hojaTrabajo.Cells["H13"].Value = 33940;
                    hojaTrabajo.Cells["H14"].Formula = "SUM(H12:H13)";
                    hojaTrabajo.Cells["I12"].Value = 25038;
                    hojaTrabajo.Cells["I13"].Value = 24950;
                    hojaTrabajo.Cells["I14"].Formula = "SUM(I12:I13)";
                    var formatoNumeros = hojaTrabajo.Cells["H12:I14"];
                    formatoNumeros.Style.Numberformat.Format = "#,##0";
                    hojaTrabajo.Cells["J12"].Value = "23/7/2023";
                    hojaTrabajo.Cells["J13"].Value = "23/7/2023";
                    hojaTrabajo.Cells["K12"].Value = "PRM-2023-621-224718";
                    hojaTrabajo.Cells["K13"].Value = "PRM-2023-621-224719";
                    hojaTrabajo.Cells["L12"].Value = 34060;
                    hojaTrabajo.Cells["L13"].Value = 33940;
                    hojaTrabajo.Cells["L14"].Formula = "SUM(L12:L13)";
                    hojaTrabajo.Cells["M12"].Value = 25038;
                    hojaTrabajo.Cells["M13"].Value = 24950;
                    hojaTrabajo.Cells["M14"].Formula = "SUM(M12:M13)";
                    var formatoNumeros2 = hojaTrabajo.Cells["L12:M14"];
                    formatoNumeros2.Style.Numberformat.Format = "#,##0";
                    hojaTrabajo.Cells["B18:D18"].Merge = true;
                    hojaTrabajo.Cells["B18"].Value = "Realizado por: TRANS BERCAM SRL";
                    hojaTrabajo.Cells["B18"].Style.Font.Size = 10;
                    hojaTrabajo.Cells["G14:I14"].Style.Fill.PatternType =
                    OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    hojaTrabajo.Cells["G14:I14"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(191, 191, 191));
                    hojaTrabajo.Cells["L14:M14"].Style.Fill.PatternType =
                    OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    hojaTrabajo.Cells["L14:M14"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(191, 191, 191));
                    package.Save();
                    }
                    // Asegurarse de que el MemoryStream esté en la posición correcta antes dedevolverlo
                    memStream.Position = 0;
                    return memStream;
                    }
        protected void ButtonEncotrarDim_Click(object sender, EventArgs e)
        {
            if (TextAduanFront.Text != "")
            {
                EntFrontera front = NegFrontera.BuscarFronteraNombre(TextAduanFront.Text);
                if (front!=null)
                {
                    string DimCadena= front.formatDim + "-" + Convert.ToString(front.NroDim) + "-";
                    LabelDim.Text = DimCadena;
                    LabelDim.Visible = true;
                }
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkELiminarDim");
                lb.Attributes.Add("onclick", "return confirm('Esta seguro de querer eliminar el Dim#:" + DataBinder.Eval(e.Row.DataItem, "Dim") + "');"); 
            }
        }
        //protected bool DatosCorrectos()
        //{
        //    bool Ver = true;
        //    for (int i = 0; i < GridView2.Rows.Count; i++)
        //    {
        //        Label labelIdDetalle = (GridView2.Rows[i].Cells[0].FindControl("Label1") as Label);
        //        int IdDetalle = Convert.ToInt32(labelIdDetalle.Text);
        //        TextBox TextFechaPrm = (GridView2.Rows[i].FindControl("FechaPRM") as TextBox);
        //        DateTime FechaPrm = Convert.ToDateTime(TextFechaPrm.Text);
        //        TextBox TextPrmNo = (GridView2.Rows[i].FindControl("TextPRM") as TextBox);
        //        string PrmNo = TextPrmNo.Text;
        //        if (FechaPrm == null || PrmNo == "")
        //        {
        //            Ver = false;
        //            return Ver;
        //        }
        //    }
        //    return Ver;
        //}
    }
}