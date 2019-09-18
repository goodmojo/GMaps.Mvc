// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    using System;

    public class MapObjectBindingBuilderBase<TMapObject, TDataItem>
        where TMapObject : MapObject
    {
        private readonly MapObjectBinding<TMapObject, TDataItem> bindingComponent;

        public MapObjectBindingBuilderBase(MapObjectBinding<TMapObject, TDataItem> mapObjectBinding)
        {
            this.bindingComponent = mapObjectBinding;
        }

        public MapObjectBindingBuilderBase<TMapObject, TDataItem> ItemDataBound(Action<TMapObject, TDataItem> action)
        {
            this.bindingComponent.ItemDataBound = action;
            return this;
        }
    }
}