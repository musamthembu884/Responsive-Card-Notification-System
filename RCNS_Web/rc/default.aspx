<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="rc._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="jquery-1.11.2.min.js"></script>
<script src="functions.js" type="text/javascript"></script>
    <link href="style.css" rel="stylesheet" type="text/css"/>
<link href="https://fonts.googleapis.com/css?family=Poiret+One" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <div class = "Container">
       
       <div class = "Logo"></div>
       
        <div class = "Brand">
        	<h1>RCNS</h1>
            <p>Responsive Card Notification System</p>
        </div>
                      <asp:TextBox ID="TextBox1" runat="server" CssClass="btnGetStarted2" MaxLength="9"></asp:TextBox>
            <asp:Button ID="start" runat="server" Text="Search" CssClass="btnGetStarted"  style="text-decoration:none; color:#3F3F3F"  OnClick="start_Click"/>

    </div>
    </form>
</body>
</html>
