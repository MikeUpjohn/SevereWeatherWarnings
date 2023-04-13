// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var mapToken = $('#map').data('accesstoken');
    mapboxgl.accessToken = mapToken;

    createMap(32.896, -97.043, 9);

    $('.expand-arrow').click(function () {
        if ($('.side-panel-container').hasClass('open')) {
            $('.side-panel-container').removeClass('open');
            $('.side-panel-container').animate({ "right": "-315px" }, "slow", function () {
                $('#expand-arrow-expand').show();
                $('#expand-arrow-collapse').hide();
            });
        } else {
            $('.side-panel-container').addClass('open');
            $('.side-panel-container').animate({ "right": "0px" }, "slow", function () {
                $('#expand-arrow-expand').hide();
                $('#expand-arrow-collapse').show();
            });
        }
    });
});

$('#get-warning-data').click(function () {
    let selectedItemsList = [];
    $('input:checkbox[name=warning-selection]:checked').each(function (index, item) {
        selectedItemsList.push($(item).val());
    });

    if (selectedItemsList.length) {
        let request = {
            event: selectedItemsList
        };

        $.post("/RetrieveData/GetData", request, function (data) {
            addWarningsToMap(data);
        });
    }
});

function addWarningsToMap(data) {
    $(data.weatherWarnings).each(function (index, item) {
        drawWarningPolygon(item);
    });
}

function drawWarningPolygon(dataItem) {
    addDataSourceToMap(dataItem.id, dataItem.warningGeometry.coOrdinates);
    drawPolygon(dataItem.id, dataItem.displayProperties.fillColourHexCode, 0.3);
    drawPolygonBorder(dataItem.id, dataItem.displayProperties.lineColourHexCode, 0.3);
}