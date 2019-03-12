using WA.Service.Dto;

namespace WA.Service
{
    internal static class AppSettings
    {

        #region Connection strings

        internal static string WAConnectionString { get; set; }
        internal static string WAEdmxConnectionString { get; set; }

        #endregion

        internal static void Init(AppSettingsDto settings)
        {

            #region Connection strings

            WAConnectionString = settings.WAConnectionString;
            WAEdmxConnectionString = settings.WAEdmxConnectionString;

            #endregion
        }
    }
}
