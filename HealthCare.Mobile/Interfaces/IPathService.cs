﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Mobile.Interfaces
{
    public interface IPathService
    {
        string InternalFolder { get; }
        string PublicExternalFolder { get; }
        string PrivateExternalFolder { get; }
    }
}
