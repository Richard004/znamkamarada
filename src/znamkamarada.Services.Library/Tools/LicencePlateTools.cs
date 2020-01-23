using System;
using System.Collections.Generic;
using System.Text;

namespace znamkamarada.Services.Library.Tools
{
    public static class LicencePlateTools
    {

        /// <summary>
        /// https://lonewolfonline.net/list-net-culture-country-codes/
        /// Valid form 'CZ*AZ8360'
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="licencePlate"></param>
        /// <returns></returns>

        public static bool TrySanitizeInputToLicencePlate(string inputString,out LicencePlate licencePlate)
        {
            licencePlate = null;
            if (string.IsNullOrWhiteSpace(inputString))
                return false;

            var str = inputString.Replace(" ", "");

            var semicollonPos = str.IndexOf('*');
            if (semicollonPos < 0)
                return false;

            var country = str.Substring(0, semicollonPos).ToUpperInvariant();
            var number = str.Substring(semicollonPos + 1).ToUpperInvariant();
            licencePlate = new LicencePlate(country, number);

            return true;
        }
    }
}
