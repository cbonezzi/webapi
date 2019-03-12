using System.Configuration;
using WA.Service.Dto;

namespace WA1
{
    /// <summary>
    /// appsettings class for ease of handling appsettings
    /// </summary>
    public static class AppSettings
    {

        #region Connection strings

        public static string WAEdmxConnectionString => ConfigurationManager.ConnectionStrings["WAEntities"].ConnectionString;
        public static string WAConnectionString => ConfigurationManager.ConnectionStrings["WebApp"].ConnectionString;

        #endregion

        /// <summary>
        /// method to pass appsettings with ease to service layer
        /// </summary>
        /// <returns></returns>
        public static AppSettingsDto ToServiceAppSettingsDto()
        {
            var dto = new AppSettingsDto();

            #region Connection strings

            dto.WAConnectionString = WAConnectionString;
            dto.WAEdmxConnectionString = WAEdmxConnectionString;

            #endregion

            return dto;
        }
    }
}