﻿// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    public class CircleFactory : IHideObjectMembers
    {
        public CircleFactory(Map map)
        {
            this.Map = map;
        }

        protected Map Map { get; private set; }

        public CircleBuilder Add()
        {
            var circle = new Circle(this.Map);

            this.Map.Circles.Add(circle);

            return new CircleBuilder(circle);
        }
    }
}
