using Microsoft.Extensions.Configuration;
using System;

namespace Nurzed
{
    public class Conexao
    {

        public static string conexaoString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();

            return configuration.GetConnectionString("conexao");

        }
    }
}
