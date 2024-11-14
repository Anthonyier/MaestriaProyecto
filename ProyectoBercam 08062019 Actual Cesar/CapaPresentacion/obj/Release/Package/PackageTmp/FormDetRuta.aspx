<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormDetRuta.aspx.cs" Inherits="CapaPresentacion.FormDetRuta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type ="text/css">
        .auto-style1{
            width:101px;
        }

        </style>
        <script src="jquery-1.8.3.js" type="text/javascript"></script>
	<script type="text/javascript" src="jquery-ui-1.9.2.custom.min.js"></script>
	<link rel="stylesheet" type="text/css" href="jquery-ui.css" />
	<script type="text/javascript">
	    $(document).ready(function () {
	        var availableTags = [ <%= ListRutas %>];
	        //int NC = Convert.ToInt32(context.Request.QueryString["Codigo"]);
	        $('#ContentPlaceHolder1_TextRuta').autocomplete({
	            source: availableTags
	        });
	        //var paramcl = document.getElementById("ContentPlaceHolder1_TextCli").value;
	        //var para = "FormularioPrincipal.Master?ClienteP=" + paramcl;
	    });
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

    <%--<script type="text/javascript">
        $(document).ready(function () {
            var availableTags = [ <%= ListCli2 %>];
	        //int NC = Convert.ToInt32(context.Request.QueryString["Codigo"]);
            $('#ContentPlaceHolder1_TextCli2').autocomplete({//TextCli2ContentPlaceHolder1_TextCli2
	            source: availableTags
	        });
	        //var paramcl = document.getElementById("ContentPlaceHolder1_TextCli").value;
	        //var para = "FormularioPrincipal.Master?ClienteP=" + paramcl;
	    });
	</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
     <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
           Registro de Detalle de Ruta</h2>
         <table>
             <tr>
                 <td style="text-align:right" class="auto-style1"> Ruta</td>
                <td><asp:DropDownList ID="Ruta" AutoPostBack="true" runat="server" Width="195px" ></asp:DropDownList></td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">Producto</td>
                 <td><asp:DropDownList ID="Producto" AutoPostBack="true" runat="server" Width="195px"></asp:DropDownList></td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">Cliente</td>
                 <td><asp:DropDownList ID="TextCli" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="TextCliente_SelectedIndexChanged"></asp:DropDownList></td>
                
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">Merma Maxima</td>
                 <td><asp:TextBox ID="TextMerma" runat="server" width="195px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">Multa Producto</td>
                 <td><asp:TextBox ID="TextMulta" runat="server" Width="195px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
             </tr>
         </table>
          <br />
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
