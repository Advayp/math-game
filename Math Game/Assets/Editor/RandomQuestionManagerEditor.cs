using Discovery.Managers;
using UnityEditor;
using UnityEngine;

namespace Discovery.Editor
{
    [CustomEditor(typeof(RandomQuestionManager))]
    public class RandomQuestionManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var questionManager = target as RandomQuestionManager;

            if (GUILayout.Button("Generate Random Question"))
            {
                questionManager!.GenerateNewQuestion();
            }
        }
    }
}