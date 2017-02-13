<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThreadsPreview.ascx.cs" Inherits="Forum.Controls.ThreadsPreview" %>
<div class="threads-preview-wrapper">
    <asp:Button ID="CreateThreadButton" runat="server" Text="Create Thread" PostBackUrl="~/Forum/CreateThread.aspx" />
    <br />
    <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
    <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
    <br />
    <hr />
    <asp:ListView ID="ListViewThreads" runat="server"
        ItemType="Forum.Data.Thread" DataSource="<%# ThreadsDataSource %>">
        <LayoutTemplate>
            <h3>Threads</h3>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>

        <ItemTemplate>
            <div class="title">
                <h4>
                    <asp:HyperLink ID="HyperLinkTitle" runat="server"
                        NavigateUrl='<%# GetRouteUrl("ForumTitle", new {id = Item.Id}) %>'> 
    <%#: Item.Title %>
                    </asp:HyperLink></h4>
            </div>
            <div class="published">
                <p>
                    Published by <%#: Item.AspNetUser.Email %> on
                    <%#: String.Format("{0:dd/MMMM/yyyy H:mm:ss}", Item.Published) %> in 
                    <%#: Item.Section.Name %>
                </p>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPagerThreads" runat="server"
        PagedControlID="ListViewFake"
        QueryStringField="page" PageSize="3">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
        </Fields>
    </asp:DataPager>
    <asp:ListView ID="ListViewFake" runat="server" Visible="false">
        <ItemTemplate>
        </ItemTemplate>
    </asp:ListView>
</div>
