using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Argos;


namespace R5T.Emden.Gmail.LessSecure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGmailLessSecureEmailSender(this IServiceCollection services)
        {
            services
                .AddGmailAuthentication()
                .AddSingleton<IEmailSender, EmailSender>()
                ;

            return services;
        }
    }
}
