<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="CyberBabushka.Pages.Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CyberBabushka</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%
                
                foreach (CyberBabushka.Models.Product product in GetProducts())
                {
                    Response.Write(String.Format(@"
                        <div class='item'>
                            <h3>{0}</h3>
                            {1}
                            <h4>{2:c}</h4>
                        </div>",
                        product.Name, product.Description, product.Price));
                }
            %>
        </div>
    </form>
</body>
</html>
