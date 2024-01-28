using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    [field: Header("BGM")]
    [field: SerializeField] public EventReference music { get; private set; }

    public static FMODEvents instance {get; private set;}

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }
        instance = this;
    }
}
