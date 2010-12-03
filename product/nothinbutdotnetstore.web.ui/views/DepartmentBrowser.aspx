<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" 
CodeFile="DepartmentBrowser.aspx.cs"
MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application" %>
<%@ Import Namespace="nothinbutdotnetstore.web.infrastructure" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
            <%--each department should go here--%>
            <%
                foreach (var department in this.model)
                {
                    var builder = Link.create();
                    builder.tokenize_with(department).include(x => x.name);
                    if (department.has_products)
                    {
                        builder.to_target<ViewProductsInADepartment>();
                    }
                    else
                    {
                        builder.to_target<ViewDepartmentsInADeparment>();
                    }
%>
            <tr class="ListItem">
               		 <td>                     
                        <a href="<%=builder%>"><%=department.name%> </a>
                     </td>
           	 </tr>        
             <%
                }
%>
           	
	    </table>            
</asp:Content>
