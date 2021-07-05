using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Discovery.UI
{
    public class ButtonLoadingScene : MonoBehaviour
    {
        public void LoadSceneUsingAsset(SceneAsset asset)
        {
            SceneManager.LoadScene(asset.name);
        }
    }
}