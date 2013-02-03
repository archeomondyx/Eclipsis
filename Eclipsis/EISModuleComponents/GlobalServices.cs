using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EISModuleComponents
{
    public class GlobalServices
    {
        EISCryptoService cryptoService = new EISCryptoService();

        public EISCryptoService CryptoService
        {
            get { return cryptoService; }
        }
    }
}
