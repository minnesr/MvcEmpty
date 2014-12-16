using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmpty.Models.EF;

namespace MvcEmpty.Repositories.Orders
{
    public class OrderRepo : IDisposable
    {
        private AppContext context;

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}