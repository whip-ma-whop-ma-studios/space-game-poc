using UnityEngine;

public class MainMenu : SceneLoader
{
    [SerializeField]
    public string _sceneToLoad;

    public void StartGame()
    {
        LoadScene(_sceneToLoad);
    }
}
