<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormProveedores.aspx.cs" Inherits="CapaPresentacion.FormProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="abrigo_formulario">
        <h2 style="text-align:center" >
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <span class="auto-style1">REGISTRO DE PROVEEDORES</span></h2>
        <style>
            .upper-case
         {
    text-transform: uppercase
         }
            .auto-style1 {
                color: #5EF20F;
            }
            .auto-style2 {
                height: 26px;
            }
        </style>
         <table>
             <tr>
                 <td style="text-align: right">Nombres: </td>
                    <td><asp:TextBox ID="txtNombres" runat="server" Width="300px" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
             </tr>
              <tr>
                    <td style="text-align: right">Apellidos: </td>
                  <td><asp:TextBox ID="txtApellidos" runat="server" Width="300px" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                  </tr> 
               <tr>
                    <td style="text-align: right" class="auto-style2">C.I.: </td>
                    <td class="auto-style2"><asp:TextBox ID="txtCI" runat="server" Width="85px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox> </td>
                   </tr> 
              <tr>
                     <td style="text-align:right">Emision:</td>
                     <td class="auto-style2"><asp:TextBox ID="txtEmision" runat="server" Width="100px" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                 </tr>
             
                 <tr>
                    <td style="text-align: right">Dirección: </td>
                    <td><asp:TextBox ID="txtDireccion" runat="server" Width="300px" Height="60px" TextMode="MultiLine" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right">Teléfono: </td>
                    <td><asp:TextBox ID="txtTelefono" runat="server" Width="300px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right">Teléfono Referencia: </td>
                    <td><asp:TextBox ID="txtTelfReferencia" runat="server" Width="300px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="text-align: right">Email: </td>
                    <td><asp:TextBox ID="txtEmail" runat="server" Width="300px" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox> </td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" 
                            ErrorMessage="Email is required" SetFocusOnError ="True" ></asp:RequiredFieldValidator></td>
                     <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email"  Display="Dynamic"
                        ControlToValidate="txtEmail" SetFocusOnError="True"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                    </td>
                   
                </tr>          
         </table>
         <br />
        <table>
                 <tr>
                    <td><asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="X-Small" 
                         BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="X-Small" BackColor="Aqua" 
                        Font-Bold="True" />
                        
                    </td>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
        </table>  
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=192.168.1.50;Initial Catalog=bercam;User Id=sa;Password=NCapas2525" 
            SelectCommand="SELECT * FROM [Roles]" ProviderName="<%$ ConnectionStrings:bercamConnectionString.ProviderName %>"></asp:SqlDataSource>
</div> 

</asp:Content>
