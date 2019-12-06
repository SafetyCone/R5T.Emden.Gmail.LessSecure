using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Gimpolis;
using R5T.Sardinia;


namespace R5T.Emden.Gmail.LessSecure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGmailLessSecureEmailSender(this IServiceCollection services)
        {
            services
                .AddOptions()
                .Configure<GmailAuthentication>()
                .AddSingleton<IEmailSender, EmailSender>()
                ;

            return services;
        }
    }
}
