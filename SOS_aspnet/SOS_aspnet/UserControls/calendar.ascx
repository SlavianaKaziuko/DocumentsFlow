<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="calendar.ascx.cs" Inherits="SOS.UserControls.Calendar" %>


<div class="col-sm-4" style="width: 300px;">
	<input type="hidden" id="_ispostback" value="<%=Page.IsPostBack.ToString()%>" />
	<div class="date-picker" data-date="" data-keyboard="true">
		<span class="value" runat="server" id="date"></span>
		<div class="date-container pull-left">
			<h4 class="weekday">Monday</h4>
			<h2 class="date">Februray 4th</h2>
			<h4 class="year pull-right">2014</h4>
		</div>
		<span data-toggle="datepicker" data-type="subtract" class="fa fa-angle-left"></span>
		<span data-toggle="datepicker" data-type="add" class="fa fa-angle-right"></span>
		<div class="input-group input-datepicker">
			<input type="text" class="form-control input-group-btn" data-format="YYYY/MM/DD" placeholder="YYYY/MM/DD">
			<span class="input-group-btn">
				<button class="btn btn-default" type="button">Go!</button>
			</span>
		</div>
		<span data-toggle="calendar" class="fa fa-calendar"></span>
	</div>

</div>

