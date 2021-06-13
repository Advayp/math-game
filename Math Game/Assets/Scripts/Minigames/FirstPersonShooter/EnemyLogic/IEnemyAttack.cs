using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.EnemyLogic
{
    public interface IEnemyAttack
    {
        bool DoesDamage { set; }
        Transform Target { get; set; }
    }
}