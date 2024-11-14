<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCrearCuentaBanco.aspx.cs" Inherits="CapaPresentacion.FormCrearCuentaBanco" %>
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
                Registro De Cuenta Banco
        </h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Nro Cuenta</td>
                <td><asp:TextBox ID="TextCuenta" runat="server" Width="300" ></asp:TextBox></td>
            </tr>
              <tr>
                    <td style="text-align:right" class="auto-style1">Banco:</td>
                    <td><asp:DropDownList ID="Banco" AutoPostBack="true" runat="server">
                            </asp:DropDownList></td>
                </tr>
             <tr>
               <td style="text-align:right; font-size:large; font-family:Calibri;" class="auto-style1">Titular</td>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="TextoTitularCuentaBanco" runat="server" Width="300px" ></asp:TextBox>
                        </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>
