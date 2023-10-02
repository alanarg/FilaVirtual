using System.ComponentModel;
using System.Reflection;

namespace FilaVirtual.Util.Extensions
{
    public static class TypeExtensions
	{
        public static object GetValueProperty(this object _object, string propertyName)
        {
            return _object?.GetType()?.GetProperty(propertyName)?.GetValue(_object);
        }
        public static bool isObject(this object _object)
        {
            return (_object?.GetType() != typeof(object) && Type.GetTypeCode(_object?.GetType()) == TypeCode.Object);
        }

    }
}
