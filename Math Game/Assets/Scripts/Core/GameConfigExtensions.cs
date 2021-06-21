using System;
using System.Collections.Generic;

namespace Discovery
{
    [Serializable]
    public enum Field
    {
        MouseSensitivity,
        FieldOfView,
        ShowEffects,
        RhythmChangeAnswerColor,
        RhythmShowConstantColorChange,
        ShowAchievements
    }

    public static class GameConfigExtensions
    {
        private static readonly Dictionary<Field, string> Variables = new Dictionary<Field, string>
        {
            { Field.MouseSensitivity, GameConfig.MouseSenseString },
            { Field.ShowEffects, GameConfig.ShowEffectsString },
            { Field.FieldOfView, GameConfig.FovString },
            { Field.RhythmChangeAnswerColor, GameConfig.ChangeAnswerColorString },
            { Field.RhythmShowConstantColorChange, GameConfig.ShowConstantColorChangeString },
            { Field.ShowAchievements, GameConfig.ShowAchievementString }
        };

        public static object Get(this GameConfig config, Field field)
        {
            var fld = typeof(GameConfig).GetField(Variables[field]);
            return fld.GetValue(config);
        }

        public static void Set(this GameConfig config, Field field, object value)
        {
            var fld = typeof(GameConfig).GetField(Variables[field]);
            fld.SetValue(config, value);
        }
    }
}