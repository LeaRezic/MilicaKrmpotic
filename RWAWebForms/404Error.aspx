<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404Error.aspx.cs" Inherits="RWAWebForms._404Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>404</title>
    <script src="Scripts/jquery-1.12.4.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="center-block" style="text-align:center">
            <img src="Content/Images/404.JPG" alt="404 image" />
            <p>
                No such file... <a href="UsersList.aspx" class="alert-link">RETURN</a>
            </p>
        </div>
    </form>
</body>
</html>
