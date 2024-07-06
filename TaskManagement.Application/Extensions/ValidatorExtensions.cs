﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Comments.Commands;

namespace TaskManagement.Application.Extensions
{
	public static class ValidatorExtensions
	{
		public static IServiceCollection RegisterValidators(this IServiceCollection services)
		{
			services.AddScoped<IValidator<CreateCommentCommand>, CreateCommentValidator>();
			services.AddScoped<IValidator<HideCommentCommand>, HideCommentValidator>();

			return services;
		}
	}
}
