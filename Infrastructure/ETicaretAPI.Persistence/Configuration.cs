using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    static class Configuration
    {

        static public string ConnectionString 
        {
            get
            {
                // Microsoft.Extensions.Configuration kütüphanesini yükleyip tüm json dosyalarını okutuyoruz ve ConfigurationManager oluşturuyoruz.
                ConfigurationManager configurationManager = new();

                // Aşagıdaki fonksiyonları kullanmak içinse  Microsoft.Extensions.Configuration.Json kütüphanesini indiriyoruz
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("PostgreSQL");
            }
                
        }

    }
}
