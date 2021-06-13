using System.Collections;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public abstract class ShowQuestion : MonoBehaviour
    {
        [SerializeField] protected GameObject questionUI;

        protected void Show()
        {
            questionUI.SetActive(true);
            StartCoroutine(Hide());
        }

        protected virtual IEnumerator Hide()
        {
            questionUI.SetActive(false);
            yield break;
        }
        
    }
}