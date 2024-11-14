<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormDetalleMulta.aspx.cs" Inherits="CapaPresentacion.DetalleMulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 101px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        // Except only numbers and dot (.) for salary textbox
        function onlyDotsAndNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode == 44) {
                return true;
            }
            if (charCode == 46) {
                return true;
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>Detalle de Multas </h2>
        <table>
            <tr>
                <td style="text-align:right; font-size:large; font-family:Calibri;" class="auto-style1"> Placa</td>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="TextoPlacaC" runat="server" Width="100px" ></asp:TextBox>
                        </asp:Panel>
                                
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            </tr>
            <tr>
                <td style="text-align:right; font-size:large; font-family:Calibri;" class="auto-style1">Precio</td>
                <td><asp:TextBox ID="txtPrecio" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
            </tr>
             <tr>
                 <td style="text-align: right" class="auto-style1">OBS: </td>
                    <td><asp:TextBox ID="txtOBS" runat="server" Width="300px" TextMode="MultiLine" CssClass="upper-case" ></asp:TextBox></td>
            </tr>
              <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Fecha Multa: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextFecha" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageTextFecha" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                                 OnClick="imgCalendarFecha_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <asp:Calendar ID="CalendarFecha" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_FechaOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Multa</td>
                <td><asp:DropDownList ID="DdlMulta" runat="server" Width="300px" CssClass="auto-style7" AutoPostBack="true" OnSelectedIndexChanged="DdlMulta_SelectedIndexChanged"></asp:DropDownList></td>
                 <td><asp:Button ID="ButtonMulta" runat="server" Text="Concepto" width="100px" Font-Size="Smaller" 
                     BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="ButtonMulta_Click" /></td>
               </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;"class="auto-style1">Periodo</td>
                <td><asp:DropDownList ID="DdlPeriodo" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;"class="auto-style1">Año</td>
                <td><asp:DropDownList ID="DdlAño" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
             <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;"class="auto-style1">Region</td>
                <td><asp:DropDownList ID="DdlRegion" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            </table> 
        <table>
            <tr>
                 <td>  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                     BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/>
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=192.168.1.50;Initial Catalog=bercam;User Id=sa;Password=NCapas2525" 
             ProviderName="<%$ ConnectionStrings:bercamConnectionString.ProviderName %>"></asp:SqlDataSource>
        </div> 
</asp:Content>
