(function ($) {
    "use strict";
	
    //Markers
    gmaps.mvc.GoogleMarker = function (map, index, config) {
        // init
        this.gMarker = null;
        this.Map = map.GMap;
        this.parent = map;
        this.index = index;
        //properties
        this.id = config.id;
        this.latitude = config.lat;
        this.longitude = config.lng;
        this.address = config.address;
        this.title = config.title;
        this.icon = config.icon;
        this.clickable = (config.clickable !== undefined) ? config.clickable : true;
        this.draggable = config.draggable;
        this.window = config.window;
        this.zIndex = config.zIndex ? config.zIndex : 0;
        this.enableMarkersClustering = config.enableMarkersClustering ? config.enableMarkersClustering : false;
        this.markerEvents = config.markerEvents;
    };

    var infowindow;
    var markersCluster = {};
    gmaps.mvc.GoogleMarker.prototype = {

        isLoaded: function () {
            return (this.gMarker !== null);
        },
        initialize: function () {
            //Work around to the issue https://code.google.com/p/gmaps-api-issues/issues/detail?id=7925
            if (this.window && this.clickable) {
                var openWindowEvent = 'click';
                if (this.window.openOnRightClick) {
                    openWindowEvent = 'rightclick';
                }
                google.maps.event.addListener(this.gMarker, openWindowEvent, gmaps.mvc.delegate(this, this.openInfoWindow));
            }

            if (this.markerEvents) {
                this.attachMarkerEvents();
            }
        },
        attachMarkerEvents: function () {
            for (var i = 0; i < this.markerEvents.length; i++) {
                var eventName = Object.getOwnPropertyNames(this.markerEvents[i])[0];
                //Work around to the issue https://code.google.com/p/gmaps-api-issues/issues/detail?id=7925
                if (eventName === 'click' && !this.clickable) continue;
                this.markerEventsCallBack(this.id, this.gMarker, this.markerEvents[i][eventName], eventName);
            }
        },
        markerEventsCallBack: function (id, marker, handler, eventName) {
            google.maps.event.addListener(marker, eventName, function (e) {
                var args = { 'id': id, 'marker': marker, 'eventName': eventName };
                $.extend(args, e);
                handler(args);
            });
        },
        createImage: function (options) {
            var image = new google.maps.MarkerImage(options.path,
                new google.maps.Size(options.size.width, options.size.height),
                new google.maps.Point(options.point.x, options.point.y),
                new google.maps.Point(options.anchor.x, options.anchor.y));
            return image;
        },
        load: function (point) {
            this.latitude = point.lat();
            this.longitude = point.lng();
            var markerOptions = {
                position: new google.maps.LatLng(this.latitude, this.longitude),
                map: this.enableMarkersClustering ? null : this.Map,
                title: this.title,
                clickable: this.clickable,
                draggable: this.draggable,
                icon: this.icon ? this.createImage(this.icon) : null,
                zIndex: this.zIndex
            };
            // create
            this.gMarker = new google.maps.Marker(markerOptions);
            $.extend(this.gMarker, { address: this.address });
            if (this.parent.fitToMarkersBounds) {
                this.parent.bounds.extend(this.gMarker.position);
            }
            this.initialize();

            markersCluster[this.id] = this.gMarker;

        },
        openInfoWindow: function () {
            if (this.isLoaded()) {
                if (infowindow) {
                    infowindow.close();
                }
                var node = document.getElementById(this.window.content).cloneNode(true);
                infowindow = new google.maps.InfoWindow(this.window);
                infowindow.setContent(node.innerHTML);
                var windowsLoc;
                if (this.window.lat && this.window.lng) {
                    windowsLoc = new google.maps.LatLng(this.window.lat, this.window.lng);
                } else {
                    windowsLoc = this.gMarker.getPosition();
                }
                infowindow.setPosition(windowsLoc);
                infowindow.open(this.Map, this.gMarker);
            }
        }
    };
})(jQuery);