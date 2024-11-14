<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormEstCamion.aspx.cs" Inherits="CapaPresentacion.FormEstCamion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
            Estado de los camiones </h2>
        <table>
            <tr>
                <td style="text-align:right; font-size: large; font-family:Calibri;" class="auto-style1"> Placa</td>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="TxtPlaca" runat="server" Width="100px"></asp:TextBox>
                            <asp:Button ID="BtnPlaca" runat="server" Text="Buscar Placa" Width="100px" Font-Size="smaller" OnClick="BtnPlaca_Click" />

                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server">
                        <tr>
                            
                          <td style="text-align:right; font-size:large; font-family:Calibri;" class="auto-style1">Chofer </td>
                          <td><asp:TextBox ID="txtChofer" runat="server" Width="300px"> </asp:TextBox></td>
                        </tr>
                            </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            </tr>
            
            <tr>
                <td style="text-align:right; font-size:large; font-family:Calibri;" class="auto-style1"> Estado</td>
                <td>
                    <asp:DropDownList ID="ddlEstado" AutoPostBack="true" runat="server" ></asp:DropDownList>
                </td>
            </tr>

            <tr>
                    <td style="text-align: right; font-size:large;font-family:Calibri;" class="auto-style1">OBS: </td>
                    <td><asp:TextBox ID="txtOBS" runat="server" Width="300px" TextMode="MultiLine" CssClass="upper-case" ></asp:TextBox></td>
                </tr>
            
        </table>
        <br />
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
