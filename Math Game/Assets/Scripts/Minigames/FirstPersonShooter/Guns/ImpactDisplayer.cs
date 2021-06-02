using System;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public class ImpactDisplayer : MonoBehaviour
    {
        [SerializeField] private Gun gun;
        [SerializeField] private GameObject impactEffect;

        private void OnEnable()
        {
            gun.Shot += ShowEffect;
        }

        private void OnDisable()
        {
            gun.Shot -= ShowEffect;
        }

        private void ShowEffect(Vector3 position, Vector3 normal)
        {
            var desiredRotation = Quaternion.LookRotation(normal);
            Instantiate(impactEffect, position, desiredRotation);
        }


    }
}