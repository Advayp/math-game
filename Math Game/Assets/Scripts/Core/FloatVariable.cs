using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery
{
	[CreateAssetMenu]
	public class FloatVariable : ScriptableObject
	{
		[FormerlySerializedAs("Value")]
		public int value;
	}
}