using System.Collections.Generic;
using UnityEngine;

namespace Discovery.Minigames.CardGame.CardLogic
{
    public class CardGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        private readonly List<GameObject> _recents = new List<GameObject>();
        
        public void DrawCard(Vector3 pos)
        {
            _recents.Add(Instantiate(prefab, pos, Quaternion.identity));
        }

        public void DestroyCard()
        {
            foreach (var recent in _recents)
            {
                Destroy(recent);
            }
        }
    }
}