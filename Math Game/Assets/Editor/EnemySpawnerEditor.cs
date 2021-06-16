using Discovery.Minigames.FirstPersonShooter.EnemyLogic;
using UnityEditor;
using UnityEngine;

namespace Discovery.Editor
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var enemySpawner = (EnemySpawner)target; 

            GUILayout.Space(20);

            if (GUILayout.Button("Spawn Enemy"))
            {
                enemySpawner.Spawn();
            }
        }
    }
}