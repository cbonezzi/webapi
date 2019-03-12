using System.Data.Entity;

namespace WA.Data.Core.Interfaces
{
    /// <summary>
    /// contextfactory signature
    /// </summary>
    public interface IContextFactory
    {
        /// <summary>
        /// this provides getting content for tables in the database
        /// </summary>
        /// <returns>table in database</returns>
        DbContext GetContext();
    }
}
