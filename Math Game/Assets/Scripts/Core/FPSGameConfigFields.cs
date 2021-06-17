using System;
using System.Collections.Generic;

namespace Discovery
{
    [Serializable]
    public enum Fields
    {
        MouseSensitivity,
        FieldOfView,
        ShowEffects
    }

    public static class FPSGameConfigExtensions
    {
        private static readonly Dictionary<Fields, string> Variables = new Dictionary<Fields, string>
        {
            { Fields.MouseSensitivity, FPSGameConfig.MouseSenseString },
            { Fields.ShowEffects, FPSGameConfig.ShowEffectsString },
            { Fields.FieldOfView, FPSGameConfig.FovString }
        };

        public static object Get(this FPSGameConfig config, Fields field)
        {
            var fld = typeof(FPSGameConfig).GetField(Variables[field]);
            return fld.GetValue(config);
        }

        public static void Set(this FPSGameConfig config, Fields field, object value)
        {
            var fld = typeof(FPSGameConfig).GetField(Variables[field]);
            fld.SetValue(config, value);    
        }
    }
}