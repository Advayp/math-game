using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Discovery
{
    public enum AvailableColors
    {
        Red,
        Green,
        Blue,
        Yellow,
    }

    public static class Extensions
    {
        private static readonly Dictionary<AvailableColors, string> Colors = new Dictionary<AvailableColors, string>()
        {
            { AvailableColors.Blue, "blue" },
            { AvailableColors.Green, "green" },
            { AvailableColors.Red, "red" },
            { AvailableColors.Yellow, "yellow" }
        };

        public static string Color(this string text, AvailableColors color)
        {
            return $"<color={Colors[color]}>{text}</color>";
        }

        public static void Show(this QuestionDisplayer questionDisplayer)
        {
            questionDisplayer.gameObject.SetActive(true);
        }

        public static void Hide(this QuestionDisplayer questionDisplayer)
        {
            questionDisplayer.gameObject.SetActive(false);
        }

        public static void Require<T>(this T o, Object context) where T : Object
        {
            if (o == null)
            {
                Debug.LogWarning($"<color=yellow>MISSING</color> {typeof(T).ToString().Color(AvailableColors.Blue)} in {context.name.Color(AvailableColors.Red)}", context);
            }
        }

        public static void RequireComponent<T>(this IEnumerable<GameObject> objects, Object context) where T : Behaviour
        {
            var gameObjects = objects as GameObject[] ?? objects.ToArray();
            if (gameObjects.Any(e => e.GetComponentInChildren<T>() == null))
            {
                Debug.LogWarning($"Expected Type <color=yellow>{typeof(T)}</color> in <color=red>{context.name}</color>", context);
            }
        }

    }
}