<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="SiteList.aspx.cs" Inherits="YouXiArticle.Views.Admin.SiteList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form id="form1" runat="server"> <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="YouXiArticle.Models.ArticleDataContext" 
        Select="new (ID, Title, Domain, StylePath)" TableName="SiteInfo" 
          EnableDelete="True" EnableUpdate="True">
    </asp:LinqDataSource>
 
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataSourceID="LinqDataSource1" 
       CellPadding="4" ForeColor="#333333" 
          GridLines="Horizontal" style="margin-right: 292px" Width="445px">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        <%#Html.ActionLink<AdminController>(c=>c.DeleteSite(Eval("ID").ToString()),"删除") %>
        <%#Html.ActionLink<AdminController>(c=>c.Nav((long)Eval("ID"),0),"添加栏目") %>
        </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" 
                SortExpression="Title" />
            <asp:BoundField DataField="Domain" HeaderText="Domain" ReadOnly="True" 
                SortExpression="Domain" />
            <asp:BoundField DataField="StylePath" HeaderText="StylePath" ReadOnly="True" 
                SortExpression="StylePath" />
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    </form>
</asp:Content>
