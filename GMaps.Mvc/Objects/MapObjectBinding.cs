// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    using System;

    public sealed class MapObjectBinding<TMapObject, TDataItem> : IMapObjectBinding<TMapObject>
        where TMapObject : MapObject
    {
        public Action<TMapObject, TDataItem> ItemDataBound
        {
            get;
            set;
        }

        void IMapObjectBinding<TMapObject>.ItemDataBound(TMapObject item, object value)
        {
            this.ItemDataBound(item, (TDataItem)value);
        }
    }
}
