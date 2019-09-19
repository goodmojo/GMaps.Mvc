﻿// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    public interface IClientEventObject
    {
        void SerializeTo(ClientSideObjectWriter writer);
    }
}