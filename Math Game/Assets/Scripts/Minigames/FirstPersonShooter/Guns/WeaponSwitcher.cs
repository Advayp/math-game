using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject[] guns;
        [SerializeField] private KeyCode[] gunKeys;
        

        private void Start()
        {
            var hasSetActive = false;
            
            foreach (var gun in guns)
            {
                if (hasSetActive)
                {
                    gun.SetActive(false);
                    continue;
                }
                gun.SetActive(true);
                hasSetActive = true;
            }
        }

        private void Update()
        {
            if (FpsQuestionManager.IsQuestionDisplaying) return;
            
            for (var i = 0; i < gunKeys.Length; i++)
            {
                if (!Input.GetKey(gunKeys[i])) continue;
                for (var j = 0; j < guns.Length; j++)
                {
                    if (j == i)
                    {
                        guns[j].SetActive(true);
                        continue;
                    }
                    guns[j].SetActive(false);
                }
            }
        }
    }
}