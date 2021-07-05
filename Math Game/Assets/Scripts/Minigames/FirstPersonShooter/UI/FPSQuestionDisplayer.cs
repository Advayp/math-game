using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.UI
{
    public class FPSQuestionDisplayer : QuestionDisplayer
    {
        [SerializeField] private FpsAnswerManager answerManager;
        
        
        public override void Initialize(Question desiredQuestion)
        {
            base.Initialize(desiredQuestion);
            answerManager.Initialize(desiredQuestion.correctAnswer);
        }
    }
}