(function ($) {
    "use strict";

    //Image Map Types
    gmaps.mvc.ImageMapType = function (map, config) {

        this.map = map;
        this.name = config.name;
        this.alt = config.altName;
        this.maxZoom = config.maxZoom;
        this.minZoom = config.minZoom;
        this.radius = config.radius;
        this.opacity = config.opacity;

        this.repeatHorizontally = config.repeatHorizontally;
        this.repeatVertically = config.repeatVertically;
        this.tileSize = new google.maps.Size(config.tileSize.width, config.tileSize.height);
        this.tileUrlPattern = config.tileUrlPattern;
    }

    gmaps.mvc.ImageMapType.prototype = {
        getTileUrl: function (coord, zoom) {
            var normalizedCoord = this.getNormalizedCoord(coord, zoom);

            if (!normalizedCoord) {
                return null;
            }

            var imageUrl = this.format(this.tileUrlPattern, coord.x, coord.y, zoom, this.tileSize.width, this.tileSize.height);
            console.log(imageUrl);
            return imageUrl;

        },
        getNormalizedCoord: function getNormalizedCoord(coord, zoom) {
            var y = coord.y;
            var x = coord.x;
            var tileRange = 1 << zoom;

            if (y < 0 || y >= tileRange) {
                if (this.repeatVertically) {
                    y = (y % tileRange + tileRange) % tileRange;
                } else {
                    return null;
                }
            }

            if (x < 0 || x >= tileRange) {
                if (this.repeatHorizontally) {
                    x = (x % tileRange + tileRange) % tileRange;
                } else {
                    return null;
                }
            }

            return {
                x: x,
                y: y
            };
        },
        format: function (value) {
            var args = Array.prototype.slice.call(arguments, 1);
            return value.replace(/{(\d+)}/g, function (match, number) {
                return typeof args[number] != 'undefined'
                  ? args[number]
                  : match
                ;
            });
        }
    }

    // Styled Map Types
    gmaps.mvc.StyledMapType = function (map, config) {

        this.map = map;
        this.name = config.name;
        this.alt = config.altName;
        this.maxZoom = config.maxZoom;
        this.minZoom = config.minZoom;
        this.radius = config.radius;
        this.opacity = config.opacity;

        this.styles = config.styles;
    }

    gmaps.mvc.StyledMapType.prototype = {}
})(jQuery);