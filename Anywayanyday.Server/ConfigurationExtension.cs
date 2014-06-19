using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Server
{
    public static class ConfigurationExtension
    {
        public static Configuration Factory(this Configuration configuration, IFactory factory)
        {
            configuration.Factory = factory;
            return configuration;
        }

        public static Configuration Factory<TFactory>(this Configuration configuration) where TFactory:IFactory , new()
        {
            configuration.Factory = new TFactory();
            return configuration;
        }

        public static Configuration PoolSize(this Configuration configuration, int poolSize)
        {
            configuration.PoolSize = poolSize;
            return configuration;
        }

        public static Configuration QueueSize(this Configuration configuration, int queueSize)
        {
            configuration.QueueSize = queueSize;
            return configuration;
        }

        public static Configuration Prefix(this Configuration configuration, string prefix)
        {
            configuration.Prefix = prefix;
            return configuration;
        }

        public static Configuration NotFoundUrl(this Configuration configuration, string url)
        {
            configuration.NotFoundUrl = url;
            return configuration;
        }

        


    }
}
