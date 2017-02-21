<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Forum._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to Heat Discussion</h1>
        <p>A must join discussion forum for every blogger. Here you can get lots of information about various popular topics.</p>
        <p><asp:HyperLink runat="server" ID="Forum" Text="Go to Forum" NavigateUrl="~/Forum/Home.aspx" /></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Newest Threads</h2>
            <p>
                 <asp:Repeater runat="server" ID="RepeaterNewestThreads" 
                     ItemType="Forum.Data.Thread" DataSource="<%# Model.NewestThreads %>">
                     <HeaderTemplate>
                         <ul>
                     </HeaderTemplate>
                     <ItemTemplate>
                         <li><asp:HyperLink runat="server" ID="HyperLinkNewest" 
                             Text="<%#: Item.Title %>" NavigateUrl='<%# GetRouteUrl("ForumTitle", new {id = Item.Id}) %>' /></li>
                     </ItemTemplate>
                     <FooterTemplate>
                         </ul>
                     </FooterTemplate>
                 </asp:Repeater>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Most Answered Threads</h2>
            <p>
              <asp:Repeater runat="server" ID="RepeaterMostAnsweredThreads" 
                     ItemType="Forum.Data.Thread" DataSource="<%# Model.MostDiscussedThreads %>">
                     <HeaderTemplate>
                         <ul>
                     </HeaderTemplate>
                     <ItemTemplate>
                         <li><asp:HyperLink runat="server" ID="HyperLinkNewest" 
                             Text="<%#: Item.Title %>" NavigateUrl='<%# GetRouteUrl("ForumTitle", new {id = Item.Id}) %>' /></li>
                     </ItemTemplate>
                     <FooterTemplate>
                         </ul>
                     </FooterTemplate>
                 </asp:Repeater>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Important Threads</h2>
            <p>
                <asp:Repeater runat="server" ID="RepeaterImportant" 
                     ItemType="Forum.Data.Thread" DataSource="<%# Model.ImportantThreads %>">
                     <HeaderTemplate>
                         <ul>
                     </HeaderTemplate>
                     <ItemTemplate>
                         <li><asp:HyperLink runat="server" ID="HyperLinkNewest" 
                             Text="<%#: Item.Title %>" NavigateUrl='<%# GetRouteUrl("ForumTitle", new {id = Item.Id}) %>' /></li>
                     </ItemTemplate>
                     <FooterTemplate>
                         </ul>
                     </FooterTemplate>
                 </asp:Repeater>
            </p>
        </div>
    </div>

</asp:Content>
