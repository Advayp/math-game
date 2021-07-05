using TMPro;
using UnityEngine;

namespace Discovery.Minigames.CardGame
{
    public class AddToScore : MonoBehaviour, IResetable
    {
        [SerializeField] private TMP_Text playerOneScoreLabel;
        [SerializeField] private TMP_Text playerTwoScoreLabel;
        
        [SerializeField] private int amountToAdd;

        private int _currentPlayerOneScore;
        private int _currentPlayerTwoScore;

        public string WinningPlayer
        {
            get {
                if (_currentPlayerOneScore > _currentPlayerTwoScore)
                {
                    return "Player One Wins!";
                }
                return _currentPlayerOneScore < _currentPlayerTwoScore ? "Player Two Wins!" : "It was a tie!";
            }
        }

        private void Start()
        {
            _currentPlayerOneScore = 0;
            _currentPlayerTwoScore = 0;
        }

        private void UpdateText()
        {
            playerOneScoreLabel.SetText(_currentPlayerOneScore.ToString());
            playerTwoScoreLabel.SetText(_currentPlayerTwoScore.ToString());
        }
        
        public void AddScoreToPlayer()
        {
        
            if (DeterminePlayer.CurrentPlayer == PlayerType.One)
            {
                _currentPlayerOneScore += amountToAdd;
            }
            else
            {
                _currentPlayerTwoScore += amountToAdd;
            }
            
            UpdateText();
        }


        public void Reset()
        {
            _currentPlayerOneScore = 0;
            _currentPlayerTwoScore = 0;
            
            UpdateText();
        }
    }
}