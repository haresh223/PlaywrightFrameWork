using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlaywrightFramework
{
    public class ConfigManager
    {
        // Static variable to hold the instance of the configuration
        public static EnvironmentConfig _environmentConfig;

        // Static property to access the configuration
        public static EnvironmentConfig GetConfig()
        {
            if (_environmentConfig == null)
            {
                // Initialize the configuration only once
                string configFilePath = "config.json"; // Path to your configuration file
                string jsonString = File.ReadAllText(configFilePath);
                _environmentConfig = JsonSerializer.Deserialize<EnvironmentConfig>(jsonString);

                if (_environmentConfig == null)
                {
                    throw new Exception("Failed to load configuration from the file.");
                }
            }

            return _environmentConfig;
        }
    }
}
