<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="SOS.Pages.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
	<title>ОПСР "SOS - Детская деревня г.Могилев"</title>
	<link type="text/css" rel="stylesheet" href="/css/bootstrap.css" />
	<script type="text/javascript" src="/js/bootstrap.min.js"></script>
</head>
<body style="min-height: 500px;">
	<div>
		<form id="Form1" runat="server">
			<table style="background-color: #32a7d8; width: 100%;">
				<tr>
					<td>
						<img src="../img/header/logo.jpg" alt="" style="height: 80px;" /></td>
					<td>
						<img src="../img/header/home.jpg" alt="" style="height: 80px;" /></td>
					<td>
						<img src="../img/header/family.jpg" alt="" style="height: 80px;" /></td>
					<td>
						<img src="../img/header/culture.jpg" alt="" style="height: 80px;" /></td>
					<td>
						<img src="../img/header/siblings.jpg" alt="" style="height: 80px;" /></td>
					<td>
						<img src="../img/header/education.jpg" alt="" style="height: 80px;" /></td>
					<td>
						<img src="../img/header/moments.jpg" alt="" style="height: 80px;" /></td>
					<td>
						<img src="../img/header/motherhood.jpg" alt="" style="height: 80px;" /></td>
					<td>
						<img src="../img/header/villages.jpg" alt="" style="height: 80px;" /></td>
				</tr>
			</table>
			<div style="width: 100%; margin-top: 20px; text-align: center;" class="alert-error">
				Возникла ошибка!
				<br />
				Пожалуйста, войдите в систему заново
				<br />
				<a href="./LoginPage.aspx">Войти</a>
			</div>
		</form>
	</div>
	<footer class="modal-footer">Любящая семья для каждого ребёнка</footer>
</body>
</html>
