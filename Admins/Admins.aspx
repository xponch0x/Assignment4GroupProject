<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admins.aspx.cs" Inherits="Assignment4GroupProject.Admins.Admins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        Hello!&nbsp;&nbsp;&nbsp;
        <asp:LoginName ID="LoginName1" runat="server" />
&nbsp;&nbsp;&nbsp;
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:GridView ID="adminGridViewInstructor" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="128px" Width="496px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <asp:GridView ID="adminGridViewMember" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="128px" Width="496px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <strong>
        <asp:Label ID="Label1" runat="server" CssClass="text-decoration-underline" Text="Add Member"></asp:Label>
        </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
        <asp:Label ID="Label2" runat="server" CssClass="text-decoration-underline" Text="Add Instructor"></asp:Label>
        </strong>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 166px; height: 21px">MemberEmail:</td>
                <td style="width: 330px; height: 21px">
                    <asp:TextBox ID="txtMemberEmail" runat="server" Width="197px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 160px">InstructorFirstName:</td>
                <td style="height: 21px">
                    <asp:TextBox ID="txtInstructorFirstName" runat="server" Width="197px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 21px; width: 166px">MemberFirstName:</td>
                <td style="height: 21px; width: 330px">
                    <asp:TextBox ID="txtMemberFirstName" runat="server" Width="197px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 160px">InstructorLastName:</td>
                <td style="height: 21px">
                    <asp:TextBox ID="txtInstructorLastName" runat="server" Width="197px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 166px">MemberLastName:</td>
                <td style="width: 330px">
                    <asp:TextBox ID="txtMemberLastName" runat="server" Width="197px"></asp:TextBox>
                </td>
                <td style="width: 160px">InstructorPhone:</td>
                <td>
                    <asp:TextBox ID="txtInstructorPhone" runat="server" Width="197px"></asp:TextBox>
&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td style="width: 166px">MemberPhoneNumber:</td>
                <td style="width: 330px">
                    <asp:TextBox ID="txtMemberPhoneNumber" runat="server" Width="197px"></asp:TextBox>
                </td>
                <td style="width: 160px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 166px">&nbsp;</td>
                <td style="width: 330px">&nbsp;&nbsp; </td>
                <td style="width: 160px">UserName:</td>
                <td>
                    <asp:TextBox ID="txtInstructorUserName" runat="server" Width="197px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 166px">UserName:</td>
                <td style="width: 330px">
                    <asp:TextBox ID="txtMemberUserName" runat="server" Width="197px"></asp:TextBox>
                </td>
                <td style="width: 160px">UserPassword:</td>
                <td>
                    <asp:TextBox ID="txtInstructorPassword" runat="server" Width="197px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 166px">UserPassword:</td>
                <td style="width: 330px">
                    <asp:TextBox ID="txtMemberPassword" runat="server" Width="197px"></asp:TextBox>
                </td>
                <td style="width: 160px">
                    <asp:Button ID="btnAddInstructor" runat="server" OnClick="btnAddInstructor_Click" Text="Add" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 166px">
                    <asp:Button ID="btnAddMember" runat="server" OnClick="btnAddMember_Click" Text="Add" />
                </td>
                <td style="width: 330px">&nbsp;</td>
                <td style="width: 160px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <strong>
        <asp:Label ID="Label5" runat="server" CssClass="text-decoration-underline" Text="Assign Member To Section"></asp:Label>
        </strong>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="height: 21px; width: 108px">Member_ID:</td>
                <td style="height: 21px; width: 355px">
                    <asp:TextBox ID="txtMemberId" runat="server"></asp:TextBox>
                </td>
                <td style="height: 21px"></td>
            </tr>
            <tr>
                <td style="width: 108px">SectionID:</td>
                <td style="width: 355px">
                    <asp:TextBox ID="txtSectionId" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="btnAssignMemberToSection" runat="server" OnClick="btnAssignMemberToSection_Click" Text="Assign" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <strong>
        <asp:Label ID="Label3" runat="server" CssClass="text-decoration-underline" Text="Delete Member"></asp:Label>
        </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
        <asp:Label ID="Label4" runat="server" CssClass="text-decoration-underline" Text="Delete Instructor"></asp:Label>
        </strong>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 128px; height: 21px">Member_UserID:</td>
                <td style="height: 21px; width: 145px">
                    <asp:TextBox ID="txtDeleteMemberId" runat="server"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 227px">&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td style="height: 21px; width: 104px">InstructorID:</td>
                <td style="height: 21px; width: 148px">
                    <asp:TextBox ID="txtDeleteInstructorId" runat="server"></asp:TextBox>
                </td>
                <td style="height: 21px">&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td style="width: 128px">
                    <asp:Button ID="btnDeleteMember" runat="server" OnClick="btnDeleteMember_Click" Text="Delete" />
                </td>
                <td style="width: 145px">&nbsp;</td>
                <td style="width: 227px">&nbsp;</td>
                <td style="width: 104px">
                    <asp:Button ID="btnDeleteInstructor" runat="server" OnClick="btnDeleteInstructor_Click" Text="Delete" />
                </td>
                <td style="width: 148px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 128px">&nbsp;</td>
                <td style="width: 145px">&nbsp;</td>
                <td style="width: 227px">&nbsp;</td>
                <td style="width: 104px">&nbsp;</td>
                <td style="width: 148px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
    </p>
</asp:Content>
