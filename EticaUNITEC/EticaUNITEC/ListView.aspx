﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="EticaUNITEC.ListView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="CategoriaId" 
        DataSourceID="SqlDataSource1">
      
      
        <EmptyDataTemplate>
            <table runat="server" 
                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        
        <ItemTemplate>
            <tr style="background-color: #FFFBD6;color: #333333;">
                <td>
                    <asp:Label ID="CategoriaNombreLabel" runat="server" 
                        Text='<%# Eval("CategoriaNombre") %>' />
                </td>
                <td>
                    <asp:Label ID="CategoriaIdLabel" runat="server" 
                        Text='<%# Eval("CategoriaId") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="1" 
                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                                <th runat="server">
                                    CategoriaNombre</th>
                                <th runat="server">
                                    CategoriaId</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" 
                        style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
       
    </asp:ListView>
    <asp:ListView ID="ListView2" runat="server" DataKeyNames="CategoriaId" 
        DataSourceID="SqlDataSource1">
        <AlternatingItemTemplate>
            <li style="">CategoriaNombre:
                <asp:Label ID="CategoriaNombreLabel" runat="server" 
                    Text='<%# Eval("CategoriaNombre") %>' />
                <br />
                CategoriaId:
                <asp:Label ID="CategoriaIdLabel" runat="server" 
                    Text='<%# Eval("CategoriaId") %>' />
                <br />
            </li>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <li style="">CategoriaNombre:
                <asp:TextBox ID="CategoriaNombreTextBox" runat="server" 
                    Text='<%# Bind("CategoriaNombre") %>' />
                <br />
                CategoriaId:
                <asp:Label ID="CategoriaIdLabel1" runat="server" 
                    Text='<%# Eval("CategoriaId") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancel" />
            </li>
        </EditItemTemplate>
        <EmptyDataTemplate>
            No data was returned.
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <li style="">CategoriaNombre:
                <asp:TextBox ID="CategoriaNombreTextBox" runat="server" 
                    Text='<%# Bind("CategoriaNombre") %>' />
                <br />CategoriaId:
                <asp:TextBox ID="CategoriaIdTextBox" runat="server" 
                    Text='<%# Bind("CategoriaId") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                    Text="Insert" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Clear" />
            </li>
        </InsertItemTemplate>
        <ItemSeparatorTemplate>
<br />
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <li style="">CategoriaNombre:
                <asp:Label ID="CategoriaNombreLabel" runat="server" 
                    Text='<%# Eval("CategoriaNombre") %>' />
                <br />
                CategoriaId:
                <asp:Label ID="CategoriaIdLabel" runat="server" 
                    Text='<%# Eval("CategoriaId") %>' />
                <br />
            </li>
        </ItemTemplate>
        <LayoutTemplate>
            <ul ID="itemPlaceholderContainer" runat="server" style="">
                <li runat="server" id="itemPlaceholder" />
            </ul>
            <div style="">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <li style="">CategoriaNombre:
                <asp:Label ID="CategoriaNombreLabel" runat="server" 
                    Text='<%# Eval("CategoriaNombre") %>' />
                <br />
                CategoriaId:
                <asp:Label ID="CategoriaIdLabel" runat="server" 
                    Text='<%# Eval("CategoriaId") %>' />
                <br />
            </li>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBLocalConnectionString %>" 
        SelectCommand="SELECT [CategoriaNombre], [CategoriaId] FROM [Categorias]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
