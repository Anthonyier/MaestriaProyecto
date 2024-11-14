<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormConciliacionPorCobrar.aspx.cs" Inherits="CapaPresentacion.ConciliacionPorCobrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 813px;
        }
        .auto-style2 {
            width: 157px;
        }
    </style>
    <script>
        function SetearMerma(obj) {
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtVolumen" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtVolumen_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtVolumenRecibido" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtVolumenRecibido_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtMermaLts" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtMermaLts_0" style="width:60px;">

            var Adatos = obj.id.split('_');
            var VolEntregado = obj.value;

            var VolRecibido = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolumenRecibido_" + Adatos[3]).value);

            document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMermaLts_" + Adatos[3]).value = (VolEntregado - VolRecibido).toFixed(2);

            if (VolEntregado > VolRecibido) {
                document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolFacturar_" + Adatos[3]).value = VolEntregado;
            }
            else {
                document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolFacturar_" + Adatos[3]).value = VolRecibido;
            }

        }
        function SetearMermaR(obj) {
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtVolumen" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtVolumen_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtVolumenRecibido" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtVolumenRecibido_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtMermaLts" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtMermaLts_0" style="width:60px;">

            var Adatos = obj.id.split('_');
            var VolEntregado = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolumen_" + Adatos[3]).value);

            var VolRecibido = obj.value;

            document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMermaLts_" + Adatos[3]).value = (VolEntregado - VolRecibido).toFixed(2);

            if (VolEntregado > VolRecibido) {
                document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolFacturar_" + Adatos[3]).value = VolEntregado;
            }
            else {
                document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolFacturar_" + Adatos[3]).value = VolRecibido;
            }

            var MermaAct = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMermaLts_" + Adatos[3]).value);

            var MontoMulta = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMontoMultaBs_" + Adatos[3]).value);

            var TarifaTransporte = $("input[id$=txtTarifaTransporte]").val();

            var VolInicial = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolumen_" + Adatos[3]).value);
            if (MermaAct < 0) {
                document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMontoTotalFactura_" + Adatos[3]).value = ((VolInicial / 1000 * TarifaTransporte)).toFixed(2);
            }
            else {
                document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMontoTotalFactura_" + Adatos[3]).value = ((VolInicial / 1000 * TarifaTransporte) - MontoMulta).toFixed(2);
            }

        }
        function CalcularMontoMulta(obj) {//aqui llega el dato de excedente permisible
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtVolumen" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtVolumen_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtVolumenRecibido" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtVolumenRecibido_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtMermaLts" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtMermaLts_0" style="width:60px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtMontoMultaBs" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtMontoMultaBs_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$TextBox1" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_TextBox1_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtVolFacturar" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtVolFacturar_0" style="width:70px;">
            //<input name="ctl00$ContentPlaceHolder1$GridDetalleConciliacion$ctl02$txtMontoTotalFactura" type="text" id="ContentPlaceHolder1_GridDetalleConciliacion_txtMontoTotalFactura_0" style="width:70px;">
            var Adatos = obj.id.split('_');

            var PrecioProdLt = $("input[id$=txtPrecioProd]").val(); //1.5;//parseFloat(document.getElementById("txtPrecioProd").value);
            //var ExcedentePErmio = //parseFloat(document.getElementById("txtPrecioProd").value);//parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolumen_" + Adatos[3]).value);

            var ExcedentePermisible = obj.value;

            document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMontoMultaBs_" + Adatos[3]).value = (PrecioProdLt * ExcedentePermisible).toFixed(2);//(VolEntregado - VolRecibido).toFixed(2);

            var MermaAct = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMermaLts_" + Adatos[3]).value);

            var MontoMulta = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMontoMultaBs_" + Adatos[3]).value);

            var TarifaTransporte = $("input[id$=txtTarifaTransporte]").val();

            var VolInicial = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtVolumen_" + Adatos[3]).value);
            if (MermaAct < 0) {
                document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMontoTotalFactura_" + Adatos[3]).value = ((VolInicial / 1000 * TarifaTransporte)).toFixed(2);
            }
            else {
                document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMontoTotalFactura_" + Adatos[3]).value = ((VolInicial / 1000 * TarifaTransporte) - MontoMulta).toFixed(2);
            }
            //<input name="ctl00$ContentPlaceHolder1$txtTotalGeneral" type="text" value="0.00" id="ContentPlaceHolder1_txtTotalGeneral" style="width:70px;">
            varMTotalFact = parseFloat(document.getElementById("ContentPlaceHolder1_GridDetalleConciliacion_txtMontoTotalFactura_" + Adatos[3]).value);

            document.getElementById("ContentPlaceHolder1_txtTotalGeneral").value = (parseFloat(document.getElementById("ContentPlaceHolder1_txtTotalGeneral").value) + varMTotalFact).toFixed(2);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
     <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
           ConciliacionPorCobrar</h2>
         <table>
             <tr>
                 <td style="text-align:right"> Cliente</td>
                  <td><asp:TextBox ID="TextCliente" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right"> #Recepcion</td>
                  <td><asp:TextBox ID="TextRecepcion" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right"> RecepcionManual</td>
                  <td><asp:TextBox ID="TextRecepcionManual" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
             </tr>
               <tr>
                 <td style="text-align:right"> Ruta</td>
                  <td><asp:TextBox ID="TextRuta" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right"> Producto</td>
                  <td><asp:TextBox ID="TextProducto" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
             </tr>

             <tr>
              <td style="text-align:right"> Precio Producto:(Bs/Lts) </td>
              <td><asp:TextBox ID="txtPrecioProd" runat="server" Width="300px" CssClass="upper-case" Text="0.00"></asp:TextBox></td>
             </tr>
             
             <tr>
              <td style="text-align:right"> Tarifa Transporte:(Bs/m3) </td>
              <td><asp:TextBox ID="txtTarifaTransporte" runat="server" Width="300px" CssClass="upper-case" Text="0.00"></asp:TextBox></td>
             </tr>

             <tr>
              <td>
             </td>
             </tr>

             <tr>
                <td>
                </td>
             <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="42px">
                    <Columns>
                        <asp:BoundField DataField="Id_Detalle" HeaderText="Id_Detalle" />
                        <asp:BoundField DataField="Placa_Camion" HeaderText="Placa_Camion" />
                        <asp:BoundField DataField="Id_Chofer" HeaderText="Id_Chofer" />
                        <asp:BoundField DataField="Monto_Anticipo" HeaderText="Monto_Anticipo" />
                        <asp:BoundField DataField="FechaCarga" HeaderText="FechaCarga" />
                        <asp:BoundField DataField="FechaDescarga" HeaderText="FechaDescarga" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
             </td>
             </tr>
             </table>
         <table>
            <tr>
                <td>

                </td>
                <td style="margin-left: 40px">
                <asp:GridView ID="GridDetalleConciliacion" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowHeaderWhenEmpty="True" OnRowDataBound="GridDetalleConciliacion_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Nro">
                            <HeaderStyle Font-Size="XX-Small" Width="30px" />
                            
                            <ItemTemplate>  
                            <asp:Label ID="lblNro" runat="server" Width="30px" DataField="lblNro"  
                                Text='<%# (GridDetalleConciliacion.PageSize * GridDetalleConciliacion.PageIndex) + Container.DisplayIndex + 1 %>'>  
                            </asp:Label>  
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Conductor" HeaderText="Conductor" />
                        <asp:BoundField DataField="Placa" HeaderText="Placa" />
                        <asp:TemplateField HeaderText="Planta Origen">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbPlantaOrigen" runat="server" Height="16px" Width="90px">
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle Width="120px"/></asp:TemplateField>
                        <asp:BoundField DataField="FechaCarga" HeaderText="Fecha Carga" />
                        <asp:TemplateField HeaderText="Volumen(Lts)">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtVolumen" runat="server" Width="70px" onblur="SetearMerma(this)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CRE Carga">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtCreCarga" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Planta Destino">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbPlantaDestino" runat="server" Height="16px" Width="90px">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaDescarga" HeaderText="Fecha Descarga" />
                        <asp:TemplateField HeaderText="Volumen Recibido(Lts)">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtVolumenRecibido" runat="server" Width="70px" onblur="SetearMermaR(this)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CRE Descarga">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtCreDescarga" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Merma(Lts)">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtMermaLts" runat="server" Width="60px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excedente Permisible (Lts)">
                            <EditItemTemplate>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtExcedentePerm" runat="server" Width="70px" onblur="CalcularMontoMulta(this)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Monto Multa Bs">
                            <EditItemTemplate>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtMontoMultaBs" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Volumen a Facturar(Lts)">
                            <EditItemTemplate>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtVolFacturar" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Monto Total Factura (Bs)">
                            <EditItemTemplate>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtMontoTotalFactura" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nro Hoja Ruta">
                            <EditItemTemplate>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtHojaRuta" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle Font-Size="XX-Small" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
            </td>
            </tr>
             </table>
         <table>
             <tr>
                 <td style="text-align:right"></td>
                 <td style="text-align:right" class="auto-style2">
                     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FormConciliacionPorPagar.aspx">Conciliacion por Pagar</asp:HyperLink>
                 </td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                  <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"></td>
                 <td style="text-align:right"> Total General</td>
                 <td style="text-align:right" >
                     <asp:TextBox ID="txtTotalGeneral" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                 </td>
             </tr>
         </table>
         </div>
</asp:Content>
