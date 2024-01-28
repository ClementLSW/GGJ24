using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void QuitGame()
    { 
        Application.Quit();
    }

    public void PlayGame()
    { 
        SceneUtils.LoadSceneReplace("SampleScene");
    }

    public void ReturnToMenu()
    { 
        //Load Menu Scene
    }
    
}
