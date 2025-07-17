<%@ Page Title="" Language="C#" MasterPageFile="~/Capa Vista/Menu.Master" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" Inherits="EXAMEN_FINAL.Capa_Vista.Proyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="estilopagina.css" rel="stylesheet" />
    <h1>PROYECTOS</h1>
      
<div class="section">
    <div class="grid-container">
        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="grid-view" AutoGenerateColumns="True"
            HeaderStyle-BackColor="#3399FF" HeaderStyle-ForeColor="White" RowStyle-BackColor="#F9F9F9">
        </asp:GridView>
    </div>
    <div class="form-container">
        <h3>Gestión de Proyectos</h3>
        
        <label for="tID">ID:</label>
        <asp:TextBox ID="tID" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="ID del proyecto (solo para eliminación)"></asp:TextBox>

        <label for="tCodigo">Código: <span class="required">*</span></label>
        <asp:TextBox ID="tCodigo" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Código único del proyecto" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="tCodigo" 
            ErrorMessage="El código es obligatorio" CssClass="error-message" ValidationGroup="ProyectoGroup"></asp:RequiredFieldValidator>

        <label for="tNombre">Nombre: <span class="required">*</span></label>
        <asp:TextBox ID="tNombre" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Nombre del proyecto" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tNombre" 
            ErrorMessage="El nombre es obligatorio" CssClass="error-message" ValidationGroup="ProyectoGroup"></asp:RequiredFieldValidator>

        <label for="tFechaInicio">Fecha de Inicio: <span class="required">*</span></label>
        <asp:TextBox ID="tFechaInicio" Type="date" runat="server" BackColor="#CCCCCC" BorderColor="Black" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="tFechaInicio" 
            ErrorMessage="La fecha de inicio es obligatoria" CssClass="error-message" ValidationGroup="ProyectoGroup"></asp:RequiredFieldValidator>

        <label for="tFechaFin">Fecha de Fin:</label>
        <asp:TextBox ID="tFechaFin" Type="date" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Opcional"></asp:TextBox>
        <asp:CompareValidator ID="cvFechaFin" runat="server" ControlToValidate="tFechaFin" 
            ControlToCompare="tFechaInicio" Operator="GreaterThan" Type="Date"
            ErrorMessage="La fecha de fin debe ser posterior a la fecha de inicio" CssClass="error-message" ValidationGroup="ProyectoGroup"></asp:CompareValidator>

        <p class="required-note"><span class="required">*</span> Campos obligatorios</p>

        <div class="buttons">
            <asp:Button ID="bAgregar1" runat="server" Text="Agregar" BackColor="#3399FF" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bAgregar1_Click" ValidationGroup="ProyectoGroup"
                OnClientClick="return confirm('¿Está seguro que desea agregar este proyecto?');" />
            <asp:Button ID="bBorrar1" runat="server" Text="Borrar" BackColor="#FF6666" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bBorrar1_Click" CausesValidation="false"
                OnClientClick="return confirm('¿Está seguro que desea eliminar este proyecto? Esta acción no se puede deshacer.');" />
            <asp:Button ID="bLimpiar" runat="server" Text="Limpiar" BackColor="#FFCC66" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bLimpiar_Click" CausesValidation="false" />
        </div>
    </div>
</div>
</asp:Content>
