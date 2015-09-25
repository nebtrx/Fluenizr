using System;
using System.Linq;

namespace Fluenizr
{
    public static class Fluenizr
    {

        static Fluenizr()
        {
            Config = new FluenizrConfig();
        }


        public static dynamic New<T>(params object[] args) where T : new()
        {
            T proxied;

            if (args.Any())
            {
                proxied = (T)Activator.CreateInstance(typeof(T), (object)args);
            }
            else
            {
                proxied = new T();
            }


            return new FluentProxy<T>(proxied);
        }

        public static FluenizrConfig Config { get; internal set; }
    }
}