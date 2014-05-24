<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PFSConsult.aspx.cs" Inherits="SOS.Pages.PFSConsult" %>

<%@ Register Src="~/UserControls/calendar.ascx" TagPrefix="uc" TagName="calendar" %>

<asp:Content ID="contTitle" ContentPlaceHolderID="TitleHolder" runat="server">
	Консультация родителя семьи-бенефицианта
</asp:Content>
<asp:Content ID="contContent" ContentPlaceHolderID="ContentHolder" runat="server">
	<span>Консультация </span><span id="consultId" runat="server"></span>
	<button id="btnExport" class="btn-success pull-right" onserverclick="btnExport_OnClick" runat="server" >
		<img src="../img/excel-icon.png" width="1" height="1" />
		Export</button>
	<table class="table">
		<tr>
			<td width="250px">ФИО</td>
			<td>
				<select runat="server" id="selParent"></select>
				<a href="./AddClient.aspx" style="margin-left: 10px;">Добавить клиента</a>
			</td>
		</tr>
		<tr>
			<td>Дата встречи</td>
			<td>
				<input type="text" class="form-control input-group-btn input-small" data-format="YYYY/MM/DD" placeholder="YYYY/MM/DD" runat="server" id="txtDate" />
				<%--<uc:calendar runat="server" ID="calendar" />--%>
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
			<td class="radio" style="padding-left: 28px;">
				<input type="radio" name="group1" value="Milk" runat="server" id="rbIsPlanned" checked="True" />
				<span>Запланировано в ПРС</span><br>
				<input type="radio" name="group1" value="Butter" runat="server" id="rbIsNotPlanned" />
				<span>Не запланировано в ПРС</span><br>
				<label><span>Другое</span></label><asp:TextBox ID="txtAnotherPlanned" runat="server" CssClass="input-medium"></asp:TextBox>
			</td>
			<td class="checkbox" style="padding-left: 28px;">
				<asp:CheckBox ID="chbInform" Text="Предоставление информации" runat="server" CssClass="" />
				<asp:CheckBox ID="chbConsulting" Text="Консультирование" runat="server" CssClass="" />
				<asp:CheckBox ID="chbPsyhoDiagn" Text="Психодиагностика" runat="server" CssClass="" />
				<asp:CheckBox ID="chbTerapetSession" Text="Терапевтическая сессия" runat="server" CssClass="" />
				<label><span>Другое</span></label><asp:TextBox ID="txtAnotherType" runat="server" CssClass="input-medium"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>Описание проблемы, запрос</td>
			<td>
				<asp:TextBox ID="txtProblem" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfvtxtProblem" runat="server" ErrorMessage="Описание проблемы, запрос не введен" ControlToValidate="txtProblem" ValidationGroup="saving" Display="Dynamic" Text="*" Font-Size="Large"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td>Основные моменты разговора (включая чувства) </td>
			<td>
				<asp:TextBox ID="txtConversation" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfvConversation" runat="server" ControlToValidate="txtConversation" ValidationGroup="saving" ErrorMessage="Основные моменты разговора не введены" Display="Dynamic" Text="*" Font-Size="Large"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td>Итог разговора, рекомендации </td>
			<td>
				<asp:TextBox ID="txtResults" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfvResults" runat="server" ErrorMessage="Итог разговора, рекомендации не введены" ControlToValidate="txtResults" ValidationGroup="saving" Display="Dynamic" Text="*" Font-Size="Large"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td>Дата следующей встречи</td>
			<td>
				<input type="text" class="form-control input-group-btn input-small" data-format="YYYY/MM/DD" placeholder="YYYY/MM/DD" runat="server" id="txtNextDate" />
				<%--<uc:calendar runat="server" ID="calendarNext" />--%>
			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<asp:Button runat="server" ID="btnSave" OnClick="Save_Click" type="submit" CssClass="btn btn-info" Text="Сохранить" />
				<asp:Button runat="server" ID="btnUpdate" OnClick="Update_Click" CssClass="btn btn-info" Text="Обновить" ValidationGroup="saving" />
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
	<label id="lblerror" runat="server" class="text-error"></label>

</asp:Content>
