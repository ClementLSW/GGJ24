using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text kicks;
    public TMP_Text gold;
    public TMP_Text highest;

    public GameMaster gameMaster;

    private void Awake()
    {
        //gameMaster = GetComponent<GameMaster>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("Updating UI");
        kicks.text = $"Potats Yeeted: {gameMaster.kicks}";
        gold.text = $"SpudBucks: $ {gameMaster.gold}";
        highest.text = $"Tallest Spudnik: {gameMaster.highest} KM";
    }
}
