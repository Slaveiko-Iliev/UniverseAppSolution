﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Models;

public class CheckIsDeletedAttribute<T> : Attribute, IAsyncActionFilter where T : class, IEntity
{
	public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
	{
		var id = context.ActionArguments["id"];
		var service = context.HttpContext.RequestServices.GetService<IRepository>();

		if (service == null)
		{
			context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
		}

		var entity = await service.AllReadOnly<T>().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == (int)id);

		if (entity != null && entity.IsDeleted)
		{
			context.Result = new BadRequestResult();
			return;
		}

		await next();
	}
}
