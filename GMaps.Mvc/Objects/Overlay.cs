// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    public class Overlay : MapObject
    {
        public Overlay(Map map)
            : base(map)
        {
        }

        public virtual double? Longitude { get; set; }

        public virtual double? Latitude { get; set; }
    }
}