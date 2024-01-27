using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private bool Debug = true;

    public int BootLevel;
    public int FertilizerLevel;
    public int SeedLevel;

    public int kicks;
    public int highest;
    public int gold;

    public UIManager ui;

    private void Awake()
    {
        if (!Debug)
        {
            kicks= 0;
            highest= 0;
            gold= 0;

            BootLevel = 0;
            FertilizerLevel = 0;
            SeedLevel = 0;
        }
        else
        {
            kicks = 0;
            highest = 0;
            gold = 1000000;

            BootLevel = 0;
            FertilizerLevel = 0;
            SeedLevel = 0;
        }

        ui.UpdateUI();
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
