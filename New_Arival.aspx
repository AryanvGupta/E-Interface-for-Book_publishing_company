
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New_Arival.aspx.cs" Inherits="Project__25M_.New_Arival"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h1>
        <asp:Label ID="Label31" runat="server" ForeColor="#99CCFF" style="font-size: 28pt" Text="New Arrival"></asp:Label>
    </h1>
    <p>&nbsp;</p>
    <p>
        <asp:GridView ID="GridView10" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="0" PageSize="5" HeaderStyle-Height="21px" HeaderStyle-Font-Size="20px" RowStyle-Height="20px" AlternatingRowStyle-Height="20px" DataSourceID="SqlDataSource10" ForeColor="#333333" GridLines="None" Height="16px" Width="840px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Item_Name" SortExpression="Item_Name">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" style="font-size: 15pt" Text='<%# Bind("Item_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item_Type" SortExpression="Item_Type">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Item_Type") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" style="font-size: 15pt" Text='<%# Bind("Item_Type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item_Desc" SortExpression="Item_Desc">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" style="font-size: 15pt" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item_Image" SortExpression="Item_Image">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Item_Image") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="130px" ImageUrl='<%# Eval("Item_Image") %>' Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Item_Name], [Item_Type], [Item_Desc], [Item_Image] FROM [New_Arrival]"></asp:SqlDataSource>
    </p>
    <p>&nbsp;</p>

</asp:Content>
