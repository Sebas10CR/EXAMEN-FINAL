<%@ Page Title="" Language="C#" MasterPageFile="~/Capa Vista/Menu.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EXAMEN_FINAL.Capa_Vista.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="estilopagina.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div style="text-align: center; margin-bottom: 30px;">
            <h1 style="color: #3399FF; font-size: 36px; margin-bottom: 10px;">¡BIENVENIDOS!</h1>
            <h2 style="color: #666; font-size: 20px; margin-bottom: 20px;">Sistema de Gestión de Proyectos de Construcción</h2>
        </div>
        
        <div style="display: grid; grid-template-columns: repeat(auto-fit, minmax(300px, 1fr)); gap: 20px; margin-top: 30px;">
            <div style="background: linear-gradient(135deg, #3399FF, #66B3FF); color: white; padding: 20px; border-radius: 10px; text-align: center;">
                <h3 style="margin-top: 0; font-size: 18px;">👥 Gestión de Empleados</h3>
                <p>Administre la información de sus empleados, categorías y salarios de manera eficiente.</p>
                <ul style="text-align: left; margin: 15px 0;">
                    <li>Registro de empleados con validación</li>
                    <li>Categorías: Administrador, Operario, Peón</li>
                    <li>Control de salarios (₡250,000 - ₡500,000)</li>
                    <li>Consulta y eliminación segura</li>
                </ul>
            </div>
            
            <div style="background: linear-gradient(135deg, #66CC66, #99DD99); color: white; padding: 20px; border-radius: 10px; text-align: center;">
                <h3 style="margin-top: 0; font-size: 18px;">🏗️ Gestión de Proyectos</h3>
                <p>Controle sus proyectos de construcción con fechas y códigos únicos.</p>
                <ul style="text-align: left; margin: 15px 0;">
                    <li>Código único por proyecto</li>
                    <li>Control de fechas de inicio y fin</li>
                    <li>Validación de fechas lógicas</li>
                    <li>Gestión completa del ciclo de vida</li>
                </ul>
            </div>
            
            <div style="background: linear-gradient(135deg, #FF9966, #FFBB99); color: white; padding: 20px; border-radius: 10px; text-align: center;">
                <h3 style="margin-top: 0; font-size: 18px;">📋 Gestión de Asignaciones</h3>
                <p>Asigne empleados a proyectos específicos con control de fechas.</p>
                <ul style="text-align: left; margin: 15px 0;">
                    <li>Asignación empleado-proyecto</li>
                    <li>Control de fechas de asignación</li>
                    <li>Seguimiento de recursos</li>
                    <li>Gestión de equipos de trabajo</li>
                </ul>
            </div>
        </div>
        
        <div style="background-color: #f9f9f9; padding: 20px; border-radius: 10px; margin-top: 30px; border-left: 4px solid #3399FF;">
            <h3 style="color: #3399FF; margin-top: 0;">🚀 Características del Sistema</h3>
            <div style="display: grid; grid-template-columns: repeat(auto-fit, minmax(250px, 1fr)); gap: 15px;">
                <div>
                    <h4 style="color: #666; margin-bottom: 5px;">✅ Validación de Datos</h4>
                    <p style="margin: 0; color: #888;">Validación completa de formularios tanto en cliente como en servidor</p>
                </div>
                <div>
                    <h4 style="color: #666; margin-bottom: 5px;">🛡️ Seguridad</h4>
                    <p style="margin: 0; color: #888;">Confirmaciones para acciones críticas y validación de entrada</p>
                </div>
                <div>
                    <h4 style="color: #666; margin-bottom: 5px;">📱 Responsive</h4>
                    <p style="margin: 0; color: #888;">Diseño adaptativo para diferentes tamaños de pantalla</p>
                </div>
                <div>
                    <h4 style="color: #666; margin-bottom: 5px;">🎨 Interfaz Moderna</h4>
                    <p style="margin: 0; color: #888;">Diseño limpio y profesional con navegación intuitiva</p>
                </div>
            </div>
        </div>
        
        <div style="text-align: center; margin-top: 30px; padding: 20px; background-color: #e8f4f8; border-radius: 10px;">
            <h3 style="color: #3399FF; margin-bottom: 10px;">¿Listo para comenzar?</h3>
            <p style="color: #666; margin-bottom: 20px;">Utilice la navegación superior para acceder a las diferentes secciones del sistema.</p>
            <div style="display: flex; justify-content: center; gap: 15px; flex-wrap: wrap;">
                <a href="Empleados.aspx" style="background-color: #3399FF; color: white; padding: 10px 20px; border-radius: 5px; text-decoration: none; transition: background-color 0.3s;">Gestionar Empleados</a>
                <a href="Proyectos.aspx" style="background-color: #66CC66; color: white; padding: 10px 20px; border-radius: 5px; text-decoration: none; transition: background-color 0.3s;">Gestionar Proyectos</a>
                <a href="Asignaciones.aspx" style="background-color: #FF9966; color: white; padding: 10px 20px; border-radius: 5px; text-decoration: none; transition: background-color 0.3s;">Gestionar Asignaciones</a>
            </div>
        </div>
    </div>
</asp:Content>
