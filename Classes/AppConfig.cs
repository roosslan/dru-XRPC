using System;
using System.Configuration;
using System.IO;

namespace trade {
    /// <summary>
    /// Доступ к настройкам приложения (App.config, section appSettings).
    /// </summary>
    internal static class AppConfig {
        /// <summary>
        /// Возвращает значение настройки или null, если настройка не задана.
        /// </summary>
        public static string Get(string key) {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Возвращает значение настройки; если она не задана или пуста — defaultValue.
        /// </summary>
        public static string Get(string key, string defaultValue) {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        /// <summary>
        /// Путь к файлу из настроек. Относительные пути считаются от папки приложения,
        /// абсолютные возвращаются как есть.
        /// </summary>
        public static string GetPath(string key, string defaultFileName) {
            string value = Get(key, defaultFileName);

            if (string.IsNullOrEmpty(value))
                value = defaultFileName;

            if (Path.IsPathRooted(value))
                return value;

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, value);
        }
    }
}
