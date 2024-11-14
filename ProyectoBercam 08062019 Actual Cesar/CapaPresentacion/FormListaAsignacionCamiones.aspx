<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaAsignacionCamiones.aspx.cs" Inherits="CapaPresentacion.FormListaAsignacionCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="jquery-1.8.3.js" type="text/javascript"></script>
	<script type="text/javascript" src="jquery-ui-1.9.2.custom.min.js"></script>
	<link rel="stylesheet" type="text/css" href="jquery-ui.css" />
	<script type="text/javascript">
	    $(document).ready(function () {
	        var availableTags = [ <%= ListClientes3 %>];
	        $('#ContentPlaceHolder1_TextCliAsig').autocomplete({
	            source: availableTags
	        });
	        //var paramcl = document.getElementById("ContentPlaceHolder1_TextCli").value;
	        //var para = "FormularioPrincipal.Master?ClienteP=" + paramcl;
	    });
	</script>
    <script type="text/javascript">
        $(document).ready(function () {
            var availableTags = [ <%= ListPlantas %>];
            $('#ContentPlaceHolder1_TextOrigen').autocomplete({
	            source: availableTags
	        });
	    });
	</script>
    <script type="text/javascript">
        $(document).ready(function () {
            var availableTags = [ <%= ListPlantas %>];
            $('#ContentPlaceHolder1_TextUbicacion').autocomplete({
                source: availableTags
            });
        });
	</script>
    <style type="text/css">
        .auto-style1 {
            width: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2>Listas de camiones por Asignación de Clientes</h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
        <table>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1"> Cliente:</td>
               <td>
                   <asp:TextBox ID="TextCliAsig" runat="server" Width="300px" CssClass="auto-style7" OnTextChanged="TextCliAsig_TextChanged" ></asp:TextBox>
                                        <asp:Button ID="Buscar" runat="server" Text="Buscar..." width="100px"   
                                            OnClick="BtnBuscarNit_Click" Font-Size="Smaller" />                         
               </td>
                <td>
                     <asp:CheckBox ID="chkActivo" Text="Activo" runat="server" OnCheckedChanged="chkActivo_CheckedChanged" />
                     <asp:CheckBox ID="chkInactivo" Text="Inactivo" runat="server" OnCheckedChanged="chkInactivo_CheckedChanged" />
                </td>
      

            </tr>
             <tr>
                <td style="text-align:right;font-family:Calibri;" class="auto-style1"> RUTA:</td>
                <td class="auto-style3"><asp:DropDownList ID="Ruta" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Ruta_SelectedIndexChanged" style="font-size: xx-small" Width="150px">
                    </asp:DropDownList>
                </td>
             </tr>
            <%-- <tr>
                <td style="text-align:right;font-family:Calibri;" class="auto-style5"> Producto:</td>
               <td>
                   <asp:TextBox ID="TextProd" runat="server" Width="300px" CssClass="auto-style7" ReadOnly="True"></asp:TextBox>
               </td>
            </tr>--%>

             <tr>
                <td style="text-align:right;font-family:Calibri;" class="auto-style5"> Monto Anticipo:</td>
                <td><asp:TextBox ID="TextAnticipo" runat="server" Width="300px" CssClass="auto-style7"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Ubicacion Origen:</td>
                <td><asp:TextBox ID="TextOrigen" runat="server" Width="300px" CssClass="auto-style7"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Ubicacion Destino:</td>
                <td><asp:TextBox ID="TextUbicacion" runat="server" Width="300px" CssClass="auto-style7"></asp:TextBox></td>
            </tr>
            <tr>
                    <td style="text-align: right;font-size:medium; font-family:Calibri;" class="auto-style1">OBS: </td>
                    <td><asp:TextBox ID="txtOBS" runat="server" Width="300px" TextMode="MultiLine" CssClass="upper-case" ></asp:TextBox></td>
            </tr>
            <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Vigencia: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextVigencia" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageVigencia" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                               OnClick="imgCalendarVigencia_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <asp:Calendar ID="CalendarVigencia" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_VigenciaOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
            <tr>
                <td style="text-align:right" class="auto-style1">Total Camiones: </td>
                <td>
                    <asp:Label ID="lblCamiones" runat="server" Text="0.00" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <td>
                <asp:GridView ID="GridViewCamiones" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridViewCamiones_PageIndexChanging" PageSize="20" style="font-weight: 700">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Seleccion">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </table>
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
