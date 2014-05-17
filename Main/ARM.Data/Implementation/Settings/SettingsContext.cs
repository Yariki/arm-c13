using ARM.Data.Interfaces.Settings;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Settings
{
    /// <summary>
    /// Контекст бази даних для налаштувань
    /// </summary>
    public class SettingsContext : BaseContext<Models.SettingParameters>, ISettingsContext
    {
    }
}