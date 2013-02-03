using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EISModuleComponents;
using EclipsisTransactionProtocol;
using Eclipsis;

namespace Eclipsis
{
    class EISMetaLayer
    {
        public static GlobalServices Services = new GlobalServices();
        public static EISModuleServices Modules = new EISModuleServices();
        public static SQLRequestProcessor SQLProcessor = new SQLRequestProcessor();
    }
}
