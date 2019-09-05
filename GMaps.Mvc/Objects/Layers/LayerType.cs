// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    internal enum LayerType
    {
        [ClientSideEnumValue("'Traffic'")]
        Traffic,
        [ClientSideEnumValue("'Transit'")]
        Transit,
        [ClientSideEnumValue("'Bicycling'")]
        Bicycling
    }
}