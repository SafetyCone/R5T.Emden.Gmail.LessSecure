using System;

using Microsoft.Extensions.Configuration;

using R5T.Argos;


namespace R5T.Emden.Gmail.LessSecure
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddGmailLessSecureConfiguration(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddGmailLessSecureAuthenticationConfiguration();

            return configurationBuilder;
        }
    }
}
