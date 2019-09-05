// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    public class InfoWindowFactory : IHideObjectMembers
    {
        private readonly Marker marker;

        public InfoWindowFactory(Marker marker)
        {
            this.marker = marker;
        }

        public InfoWindowBuilder Add()
        {
            var window = new InfoWindow(this.marker);

            this.marker.Window = window;

            return new InfoWindowBuilder(window);
        }
    }
}
