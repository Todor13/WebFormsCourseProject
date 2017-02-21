<%@ Page Title="" Language="C#" MasterPageFile="~/Forum/Forum.master" AutoEventWireup="true" CodeBehind="CreateThread.aspx.cs" Inherits="Forum.Forum.CreateThread" ValidateRequest="false" %>

<asp:Content ContentPlaceHolderID="ForumMainContent" ID="CreateThreadContent" runat="server">
    <h2>Create Thread</h2>
    <asp:Label runat="server" ID="LabelError" Text="<%# Model.Error %>" />
    <hr />
    <asp:Label ID="LabelTitle" Font-Size="Large" runat="server" Text="Title"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" Display="Dynamic" ControlToValidate="TextBoxTitle"
         runat="server" ForeColor="DarkRed" ErrorMessage=" is required!"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" ControlToValidate="TextBoxTitle" 
        ValidationExpression="^.{7,100}$" runat="server" ForeColor="DarkRed"
         ErrorMessage=" length must be between 7 and 100 characters long!"></asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="TextBoxTitle" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
    <br />
    <hr />
    <asp:Label ID="LabelSection" Font-Size="Large" runat="server" Text="Select Section"></asp:Label>
    <br />
    <asp:DropDownList runat="server" ID="DropDownSections" DataSource="<%# Model.Sections %>"></asp:DropDownList>
    <br />
    <hr />
    <asp:Label ID="LabelContent" Font-Size="Large" runat="server" Text="Content"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldContent" runat="server" ErrorMessage=" is required!" 
        ControlToValidate="TextBoxContent" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidatorContent" ControlToValidate="TextBoxContent" 
        ValidationExpression="^.{50,}$" runat="server" ForeColor="DarkRed" 
        ErrorMessage=" length must be between 50 and 2500 characters long!"></asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="TextBoxContent" runat="server" Width="100%" Height="15em" TextMode="MultiLine"></asp:TextBox>
    <br /><br />
    <asp:Button ID="ButtonCreate" runat="server" CausesValidation="true" Text="Create" OnClick="ButtonCreate_Click" />
    <hr />

</asp:Content>
