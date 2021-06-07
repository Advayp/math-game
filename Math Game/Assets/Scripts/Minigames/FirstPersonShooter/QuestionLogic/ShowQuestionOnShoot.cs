using System.Collections;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.QuestionLogic
{
    public class ShowQuestionOnShoot : ShowQuestion
    {
        [SerializeField] private Crate crate;

        private void OnEnable()
        {
            crate.Death += OnCrateDeath;
        }

        private void OnDisable()
        {
            crate.Death += OnCrateDeath;
        }

        private void OnCrateDeath()
        {
            Show();
        }

        protected override IEnumerator Hide()
        {
            yield return new WaitForSeconds(1f);
            questionUI.SetActive(false);
        }
    }
}