﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaRoles.aspx.cs" Inherits="EticaUNITEC.MantenimientoRoles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/grids/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/forms/style1.css" rel="stylesheet" type="text/css" />
    <link href="../Css/forms/style2.css" rel="stylesheet" type="text/css" />
    <link href="../Css/forms/style3.css" rel="stylesheet" type="text/css" />
    <link href="../Css/forms/signup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="signuponepage main content clearfix">
                <div class="signup-steps step-1 clearfix">
                    <h1 class="redtext">Roles Actuales</h1>
                </div>
            </div>
        </div>
        <div id="container">
        <asp:GridView ID="gridRoles" 
            GridLines="None"
            AllowPaging="true"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt"

            runat="server" 
            AutoGenerateColumns="False" 
            DataSourceID="DSEtica" 
            DataKeyNames="RolId"  
            onrowdeleting="gridRoles_RowDeleting">
            <Columns>
                <asp:BoundField DataField="RolId" HeaderText="RolId" 
                    SortExpression="RolId" ReadOnly="True" Visible="False"/>
                <asp:BoundField DataField="RolNombre" HeaderText="Nombre" 
                    SortExpression="RolNombre" />
                <asp:BoundField DataField="RolDescripcion" HeaderText="Descripción" 
                    SortExpression="RolDescripcion" />
                <asp:TemplateField ShowHeader="False" HeaderText="Modificar">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "MantenimientoRoles.aspx?id=" + Eval("RolId") %>'>Modificar</asp:HyperLink>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="Borrar">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            OnClientClick="return confirm('Esta seguro que quiere borrar este Rol?');"
                            CommandName="Delete" Text="Borrar"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="DSEtica" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBLocalConnectionString %>" 
            SelectCommand="SELECT [RolNombre], [RolDescripcion], [RolId] FROM [Roles]" 
            DeleteCommand="DELETE FROM [Roles] WHERE [RolId] = @RolId" 
            InsertCommand="INSERT INTO [Roles] ([RolNombre], [RolDescripcion]) VALUES (@RolNombre, @RolDescripcion)" 
            UpdateCommand="UPDATE [Roles] SET [RolNombre] = @RolNombre, [RolDescripcion] = @RolDescripcion WHERE [RolId] = @RolId">
            <DeleteParameters>
                <asp:Parameter Name="RolId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="RolNombre" Type="String" />
                <asp:Parameter Name="RolDescripcion" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="RolNombre" Type="String" />
                <asp:Parameter Name="RolDescripcion" Type="String" />
                <asp:Parameter Name="RolId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
            <asp:Button ID="btnAgregar" class="g-button" runat="server" onclick="btnAgregar_Click" Text="Agregar Nuevo" />
        <br />
    
    </div>
    </form>
</body>
</html>
