<%@ Page Title="" Language="C#" MasterPageFile="~/Capa Vista/Menu.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="EXAMEN_FINAL.Capa_Vista.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="estilopagina.css" rel="stylesheet" />
    <h1>EMPLEADOS</h1>
         
<div class="section">
    <div class="grid-container">
        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="grid-view" AutoGenerateColumns="True"
            HeaderStyle-BackColor="#3399FF" HeaderStyle-ForeColor="White" RowStyle-BackColor="#F9F9F9">
        </asp:GridView>
    </div>
    <div class="form-container">
        <h3>Gestión de Empleados</h3>
        
        <!-- Search Section -->
        <div style="background-color: #f0f8ff; padding: 15px; border-radius: 5px; margin-bottom: 20px;">
            <h4 style="color: #3399FF; margin-top: 0;">🔍 Búsqueda de Empleados</h4>
            <div style="display: grid; grid-template-columns: 1fr auto; gap: 10px; align-items: end;">
                <div>
                    <label for="tBuscar">Buscar por nombre, carnet o correo:</label>
                    <asp:TextBox ID="tBuscar" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Ingrese término de búsqueda"></asp:TextBox>
                </div>
                <asp:Button ID="bBuscar" runat="server" Text="Buscar" BackColor="#6699FF" BorderColor="Black" 
                    Font-Names="Arial Black" Font-Size="Medium" OnClick="bBuscar_Click" CausesValidation="false" />
            </div>
        </div>
        
        <label for="tID">ID:</label>
        <asp:TextBox ID="tID" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="ID del empleado (solo para consulta/eliminación)"></asp:TextBox>

        <label for="tNumeroCarnet">Número de Carnet: <span class="required">*</span></label>
        <asp:TextBox ID="tNumeroCarnet" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Número de carnet único" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNumeroCarnet" runat="server" ControlToValidate="tNumeroCarnet" 
            ErrorMessage="El número de carnet es obligatorio" CssClass="error-message" ValidationGroup="EmpleadoGroup"></asp:RequiredFieldValidator>

        <label for="tNombre">Nombre: <span class="required">*</span></label>
        <asp:TextBox ID="tNombre" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Nombre completo" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tNombre" 
            ErrorMessage="El nombre es obligatorio" CssClass="error-message" ValidationGroup="EmpleadoGroup"></asp:RequiredFieldValidator>

        <label for="tFechaNaci">Fecha de Nacimiento: <span class="required">*</span></label>
        <asp:TextBox ID="tFechaNaci" type="date" runat="server" BackColor="#CCCCCC" BorderColor="Black" max="2005-12-31" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFechaNaci" runat="server" ControlToValidate="tFechaNaci" 
            ErrorMessage="La fecha de nacimiento es obligatoria" CssClass="error-message" ValidationGroup="EmpleadoGroup"></asp:RequiredFieldValidator>

        <label for="DropDownList1">Categoría:</label>
        <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#CCCCCC" BorderColor="Black">
            <asp:ListItem Selected="True" Value="Administrador">Administrador</asp:ListItem>
            <asp:ListItem Value="Operario">Operario</asp:ListItem>
            <asp:ListItem Value="Peón">Peón</asp:ListItem>
        </asp:DropDownList>
        
        <label for="tSalario">Salario (₡250,000 - ₡500,000): <span class="required">*</span></label>
        <asp:TextBox ID="tSalario" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Ejemplo: 350000" TextMode="Number" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSalario" runat="server" ControlToValidate="tSalario" 
            ErrorMessage="El salario es obligatorio" CssClass="error-message" ValidationGroup="EmpleadoGroup"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvSalario" runat="server" ControlToValidate="tSalario" 
            MinimumValue="250000" MaximumValue="500000" Type="Double"
            ErrorMessage="El salario debe estar entre ₡250,000 y ₡500,000" CssClass="error-message" ValidationGroup="EmpleadoGroup"></asp:RangeValidator>
        
        <label for="tDireccion">Dirección:</label>
        <asp:TextBox ID="tDireccion" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Dirección (por defecto: San José)"></asp:TextBox>
        
        <label for="tTelefono">Teléfono:</label>
        <asp:TextBox ID="tTelefono" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="Número de teléfono"></asp:TextBox>
        
        <label for="tCorreo">Correo: <span class="required">*</span></label>
        <asp:TextBox ID="tCorreo" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="correo@ejemplo.com" TextMode="Email" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="tCorreo" 
            ErrorMessage="El correo es obligatorio" CssClass="error-message" ValidationGroup="EmpleadoGroup"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="tCorreo" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ErrorMessage="Por favor ingrese un correo válido" CssClass="error-message" ValidationGroup="EmpleadoGroup"></asp:RegularExpressionValidator>

        <p class="required-note"><span class="required">*</span> Campos obligatorios</p>

        <div class="buttons">
            <asp:Button ID="bAgregar1" runat="server" Text="Agregar" BackColor="#3399FF" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bAgregar1_Click" ValidationGroup="EmpleadoGroup"
                OnClientClick="return confirm('¿Está seguro que desea agregar este empleado?');" />
            <asp:Button ID="bBorrar1" runat="server" Text="Borrar" BackColor="#FF6666" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bBorrar1_Click" CausesValidation="false"
                OnClientClick="return confirm('¿Está seguro que desea eliminar este empleado? Esta acción no se puede deshacer.');" />
            <asp:Button ID="bConsultar" runat="server" Text="Consultar" BackColor="#66CC66" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bConsultar1_Click" CausesValidation="false" />
            <asp:Button ID="bLimpiar" runat="server" Text="Limpiar" BackColor="#FFCC66" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bLimpiar_Click" CausesValidation="false" />
        </div>
        
        <h3>Resultado de Consulta</h3>
        <div class="grid-container2">
            <asp:GridView ID="GridView2" runat="server" Width="100%" CssClass="grid-view" AutoGenerateColumns="True"
                HeaderStyle-BackColor="#66CC66" HeaderStyle-ForeColor="White" RowStyle-BackColor="#F9F9F9">
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>
