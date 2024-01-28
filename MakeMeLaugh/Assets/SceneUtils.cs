using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtils : MonoBehaviour
{
    private static readonly Stack<Scene> LoadedScenes = new();
    
    public static void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        LoadedScenes.Push(SceneManager.GetActiveScene());
    }

    public static void UnloadLastScene()
    {
        SceneManager.UnloadSceneAsync(LoadedScenes.Pop());
        SceneManager.SetActiveScene(LoadedScenes.Last());
    }
    
}
