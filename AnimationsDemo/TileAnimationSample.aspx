<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TileAnimationSample.aspx.cs" Inherits="AnimationsDemo.TileAnimationSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tile</title>
  <%--<link href='http://fonts.googleapis.com/css?family=Roboto+Slab' rel='stylesheet' type='text/css'/>--%>
  <link rel="stylesheet" href="style.css"/>
  <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
     <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
    <script src="JavaScript1.js"></script>
 <%-- <script src="../../external/jquery.animations.min.js"></script>--%>
  <script src="../../jquery.animations-tile.js"></script>
  <%--<script src="app.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="container" class="ui-widget-content ui-corner-all">
      <img id="image" src="images/ams_food_vendor_vending_machine_large.jpg" />
    </div>
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            var selectedeffect = "Explode";
            var options = {
                effect:"puff",
                //pieces:25
               // easing: "easeOutBounce",
                percent:80
            };
          //  var demo = $;
            function callback() {
                setTimeout(function () {
                    $("#container").removeAttr("style").hide().fadeIn();
                }, 1000);
            };
            //$("#image").effect("shake", options, 1000);
            $("#image").effect("explode", {effect:"explode",pieces:25}, 2000);
            var animation = 'tile';
            function assemble() {
                options = {
                    duration: 2000,
                    rows: 12,
                    cols: 8,
                    effect: 'flyIn',
                    fillMode: 'backwards'
                }
                animate();
            }
            function animate() {
                if ($.isEmptyObject(options))
                    $('#code').text("$('#image').animate('" + animation + "');");
                else
                   // $('#code').text("$('#image').animate('" + animation + "', " + JSON.stringify(options, null, 2) + ");");
                $('#image').animate(animation, options);
            }
            var img = $('#image')[0];
            if (img.complete || img.readyState === 4)
                assemble();
            else
                $('#image').bind('load', assemble);
        });
       
    </script>
</body>
</html>
