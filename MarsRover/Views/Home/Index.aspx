<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MarsRover.Models.ViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   

<script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<script type="text/javascript">
    function AjaxSubmit() {
        var inputText = $('#Input').val();                
        $.ajax({
            type: "Post",
            url: "/Home/AjaxProcess",
            data: {inp : inputText},
            complete: function (data, textStatus) { $('#Output').text(data.responseText); }
        });
    }

    function AjaxRefreshLT() {
        $.ajax({
            type: "Get",
            url: "/lasttrack/get",
            complete: function (data, textStatus) {
                $('#Track').text(data.responseText);
            }
        });
    }

    function AjaxRefreshRH() {
        $.getJSON("http://localhost:52998/api/recordholder",
                    function (data) {
                        $('#Longest').text(data.Holder);
                    })
                }

</script>

     <%Html.BeginForm("Process", "Home", FormMethod.Post); %>     
         <%= Html.TextAreaFor(model => model.Input)%>
         <br />
         <input type="submit" value="Submit" /><br />
         <a onclick="AjaxSubmit();" href="#" id="sbmt">AjaxSubmit</a>

     <%Html.EndForm(); %>
     
     <%= Html.TextAreaFor(model => model.Output) %>  
     
     <br />Last Track(<a onclick="AjaxRefreshLT();" href="#" id="A1">AjaxRefresh</a>):<%= Html.TextAreaFor(model => model.Track) %>     
     
     <br />Record Holder(<a onclick="AjaxRefreshRH();" href="#" id="A2">AjaxRefresh</a>):<%= Html.TextAreaFor(model => model.Longest)%>     
    
</asp:Content>
