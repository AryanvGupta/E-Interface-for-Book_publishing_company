<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Product_Status.aspx.cs" Inherits="Project__25M_.Admin_Product_Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
<br />

    <strong>

    <asp:Label ID="Label1" runat="server" style="font-size: 20pt" Text="Product Status"></asp:Label>
    </strong>
    <br />


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="7" RowStyle-Height="15px" HeaderStyle-Height="20px" HeaderStyle-Font-Size="16px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="1" DataKeyNames="Order_Id" DataSourceID="SqlDataSource4" ForeColor="Black" GridLines="Vertical" Height="16px" Width="1194px" AllowPaging="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Order_Id" InsertVisible="False" SortExpression="Order_Id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" style="font-size: 10pt" Text='<%# Eval("Order_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" style="font-size: 10pt" Text='<%# Bind("Order_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User_Id" SortExpression="User_Id">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" style="font-size: 10pt" Text='<%# Bind("User_Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" style="font-size: 10pt" Text='<%# Bind("User_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User_Name" SortExpression="User_Name">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" style="font-size: 10pt" Text='<%# Bind("User_Name") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" style="font-size: 10pt" Text='<%# Bind("User_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Package_Status" SortExpression="Package_Status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Package_Status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" style="font-size: 10pt" Text='<%# Bind("Package_Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tenitive_Dlv_Date" SortExpression="Tenitive_Delivery_Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tenitive_Delivery_Date") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" style="font-size: 10pt" Text='<%# Bind("Tenitive_Delivery_Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Products" SortExpression="Products">
                    <EditItemTemplate>
                        <asp:Label ID="Label6" runat="server" style="font-size: 10pt" Text='<%# Bind("Products") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" style="font-size: 10pt" Text='<%# Bind("Products") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Products_Image" SortExpression="Products_Image">
                    <EditItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Bind("Products_Image") %>' Width="80px" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Bind("Products_Image") %>' Width="80px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                    <EditItemTemplate>
                        <asp:Label ID="Label8" runat="server" style="font-size: 10pt" Text='<%# Bind("Quantity") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" style="font-size: 10pt" Text='<%# Bind("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                    <EditItemTemplate>
                        <asp:Label ID="Label9" runat="server" style="font-size: 10pt" Text='<%# Bind("Amount") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" style="font-size: 10pt" Text='<%# Bind("Amount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="20px" ImageUrl="~/Images/update.png" CommandName="Update" Width="20px" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="20px" ImageUrl="~/Images/cancel.jfif" CommandName="Cancel" Width="20px" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" ImageUrl="~/Images/edit.jpg" CommandName="Edit" />
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
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Product_Status]" UpdateCommand="UPDATE Product_Status SET Package_Status = @Package_Status, Tenitive_Delivery_Date = @Tenitive_Delivery_Date WHERE (Order_Id = @Order_Id)">
            <UpdateParameters>
                <asp:ControlParameter ControlID="GridView1" Name="Package_Status" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="GridView1" Name="Tenitive_Delivery_Date" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="GridView1" Name="Order_Id" PropertyName="SelectedValue" />
            </UpdateParameters>
    </asp:SqlDataSource>
    <p />


</asp:Content>
