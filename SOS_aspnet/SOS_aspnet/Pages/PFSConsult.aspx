<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PFSConsult.aspx.cs" Inherits="SOS.Pages.PFSConsult" %>

<%@ Register Src="~/UserControls/calendar.ascx" TagPrefix="uc" TagName="calendar" %>

<asp:Content ID="contTitle" ContentPlaceHolderID="TitleHolder" runat="server">
	Консультация родителя семьи-бенефицианта
</asp:Content>
<asp:Content ID="contContent" ContentPlaceHolderID="ContentHolder" runat="server">
	<span>Консультация </span><span id="consultId" runat="server"></span>
	<table class="table">
		<tr>
			<td width="250px">ФИО</td>
			<td>
				<select runat="server" id="selParent"></select>
			</td>
		</tr>
		<tr>
			<td>Дата встречи</td>
			<td>
				<uc:calendar runat="server" ID="calendar" />
			</td>
		</tr>
		<tr>
			<td>Форма</td>
			<td>

				<select id="SelForm" runat="server"></select>
			</td>
		</tr>
		<tr>
			<td>Содержание</td>
			<td>

				<select id="SelContent" runat="server"></select>
			</td>
		</tr>
		<tr>
			<td>
				<asp:RadioButton ID="rbIsPlanned" Text="Запланировано в ПРС" runat="server" CssClass="radio"/>
				<asp:RadioButton ID="rbIsNotPlanned" Text="Не запланировано в ПРС" runat="server" CssClass="radio"/>
				<span>Другое</span><asp:TextBox ID="txtAnotherPlanned" runat="server" CssClass="input-medium"></asp:TextBox>
			</td>
			<td>
				<asp:CheckBox ID="chbInform" Text="Предоставление информации" runat="server"  CssClass="checkbox"/>
				<asp:CheckBox ID="chbConsulting" Text="Консультирование" runat="server"  CssClass="checkbox"/>
				<asp:CheckBox ID="chbPsyhoDiagn" Text="Психодиагностика" runat="server"  CssClass="checkbox"/>
				<asp:CheckBox ID="chbTerapetSession" Text="Терапевтическая сессия" runat="server" CssClass="checkbox"/>
				<span>Другое</span><asp:TextBox ID="txtAnotherType" runat="server" CssClass="input-medium"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>Описание проблемы, запрос</td>
			<td>
				<asp:TextBox ID="txtProblem" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfvtxtProblem" runat="server" ErrorMessage="Описание проблемы, запрос не введен" ControlToValidate="txtProblem" ValidationGroup="saving" Display="Dynamic" Text="*" Font-Size="Large"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td>Основные моменты разговора (включая чувства) </td>
			<td>
				<asp:TextBox ID="txtConversation" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfvConversation" runat="server" ControlToValidate="txtConversation" ValidationGroup="saving" ErrorMessage="Основные моменты разговора не введены" Display="Dynamic" Text="*" Font-Size="Large"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td>Итог разговора, рекомендации </td>
			<td>
				<asp:TextBox ID="txtResults" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfvResults" runat="server" ErrorMessage="Итог разговора, рекомендации не введены" ControlToValidate="txtResults" ValidationGroup="saving" Display="Dynamic" Text="*" Font-Size="Large"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td>Дата следующей встречи</td>
			<td>
				<uc:calendar runat="server" ID="calendarNext" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<asp:Button runat="server" ID="btnSave" OnClick="Save_Click" type="submit" CssClass="btn btn-info" Text="Сохранить" />
				<asp:Button runat="server" ID="btnUpdate" OnClick="Update_Click" CssClass="btn btn-info" Text="Обновить" ValidationGroup="saving" /></td>
		</tr>
		<tr>
			<td></td>
			<td>
				<div id="errormessage" runat="server" visible="False" style="color: red; text-align: center;">
				</div>
				<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="saving" DisplayMode="BulletList" />
			</td>
		</tr>
	</table>


</asp:Content>
