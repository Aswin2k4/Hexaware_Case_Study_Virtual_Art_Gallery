using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace VirtualArtGallery.Utility
{
    internal class DBConnection
    {
        private static IConfiguration _iconfiguration;

        static DBConnection()
        {
            // Load the configuration from appsettings.json
            LoadAppSettingsFile();
        }

        private static void LoadAppSettingsFile()
        {
            try
            {
                // Set up configuration to read from appsettings.json
                var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())  // Get the base directory of the application
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Ensure file exists

                _iconfiguration = builder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                throw; // Re-throw exception to halt execution if configuration file is missing
            }
        }

        /// <summary>
        /// Retrieves the connection string from appsettings.json
        /// </summary>
        /// <returns>The connection string</returns>
        public static string GetConnectionString()
        {
            try
            {
                // Get the connection string from appsettings.json
                var connectionString = _iconfiguration.GetConnectionString("LocalConnectionString");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'LocalConnectionString' is missing or empty in appsettings.json");
                }

                return connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving connection string: {ex.Message}");
                throw; // Re-throw exception to ensure the program doesn't continue with an invalid connection
            }
        }
    }
}
