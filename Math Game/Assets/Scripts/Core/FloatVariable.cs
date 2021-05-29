using UnityEngine;
using UnityEngine.Serialization;

namespace MathGame.Core
{
	[CreateAssetMenu]
	public class FloatVariable : ScriptableObject
	{
		[FormerlySerializedAs("Value")]
		public int value;
	}
}