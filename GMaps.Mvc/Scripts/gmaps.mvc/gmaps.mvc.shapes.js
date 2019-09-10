(function ($) {
    "use strict";
	
    //Polyline
    gmaps.mvc.GooglePolyline = function (map, config) {
        //init
        this.Map = map;
        this.gPolyline = null;
        //properties
        this.clickable = config.clickable;
        this.points = config.points;
        this.strokeColor = config.strokeColor;
        this.strokeOpacity = config.strokeOpacity;
        this.strokeWeight = config.strokeWeight;
        this.points = [];

        if (config.points) {
            for (var i = 0; i < config.points.length; i++) {
                this.points.push(new google.maps.LatLng(config.points[i].lat, config.points[i].lng));
            }
        }
    };

    gmaps.mvc.GooglePolyline.prototype = {
        isLoaded: function () {
            return this.gPolyline !== null;
        },
        load: function () {
            var options = {
                path: this.points,
                strokeColor: this.strokeColor,
                strokeOpacity: this.strokeOpacity,
                strokeWeight: this.strokeWeight,
                clickable: this.clickable
            };
            var polyline = new google.maps.Polyline(options);
            polyline.setMap(this.Map);
        }
    };

    //Polygons
    gmaps.mvc.GooglePolygon = function (map, config) {
        //init
        this.Map = map;
        this.gPolygon = null;
        //properties
        this.clickable = config.clickable;
        this.fillColor = config.fillColor;
        this.fillOpacity = config.fillOpacity;
        this.points = config.points;
        this.strokeColor = config.strokeColor;
        this.strokeOpacity = config.strokeOpacity;
        this.strokeWeight = config.strokeWeight;
        this.points = [];

        if (config.points) {
            for (var i = 0; i < config.points.length; i++) {
                this.points.push(new google.maps.LatLng(config.points[i].lat, config.points[i].lng));
            }
        }

    };

    gmaps.mvc.GooglePolygon.prototype = {
        isLoaded: function () {
            return this.gPolygon !== null;
        },
        load: function () {
            var options = {
                paths: this.points,
                strokeColor: this.strokeColor,
                strokeOpacity: this.strokeOpacity,
                strokeWeight: this.strokeWeight,
                fillColor: this.fillColor,
                fillOpacity: this.fillOpacity,
                clickable: this.clickable
            };
            var polygon = new google.maps.Polygon(options);
            polygon.setMap(this.Map);
        }
    };

    // Circles
    gmaps.mvc.GoogleCircle = function (map, config) {
        //init
        this.Map = map;
        this.gCircle = null;
        //properties
        this.clickable = config.clickable;
        this.fillColor = config.fillColor;
        this.fillOpacity = config.fillOpacity;
        this.points = config.points;
        this.strokeColor = config.strokeColor;
        this.strokeOpacity = config.strokeOpacity;
        this.strokeWeight = config.strokeWeight;
        this.center = config.center;
        this.radius = config.radius;
    };

    gmaps.mvc.GoogleCircle.prototype = {
        isLoaded: function () {
            return this.GCircle !== null;
        },
        load: function () {
            var options = {
                center: new google.maps.LatLng(this.center.lat, this.center.lng),
                radius: this.radius,
                strokeColor: this.strokeColor,
                strokeOpacity: this.strokeOpacity,
                strokeWeight: this.strokeWeight,
                fillColor: this.fillColor,
                fillOpacity: this.fillOpacity,
                clickable: this.clickable
            };
            var circle = new google.maps.Circle(options);
            circle.setMap(this.Map);
        }
    };
})(jQuery);