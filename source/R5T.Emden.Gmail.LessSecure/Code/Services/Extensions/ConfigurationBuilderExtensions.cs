using System;

using Microsoft.Extensions.Configuration;

using R5T.Scotia;


namespace R5T.Emden.Gmail.LessSecure
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddGmailLessSecureConfiguration(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddUserSecretsFileRivetLocation(FileNames.GmailLessSecureConfigurationJsonFileName);

            return configurationBuilder;
        }
    }
}
