<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormImagenesJoseluisCamiones.aspx.cs" Inherits="CapaPresentacion.FormImagenesJoseluisCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
         <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Registro De Imagenes
        </h2>
        <table>
             <tr>
                 <td style="text-align: right">ID: </td>
                <td>
                    <asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td style="text-align: right">Placa: </td>
                <td>
                    <asp:TextBox ID="TextBoxPlaca" runat="server" Width="320px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td style="text-align:right">Certificado de Extintores</td>
                 <td>
                     <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                             <asp:TextBox ID="TextCertExtintores" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageCertExtin" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageCertExtin_Click" />
                             <asp:Label ID="LabelCertExtin" runat="server" Text ="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                             </td>
                             <td style="text-align:right"></td>
                                <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarCertExtin" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarCertExtin_selectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
                <td style="text-align:right">CheckList</td>
                <td>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                             <asp:TextBox ID="TextCheckList" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageCheckList_Click"  />
                             <asp:Label ID="Label1" runat="server" Text ="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                             </td>
                             <td style="text-align:right"></td>
                                <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarCheckList" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarCheckList_selectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
                           BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/>
                        <asp:Button ID="BtnImagenesCarla" runat="server"  Text="ImagenesCarla" Width="100px" Font-Size="Smaller" 
                          BackColor="Aqua" Font-Bold="true" Font-Italic="false" OnClick="BtnImagenesCarla_Click"  />
                    </td>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
        </table>  
    </div>
</asp:Content>
