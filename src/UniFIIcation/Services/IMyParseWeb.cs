﻿using System.Collections.Generic;

namespace UniFIIcation.Services
{
    public interface IMyParseWeb
    {
        List<string> ExtractContent(string url);
    }
}
