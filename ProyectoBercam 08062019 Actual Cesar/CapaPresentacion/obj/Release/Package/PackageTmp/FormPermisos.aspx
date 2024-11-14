<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormPermisos.aspx.cs" Inherits="CapaPresentacion.FormPermisos" %>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
            Otorgador de permisos</h2>
        <table>
            <tr>
                <td><asp:TextBox ID="txtBuscar" runat="server" Width="300px" ></asp:TextBox> </td>
                <td><asp:Button ID="BtnBuscar" runat="server" Text="Buscar" width="100px" OnClick="BtnBuscar_Click"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <table>
                    <tr>
                        <td>
                           <h2> 
                               Permiso para personas
                            </h2>
                          </td>
                      </tr>
                 
                    <tr>
                        
                        <td>
                            <asp:CheckBox ID="chkInsertar" Text="Crear Persona" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkDeshab" Text="Deshabilitar" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkUsuario" Text="Crear Usuario" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkDocument" Text="Agregar Documentos" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ChkModificar" Text="Modificar Usuario" runat="server" />
                        </td>
                        <td>
                              <asp:CheckBox ID="ChkLista" Text="Lista de Usuario" runat="server" />
                        </td>
                    </tr>
                    <tr>
                       <td>
                           <asp:Button ID="BtnPersConc" runat="server" Text="<-Servicios" Width="150px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BtnPersConc_Click" />
                       </td>
                        <td>
                            <asp:Button ID="BttnGuardar" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BttnGuardar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPersona" runat="server" Text="Camion->" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButtonPersona_Click" />
                        </td>
                    </tr> 
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table>
                    <tr>
                        <td>
                           <h2> 
                               Permiso para Camiones
                            </h2>
                          </td>
                      </tr>
                    
                     <tr>
                        
                        <td>
                            <asp:CheckBox ID="CheckCamion" Text="Crear Camiom" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckLista" Text="Lista de Camion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckModCam" Text="Modificar Camiones" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckDocumCamion" Text="Documentos de Camion" runat="server" />
                        </td>
                    </tr>
                     <tr>
                       <td>
                           <asp:Button ID="ButtPersona" runat="server" Text="<-Persona" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButtPersona_Click" />
                       </td>
                        <td>
                            <asp:Button ID="ButGuardar" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButGuardar_Click1" />
                        </td>
                        <td>
                            <asp:Button ID="ButtCamion" runat="server" Text="Ruta->" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButtCamion_Click" />
                        </td>
                    </tr> 
                </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <table>
                    <tr>
                        <td>
                           <h2> 
                               Permiso para Rutas
                            </h2>
                          </td>
                      </tr>
                    
                     <tr>
                        
                        <td>
                            <asp:CheckBox ID="CheckRuta" Text="Crear Ruta" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckListaRut" Text="Lista de Rutas" runat="server" />
                        </td>
                         <td>
                             <asp:CheckBox ID="CheckModificarRutas" Text="Modificar Rutas" runat="server" />
                         </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckProgram" Text="Programar Rutas" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckAnular" Text="Anular Rutas" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckListaProgram" Text="Lista Programacion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckEditar" Text="Modificar Programacion" runat="server" />
                        </td>
                       <td>
                           <asp:CheckBox ID="CheckEditMerma" Text="Editar Merma" runat="server" />
                       </td>
                          <td>
                            <asp:CheckBox ID="CheckConfirmar" Text="Confirmar Ruta" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckNoDespachar" Text="No Despachar" runat="server" />
                        </td>
                    </tr>
                     <tr>
                       <td>
                           <asp:Button ID="ButCamion" runat="server" Text="<-Camion" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButCamion_Click" />
                       </td>
                        <td>
                            <asp:Button ID="BuGuardar" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BuGuardar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonRuta" runat="server" Text="Conciliaciones->" Width="150px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButtonRuta_Click" />
                        </td>
                    </tr> 
                </table>
            </asp:View>
            <asp:View ID="View4" runat="server" >
                <table>
                    <tr>
                        <td>
                           <h2> 
                               Permiso para Conciliaciones
                            </h2>
                          </td>
                      </tr>
                     <tr>
                        <td>
                            <asp:CheckBox ID="CheckListaConcCobrarRef" Text="Lista Conciliacion Por Cobrar Ref" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckListaConcCobrarCorp" Text="Lista Conciliacion Por Cobrar Corp" runat="server" />
                        </td>
                         <td>
                             <asp:CheckBox ID="CheckListaConcCobrarAlcohol" Text="Lista Conciliacion Por Cobrar Alcohol" runat="server" />
                         </td>
                         <td>
                             <asp:CheckBox ID="CheckListaConcCobrarAceite" Text="Lista Conciliacion Por Cobrar Aceite" runat="server" />
                         </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckListaConcPagarRef" Text="Lista Conciliacion Por Pagar Ref" runat="server" />
                         </td>
                        <td>
                            <asp:CheckBox ID="CheckListaConcPagarCorp" Text="Lista Conciliaicon Por Pagar Corp" runat="server" />
                        </td>
                             
                        <td>
                            <asp:CheckBox ID="CheckListaConcPagarAlcohol" Text="Lista Conciliacion Pagar Alcohol" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckListaConcPagarAceite" Text="Lista Conciliacion Pagar Aceite" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckAprobarRef" Text="Asegurar Ref" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckAprobarCorp" Text="Asegurar Corp" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckAprobarAlcohol" Text="Asegurar Alcohol" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckAprobarAceite" Text="Asegurar Aceite" runat="server" />
                        </td>
                    </tr>
                     <tr>
                       <td>
                           <asp:Button ID="BConcRuta" runat="server" Text="<-Ruta" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BConcRuta_Click" />
                       </td>
                        <td>
                            <asp:Button ID="BttonConcGuardar" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BttonConcGuardar_Click"  />
                        </td>
                        <td>
                            <asp:Button ID="BttonConcCarro" runat="server" Text="Carro Guia->" Width="130px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BttonConcCarro_Click"  />
                        </td>
                    </tr> 
             
                </table> 

            </asp:View>
          <asp:View ID="View5" runat="server" >
                <table>
                    <tr>
                        <td>
                           <h2> 
                               Permiso para Carro Guia
                            </h2>
                          </td>
                      </tr>
                     <tr>
                        <td>
                            <asp:CheckBox ID="CheckCarroGuia" Text="Crear Carro Guia" runat="server" />
                        </td>
                        
                         </tr>
                    <tr>
                         <td>
                             <asp:CheckBox ID="CheckDetCarroGuia" Text="Crear Detalle de Carro Guia" runat="server" />
                         </td>
                         <td>
                             <asp:CheckBox ID="CheckListaDetCarroGuia" Text="Lista Detalle Carro Guia" runat="server" />
                         </td>
                        <td>
                            <asp:CheckBox ID="CheckAsegCarroGuia" Text="Asegurar Carro Guia" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        
                         <td>
                             <asp:CheckBox ID="CheckConCarroGuia" Text="Crear Conc Carro Guia" runat="server" />
                         </td>
                         <td>
                             <asp:CheckBox ID="CheckListConcCarroGuia" Text="Lista Conc Carro Guia" runat="server" />
                         </td>
                         <td>
                             <asp:CheckBox ID="CheckAprobCarroGuia" Text="Aprobar Conc de Carro Guia" runat="server" /> 
                         </td>
                    </tr>
                     <tr>
                       <td>
                           <asp:Button ID="BtBConci" runat="server" Text="<-Conciliaciones" Width="150px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BtBConci_Click" />
                       </td>
                        <td>
                            <asp:Button ID="BCaroGuia" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BCaroGuia_Click"  />
                        </td>
                        <td>
                            <asp:Button ID="BCarPersona" runat="server" Text="Anticipos->" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="BCarPersona_Click"  />
                        </td>
                    </tr> 
                    </table> 

          </asp:View>
           <asp:View ID="View6" runat="server" >
               <table>
                   <tr>
                       <td>
                           <h2> 
                               Permiso para Anticipos
                            </h2>
                       </td>
                   </tr>
                   <tr>
                        
                         <td>
                             <asp:CheckBox ID="CheckPagarAnticipo" Text="Pagar Anticipo" runat="server" />
                         </td>
                         <td>
                             <asp:CheckBox ID="CheckVerAnticipo" Text="Ver Anticipo" runat="server" />
                         </td>
                         <td>
                             <asp:CheckBox ID="CheckModAnticipo" Text="Modificar Anticipo" runat="server" /> 
                         </td>
                       <td>
                           <asp:CheckBox ID="CheckEliminarAnticipo" Text="EliminarAnticipo" runat="server" />
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Button ID="ButVolCarroGuia" runat="server" Text="<-Carro Guia" Width="150px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButVolCarroGuia_Click" />
                       </td>
                        <td>
                            <asp:Button ID="ButtGuardarPermAnticip" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButtGuardarPermAnticip_Click"   />
                        </td>
                        <td>
                            <asp:Button ID="ButIrPersona" runat="server" Text="Pagos->" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButIrPersona_Click" />
                        </td>
                   </tr>
               </table>
           </asp:View>
            <asp:View ID="View7" runat="server" >
                <table>
                    <tr>
                        <td>
                            <h2>
                                Permiso Para Pagos
                            </h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckPagarLiquidacion" Text="Pagar Liquidacion" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckPagarliquidacionAceite" Text="Pagar Liquidacion Aceite" runat="server" />
                        </td>
                    </tr>
                    <tr>
                         <td>
                           <asp:Button ID="ButAnticVolver" runat="server" Text="<-Anticipo" Width="150px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButAnticVolver_Click"  />
                       </td>
                        <td>
                            <asp:Button ID="ButGuardarPago" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButGuardarPago_Click"  />
                        </td>
                        <td>
                            <asp:Button ID="ButAdelantoDePagoVol" runat="server" Text="Adelanto De Pago->" Width="200px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButAdelantoDePagoVol_Click" />
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View8" runat="server">
                <table>
                    <tr>
                        <td>
                            <h2>
                                Permiso Adelanto De Pagos
                            </h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckPagarAdelantoDePago" Text="Pagar Adelanto De Pago"  runat="server"/>
                        </td>
                    </tr>
                     <tr>
                         <td>
                           <asp:Button ID="ButVolPagados" runat="server" Text="<-Pago Liquidacion" Width="150px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButVolPagados_Click"  />
                       </td>
                        <td>
                            <asp:Button ID="ButtonGuardarPermAdelanto" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButtonGuardarPermAdelanto_Click"  />
                        </td>
                        <td>
                            <asp:Button ID="ButtonAServicios" runat="server" Text="Servicios->" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButtonAServicios_Click" style="height: 29px" />
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View9" runat="server">
                <table>
                    <tr>
                        <td>
                            <h2>
                                Permiso Para Servicios
                            </h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckGuardarTelefono" Text="Guardar Telefono" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckModificarTelefono" Text="ModificarTelefono" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckEliminarTelefono" Text="EliminarTelefono" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckGuardarRastreo" Text="Guardar Rastreo" runat ="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckModificarRastreo" Text="Modificar Rastreo" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckEliminarRastreo" Text="Eliminar Rastreo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:Button ID="ButVolPagAdelant" runat="server" Text="<-Adelanto De Pago" Width="250px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButVolPagAdelant_Click"  />
                       </td>
                        <td>
                            <asp:Button ID="ButonGuardarServicios" runat="server" Text="Guardar" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="ButonGuardarServicios_Click"  />
                        </td>
                        <td>
                            <asp:Button ID="Button3" runat="server" Text="Personas->" Width="100px" BackColor="Yellow"
                                Font-Bold="true" OnClick="Button3_Click" />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        </div>
</asp:Content>
