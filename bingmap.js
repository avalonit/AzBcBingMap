
var map;

function initMap() {

    try {
      map = new Microsoft.Maps.Map('#bingMap',{});
      window.addEventListener("message", onMessage, false);
    }
    catch(err) {
        alert(err);
      } 
}

function centerMap(lat, lng)
{

    try {
        var position = new Microsoft.Maps.Location(lat, lng)

        //Create custom Pushpin
        var pin = new Microsoft.Maps.Pushpin(position, {
            icon: 'https://www.bingmapsportal.com/Content/images/poi_custom.png',
            anchor: new Microsoft.Maps.Point(12, 39)
        });
  
        //Add the pushpin to the map
        map.entities.push(pin);
        map.setView({center: position, zoom: 17 });
      }
      catch(err) {
        alert(err);
      } 

}


function onMessage(event) {
  //if (event.origin !== __ViewerOrigin) {
  //    console.log('Blocked invalid cross-domain call');
  //    return;
  //}

  var data = event.data;

  if (typeof(window[data.func]) == "function") {
      window[data.func].call(null, event.data.lat, event.data.lng);
  }
}