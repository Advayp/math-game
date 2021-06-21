using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

namespace Discovery.Achievements
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ViewAchievement : MonoBehaviour
    {
        [SerializeField] private Achievements achievement;
        
        
        private TMP_Text _label;

        private void Awake()
        {
            achievement.Require(this);
            _label = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            var sb = new StringBuilder();
            
            foreach (var achievementText in achievement.texts.Take(5))
            {
                sb.Append(achievementText).Append("\n");
            }
            
            _label.SetText(sb.ToString());
        }

    }
}