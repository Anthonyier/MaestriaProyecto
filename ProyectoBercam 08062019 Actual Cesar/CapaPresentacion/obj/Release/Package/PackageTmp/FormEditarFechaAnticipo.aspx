<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormEditarFechaAnticipo.aspx.cs" Inherits="CapaPresentacion.FormEditarFechaAnticipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario" >
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Registro de Imagenes Anticipos</h2>
        <table>
            <tr>
                    <%--<td style="text-align: right">Fecha De Anticipo: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="txtFechaAnticipo" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="imgFechaAnticipo" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgAnticipo_Click" />
                            <asp:Label ID="lblAnticipo" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                            <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                   <%-- </td>
                    <br />
                    --%>
                   <%-- <td style="text-align: right"> </td>
                    <td>--%>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <%--<asp:Calendar ID="CalendarAnticipo" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarAnticipo_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>--%>
                </tr>
            <tr>
                <td style="text-align:right" >Documento Anticipo </td>
                <td><asp:TextBox ID="TextAnticip" runat="server" Width="320px"></asp:TextBox></td>
                 <td><asp:Button ID="BtnAnticip" runat="server" Text="Descargar" width="100px" OnClick="BtnAnticip_Click"/></td>
            </tr>
        </table>
    </div>
    <table>
                 <tr>
                   <%-- <td><asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                         BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>--%>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
        </table>  
</asp:Content>
