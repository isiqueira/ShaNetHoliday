using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.WebService.Client.Configuration
{
    public class HolidayConfig : ConfigurationSection
    {
        /// <summary>
        /// Url de base de l'Api.
        /// </summary>
        [ConfigurationProperty( nameof( BaseApiUrl ), IsRequired = true, DefaultValue = "http://holiday.ShaNet.dom/api/" )]
        public string BaseApiUrl => (string)this[ nameof( BaseApiUrl ) ];

        public static HolidayConfig Conf { get; }

        static HolidayConfig()
        {
            Conf = (HolidayConfig)ConfigurationManager.GetSection( nameof( HolidayConfig ) );
            if ( System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime )
            {
                Conf = new HolidayConfig();
            }

            if ( ( Conf?.ElementInformation.IsPresent != true ) && System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime )
            {
                throw new Exception( $"La section de configuration {nameof( HolidayConfig )} n'a pas été trouvée." );
            }
        }

        public static void CheckConsistency() { }
    }
}
