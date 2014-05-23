<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="SOS.Pages.AddClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
	Добавить клиента
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptHolder">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
	<select runat="server" id="selType">
	</select>
	<div>
		<span>Фамилия</span><asp:TextBox runat="server" ID="txtSurname" CssClass="input-medium"></asp:TextBox>
	</div>
	<div>
		<span>Имя</span><asp:TextBox runat="server" ID="txtName" CssClass="input-medium"></asp:TextBox>
	</div>
	<div>
		<span>Отчество</span><asp:TextBox runat="server" ID="txtFarthersName" CssClass="input-medium"></asp:TextBox>
	</div>

	<div>
		Пол
	<div class="radio" style="width: 500px; margin-left: 50px;">
		<asp:RadioButtonList runat="server" ID="rbMale">
			<asp:ListItem>Мужской</asp:ListItem>
			<asp:ListItem>Женский</asp:ListItem>
		</asp:RadioButtonList>
		<div>Дата рождения</div>
	</div>
	</div>
	<asp:Button runat="server" ID="btnSaveClient" OnClick="SaveClient_Click" Text="Сохранить" CssClass="btn" />


</asp:Content>
