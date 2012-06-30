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

            _unitOfWork = UnitOfWorkProvider.GetCurrent();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                _unitOfWork.Commit();
                _unitOfWork.Dispose();
            }
        }

        public void OnException(ExceptionContext filterContext)
        {
            _unitOfWork.Rollback();
            _unitOfWork.Dispose();
        }
    }
}