
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_New_Arrival.aspx.cs" Inherits="Project__25M_.Admin_New_Arrival" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <p>
        &nbsp;</p>
    <p>
        <strong>
        <asp:Label ID="Label6" runat="server" ForeColor="Black" style="font-size: 20pt" Text="New Arrival"></asp:Label>
        </strong>
    <br />
</p>
    <p>
    <asp:GridView ID="GridView1" runat="server" HeaderStyle-Font-Size="18px" HeaderStyle-Height="20px" AutoGenerateColumns="False" DataKeyNames="Item_Id" DataSourceID="SqlDataSource3" BackColor="White" BorderColor="#DEDFDE" CellPadding="0" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" Height="370px" Width="1135px" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item_Id" SortExpression="Item_Id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" PlaceHolder="Item_Id"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" PlaceHolder="Item_Id"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Item_Id") %>' style="font-size: 12.5pt"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item_Name" SortExpression="Item_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Item_Name") %>' PlaceHolder="Item_Name"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox14" runat="server" PlaceHolder="Item_Name"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Item_Name") %>' style="font-size: 12.5pt"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item_Type" SortExpression="Item_Id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Item_Type") %>' PlaceHolder="Item_Type"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox13" runat="server" PlaceHolder="Item_Type"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Item_Type") %>' style="font-size: 12.5pt"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item_Desc" SortExpression="Item_Desc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Item_Desc") %>' PlaceHolder="Item_Desc"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox12" runat="server" PlaceHolder="Item_Desc"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Item_Desc") %>' style="font-size: 12.5pt"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item_Image" SortExpression="Item_Image">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Item_Image") %>' PlaceHolder="Item_Image"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" PlaceHolder="Item_Image"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Eval("Item_Image") %>' Width="75px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <FooterTemplate>
                    <asp:ImageButton ID="ImageButton5" runat="server" Height="20px" ImageUrl="~/Images/23.png" OnClick="ImageButton5_Click" Width="20px" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton4" runat="server" Height="20px" ImageUrl="~/Images/delete.jpg" Width="20px" OnClick="ImageButton4_Click" />
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
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [New_Arrival]"></asp:SqlDataSource>
</p>
</asp:Content>


