<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmKilometraje.aspx.cs" Inherits="CapaPresentacion.FrmKilometraje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type ="text/css">
        .auto-style1{
            width:101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            Registro De Kilometrajes
        </h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Kilometraje</td>
                <td><asp:TextBox ID="TextKilometraje" runat="server" Width="300px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Cliente</td>

                <td>
                    
                          
                      <asp:TextBox ID="TextClienteKilometraje" runat="server" Width="300px" OnTextChanged="TextClienteKilometraje_TextChanged" ></asp:TextBox>
                  
                    <asp:Button ID="ButtonRuta" runat="server" Text="Buscar" OnClick="ButtonRuta_Click" />
                    </td>
            </tr>
            <tr>
                 <td style="text-align:right;font-family:Calibri;" class="auto-style1"> RUTA:</td>
                <td class="auto-style3"><asp:DropDownList ID="DDLRuta" AutoPostBack="true" runat="server" style="font-size: xx-small">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <table>
            <tr>
                <td><asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" Width="100px"  Font-Size="Smaller" BackColor="Aqua" font-bold="true" font-italic="false" OnClick="ButtonGuardar_Click" />
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                <td><asp:Label ID="lblError" runat="server" text="" Visible="false" forecolor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
