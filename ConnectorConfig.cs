using System;
using Microsoft.Extensions.Configuration;

namespace com.businesscentral
{

    public partial class ConnectorConfig
    {
        public ConnectorConfig(IConfigurationRoot config)
        {
            if (config != null)
            {
                bing_url = config["bing_url"];
                bing_key = config["bing_key"];
            }
            // If you are customizing here it means you
            //  should give a look on how use
            //  azure configuration file
            if (String.IsNullOrEmpty(bing_url))
                bing_url = "https://www.bing.com/api/maps/mapcontrol?callback=initMap&key=";
            if (String.IsNullOrEmpty(bing_key))
                bing_key = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
        }

        public String bing_url;
        public String bing_key;
    }
}
