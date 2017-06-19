using System.Data.Entity;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using ProductsDomain.Features.Shared;
using System.Threading;
using System.Threading.Tasks;
using ProductsDomain.Orm;

namespace ProductsAPI.Filters
{
    public class DbTransactionFilter : IAutofacActionFilter
    {
        private const string DbTransactionKey = "DbContext.Transaction";
        private readonly AdventureWorksContext _dbContext;
        private readonly HttpRequestMessage _requestMessage;

        public DbTransactionFilter(
            AdventureWorksContext dbContext,
            HttpRequestMessage requestMessage)
        {
            _dbContext = dbContext;
            _requestMessage = requestMessage;
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _requestMessage.Properties[DbTransactionKey] = _dbContext.Database.BeginTransaction();
            }, cancellationToken);
        }

        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                if (!_requestMessage.Properties.ContainsKey(DbTransactionKey)) return;

                var transaction = (DbContextTransaction)_requestMessage.Properties[DbTransactionKey];

                try
                {
                    if (actionExecutedContext.Exception != null || !actionExecutedContext.Response.IsSuccessStatusCode)
                    {
                        transaction.Rollback();
                    }
                    else
                    {
                        transaction.Commit();
                    }
                }
                finally
                {
                    _requestMessage.Properties.Remove(DbTransactionKey);
                    transaction.Dispose();
                }
            }, cancellationToken);
        }
    }
}