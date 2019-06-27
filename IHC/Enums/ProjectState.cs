using System;
using System.ComponentModel;

namespace IHC.Enums
{
    public enum ProjectState
    {
        [Description("Em negociação")]
        IN_NEGOCIATION,
        [Description("Contratado")]
        CONTRACTED,
        [Description("Cancelado")]
        CANCELLED,
        [Description("Concluído")]
        CONCLUDED,
        NULL
    }

    public static class ProjectStateExtensions
    {

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            return default(T);
        }

        public static string ToDescriptionString(this ProjectState val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
