﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Capa Vista/Menu.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="EXAMEN_FINAL.Capa_Vista.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="estilopagina.css" rel="stylesheet" />
    <h1>ASIGNACIONES</h1>
     
<div class="section">
    <div class="grid-container">
        <asp:GridView ID="GridView1" runat="server" Width="400px"></asp:GridView>
    </div>
    <div class="form-container">
        <label for="TextBox1">ID:</label>
        <asp:TextBox ID="tID" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        <label for="TextBox2">Empleado ID:</label>
        <asp:TextBox ID="tEmpleadoID" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        <label for="TextBox3">ProyectoID:</label>
        <asp:TextBox ID="tProyectoID" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        <label for="TextBox4">Fecha Asignacion:</label>
        <asp:TextBox ID="tFechaAsig" Type="date" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>



        

        <div class="buttons">
            <asp:Button ID="bAgregar1" runat="server" Text="Agregar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bAgregar1_Click" />
            <asp:Button ID="bBorrar1" runat="server" Text="Borrar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bBorrar1_Click" />
            
            </div>
            
        </div>
    </div>
</asp:Content>