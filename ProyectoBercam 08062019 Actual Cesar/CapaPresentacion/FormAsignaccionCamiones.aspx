<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormAsignaccionCamiones.aspx.cs" Inherits="CapaPresentacion.FormAsignaccionCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type ="text/css">
        .auto-style1{
            width:101px;
        }

        </style>

    <style>
            .upper-case
         {
    text-transform: uppercase
         }
        .auto-style2 {
        width: 132px;
    }
        </style>

       <script type="text/javascript">
        $(document).ready(function () {
            var availableTags3 = [ <%= ListPlacas %>];

            $('#ContentPlaceHolder1_Camiones').autocomplete({
                       source: availableTags3
                   });
               });

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
           Registro de Asignacion de Camion</h2>
         <table>
               <tr>
                   <td class="auto-style2">

                   </td>
                   <td>
                       <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
                   </td>
              </tr>
              <tr>
                <td style="text-align:right" class="auto-style2"> Placa Camion:    </td>
                <td><asp:TextBox ID="Camiones" AutoPostBack="true"  runat="server" OnTextChanged="Camiones_TextChanged">
                    </asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:right" class="auto-style2"> Chofer Camion:    </td>
                <td><asp:TextBox ID="txtChofer" AutoPostBack="true"  runat="server" OnTextChanged="Camiones_TextChanged" Height="20px" ReadOnly="True" Width="219px"></asp:TextBox></td>
            </tr>
               <tr>
                <td style="text-align:right" class="auto-style2"> Cliente:</td>
                <td><asp:DropDownList ID="Cliente" AutoPostBack="true"  runat="server" >
                    </asp:DropDownList></td>
                   <td><asp:Button ID="ButtonCliente" runat="server" Text="Agregar" width="100px" Font-Size="Smaller" 
                     BackColor="Green" Font-Bold="True" Font-Italic="False" OnClick="ButtonCliente_Click" /></td>
            </tr>
         </table>
          <br />
         <table>
             <tr>
                 <td>

                 </td>
                 <td>
                     <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Font-Size="XX-Small">
                         <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                         <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                         <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                         <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                         <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#594B9C" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#33276A" />
                     </asp:GridView>
                 </td>
             </tr>
         </table>

        <table>
            <tr>
                <td></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
         </div>
</asp:Content>
