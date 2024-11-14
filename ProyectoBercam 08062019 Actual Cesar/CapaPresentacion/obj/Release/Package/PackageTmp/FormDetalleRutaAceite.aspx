<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormDetalleRutaAceite.aspx.cs" Inherits="CapaPresentacion.FormDetalleRutaAceite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type ="text/css">
        .auto-style1{
            width:101px;
        }

        </style>

    <style>
            .upper-case
         {
    text-transform: uppercase
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
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
           Registro de Detalle Ruta Aceite</h2>
        <table>
             <tr>
                <td style="text-align:right" class="auto-style1"> Cliente</td>
                <td><asp:DropDownList ID="Cliente" AutoPostBack="true" runat="server" Width="195px" OnSelectedIndexChanged="Cliente_SelectedIndexChanged" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Ruta</td>
                <td><asp:DropDownList ID="Ruta" AutoPostBack="true" runat="server" Width="400px" ></asp:DropDownList></td>
            </tr>
                 <tr>
                 <td style="text-align:right" class="auto-style1"> Precio</td>
                 <td><asp:TextBox ID="TextPrecio" runat="server" Width="300px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
         
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">PrecioFletero</td>
                 <td><asp:TextBox ID="TextFletero" runat="server" Width="300px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
             </tr>
           
            <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Fecha Inicial: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextFechaInicial" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageFechaInicial" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                                 OnClick="imgCalendarFechaInicial_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarFechaInicial" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_FechaInicialOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Fecha Final: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextFechaFinal" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImagenFechaFinal" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                                 OnClick="imgCalendarFechaFinal_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarFechaFinal" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_FechaFinalOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
    </div>
</asp:Content>

