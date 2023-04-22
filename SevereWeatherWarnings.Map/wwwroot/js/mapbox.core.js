let map;
const mapStyle = 'mapbox://styles/mikeupjohn/cleyos0o0000t01p9r4ovd33n';

let mapSources = [];
let mapLayers = [];

function createMap(latitude, longitude, zoom) {
    if (map === undefined) {
        map = new mapboxgl.Map({
            container: 'map',
            style: mapStyle,
            center: [longitude, latitude],
            zoom: zoom
        });
    }
}

function addDataSourceToMap(dataItem) {
    mapSources.push(dataItem.id);
    console.log(dataItem);
    map.addSource(dataItem.id, {
        'type': 'geojson',
        'data': {
            'type': 'Feature',
            'geometry': {
                'type': 'Polygon',
                'coordinates': dataItem.warningGeometry.coOrdinates
            },
            'properties': {
                'event': dataItem.warningProperties.event,
                'headline': dataItem.warningProperties.headline,
                'description': dataItem.warningProperties.description,
                'instruction': dataItem.warningProperties.instruction,
                'expiryDate': dataItem.warningProperties.expiryDate,
                'areaDescription': dataItem.warningProperties.areaDescription,
                'fillColour': dataItem.displayProperties.fillColourHexCode,
                'lineColour': dataItem.displayProperties.lineColourHexCode
            }
        }
    });

    map.on('click', dataItem.id, (e) => {
        var mapSourceProperties = e.features[0].properties;

        $('#warning-title').html(mapSourceProperties.event);
        $('#headline').html(mapSourceProperties.headline);
        $('#expiryDate').html(mapSourceProperties.expiryDate);
        $('#areaDescription').html(mapSourceProperties.areaDescription);

        new mapboxgl.Popup({ closeButton: false })
            .setLngLat(e.lngLat)
            .setHTML($('#warning-container').html())
            .addTo(map);

        $('.mapboxgl-popup-content').css('background-color', mapSourceProperties.fillColour).css('border', '1px solid ' + mapSourceProperties.lineColour);
        $('.mapboxgl-popup-tip').css('border-bottom-color', mapSourceProperties.fillColour).css('border-top-color', mapSourceProperties.fillColour);
    });
}

function drawPolygon(id, fillColourHex, fillOpacity) {
    mapLayers.push(id);
    map.addLayer({
        'id': id,
        'type': 'fill',
        'source': id,
        'layout': {},
        'paint': {
            'fill-color': fillColourHex,
            'fill-opacity': fillOpacity
        }
    });
}

function drawPolygonBorder(id, lineColourHex, lineThickness) {
    const polygonId = 'outline-' + id
    mapLayers.push(polygonId);

    map.addLayer({
        'id': polygonId,
        'type': 'line',
        'source': id,
        'layout': {},
        'paint': {
            'line-color': lineColourHex,
            'line-width': lineThickness
        }
    });
}

function removeLayer(id) {
    map.removeLayer(id);
}

function removeSource(id) {
    map.removeSource(id);
}