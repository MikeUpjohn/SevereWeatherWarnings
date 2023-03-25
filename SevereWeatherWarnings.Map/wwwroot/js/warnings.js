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
        event: 'FlashFloodWarning'
    };

    $.post("/RetrieveData/GetData", request, function (data) {
        console.log(data);
    });
});