using TMPro;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    [RequireComponent(typeof(TMP_Text))]
    public class DisplayAmmo : MonoBehaviour, IAmmoDisplayer
    {
        private TMP_Text _label;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        public void UpdateText(int ammoCount)
        {
            _label.SetText(ammoCount.ToString());
        }
    }
}
