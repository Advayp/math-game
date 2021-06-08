using System.Collections.Generic;

namespace MathGame
{
    public enum AvailableColors
    {
        Red,
        Green,
        Blue
    }

    public static class Extensions
    {
        private static readonly Dictionary<AvailableColors, string> Colors = new Dictionary<AvailableColors, string>()
        {
            {AvailableColors.Blue, "blue"},
            {AvailableColors.Green, "green"},
            {AvailableColors.Red, "red"}
        };

        public static string Color(this string text, AvailableColors color)
        {
            return $"<color={Colors[color]}>{text}</color>";
        }

        public static string Bold(this string text)
        {
            return $"<b>{text}</b>";
        }
    }
}