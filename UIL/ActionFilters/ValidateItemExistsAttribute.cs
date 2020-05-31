using BLL.Services.InterfacesServices;
using DAL.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIL.ActionFilters
{
    public class ValidateItemExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public ValidateItemExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT") ? true : false;
            var id = (int)context.ActionArguments["id"];
            var item = await _repository.Items.GetItemAsync(id, trackChanges);

            if (item == null)
            {
                _logger.LogInfo($"Item with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("item", item);
                await next();
            }
        }
    }
}
      
