using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.EnemyLogic
{
    public interface IEnemyAttack
    {
        bool DoesDamage { set; }
        Transform Target { get; set; }
    }
}