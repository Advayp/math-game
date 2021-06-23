using System;
using Discovery.Display;

namespace Discovery.Managers
{
    [Serializable]
    public struct ConfigurableAnswer : IResetable
    {
        public AnswerDisplayer displayer;
        public AnswerChecker answerChecker;

        public void InitializeDisplayer(Answer answer)
        {
            displayer.Initialize(answer);
        }

        public void InitializeAnswerChecker(Answer answer)
        {
            answerChecker.answerToCheck = answer;
        }

        public void Reset()
        {
           answerChecker.Reset(); 
        }
    }
}