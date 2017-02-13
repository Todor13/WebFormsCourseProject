<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Forum.Forum.Test" %>
<%@ Register Src="~/Controls/ThreadsPreview.ascx" TagName="ThreadsPreview" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ForumMainContent" runat="server">
    <h1>Test</h1>
    <uc:ThreadsPreview runat="server" ID="ThreadsPreviewUC" />
</asp:Content>
