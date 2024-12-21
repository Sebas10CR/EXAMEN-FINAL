<%@ Page Title="" Language="C#" MasterPageFile="~/Capa Vista/Menu.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="EXAMEN_FINAL.Capa_Vista.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="estilopagina.css" rel="stylesheet" />
    0<h1>EMPLEADOS</h1>
         
<div class="section">
    <div class="grid-container">
        <asp:GridView ID="GridView1" runat="server" Width="400px"></asp:GridView>
    </div>
    <div class="form-container">
        <label for="TextBox1">ID:</label>
        <asp:TextBox ID="tID" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        <label for="TextBox2">Numero Carnet:</label>
        <asp:TextBox ID="tNumeroCarnet" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        <label for="TextBox3">Nombre:</label>
        <asp:TextBox ID="tNombre" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        <label for="TextBox4">Fecha Nacimiento:</label>
        <asp:TextBox ID="tFechaNaci" type="date" runat="server" BackColor="#CCCCCC" BorderColor="Black" max="2005-12-31" ></asp:TextBox>

        <label for="TextBox5">Categoria:</label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Selected="True">Administrador</asp:ListItem>
                <asp:ListItem>Operario</asp:ListItem>
                <asp:ListItem>Peón</asp:ListItem>
            </asp:DropDownList>
        
        <label for="TextBox6">Salario:</label>
        <asp:TextBox ID="tSalario" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>
        
        <label for="TextBox7">Direccion:</label>
        <asp:TextBox ID="tDireccion" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>
        
        <label for="TextBox8">Telefono:</label>
        <asp:TextBox ID="tTelefono" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>
        
        <label for="TextBox9">Correo:</label>
        <asp:TextBox ID="tCorreo" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        

        <div class="buttons">
            <asp:Button ID="bAgregar1" runat="server" Text="Agregar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bAgregar1_Click" />
            <asp:Button ID="bBorrar1" runat="server" Text="Borrar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bBorrar1_Click" />
            <asp:Button ID="bConsultar" runat="server" Text="Consultar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bConsultar1_Click" />
            </div>
            <h1>Consultas</h1>
       
            <br />  
            <div class="grid-container2">
            <asp:GridView ID="GridView2" runat="server" Width="400px">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
