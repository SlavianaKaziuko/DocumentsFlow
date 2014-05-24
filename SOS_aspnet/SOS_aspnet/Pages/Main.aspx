<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SOS.Pages.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
	Журнал специалиста
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">

	<div id="divUser" runat="server">
		<asp:GridView ID="GVIndivCfsJournal" runat="server" Width="100%" AllowPaging="true" PageSize="30" OnPageIndexChanging="CFSgridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" FooterStyle="table" OnSorting="Sorting">
			<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
		</asp:GridView>
		<i>стр.<%=GVIndivCfsJournal.PageIndex + 1%> из <%=GVIndivCfsJournal.PageCount%>
		</i>
		<br />
		<asp:DropDownList ID="selCfsConsult" runat="server"></asp:DropDownList>
		<button class="btn" id="btnGoToCfsConsult" runat="server" onserverclick="ViewCfsConsult">Перейти к редактированию (CFS)</button>
		<br />
		<asp:GridView ID="GVIndivPfsJournal" runat="server" Width="100%" AllowPaging="true" PageSize="30" OnPageIndexChanging="PFSgridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" FooterStyle="table" OnSorting="Sorting">
			<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
		</asp:GridView>
		<i>стр.<%=GVIndivPfsJournal.PageIndex + 1%> из <%=GVIndivPfsJournal.PageCount%>
		</i>
		<br />
		<asp:DropDownList ID="selPfsConsult" runat="server"></asp:DropDownList>
		<button class="btn" id="btnGoToPfsConsult" runat="server" onserverclick="ViewPfsConsult">Перейти к редактированию (PFS)</button>
	</div>

	<div id="divSuper" runat="server">
		<div style="width: 100%; overflow-x: scroll;">
			<asp:GridView ID="GVSpecJournal" runat="server" Width="100%" AllowPaging="true" PageSize="30" OnPageIndexChanging="gridView_PageIndexChanging" AllowSorting="True" HeaderStyle="table" ShowHeaderWhenEmpty="True" EmptyDataText="нет данных для выбранного периода" OnSorting="Sorting">
				<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
			</asp:GridView>
		</div>
		<i>стр.<%=GVSpecJournal.PageIndex + 1%>из <%=GVSpecJournal.PageCount%></i>

	</div>

</asp:Content>
