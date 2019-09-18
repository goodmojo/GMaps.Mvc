// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    using System.Collections.Generic;

    public class PolylineSerializer : ShapeSerializeBase<Polyline>
    {
        private readonly Polyline polyline;

        public PolylineSerializer(Polyline polyline)
            : base(polyline)
        {
            this.polyline = polyline;
        }

        public override IDictionary<string, object> Serialize()
        {
            var result = base.Serialize();

            result.Add("Points", this.polyline.Points);

            return result;
        }
    }
}