using Discovery.Minigames.Rhythm;
using UnityEditor;
using UnityEngine;

namespace Discovery.Editor
{
    [CustomEditor(typeof(QuestionMaker))]
    public class QuestionMakerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var questionMaker = target as QuestionMaker;

            GUILayout.Space(10);
            
            if (GUILayout.Button("Update Text"))
            {
                questionMaker?.UpdateQuestionUI();
            }
        }
    }
}