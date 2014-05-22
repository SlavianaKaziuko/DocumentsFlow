<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SOS.Pages.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
	Журнал специалиста
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
				
		<asp:GridView ID="GVIndivJournal" runat="server" Width="100%" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridView_PageIndexChanging">
			<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
		</asp:GridView>
			<i>You are viewing page
					<%=GVIndivJournal.PageIndex + 1%>
of
					<%=GVIndivJournal.PageCount%>
			</i>
			<asp:Button ID="btnExpJournal" runat="server" OnClick="JournalExport" CssClass="btn"  Visible="False"/>


</asp:Content>
