var gmaps;

(function ($) {
    "use strict";

    gmaps = {
        mvc: {
            create: function (query, settings) {
                var name = settings.name;
                var options = $.extend({}, $.fn[name].defaults, settings.options);

                return query.each(function () {
                    var $$ = $(this);
                    options = $.meta ? $.extend({}, options, $$.data()) : options;

                    if (!$$.data(name)) {
                        var component = settings.init(this, options);

                        $$.data(name, component);

                        gmaps.mvc.trigger(this, 'load');

                        if (settings.success && !$.isEmptyObject(options)) settings.success(component);
                    }
                });
            },
            bind: function (context, events) {
                var $element = $(context.element ? context.element : context);
                $.each(events, function (eventName) {
                    if ($.isFunction(this)) $element.bind(eventName, this);
                });
            },
            delegate: function (context, handler) {
                return function (e) {
                    handler.apply(context, [e, this]);
                };
            },
            trigger: function (element, eventName, e) {
                e = $.extend(e || {}, new $.Event(eventName));
                e.stopPropagation();
                $(element).trigger(e);
                return e.isDefaultPrevented();
            },
        }
    }



    // jQuery extender
    $.fn.GoogleMap = function (options) {
        return gmaps.mvc.create(this, {
            name: 'GoogleMap',
            init: function (element, options) {
                return new gmaps.mvc.GoogleMap(element, options);
            },
            options: options,
            success: function (map) {
                map.load();
            }
        });
    };
})(jQuery);
