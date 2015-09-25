using System;
using System.Dynamic;
using System.Reflection;

namespace Fluenizr
{
    public class FluentProxy<T> : DynamicObject
    {
        private readonly T _proxied;

        public FluentProxy(T proxied)
        {
            _proxied = proxied;
        }

        public static implicit operator T(FluentProxy<T> proxy)
        {
            return proxy._proxied;
        }

        public T TypedInstance
        {
            get
            {
                return _proxied;
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var fluentPrefix = Fluenizr.Config.FluentPrefix;

            var hasFluentPrefix = binder.Name.StartsWith(fluentPrefix);
            var propertyName = hasFluentPrefix ? binder.Name.Substring(fluentPrefix.Length) : string.Empty;

            if (hasFluentPrefix)
            {
                PropertyInfo property = _proxied.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                if (null != property && property.CanWrite)
                {
                    property.SetValue(_proxied, args[0], null);
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            else
            {
                throw new NotSupportedException();
            }
            result = this;

            return true;
        }
    }
}