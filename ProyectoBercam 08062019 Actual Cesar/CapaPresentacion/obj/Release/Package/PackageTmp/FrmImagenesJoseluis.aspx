<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmImagenesJoseluis.aspx.cs" Inherits="CapaPresentacion.FrmImagenesJoseluis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="abrigo_formulario">
          <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Registro de Imagenes</h2>
         <table>
             <tr>
                 <td style="text-align: right">C.I.: </td>
                <td>
                    <asp:TextBox ID="TextBoxCi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td style="text-align: right">Persona: </td>
                <td>
                    <asp:TextBox ID="TextBoxPersona" runat="server" Width="320px"></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td style="text-align: right">Certificado Medico</td>
                     <td>
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate> 
                        <asp:TextBox ID="TextCertMedico" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageCertMed" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageCertMed_Click"  />
                        <asp:Label ID="LabelCertMedico" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                     </td>
                               <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Especifique una Fecha" ControlToValidate="txtVigenciaFelcn"></asp:RequiredFieldValidator></td>--%>
                    <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarCertMedico" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"  NextPrevFormat="FullMonth" OnSelectionChanged="CalendarCertMedico_SelectionChanged">
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
                    <td><asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                        OnClick="BtnGuardar_Click" BackColor="Aqua" Font-Bold="True" Font-Italic="False"/> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/>
                    </td>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
        </table>  
     </div> 
</asp:Content>
