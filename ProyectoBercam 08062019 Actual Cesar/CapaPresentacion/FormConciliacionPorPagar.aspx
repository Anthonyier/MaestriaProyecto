<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormConciliacionPorPagar.aspx.cs" Inherits="CapaPresentacion.FormConciliacionPorPagar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 813px;
        }
        </style>
    <script>

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="abrigo_Formulario">
         <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
           Conciliacion Por Pagar</h2>
        <table>
            <tr>
                <td style="text-align:right">Transportista</td>
                <td><asp:TextBox ID="TextCliente" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">#Recepcion</td>
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
                    <asp:GridView ID="GridDetalle" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Recepcion">
                                 <%--<HeaderStyle Font-Size="XX-Small" Width="30px" />--%>
                            
                            <ItemTemplate>  
                            <asp:Label ID="Recepcion" runat="server" Width="30px" DataField="lblRecepcion"  
                                Text='<%# (GridDetalle.PageSize * GridDetalle.PageIndex) + Container.DisplayIndex + 1 %>'>  
                            </asp:Label>  
                        </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField="Placa" HeaderText="Placa"/>
                         <asp:TemplateField HeaderText="Tipo">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtTipo" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="Producto" HeaderText="Producto" />
                            <asp:BoundField DataField="FechaCarga" HeaderText="Fecha Carga" />
                            <asp:BoundField DataField="FechaDescarga" HeaderText="Fecha Descarga"/>
                           <asp:TemplateField HeaderText="Planta Origen">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbPlantaOrigen" runat="server" Height="16px" Width="90px">
                                </asp:DropDownList>
                            </ItemTemplate>
                          </asp:TemplateField>
                             <asp:TemplateField HeaderText="Planta Destino">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbPlantaDestino" runat="server" Height="16px" Width="90px">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Despacho">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtDespacho" runat="server" Width="70px" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recepcion">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtRecepcion" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance">
                            <ItemTemplate>  
                                     <asp:TextBox ID="txtBalance" runat="server" Width="70px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="%Merma">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPorcentaje" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LtsAdmisible">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAdmisi" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LtsCobrable">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCobrable" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BOB/LTS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBOBLTS" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BOB">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBOB" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProductoPrima">
                                <ItemTemplate>
                                  <asp:TextBox ID="txtPrima" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ResponsabilidadCivil">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCivil" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FleteBOB/LTS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFleteBo" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FleteBOB">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFlete" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
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
    </div>
</asp:Content>
