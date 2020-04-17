using System;
using System.Text;

namespace com.businesscentral
{

    public partial class BingMapComposer
    {
        public string Compose(ConnectorConfig config)
        {
            StringBuilder message = new StringBuilder();

            string url = config.bing_url + config.bing_key;

            message.AppendLine("<!DOCTYPE html>");
            message.AppendLine("<html>");
            message.AppendLine("  <head>");
            message.AppendLine("    <title>Bing Map</title>");
            message.AppendLine("    <meta name=\"viewport\" content=\"initial-scale=1.0\">");
            message.AppendLine("    <meta charset=\"utf-8\">");
            message.AppendLine("    <script type='text/javascript' src='" + url + "' async defer></script>");
            //message.AppendLine("    <script src=\"bingmap.js\" ></script>");
            message.AppendLine(ComposeJavaScript());
            message.AppendLine("    <style>");
            message.AppendLine("      #map {");
            message.AppendLine("        height: 100%;");
            message.AppendLine("      }");
            message.AppendLine("      /* Optional: Makes the sample page fill the window. */");
            message.AppendLine("      html, body {");
            message.AppendLine("        height: 100%;");
            message.AppendLine("        margin: 0;");
            message.AppendLine("        padding: 0;");
            message.AppendLine("      }");
            message.AppendLine("    </style>");
            message.AppendLine("  </head>");
            message.AppendLine("  <body>");
            message.AppendLine("    <div id=\"bingMap\"></div>");
            message.AppendLine("  </body>");
            message.AppendLine("</html>");

            return message.ToString();
        }

        public string ComposeJavaScript()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("<script type='text/javascript'>");
            message.AppendLine("var map;");
            message.AppendLine("function initMap() {");
            message.AppendLine("  try {");
            message.AppendLine("    map = new Microsoft.Maps.Map('#bingMap', {});");
            message.AppendLine("    window.addEventListener(\"message\", onMessage, false);");
            message.AppendLine("  }");
            message.AppendLine("  catch (err) {");
            message.AppendLine("    alert(err);");
            message.AppendLine("  }");
            message.AppendLine("}");

            message.AppendLine("function centerMap(lat, lng) {");
            message.AppendLine("  try {");
            message.AppendLine("    var position = new Microsoft.Maps.Location(lat, lng)");
            message.AppendLine("    //Create custom Pushpin");
            message.AppendLine("    var pin = new Microsoft.Maps.Pushpin(position, {");
            message.AppendLine("      icon: 'https://www.bingmapsportal.com/Content/images/poi_custom.png',");
            message.AppendLine("      anchor: new Microsoft.Maps.Point(12, 39)");
            message.AppendLine("    });");

            message.AppendLine("    //Add the pushpin to the map");
            message.AppendLine("    map.entities.push(pin);");
            message.AppendLine("    map.setView({ center: position, zoom: 17 });");
            message.AppendLine("  }");
            message.AppendLine("  catch (err) {");
            message.AppendLine("   alert(err);");
            message.AppendLine("  }");
            message.AppendLine("}");

            message.AppendLine("function onMessage(event) {");
            message.AppendLine("  var data = event.data;");
            message.AppendLine("   if (typeof (window[data.func]) == \"function\") {");
            message.AppendLine("     window[data.func].call(null, event.data.lat, event.data.lng);");
            message.AppendLine("   }");
            message.AppendLine(" }");

            message.AppendLine(" </script>");
            return message.ToString();
        }
    }
}
