// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    using System;
    using System.Drawing;

    public abstract class ShapeBuilderBase<TShape>
        where TShape : Shape
    {
        protected ShapeBuilderBase(ShapeBuilderBase<TShape> builder)
            : this(PassThroughNonNull(builder).Shape)
        {
        }

        protected ShapeBuilderBase(TShape shape)
        {
            this.Shape = shape;
        }

        protected TShape Shape { get; }

        public ShapeBuilderBase<TShape> Clickable(bool enabled)
        {
            this.Shape.Clickable = enabled;
            return this;
        }

        public ShapeBuilderBase<TShape> StrokeColor(Color value)
        {
            this.Shape.StrokeColor = value;
            return this;
        }

        public ShapeBuilderBase<TShape> StrokeOpacity(double value)
        {
            this.Shape.StrokeOpacity = value;
            return this;
        }

        public ShapeBuilderBase<TShape> StrokeWeight(int value)
        {
            this.Shape.StrokeWeight = value;
            return this;
        }

        public ShapeBuilderBase<TShape> ZIndex(int value)
        {
            this.Shape.ZIndex = value;
            return this;
        }

        private static ShapeBuilderBase<TShape> PassThroughNonNull(ShapeBuilderBase<TShape> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}
