namespace extgen.Config.Utils
{
    public interface IFromConfig<Self, Options> 
    {
        public static abstract Self FromConfig(Options targetOptions);
    }
}
