<%@ Page Title="" Language="C#" MasterPageFile="~/Capa Vista/Menu.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="EXAMEN_FINAL.Capa_Vista.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="estilopagina.css" rel="stylesheet" />
    <h1>ASIGNACIONES</h1>
     
<div class="section">
    <div class="grid-container">
        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="grid-view" AutoGenerateColumns="True"
            HeaderStyle-BackColor="#3399FF" HeaderStyle-ForeColor="White" RowStyle-BackColor="#F9F9F9">
        </asp:GridView>
    </div>
    <div class="form-container">
        <h3>Gestión de Asignaciones</h3>
        
        <label for="tID">ID:</label>
        <asp:TextBox ID="tID" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="ID de la asignación (solo para eliminación)"></asp:TextBox>

        <label for="ddlEmpleados">Empleado: <span class="required">*</span></label>
        <asp:DropDownList ID="ddlEmpleados" runat="server" BackColor="#CCCCCC" BorderColor="Black" AutoPostBack="true" OnSelectedIndexChanged="ddlEmpleados_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvEmpleado" runat="server" ControlToValidate="ddlEmpleados" 
            ErrorMessage="Debe seleccionar un empleado" CssClass="error-message" ValidationGroup="AsignacionGroup"></asp:RequiredFieldValidator>

        <label for="tEmpleadoID">ID Empleado: <span class="required">*</span></label>
        <asp:TextBox ID="tEmpleadoID" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="ID del empleado" TextMode="Number" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmpleadoID" runat="server" ControlToValidate="tEmpleadoID" 
            ErrorMessage="El ID del empleado es obligatorio" CssClass="error-message" ValidationGroup="AsignacionGroup"></asp:RequiredFieldValidator>

        <label for="ddlProyectos">Proyecto: <span class="required">*</span></label>
        <asp:DropDownList ID="ddlProyectos" runat="server" BackColor="#CCCCCC" BorderColor="Black" AutoPostBack="true" OnSelectedIndexChanged="ddlProyectos_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvProyecto" runat="server" ControlToValidate="ddlProyectos" 
            ErrorMessage="Debe seleccionar un proyecto" CssClass="error-message" ValidationGroup="AsignacionGroup"></asp:RequiredFieldValidator>

        <label for="tProyectoID">ID Proyecto: <span class="required">*</span></label>
        <asp:TextBox ID="tProyectoID" runat="server" BackColor="#CCCCCC" BorderColor="Black" placeholder="ID del proyecto" TextMode="Number" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvProyectoID" runat="server" ControlToValidate="tProyectoID" 
            ErrorMessage="El ID del proyecto es obligatorio" CssClass="error-message" ValidationGroup="AsignacionGroup"></asp:RequiredFieldValidator>

        <label for="tFechaAsig">Fecha de Asignación: <span class="required">*</span></label>
        <asp:TextBox ID="tFechaAsig" Type="date" runat="server" BackColor="#CCCCCC" BorderColor="Black" required></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFechaAsig" runat="server" ControlToValidate="tFechaAsig" 
            ErrorMessage="La fecha de asignación es obligatoria" CssClass="error-message" ValidationGroup="AsignacionGroup"></asp:RequiredFieldValidator>

        <p class="required-note"><span class="required">*</span> Campos obligatorios</p>
        <p style="color: #666; font-size: 12px; font-style: italic;">
            💡 Puede usar los dropdowns para seleccionar automáticamente los IDs, o ingresarlos manualmente.
        </p>

        <div class="buttons">
            <asp:Button ID="bAgregar1" runat="server" Text="Agregar" BackColor="#3399FF" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bAgregar1_Click" ValidationGroup="AsignacionGroup"
                OnClientClick="return confirm('¿Está seguro que desea crear esta asignación?');" />
            <asp:Button ID="bBorrar1" runat="server" Text="Borrar" BackColor="#FF6666" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bBorrar1_Click" CausesValidation="false"
                OnClientClick="return confirm('¿Está seguro que desea eliminar esta asignación? Esta acción no se puede deshacer.');" />
            <asp:Button ID="bLimpiar" runat="server" Text="Limpiar" BackColor="#FFCC66" BorderColor="Black" 
                Font-Names="Arial Black" Font-Size="Medium" OnClick="bLimpiar_Click" CausesValidation="false" />
        </div>
    </div>
</div>
</asp:Content>
