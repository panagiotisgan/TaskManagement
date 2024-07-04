using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Services;

namespace TaskManagement.Infrastructure.Extensions
{
	public static class ServicesExtension
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddTransient<ICommentService, CommentService>();
			return services;
		}
	}
}
