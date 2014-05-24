<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="JournalsPage.aspx.cs" Inherits="SOS.Pages.JournalsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
	CFS Journal
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">

	<ul class="nav nav-tabs left">
		<li><a id="aCfsJournal" href="?page=vCfsJournal" onclick="SetJournal" runat="server" class="">Журнал по детям семей-бенефициантов</a></li>
		<li><a id="aPfsJournal" href="?page=vPfsJournal" onclick="SetJournal" runat="server" class="">Журнал по родителям семей-бенефициантов</a></li>
		<li><a id="aSpecJournal" href="?page=vSpecJournal" onclick="SetJournal" runat="server" class="">Журнал по специалистам</a></li>
	</ul>
	<asp:DropDownList CssClass="dropdown dropdown-toggle" ID="periods_dropdown" runat="server" SelectedIndexChanged="GetJournal_Click" AutoPostBack="True">
	</asp:DropDownList>
	<%--	<button class="btn" id="GetCfsJournal" runat="server" onserverclick="GetJournal_Click">&gt;&gt;</button>--%>
	<asp:MultiView ID="Journals" runat="server">
		<asp:View ID="vCfsJournal" runat="server">
			<asp:Button ID="btnExpCfsJournal" runat="server" OnClick="CfsJournalExport" CssClass="btn" Text="Печать" />
			<div style="width: 100%; overflow-x: scroll;">
				<asp:GridView ID="GVCfsJournal" runat="server" Width="100%" AllowPaging="true" PageSize="30" OnPageIndexChanging="gridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" ShowHeaderWhenEmpty="True" EmptyDataText="нет данных для выбранного периода" OnSorting="GVSpecJournal_Sorting">
					<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
				</asp:GridView>
			</div>
			<i>стр. <%=GVCfsJournal.PageIndex + 1%> из <%=GVCfsJournal.PageCount%>
			</i>

		</asp:View>
		<asp:View ID="vPfsJournal" runat="server">
			<asp:Button ID="btnExpPfsJournal" runat="server" OnClick="PfsJournalExport" CssClass="btn" Text="Печать" />
			<div style="width: 100%; overflow-x: scroll;">
				<asp:GridView ID="GVPfsJournal" runat="server" Width="100%" AllowPaging="true" PageSize="30" OnPageIndexChanging="gridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" ShowHeaderWhenEmpty="True" EmptyDataRowStyle="table" EmptyDataText="нет данных для выбранного периода" OnSorting="GVSpecJournal_Sorting">
					<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
				</asp:GridView>
			</div>
			<i>стр. <%=GVPfsJournal.PageIndex + 1%> из <%=GVPfsJournal.PageCount%></i>
		</asp:View>
		<asp:View ID="vSpecJournal" runat="server">
			<asp:Button ID="btnExpSpecJournal" runat="server" OnClick="SpecJournalExport" CssClass="btn" Text="Печать" />
			<div style="width: 100%; overflow-x: scroll;">
				<asp:GridView ID="GVSpecJournal" runat="server" Width="100%" AllowPaging="true" PageSize="30" OnPageIndexChanging="gridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" ShowHeaderWhenEmpty="True" EmptyDataText="нет данных для выбранного периода" OnSorting="GVSpecJournal_Sorting">
					<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
				</asp:GridView>
			</div>
			<i>стр.<%=GVSpecJournal.PageIndex + 1%>из <%=GVSpecJournal.PageCount%></i>
		</asp:View>
	</asp:MultiView>
	<label id="lblerror" runat="server" class="text-error"></label>
	<br />

</asp:Content>
