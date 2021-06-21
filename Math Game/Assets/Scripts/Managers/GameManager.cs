using UnityEngine;

namespace Discovery.Managers
{

    public class GameManager : MonoBehaviour
    {

        public void Quit()
        {
            Debug.Log("Application has now quit");
            Application.Quit();
        }

    }
}