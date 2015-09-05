$(document).ready(function () {

    //var win = window.open('../googlemap.aspx?zip=11710', '_blank');
    //if (win) { win.focus(); }

    var docHeigth = $(document).height() - 20;    
    $('#divMap').height(docHeigth + 'px');
    if (getQuestringParameterByName('lat') && getQuestringParameterByName('lng')) {
        //ShowLocationOnMapByLangLat(-73.55408790, 40.69475500);
        ShowLocationOnMapByLangLat(getQuestringParameterByName('lng'), getQuestringParameterByName('lat'));
    } else if (getQuestringParameterByName('zip')) {
        //ShowLocationOnMapByZip('11710');
        ShowLocationOnMapByZip(getQuestringParameterByName('zip'));
    } else {
        ShowLocationOnMapByZip('United States of America',5);        
    }
});




function ShowLocationOnMapByLangLat(langitude, latitude) {   
    
    var lat = latitude;
    var lng = langitude;
    var myLatlng = new google.maps.LatLng(lat, lng);
    
    var map = new google.maps.Map(document.getElementById('divMap'));
    google.maps.event.addListenerOnce(map, 'idle', function () {        
        var Marker = new google.maps.Marker({
            position: myLatlng,
            map: map
        });
        google.maps.event.trigger(map, 'resize');
        map.setCenter(myLatlng);
        map.setZoom(10);
    });
    
}

function ShowLocationOnMapByZip(address, zoom) {
    if (typeof (zoom) === 'undefined') zoom = 10;
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ address: address/*'United State, 380061' zip you got from user input */ },
        function (results_array, status) {

            var lat = results_array[0].geometry.location.lat();
            var lng = results_array[0].geometry.location.lng();
            var myLatlng = new google.maps.LatLng(lat, lng);

            var map = new google.maps.Map(document.getElementById('divMap'));

            google.maps.event.addListenerOnce(map, 'idle', function () {
                if (address != 'United States of America') {
                    var Marker = new google.maps.Marker({
                        position: myLatlng,
                        map: map
                    });
                }
                google.maps.event.trigger(map, 'resize');
                map.setCenter(myLatlng);
                //map.setZoom(10);
                map.setZoom(zoom);
            });
        });
    $('#googleMap').modal();
    $('#googleMap').modal('show');
}

function getQuestringParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}