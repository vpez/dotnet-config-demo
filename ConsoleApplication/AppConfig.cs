using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;

namespace ConsoleApplication
{
    public class AppConfig
    {
        public enum CognitiveServiceVendor
        {
            Microsoft,             
            Google, 
            Amazon
        }

        public List<string> GetKeys(CognitiveServiceVendor vendor, string serviceName)
        {
            var nameValueCollection = ConfigurationManager.GetSection("CognitiveServices/" + vendor) as NameValueCollection;

            if (nameValueCollection == null)
            {
                throw new ConfigurationErrorsException("Cannot find configuration: CognitiveServices/" + vendor);
            }

            foreach (var key in nameValueCollection.AllKeys)
            {
                if (key.Equals(serviceName))
                {
                    return new List<string>(nameValueCollection[key].Split(','));
                }
            }
            
            throw new ConfigurationErrorsException("Cannot find configuration: CognitiveServices/" + vendor + "/" + serviceName);
        }
    }
}