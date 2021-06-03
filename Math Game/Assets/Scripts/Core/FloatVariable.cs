using UnityEngine;
using UnityEngine.Serialization;

namespace MathGame
{
	[CreateAssetMenu]
	public class FloatVariable : ScriptableObject
	{
		[FormerlySerializedAs("Value")]
		public int value;
	}
}