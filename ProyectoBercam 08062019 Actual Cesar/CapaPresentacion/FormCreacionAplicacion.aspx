<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCreacionAplicacion.aspx.cs" Inherits="CapaPresentacion.FormCreacionAplicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2>Creacion De Aplicacion</h2>
        <table>
            <tr>
                <td style="text-align:right">ASEGURADO: </td>
                <td><asp:TextBox ID="TextAsegurado" runat ="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">ASEGURADO ADICIONAL: </td>
                <td><asp:TextBox ID="TextAseguradoAdicional" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Producto Asegurado: </td>
                <td><asp:TextBox ID="TextProdAseg" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Volumen Transportado: </td>
                <td>
                    <asp:TextBox ID="TextVolTrans" runat="server"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="Metros Cúbicos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Precio Promedio </td>
                <td>
                    <asp:TextBox ID="TextPrecPromed" runat="server"></asp:TextBox>
                    <asp:Label ID="LabelPrecioProd" runat="server" Text="$us"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="ButtonCalcular" runat="server" Text="Cacular Valor" OnClick="ButtonCalcular_Click"  />
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Valor Asegurado: </td>
                <td>
                    <asp:TextBox ID="TextValAseg" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="dólares"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Número De Dim: </td>
                <td><asp:TextBox ID="TextNumeroDim" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Medio De Transporte: </td>
                <td><asp:TextBox ID="TextMeTrans" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Limite Maximo Por Embarque: </td>
                <td>
                    <asp:TextBox ID="TextLimiteMaximo" runat="server"></asp:TextBox>
                     <asp:Label ID="Label3" runat="server" Text="$US" ></asp:Label>
                </td>
               
                
            </tr>
            <tr>
                <td style="text-align:right">Travesia: </td>
                <td><asp:TextBox ID="TextTravesia" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Frontera De Ingreso: </td>
                <td><asp:TextBox ID="TextFronteraIngreso" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Coberturas: </td>
                <td><asp:TextBox ID="TextCoberturas" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Periodo De Carga: </td>
                <td style="text-align:center">Desde: 
                    <asp:TextBox ID="TextPeriodoCargaDesde" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:center">Hasta:
                    <asp:TextBox ID="TextPeriodoCargaHasta" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Deducible: </td>
                <td><asp:TextBox ID="TextDeducible" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Prima Total: </td>
                <td>
                    <asp:TextBox ID="TextPrimaTotal" runat="server"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="$US"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Forma De Pago: </td>
                <td><asp:TextBox ID="TextFormaDePago" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                <td><asp:Button ID="ButtonGuardar" runat ="server" Text="Guardar" BackColor="Green" OnClick="ButtonGuardar_Click"/></td>
                <td><asp:Button ID="ButtonAtras" runat="server" Text="<-Atras" BackColor="Red" OnClick="ButtonAtras_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
