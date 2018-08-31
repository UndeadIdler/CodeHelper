using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CodeHelper
{
    public static class Configs
    {
        ///<summary> 
        ///返回config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<param name="config">Configuration实例</param>
        ///<returns></returns> 
        public static string GetAppSettingsItemValue(this Configuration config, string strKey)
        {
            foreach (KeyValueConfigurationElement key in config.AppSettings.Settings)
            {
                if (key.Key == strKey)
                {
                    return config.AppSettings.Settings[strKey].Value;
                }
            }
            return string.Empty;
        }


        /// <summary>
        /// 获取所有的appSettings的节点。
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetAppSettings(this Configuration config)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (KeyValueConfigurationElement key in config.AppSettings.Settings)
            {
                dict[key.Key] = key.Value;
            }
            return dict;
        }


        ///<summary>  
        ///更新在config文件中appSettings配置节增加一对键、值对。
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        ///<param name="config"></param>
        public static void UpdateAppSettingsItemValue(this Configuration config, string newKey, string newValue)
        {
            UpdateAppSettingsItemNoSave(config, newKey, newValue);
            ////// Save the changes in App.config file.      
            config.Save(ConfigurationSaveMode.Modified);

            ////// Force a reload of a changed section.      
            ConfigurationManager.RefreshSection("appSettings");
        }


        private static void UpdateAppSettingsItemNoSave(Configuration config, string newKey, string newValue)
        {
            bool isModified = false;
            foreach (KeyValueConfigurationElement key in config.AppSettings.Settings)
            {
                if (key.Key == newKey)
                { isModified = true; }
            }

            // You need to remove the old settings object before you can replace it      
            if (isModified)
            { config.AppSettings.Settings.Remove(newKey); }

            // Add an Application Setting.      
            config.AppSettings.Settings.Add(newKey, newValue);
        }
    }
}
