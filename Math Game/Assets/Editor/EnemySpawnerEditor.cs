using MathGame.Minigames.FirstPersonShooter.EnemyLogic;
using UnityEditor;
using UnityEngine;

namespace MathGame.Editor
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var enemySpawner = target as EnemySpawner;

            GUILayout.Space(20);
            
            if (GUILayout.Button("Spawn Enemy"))
            {
                enemySpawner?.Spawn();
            }
        }
    }
}