// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    using System.Drawing;

    public abstract class Shape2DBuilderBase<TShape2D> : ShapeBuilderBase<TShape2D>
        where TShape2D : Shape2D
    {
        protected Shape2DBuilderBase(TShape2D shape2D)
            : base(shape2D)
        {
        }

        public Shape2DBuilderBase<TShape2D> FillColor(Color value)
        {
            this.Shape.FillColor = value;
            return this;
        }

        public Shape2DBuilderBase<TShape2D> FillOpacity(double value)
        {
            this.Shape.FillOpacity = value;
            return this;
        }
    }
}
