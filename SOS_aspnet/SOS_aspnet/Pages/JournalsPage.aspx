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
	<asp:DropDownList CssClass="dropdown dropdown-toggle" ID="periods_dropdown" runat="server">
	</asp:DropDownList>
	<button class="btn" id="GetCfsJournal" runat="server" onserverclick="GetCfsJournal_Click">&gt;&gt;</button>

	<asp:MultiView ID="Journals" runat="server">
		<asp:View ID="vCfsJournal" runat="server">
			Журнал по детям семей-бенефициантов
		<asp:GridView ID="GVCfsJournal" runat="server" Width="100%" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" ShowHeaderWhenEmpty="True">
			<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
		</asp:GridView>
			<i>You are viewing page
					<%=GVCfsJournal.PageIndex + 1%>
of
					<%=GVCfsJournal.PageCount%>
			</i>
			<asp:Button ID="btnExpCfsJournal" runat="server" OnClick="CfsJournalExport" CssClass="btn" />
		</asp:View>
		<asp:View ID="vPfsJournal" runat="server">
			Журнал по родителям семей-бенефициантов
		<asp:GridView ID="GVPfsJournal" runat="server" Width="100%" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" ShowHeaderWhenEmpty="True" EmptyDataRowStyle="table" EmptyDataText="нет данных для выбранного периода">
			<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
		</asp:GridView>
			<i>You are viewing page
					<%=GVCfsJournal.PageIndex + 1%>
of
					<%=GVCfsJournal.PageCount%>
			</i>
			<asp:Button ID="btnExpPfsJournal" runat="server" OnClick="PfsJournalExport" CssClass="btn" />
		</asp:View>
		<asp:View ID="vSpecJournal" runat="server">
			Журнал по специалистам
		<asp:GridView ID="GVSpecJournal" runat="server" Width="100%" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" ShowHeaderWhenEmpty="True">
			<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
		</asp:GridView>
			<i>You are viewing page
					<%=GVCfsJournal.PageIndex + 1%>
of
					<%=GVCfsJournal.PageCount%>
			</i>
			<asp:Button ID="btnExpSpecJournal" runat="server" OnClick="SpecJournalExport" CssClass="btn" />
		</asp:View>
	</asp:MultiView>
	<label id="lblerror" runat="server" class="error"></label>
	<br />

</asp:Content>
