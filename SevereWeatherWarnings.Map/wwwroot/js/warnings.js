// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let map;

$(document).ready(function () {
    var mapToken = $('#map').data('accesstoken');
    mapboxgl.accessToken = mapToken;

    map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mikeupjohn/cleyos0o0000t01p9r4ovd33n',
        center: [- 97.043, 32.896],
        zoom: 9
    });
});

$('#flash-flood-warnings').click(function () {
    var request = {
        event: 'FloodWarning'
    };

    $.post("/RetrieveData/GetData", request, function (data) {
        addWarningsToMap(data);
    });
});

function addWarningsToMap(data) {
    $(data.weatherWarnings).each(function (index, item) {
        console.log(item);
        map.addSource(item.id, {
            'type': 'geojson',
            'data': {
                'type': 'Feature',
                'geometry': {
                    'type': 'Polygon',
                    'coordinates': item.warningGeometry.coOrdinates
                }
            }
        });

        map.addLayer({
            'id': item.id,
            'type': 'fill',
            'source': item.id,
            'layout': {},
            'paint': {
                'fill-color': '#0080FF',
                'fill-opacity': 0.5
            }
        });

        map.addLayer({
            'id': 'outline' + item.id,
            'type': 'line',
            'source': item.id,
            'layout': {},
            'paint': {
                'line-color': '#000',
                'line-width': 3
            }
        });

        console.log('Added layer with id ' + item.id + ' to the map');
    });
}