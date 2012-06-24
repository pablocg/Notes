using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notes.NH.Repositories;

namespace Notes.Web.Filters
{
    public class UnitOfWorkFilter : IActionFilter, IExceptionFilter
    {
        private IUnitOfWork _unitOfWork;

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //usar algun provider para obtener el unit of work actual, y no crearlo para cada action,
            //ya que crea un sessionfactory y es costoso.
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        public void OnException(ExceptionContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}