<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormConfirmarProgMic.aspx.cs" Inherits="CapaPresentacion.FormConfirmarProgMic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type ="text/css">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="abrigo_formulario">
        <h2 style="text-align:center" >
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
            <span class="auto-style4">Confirmacion De Rutas</span></h2>
        <table>
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
            </table>
          <table>
            <tr>
                <td style="text-align: right" class="auto-style2">No.CRT: </td>
                <td><asp:Label ID="LabelCrt" runat="server"></asp:Label></td>
                <td class="auto-style2"><asp:TextBox ID="txtNoCrt" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style2">No.Mic: </td>
                <td><asp:Label ID="LabelMic" runat="server"></asp:Label></td>
                <td class="auto-style2"><asp:TextBox ID="txtNroMic" runat="server"></asp:TextBox></td>
            </tr>
              </table>
          <table>
               <tr>
                  <td style="text-align: right" class="auto-style2">Volumen CRT:</td>
                  <td class="auto-style2"><asp:TextBox ID="txtVolumenCRT" runat="server"></asp:TextBox></td>
              </tr>
            <tr>
                <td style="text-align:right" class="auto-style2">Volumen Mic:</td>
                <td class="auto-style2"><asp:TextBox ID="txtVolumenMic" runat="server"></asp:TextBox></td>
            </tr>
              <tr>
                  <td style="text-align: right" class="auto-style2">Peso CRT:</td>
                  <td class="auto-style2"><asp:TextBox ID="txtPesoCRT" runat="server"></asp:TextBox></td>
              </tr>
            <tr>
                <td style="text-align: right" class="auto-style2">Peso Mic:</td>
                <td class="auto-style2"><asp:TextBox ID="txtPesoMic" runat="server" ></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                 <td>  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                     BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/>
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/>
                     <asp:Button ID="btnAtras" runat="server" Text="<-Atras" Width="100px" Font-Size="Smaller" BackColor="Aqua" Font-Bold="true" OnClick="btnAtras_Click" />
                 </td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
