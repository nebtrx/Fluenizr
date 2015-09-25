namespace Fluenizr
{
    public static class FluenizrExtensions
    {
        public static dynamic Fluenize<T>(this T obj)
        {
            return new FluentProxy<T>(obj);
        }
    }
}