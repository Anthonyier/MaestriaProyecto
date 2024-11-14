<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormDetalleTelefono.aspx.cs" Inherits="CapaPresentacion.FormDetalleTelefono" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type ="text/css">
        .auto-style1{
            width:101px;
        }

        </style>
    <script language="javascript" type="text/javascript">
        // Except only numbers and dot (.) for salary textbox
        function onlyDotsAndNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode == 44) {
                return true;
            }
            if (charCode == 46) {
                return true;
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManagaer1" runat="server" ></asp:ScriptManager>
            Registro De Telefono
        </h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Placa</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" update="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:TextBox ID="TextBoxPlacaTelf" runat="server" Width="300px"></asp:TextBox>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:CheckBox ID="chkCamion" Text="No hay Placa" runat="server" AutoPostBack="true"  OnCheckedChanged="chkCamion_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:TextBox ID="TextPropietario" runat="server" Width="300px" Visible="false"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:right" class="auto-style1">Numero</td>
                <td><asp:TextBox ID="TextNumero" runat="server" Width="300px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">MontoCobrar</td>
                <td><asp:TextBox ID="TextMontoCobrar" runat="server" Width="300px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1 ">Credito</td>
                <td><asp:TextBox ID="TextCredito" runat="server" Width="300px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
            </tr>
            <tr>

                <td style="text-align:right" class="auto-style1">Libre</td>
                <td>
                  <asp:CheckBox ID="chkSi" Text="Si" AutoPostBack="true"  runat="server" OnCheckedChanged="chkSi_CheckedChanged"  />
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:CheckBox ID="chkNo" Text="No" AutoPostBack="true" runat="server" OnCheckedChanged="chkNo_CheckedChanged" />
                </td>
             
            </tr>

            <tr>
                <td style="text-align:right;font-family:Calibri;"class="auto-style1">Año</td>
                <td><asp:DropDownList ID="DdlAño" runat="server" Width="300px" CssClass="auto-style1"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-family:Calibri;"class="auto-style1">Mes</td>
                <td><asp:DropDownList ID="DdlMes" runat="server" Width="300px" CssClass="auto-style1" ></asp:DropDownList></td>
            </tr>
        </table>
         <table>
            <tr>
                <td>  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"  />
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" Font-Bold="True"/>
                 <asp:Button ID="BtnConjunto" runat="server" Text="Guardar En Grupo" width="130px" Font-Size="Smaller" BackColor="Aqua" Font-Bold="True" OnClick="BtnConjunto_Click"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
