using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.Data.Core.Interfaces;

namespace WA.Data.Core
{
    public class ContextFactory : Disposable, IContextFactory
    {
        private DbContext _dbContext;
        private readonly string _cnString;

        /// <summary>
        /// build context based on connectionString
        /// </summary>
        /// <param name="cnString"></param>
        public ContextFactory(string cnString)
        {
            _cnString = cnString;
        }

        /// <summary>
        /// build context based on connectionString
        /// </summary>
        /// <returns></returns>
        public DbContext GetContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new WebAppEntities(_cnString);
            }

            return _dbContext;
        }

        /// <summary>
        /// this gets called when shutting down application to dispose of context.
        /// </summary>
        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
