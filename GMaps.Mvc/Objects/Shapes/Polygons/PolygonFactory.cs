// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    public class PolygonFactory : MapObject, IHideObjectMembers
    {
        public PolygonFactory(Map map)
            : base(map)
        {
        }

        public PolygonBuilder Add()
        {
            var polygon = new Polygon(this.Map);

            this.Map.Polygons.Add(polygon);

            return new PolygonBuilder(polygon);
        }
    }
}
