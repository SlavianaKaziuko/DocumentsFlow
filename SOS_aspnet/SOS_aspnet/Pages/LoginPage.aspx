<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SOS.Pages.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>ОПСР "SOS - Детская деревня г.Могилев"</title>
	<%--	<link type="text/css" rel="stylesheet" href="/css/bootstrap.min.css" />--%>
	<link type="text/css" rel="stylesheet" href="../css/bootstrap.css" />
	<%--	<script type="text/javascript" src="~/js/jquery.js"></script>--%>
	<script type="text/javascript" src="../js/bootstrap.min.js"></script>
	
	<%--	<script type="text/javascript" src="~/js/bootstrap-dropdown.js"></script>--%>
</head>
<body style="min-height: 500px;">
	<div>
		<form runat="server">
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
			<div style="width: 100%;">
				<div style="margin: 10px auto; padding: 30px; border-radius: 5px; border: #32a7d8 medium solid; width: 300px; display: inline-block; vertical-align: top;">
					<table width="100%">
						<tr>
							<td>
								<label id="lblusername" for="username" runat="server">Имя</label>
							</td>
							<td>
								<input id="username" type="text" runat="server" />
							</td>
						</tr>
						<tr>
							<td>
								<label id="lblpassword" for="password" runat="server">Пароль</label>
							</td>
							<td>
								<input id="password" type="password" runat="server" />
							</td>
						</tr>
						<tr>
							<td></td>
							<td>
								<button class="btn-success" type="submit" title="OK" runat="server" onserverclick="LoginUser">Войти </button>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<div id="errormessage" runat="server" visible="False" style="color: red; text-align: center;">
								</div>
							</td>
						</tr>
					</table>
				</div>
				<div style="display: inline-block; margin: 10px auto 0; width: 70%;">
					<ul class="slides">
						<input type="radio" name="radio-btn" id="img-1" checked />
						<li class="slide-container">
							<div class="slide">
								<img src="../img/photos/IMGP1022.jpg" />
							</div>
							<div class="nav">
								<label for="img-6" class="prev">&#x2039;</label>
								<label for="img-2" class="next">&#x203a;</label>
							</div>
						</li>

						<input type="radio" name="radio-btn" id="img-2" />
						<li class="slide-container">
							<div class="slide">
								<img src="../img/photos/IMGP0400.jpg" />
							</div>
							<div class="nav">
								<label for="img-1" class="prev">&#x2039;</label>
								<label for="img-3" class="next">&#x203a;</label>
							</div>
						</li>

						<input type="radio" name="radio-btn" id="img-3" />
						<li class="slide-container">
							<div class="slide">
								<img src="../img/photos/IMGP0465.jpg" />
							</div>
							<div class="nav">
								<label for="img-2" class="prev">&#x2039;</label>
								<label for="img-4" class="next">&#x203a;</label>
							</div>
						</li>

						<input type="radio" name="radio-btn" id="img-4" />
						<li class="slide-container">
							<div class="slide">
								<img src="../img/photos/IMGP0577.jpg" />
							</div>
							<div class="nav">
								<label for="img-3" class="prev">&#x2039;</label>
								<label for="img-5" class="next">&#x203a;</label>
							</div>
						</li>

						<input type="radio" name="radio-btn" id="img-5" />
						<li class="slide-container">
							<div class="slide">
								<img src="../img/photos/IMGP0394.jpg" />
							</div>
							<div class="nav">
								<label for="img-4" class="prev">&#x2039;</label>
								<label for="img-6" class="next">&#x203a;</label>
							</div>
						</li>

						<input type="radio" name="radio-btn" id="img-6" />
						<li class="slide-container">
							<div class="slide">
								<img src="../img/photos/IMGP2791.jpg" />
							</div>
							<div class="nav">
								<label for="img-5" class="prev">&#x2039;</label>
								<label for="img-1" class="next">&#x203a;</label>
							</div>
						</li>

						<li class="nav-dots">
							<label for="img-1" class="nav-dot" id="img-dot-1"></label>
							<label for="img-2" class="nav-dot" id="img-dot-2"></label>
							<label for="img-3" class="nav-dot" id="img-dot-3"></label>
							<label for="img-4" class="nav-dot" id="img-dot-4"></label>
							<label for="img-5" class="nav-dot" id="img-dot-5"></label>
							<label for="img-6" class="nav-dot" id="img-dot-6"></label>
						</li>
					</ul>
				</div>
			</div>
		</form>
	</div>
	<footer class="modal-footer">Любящая семья для каждого ребёнка</footer>
</body>
</html>
