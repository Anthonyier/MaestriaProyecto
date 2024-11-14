﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCobroGuia.aspx.cs" Inherits="CapaPresentacion.FormCobroGuia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" >
     .auto-style1{
            width:101px;
        }
        .auto-style2 {
            width: 101px;
            height: 26px;
            font-size: medium;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            font-family: Arial;
            color: #003EFF;
            font-size: x-large;
        }
        .auto-style5 {
            width: 101px;
            font-size: medium;
        }
        .auto-style7 {
            font-size: xx-small;
        }
        .upper-case {
            font-size: xx-small;
        }
        </style>
    <script language="javascript" type="text/javascript">
        // Except only numbers and dot (.) for salary textbox
        function onlyDotsAndNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode == 44) {
                return true;
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2 style="text-align:center" >
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
            <span class="auto-style4">Cobro de Carro Guia</span></h2>
        <table>
            <tr>
            <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Placa:</td>
                <td><asp:TextBox ID="TextPlaca" runat="server" Width="100px" CssClass="auto-style7"></asp:TextBox></td>
                </tr>

            <tr>
            <td style="text-align: right; font-size:medium;font-family:Calibri;" class="auto-style1">Monto</td>
                <td><asp:TextBox ID="TextMonto" runat="server" Width="100px" class="auto-style7 "></asp:TextBox> </td>
            </tr>
             <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Fecha Carga: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextCarga" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageTextCarga" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                                 OnClick="imgCalendarCarga_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <asp:Calendar ID="CalendarCarga" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_CargaOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Ubicacion Origen:</td>
                 <td><asp:DropDownList ID="DdlOrigen" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Ubicacion Destino:</td>
                <td><asp:DropDownList ID="DdlDestino" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri" class="auto-style1">Ruta</td>
                <td><asp:DropDownList ID="DdlRuta" runat="server" AutoPostBack="true" Width="300px" CssClass="auto-style7" OnSelectedIndexChanged="DdlRuta_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Proovedor</td>
                <td><asp:DropDownList ID="DdlProv" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Año</td>
                <td><asp:DropDownList ID="DdlAño" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Placa</td>
                <td><asp:DropDownList ID="DdlPlaca" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
            <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Periodo</td>
                <td><asp:DropDownList ID="DdlPeriodo" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Region</td>
                <td><asp:DropDownList ID="DdlRegion" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList> </td>
            </tr>
             <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Producto</td>
                <td><asp:DropDownList ID="DdlProducto" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList> </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" ShowHeaderWhenEmpty="True" PageSize="20" GridLines="Horizontal" >
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                          <EmptyDataTemplate>
                            <b> No Existen Registros !!!</b>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:Button runat="server" ID="Agregar" Text="Agregar" OnClick="Agregar_Click" />
                    <asp:Button runat="server" ID="Modificar" Text="Modificar" OnClick="Modificar_Click" />
                     <asp:TextBox ID="txtFila" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br/>
        <table>
            <tr>
                 <td>  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                    BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/>
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SERVIDOR;Initial Catalog=bercam;Integrated Security=True" 
             ProviderName="<%$ ConnectionStrings:bercamConnectionString.ProviderName %>"></asp:SqlDataSource>

    </div>
</asp:Content>