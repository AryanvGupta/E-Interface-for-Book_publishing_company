
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Weekly_Sugg.aspx.cs" Inherits="Project__25M_.Admin_Weekly_Sugg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p />
    <p />
    <p />

        &nbsp;<p />

        <strong>

    <asp:Label ID="Label1" runat="server" style="font-size: 20pt" Text="Weekly Suggestion"></asp:Label>

        </strong>

    <p />
    <p />

        <asp:GridView ID="GridView1" runat="server" HeaderStyle-Font-Size="20px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="22px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Suggestion_Id" DataSourceID="SqlDataSource5" ForeColor="Black" GridLines="Vertical" ShowFooter="True" Width="1131px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Suggestion_Id" InsertVisible="False" SortExpression="Suggestion_Id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Suggestion_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Suggestion_Id") %>' style="font-size: 12.5pt"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>' Placeholder="Name"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>' style="font-size: 12.5pt"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type" SortExpression="Type">
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Type") %>' Placeholder="Type"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Type") %>' style="font-size: 12.5pt"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Description") %>' Placeholder="Description"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>' style="font-size: 12.5pt"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Image") %>' Placeholder="Image Location"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Eval("Image") %>' Width="75px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <FooterTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="20px" ImageUrl="~/Images/23.png" OnClick="ImageButton2_Click" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" ImageUrl="~/Images/delete.jpg" Width="20px" OnClick="ImageButton1_Click1" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Weekly_Suggestion]"></asp:SqlDataSource>
</asp:Content>


