<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" 
CodeFile="DepartmentBrowser.aspx.cs"
MasterPageFile="Store.master" %>
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
                     <a href="<%=LinkBuilder.for(deparment)
                                         .to_run<ViewDepartmentsInDepartment>()
                                         .include(x => x.name,"dept_name")%>"><%=department.name%></a>
                     h

                	</td>
           	 </tr>        
             <%
                }
%>
           	
	    </table>            
</asp:Content>
