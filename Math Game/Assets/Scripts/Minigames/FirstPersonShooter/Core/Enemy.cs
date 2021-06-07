﻿using UnityEngine;
using UnityEngine.AI;

namespace MathGame.Minigames.FirstPersonShooter
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour, IEnableable
    {
        [SerializeField] private EnemySet set;
        
        
        [HideInInspector]
        public Transform target;

        private NavMeshAgent _agent;
        private bool _isEnabled = true;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            set.Add(this);
        }

        private void Update()
        {
            if (_isEnabled == false) return;
            _agent.SetDestination(target.position);
        }

        private void OnDestroy()
        {
           set.Remove(this); 
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}