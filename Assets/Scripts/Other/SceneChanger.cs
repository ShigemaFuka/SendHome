using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private string _sceneName = default;

    private void ChangeScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void OnClick(string sceneName)
    {
        _sceneName = sceneName;
        ChangeScene();
    }
}