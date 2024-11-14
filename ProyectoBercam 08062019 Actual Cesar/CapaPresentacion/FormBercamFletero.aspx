<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormBercamFletero.aspx.cs" Inherits="CapaPresentacion.FormBercamFletero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 59px;
        }
        .auto-style3 {
            width: 239px;
        }
        .auto-style2 {
            width: 101px;
            height: 26px;
            font-size: medium;
        }
        .auto-style4 {
            width: 240px;
        }
        .auto-style5 {
            width: 101px;
            font-size: medium;
        }
        .auto-style7 {
            font-size: xx-small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2 style="text-align:center" >
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <span class="auto-style4">PROGRAMACION BERCAM/FLETEROS</span></h2>
        <table>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1"> Cliente:</td>
               <td>
                   <asp:TextBox ID="TextoClientes" runat="server" Width="300px" CssClass="auto-style7" ></asp:TextBox>
                   </td> 
            </tr>
            <tr>
                <td style="text-align:right;font-family:Calibri;"class="auto-style2 ">Periodo</td>
                <td class="auto-style3 "><asp:DropDownList Id="ddlPeriodo" AutoPostBack="true" runat="server" style="height: 22px" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged"></asp:DropDownList> 
                </td>
                 <td style="text-align:right;font-family:Calibri;"class="auto-style2">Año</td>
                <td class="auto-style3"><asp:DropDownList ID="DdlAño" AutoPostBack="true" runat="server" style="height:22px"></asp:DropDownList>
                <asp:Button ID="ButtonPeriodo" runat ="server" text="BuscConcil"/>
                </td>
                                    
            </tr>
            <tr>
                <td style="text-align:right;font-family:Calibri;"class="auto-style2 ">Placa</td>
                <td class="auto-style3 "><asp:DropDownList Id="DdlPlaca" AutoPostBack="true" runat="server" style="height: 22px"></asp:DropDownList> 
                </td>
            </tr>
            <tr>
                  <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style1">Rutas</td>
               <td>
                   <asp:TextBox ID="TextBoxRutas" runat="server" Width="300px"></asp:TextBox>
               </td>
            </tr>
           <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style1">Propietario</td>
               <td>
                   <asp:TextBox ID="TextBoxNombPropietario" runat="server" Width="300px"></asp:TextBox>
               </td>
            </tr>
            <tr>
                 <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style1">Titular Banco</td>
               <td>
                   <asp:TextBox ID="TextBoxNomBanco" runat="server" Width="300px"></asp:TextBox>
               </td>
            </tr>
             <tr>
                  <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style1">Anticipo</td>
               <td>
                   <asp:TextBox ID="TextAnticipo" runat="server" Width="300px"></asp:TextBox>
               </td>
             </tr>
         
        </table>
        <br />
         <table>
            <tr>
                 <td>  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                     BackColor="Aqua" Font-Bold="True" Font-Italic="False"/>
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
