using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using R5T.Argos;
using R5T.Dacia;
using R5T.Gimpolis;


namespace R5T.Emden.Gmail.LessSecure
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="EmailSender"/> implementation of <see cref="IEmailSender"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddEmailSender(this IServiceCollection services,
            IServiceAction<IOptions<GmailAuthentication>> gmailAuthenticationOptions)
        {
            services
                .AddSingleton<IEmailSender, EmailSender>()
                .Run(gmailAuthenticationOptions)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="EmailSender"/> implementation of <see cref="IEmailSender"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IEmailSender> AddEmailSenderAction(this IServiceCollection services,
            IServiceAction<IOptions<GmailAuthentication>> gmailAuthenticationOptions)
        {
            var serviceAction = ServiceAction.New<IEmailSender>(() => services.AddEmailSender(
                gmailAuthenticationOptions));

            return serviceAction;
        }
    }
}
