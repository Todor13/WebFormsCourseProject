<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Forum.Forum.Home" MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="~/Controls/ThreadsPreview.ascx" TagName="ThreadsPreviw" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <uc:ThreadsPreviw runat="server" ID="ThreadsPreview" OnSearchButtonClick="ThreadsPreview_SearchButtonClick"></uc:ThreadsPreviw>
</asp:Content>
