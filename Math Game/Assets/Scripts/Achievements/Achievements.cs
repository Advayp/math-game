using System.Collections.Generic;
using UnityEngine;

namespace Discovery.Achievements
{
    [CreateAssetMenu]
    public class Achievements : ScriptableObject
    {
        public int questionsAnswered;
        public int score;
        public List<string> texts = new List<string>();

        public void Reset()
        {
            texts = new List<string>();
            questionsAnswered = 0;
            score = 0;
        }

        public void AddText(string text)
        {
            texts.Add(text);
        }
    }

}