﻿let prevSources = [];
let newSources = [];
let sourcesToAdd = [];
let sourcesToDelete = [];
let warningCount = 0;

$(document).ready(function () {
    var mapToken = $('#map').data('accesstoken');
    mapboxgl.accessToken = mapToken;

    createMap(32.896, -97.043, 9);

    addRadarLayer();

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

    loadWarnings();
});

$('#get-warning-data').click(function () {
    loadWarnings();
});

function loadWarnings() {
    let selectedItemsList = [];

    $('input:checkbox[name=warning-selection]:checked').each(function (index, item) {
        selectedItemsList.push($(item).val());
    });

    if (selectedItemsList.length) {
        let request = {
            event: selectedItemsList
        };

        prevSources = newSources;
        newSources = [];
        sourcesToAdd = [];
        sourcesToDelete = [];

        $.post("/RetrieveData/GetAllLiveWarnings", request, function (data) {
            mapNewData(data);

            let existsInNewSourceData;
            $(newSources).each(function (index, newElement) {
                existsInNewSourceData = false;
                $(prevSources).each(function (index, prevElement) {
                    if (newElement.id == prevElement.id) {
                        existsInNewSourceData = true;
                    }
                });

                if (!existsInNewSourceData) {
                    sourcesToAdd.push(newElement);
                }
            });

            let existsInOldSourceData;
            $(prevSources).each(function (index, prevElement) {
                existsInOldSourceData = false;
                $(newSources).each(function (index, newElement) {
                    if (prevElement.id == newElement.id) {
                        existsInOldSourceData = true;
                    }
                });

                if (!existsInOldSourceData) {
                    sourcesToDelete.push(prevElement);
                }
            });

            removeWarningsFromMap(sourcesToDelete);
            addWarningsToMap(sourcesToAdd);

            warningCount = warningCount - sourcesToDelete.length + sourcesToAdd.length;
            $('#warning-count').html(warningCount);
        });
    }
}

function addWarningsToMap(sourcesToAdd) {
    $(sourcesToAdd).each(function (index, element) {
        drawWarningPolygon(element);
    });
}

function drawWarningPolygon(dataItem) {
    addDataSourceToMap(dataItem);
    drawPolygon(dataItem.friendlyId, dataItem.displayProperties.fillColourHexCode, 0.3);
    drawPolygonBorder(dataItem.friendlyId, dataItem.displayProperties.lineColourHexCode, 0.3);
}

function removeWarningsFromMap(sourcesToDelete) {
    $(sourcesToDelete).each(function (index, element) {
        removeLayer("outline-" + element.id);
        removeLayer(element.id);
        removeSource(element.id);
    });
}

function mapNewData(data) {
    $(data.weatherWarnings).each(function (index, item) {
        newSources.push(item);
    });
}

// old key 9273f14c853b4634b3f14c853bd634ab
const twcApiKey = '2ec2232d72f1484282232d72f198421d';

const timeSlices = fetch('https://api.weather.com/v3/TileServer/series/productSet/PPAcore?apiKey=' +
    twcApiKey);

// this function resolves the metadata promise,
// extracts the most recent publish time for radar data,
// and adds the radar layer to the map
const addRadarLayer = () => {
    timeSlices
        .then((res) => res.json())
        .then((res) => {
            const radarTimeSlices = res.seriesInfo.radar.series;
            const latestTimeSlice = radarTimeSlices[0].ts;

            // insert the latest time for radar into the source data URL
            map.addSource('twcRadar', {
                type: 'raster',
                tiles: [
                    'https://api.weather.com/v3/TileServer/tile/radar?ts=' +
                    latestTimeSlice +
                    '&xyz={x}:{y}:{z}&apiKey=' +
                    twcApiKey,
                ],
                tileSize: 256,
            });

            // place the layer before the "aeroway-line" layer
            map.addLayer(
                {
                    id: 'radar',
                    type: 'raster',
                    source: 'twcRadar',
                    paint: {
                        'raster-opacity': 0.5,
                    },
                },
                'aeroway-line'
            );
        });
};

setInterval(function () {
    loadWarnings();

    console.log("refreshing map after 1 minute");
}, 60000);

if ($('.warning-details').length) {
    $(".warning-details").css("height", ($(window).innerHeight() - $(".warning-banner").innerHeight()) + "px");
}