<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCreacionCamiones.aspx.cs" Inherits="CapaPresentacion.FormCreacionCamiones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <input type="text" name="Placa"/>

        <select name="Marca">
            <option value="Toyota">Toyota</option>
            <option value="Mitsubishi">Mitsubishi</option>
            <option value="Honda"> Honda</option>
        </select>

        <select name="Color">
            <option value="Rojo">Rojo</option>
            <option value="Azul">Azul</option>
            <option value="Verde">Verde</option>
            <option value="Amarillo">Amarillo</option>
            </select>

        <input type="text" name="Capcidad" />
        <input type="text" name="CiChofer" />
        <button onclick="buscar">buscar</button>
        <input type="text" name="DatosChofer" />
        <input type="text" name="CiPropietario" />
        <button  onclick="buscar"> buscar</button>
        <input type="text" name="DatosPropietario"/>
        <input type="text" name="DtosTitularBanco" />

    </div>
    </form>
</body>
</html>
