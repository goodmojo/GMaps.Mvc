// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    using System.Collections.Generic;
    using System.Globalization;

    public class DefaultLayerSerializer : LayerSerializer<Layer>
    {
        internal DefaultLayerSerializer(Layer layer) : base(layer) { }
    }
    public class LayerSerializer<TLayer> : ISerializer
        where TLayer : Layer
    {
        internal LayerSerializer(TLayer layer)
        {
            this.Layer = layer;
        }

        public TLayer Layer { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result["name"] = this.Layer.Name.ToLower(CultureInfo.InvariantCulture);
            result["options"] = this.LayerSerialize();
            return result;
        }

        protected virtual IDictionary<string, object> LayerSerialize()
        {
            return new Dictionary<string, object>();
        }
    }
}