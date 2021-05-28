using UnityEngine;
using UnityEditor;
using MathGame.Core;

namespace MathGame.EditorTools
{
	[CustomEditor(typeof(AnswerManager))]
	public class AnswerManagerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			var answerManager = target as AnswerManager;
			GUILayout.BeginHorizontal();

			if (GUILayout.Button("Change All to Correct"))
			{
				answerManager.ChangeToCorrect();
			}
			if (GUILayout.Button("Change All to Wrong"))
			{
				answerManager.ChangeToWrong();
			}
			if (GUILayout.Button("Change All to Default"))
			{
				answerManager.ChangeToDefault();
			}

			GUILayout.EndHorizontal();
		}
	}
}