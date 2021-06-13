using Discovery.Minigames.FirstPersonShooter;
using UnityEditor;
using UnityEngine;

namespace Discovery.Editor
{
    [CustomEditor(typeof(FpsQuestionManager))]
    public class FpsQuestionManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            var manager = target as FpsQuestionManager;

            GUILayout.Space(10);

            if (GUILayout.Button("Hide Question"))
            {
                manager?.HideQuestion();
            }
        }
    }
}