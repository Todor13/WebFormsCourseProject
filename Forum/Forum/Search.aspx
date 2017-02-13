<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Forum.Forum.Search" MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="~/Controls/ThreadsPreview.ascx" TagName="ThreadsPreview" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <uc:ThreadsPreview runat="server" ID="ThreadsPreview" />
</asp:Content>
