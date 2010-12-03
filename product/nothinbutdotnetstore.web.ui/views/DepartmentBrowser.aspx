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
                    %>
            <tr class="ListItem">
               		 <td>                     
                   ?sdfsfd :sdfsdf
                        <a href="<%=Link.to_run_iif<ViewProductsInADepartment,ViewDepartmentsInADeparment>(department.has_products)
                                         .tokenize_with(department)
                                         .include(x => x.name)%>"><%=department.name%></a>
                     </td>
           	 </tr>        
             <%
                }
%>
           	
	    </table>            
</asp:Content>
