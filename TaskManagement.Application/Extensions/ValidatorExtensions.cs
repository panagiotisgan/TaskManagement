using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Assignment.Commands;
using TaskManagement.Application.Assignment.Queries;
using TaskManagement.Application.Comments.Commands;

namespace TaskManagement.Application.Extensions
{
	public static class ValidatorExtensions
	{
		public static IServiceCollection RegisterValidators(this IServiceCollection services)
		{
			services.AddScoped<IValidator<CreateCommentCommand>, CreateCommentValidator>();
			services.AddScoped<IValidator<HideCommentCommand>, HideCommentValidator>();
			services.AddScoped<IValidator<GetAssignment>, GetAssignmentValidator>();
			services.AddScoped<IValidator<CreateAssignmentCommand>, CreateAssignmentValidator>();
			services.AddScoped<IValidator<UpdateAssignmentCommand>, UpdateAssignmentValidatror>();
			//services.AddScoped<IValidator<CreateLogCommand>, CreateLogValidator>();

			return services;
		}
    }
}
