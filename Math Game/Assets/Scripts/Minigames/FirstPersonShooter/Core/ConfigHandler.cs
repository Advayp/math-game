using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class ConfigHandler : MonoBehaviour
    {
        [SerializeField] private GameConfig config;

        [SerializeField, Header("Dependencies"), Space]
        private Camera mainCam;


        private void Awake()
        {
            config.Require(this);
            mainCam = mainCam ? mainCam : Camera.main;
        }

        private void Start()
        {
            InitializeCamera();
        }

        private void InitializeCamera()
        {
            mainCam.fieldOfView = config.fov;
        }

    }
}