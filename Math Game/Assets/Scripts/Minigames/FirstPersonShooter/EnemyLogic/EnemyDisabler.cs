using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.EnemyLogic
{
    public class EnemyDisabler : MonoBehaviour, IEnableable
    {
        [SerializeField] private EnemySet set;

        public void Enable()
        {
            set.ForEach(e =>
            {
                e.Enable();
            });
        }

        public void Disable()
        {
            set.ForEach(e =>
            {
                e.Disable();
            });
        }
    }
}