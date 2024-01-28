using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    public static void LoadSceneReplace(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        LoadedScenes.Clear();
        LoadedScenes.Push(SceneManager.GetActiveScene());
    }

    public static void UnloadLastScene()
    {
        SceneManager.UnloadSceneAsync(LoadedScenes.Pop());
        SceneManager.SetActiveScene(LoadedScenes.Last());
    }

    public static void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(sceneName));
    }
    
}
