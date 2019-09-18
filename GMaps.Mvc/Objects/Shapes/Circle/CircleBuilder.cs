// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    public class CircleBuilder : Shape2DBuilderBase<Circle>
    {
        public CircleBuilder(Circle shape)
            : base(shape)
        {
        }

        public CircleBuilder Center(Location point)
        {
            this.Shape.Center = point;
            return this;
        }

        public CircleBuilder Radius(int value)
        {
            this.Shape.Radius = value;
            return this;
        }
    }
}
