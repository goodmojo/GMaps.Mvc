(function ($) {
    "use strict";
    // HeatMapLayer
    gmaps.mvc.HeatMapLayer = function (map, config) {

        this.map = map;
        this.dissipating = (config.dissipating !== undefined) ? config.clickable : true;
        this.maxIntensity = config.maxIntensity;
        this.opacity = config.opacity;
        this.radius = config.radius;
        this.gradient = config.gradient;
        this.data = config.data;
    }

    gmaps.mvc.HeatMapLayer.prototype = {}

    // KmlLayer
    gmaps.mvc.KmlLayer = function (map, config) {

        this.map = map;
        this.clickable = config.clickable;
        this.preserveViewport = config.preserveViewport;
        this.screenOverlays = config.screenOverlays;
        this.suppressInfoWindows = config.suppressInfoWindows;
        this.zIndex = config.zIndex;
        this.url = config.url;
    }

    gmaps.mvc.KmlLayer.prototype = {}
})(jQuery);