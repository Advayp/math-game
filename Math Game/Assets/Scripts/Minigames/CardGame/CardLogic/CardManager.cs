using System.Linq;
using Discovery.Minigames.CardGame.QuestionLogic;
using UnityEngine;

namespace Discovery.Minigames.CardGame.CardLogic
{

    public class CardManager : MonoBehaviour
    {
        [SerializeField] private CardSet set;
        [SerializeField] private CardGenerator generator;
        [SerializeField] private float interval;
        [SerializeField] private DisplayAnswerBox answerBox;


        private float _lastTimeFlipped;

        public bool CanPressSpace => Time.time - _lastTimeFlipped >= interval && answerBox.IsQuestionActive == false;
        private bool CanFlip => Time.time - _lastTimeFlipped >= interval && Input.GetKeyDown(KeyCode.Space) && answerBox.IsQuestionActive == false;

        private void Awake()
        {
            set.Require(this);
            generator.Require(this);
        }

        private void Update()
        {
            if (!CanFlip) return;
            FlipCards();
        }

        private void FlipCards()
        {
            generator.DestroyCard();
            _lastTimeFlipped = Time.time;

            var items = set.Items.ToList();

            foreach (var item in items)
            {
                item.StartFlipping();
            }
        }
    }
}