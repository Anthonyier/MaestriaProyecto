<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormImagenesCarroGuia.aspx.cs" Inherits="CapaPresentacion.FormImagenesCarroGuia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="abrigo_formulario" >
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Registro de Imagenes CarroGuia</h2>
        <table>
            <tr>
                 <td style="text-align: right">Carro Guia: </td>
                <td>
                     <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional" >
                                <ContentTemplate>
                                    <asp:FileUpload ID="FileUpCarroguia" runat="server" Width="160px" Font-Size="Smaller"/>
                                </ContentTemplate> 
                        </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="text-align:right" >Documento CarroGuia </td>
                <td><asp:TextBox ID="TextPagado" runat="server" Width="320px"></asp:TextBox></td>
                 <td><asp:Button ID="BtnCarroGuia" runat="server" Text="Descargar" width="100px" OnClick="BtnCarroGuia_Click"/></td>
            </tr>
             <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Fecha Pago: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextFecha" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageFecha" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                                 OnClick="imgCalendarFecha_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarFechaPago" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
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
        </table>
    </div>
     <table>
                 <tr>
                    <td><asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                         BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click" /> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
          
        </table>  
</asp:Content>
