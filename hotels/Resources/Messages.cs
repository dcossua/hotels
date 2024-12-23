using System.Reflection;
using System.Resources;

namespace hotels.Resources
{
    /// <summary>
    /// Allows access to predefined messages from resources file Messages.resx.
    /// </summary>
    public class Messages
    {
        // Access to Messages.resx file
        private static ResourceManager _resourceManager = new ResourceManager("hotels.App_Data.Messages", Assembly.GetExecutingAssembly());

        /// <summary>
        /// Obtains associated message by key from resources file.
        /// </summary>
        /// <param name="key">The key that identifies the message.</param>
        /// <returns>Message associated with the specfied key</returns>
        public static string GetMessage(string key)
        {
            return _resourceManager.GetString(key);
        }
    }
}
