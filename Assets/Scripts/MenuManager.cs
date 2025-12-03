using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scene to Load")]
    public string sceneToLoad; // Assign the scene name in the inspector

    // Call this function from the button OnClick()
    public void PlayGame()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No scene assigned to MenuManager!");
        }
    }
}