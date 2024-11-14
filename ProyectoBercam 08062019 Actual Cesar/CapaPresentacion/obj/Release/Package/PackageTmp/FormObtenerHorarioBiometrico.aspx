<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormObtenerHorarioBiometrico.aspx.cs" Inherits="CapaPresentacion.FormObtenerHorarioBiometrico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <div id="abrigo_formulario">
        <table >
            <tr>
                
                <td>
                    <asp:Button ID="ButtCargar" runat="server"  Visible="false" Text="Cargar" OnClick="ButtCargar_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtReporte" runat="server" Text="Reporte" OnClick="ButtReporte_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtLista" runat="server" Text="Lista" OnClick="ButtLista_Click" />
                </td>
            </tr>
        </table>
        <h2> Seleccione Fecha Mañana</h2>
        <table>
            <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Fecha: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextMañana" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageTextMañana" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                                 OnClick="ImagenMañana_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <asp:Calendar ID="CalendarMañana" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_MañanaOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
           <%-- <tr>
                <td style ="text-align:right">Persona</td>
                <td>
                    <asp:TextBox ID="TextPersonaZkTeUsuario" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>--%>
        </table>
      
        <table>
            <tr>
                <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField HeaderText="Nombre" />
                    <asp:BoundField HeaderText="User ID" />
                    <asp:BoundField HeaderText="Verify Date" />
                    <%--<asp:BoundField HeaderText="Verify Type" Visible="False" />
                    <asp:BoundField HeaderText="Verify State" Visible="False" />
                    <asp:BoundField HeaderText="WorkCode" Visible="False" />--%>
                </Columns>

            </asp:GridView>
              </td>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" />
                            <asp:BoundField HeaderText="Inicio" />
                            <asp:BoundField HeaderText ="Final" />
                            <asp:BoundField HeaderText="Horas" />
                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
