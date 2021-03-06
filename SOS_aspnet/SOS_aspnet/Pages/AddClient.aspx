﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="SOS.Pages.AddClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
	Добавить клиента
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptHolder">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
	<asp:DropDownList runat="server" ID="selType"  class="span2" style="margin-left: 20px;"/>
	<div>
		<span class="span2">Фамилия</span><asp:TextBox runat="server" ID="txtSurname" CssClass="input-medium"></asp:TextBox>
	</div>
	<div>
		<span class="span2">Имя</span><asp:TextBox runat="server" ID="txtName" CssClass="input-medium"></asp:TextBox>
	</div>
	<div>
		<span class="span2">Отчество</span><asp:TextBox runat="server" ID="txtFarthersName" CssClass="input-medium"></asp:TextBox>
	</div>
	<span class="span2">Пол</span>
	<div class="radio" style="width: 500px; margin-left: 50px;">
		<asp:RadioButtonList runat="server" ID="rbMale">
			<asp:ListItem Selected="True">Мужской</asp:ListItem>
			<asp:ListItem>Женский</asp:ListItem>
		</asp:RadioButtonList>
	</div>

	<span class="span2">Дата рождения</span>
	<input type="text" class="form-control input-group-btn input-small" data-format="YYYY/MM/DD" placeholder="YYYY/MM/DD" runat="server" id="txtBirthDate" />


	<br/>
	<asp:Button runat="server" ID="btnSaveClient" OnClick="SaveClient_Click" Text="Сохранить" CssClass="btn" style="margin-left: 80px;"/>


</asp:Content>
