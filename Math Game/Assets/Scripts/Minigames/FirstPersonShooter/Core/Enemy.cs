using UnityEngine;
using UnityEngine.AI;

namespace Discovery.Minigames.FirstPersonShooter
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour, IEnableable
    {
        [SerializeField] private EnemySet set;

        [HideInInspector]
        public Transform target;

        private NavMeshAgent _agent;

        public bool IsEnabled { get; private set; } = true;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            set.Add(this);
        }

        private void Update()
        {
            if (IsEnabled == false) return;
            _agent.SetDestination(target.position);
        }

        private void OnDestroy()
        {
            set.Remove(this);
        }

        public void Enable()
        {
            _agent.isStopped = false;
            IsEnabled = true;
        }

        public void Disable()
        {
            _agent.isStopped = true;
            IsEnabled = false;
        }

    }
}