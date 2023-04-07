// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//let map;

$(document).ready(function () {
    var mapToken = $('#map').data('accesstoken');
    mapboxgl.accessToken = mapToken;

    createMap(32.896, -97.043, 9);

    $('.expand-arrow').click(function () {
        if ($('.side-panel-container').hasClass('open')) {
            $('.side-panel-container').removeClass('open');
            $('.side-panel-container').animate({ "right": "-315px" }, "slow");
        } else {
            $('.side-panel-container').addClass('open');
            $('.side-panel-container').animate({ "right": "0px" }, "slow");
        }
    });
});

$('#flood-warnings').click(function () {
    var request = {
        event: 'FloodWarning'
    };

    $.post("/RetrieveData/GetData", request, function (data) {
        addWarningsToMap(data);
    });
});

function addWarningsToMap(data) {
    $(data.weatherWarnings).each(function (index, item) {
        drawWarningPolygon(item);
    });
}

function drawWarningPolygon(dataItem) {
    addDataSourceToMap(dataItem.id, dataItem.warningGeometry.coOrdinates);
    drawPolygon(dataItem.id, '#00FF00', 0.15);
    drawPolygonBorder(dataItem.id, '#00FF00', 0.15);
}