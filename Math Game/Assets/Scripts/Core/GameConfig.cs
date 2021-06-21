using UnityEngine;

namespace Discovery
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        public const string MouseSenseString = nameof(mouseSensitivity);
        public const string FovString = nameof(fov);
        public const string ShowEffectsString = nameof(showEffects);
        public const string ChangeAnswerColorString = nameof(changeAnswerColor);
        public const string ShowConstantColorChangeString = nameof(showConstantColorChange);
        public const string ShowAchievementString = nameof(showAchievementsOnScreen);
        
        [Range(100, 250), Header("FPS"), Space]
        public float mouseSensitivity;
        [Range(30, 100)]
        public float fov;
        public bool showEffects;
        
        [Header("Rhythm"), Space]
        public bool changeAnswerColor;
        public bool showConstantColorChange;

        [Header("Question Set"), Space]
        public bool showAchievementsOnScreen;

    }
}