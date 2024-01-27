using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int kicks;
    public int highest;
    public int gold;

    public UIManager ui;

    private void Awake()
    {
        kicks= 0;
        highest= 0;
        gold= 0;
    }

    public void ResetKicks()
    {
        kicks = 0;
        ui.UpdateUI();
    }

    public void IncrementKicks()
    {
        kicks++;
        ui.UpdateUI();
    }

    public void IncrementHi(int val)
    {
        if(val  > highest) highest = val;
        ui.UpdateUI();
    }

    public void IncrementGold(int val)
    {
        gold += val;
        ui.UpdateUI();
    }

    public void GameOver()
    {
        // Show Win State screen;
    }
}
