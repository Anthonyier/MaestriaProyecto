<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormConciliacionAsegurada.aspx.cs" Inherits="CapaPresentacion.FormConciliacionAsegurada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" >
        .auto-style1{
            width:59px
        }
        .auto-style2{
            width: 239px
        }
        .auto-style3{
            width:240px
        }
        .auto-style4{
            width:239px;
            height:26px;
        }
        .auto-style5{
            height:26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo-formulario">
        <table>
            <tr>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                </tr>
            </table>
         <table>
             <tr>
                 <td style="text-align:right;font-family:Calibri;" class="auto-style1">FleteBruto</td>
                 <td>
                      <asp:TextBox ID="TextFleteBruto" runat="server" Width="100px"></asp:TextBox>
                 </td>
                 <td style="text-align:right;font-family:Calibri;" class="auto-style1 ">MultaMerma</td>
                 <td>
                     <asp:TextBox ID="TextMultaMerma" runat="server" Width="100px"></asp:TextBox>
                 </td>
                 <td style="text-align:right;font-family:Calibri;" class="auto-style1">Seguro Prod</td>
                 <td>
                     <asp:TextBox ID="TextSeguroProd" runat="server" Width="100px"></asp:TextBox>
                 </td>
                 <td style="text-align:right;font-family:Calibri;" class="auto-style1">Resp Civil</td>
                 <td>
                     <asp:TextBox ID="TextRespCivil" runat="server" Width="100px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td style="text-align:right;font-family:Calibri;" class="auto-style1">Anticipos</td>
                 <td>
                     <asp:TextBox ID="TextAnticipos" runat="server" Width="100px"></asp:TextBox>
                 </td>
                 <td style="text-align:right;font-family:Calibri;" class="auto-style1">Carro Guia</td>
                 <td>
                     <asp:TextBox ID="TextCarroGuia" runat="server" Width="100px" ></asp:TextBox>
                 </td>
                 <td style="text-align:right;font-family:Calibri" class="auto-style1">Servicios</td>
                 <td>
                     <asp:TextBox ID="TextServicios" runat="server" Width="100px"></asp:TextBox>
                 </td>
                 <td style="text-align:right;font-family:Calibri" class="auto-style1">Adelantos</td>
                 <td>
                     <asp:TextBox ID="TextAdelantos" runat="server" Width="100px"></asp:TextBox>
                 </td>
             </tr>
         </table>
        <br />
        <table>
            <tr>
                <td><asp:Button ID="BtnAsegurar" runat="server" Text="Asegurar" Width="150px" Font-Size="Smaller" 
                    BackColor="Green" font-bold="true" font-italic="false" Height="70px" /></td>
            </tr>
        </table>
          
    </div>
</asp:Content>
