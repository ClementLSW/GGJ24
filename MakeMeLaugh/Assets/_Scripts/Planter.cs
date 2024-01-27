using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Planter : MonoBehaviour
{
    public RuleTile plantTile;
    public Tilemap tilemap;
    public Vector3Int tilePosition;
    [SerializeField] GridLayout grid;
    public GameMaster gameMaster;

    public bool isPlanting = false;
    public Vector3Int plantPos = Vector3Int.zero;
    public int plantTargetHeight = 0;
    public int plantCurrentHeight = 0;
    public float growth_t = 0;
    public float growthDelay = 0.1f;

    public yeet potat;

    private void Awake()
    {
        potat = FindObjectOfType<yeet>();
    }

    public void Plant(Vector3 originTile)
    {
        tilePosition = grid.LocalToCell(originTile);

        plantPos = tilePosition;
        plantTargetHeight = tilePosition.x/4;

        isPlanting = true;
    }

    private void Update()
    {
        if (isPlanting)
        {
            if(growth_t < growthDelay)
            {
                tilemap.SetTile(tilePosition + (Vector3Int.up * (plantCurrentHeight)), plantTile);
                if(++plantCurrentHeight >= plantTargetHeight)
                {
                    isPlanting = false;
                    gameMaster.IncrementHi(plantCurrentHeight);
                    gameMaster.IncrementGold(plantCurrentHeight / 2); // TODO: Fix magic numbers
                    plantTargetHeight = 0;
                    growth_t = 0;
                    if(plantCurrentHeight < 384)
                    {
                        plantCurrentHeight = 0;
                    }

                    potat.ResetPotat();
                }
                growth_t = growthDelay;

                if(plantCurrentHeight >= 384)
                {
                    Debug.Log("Win");
                }
            }

            growth_t -= Time.deltaTime;
        }
    }
}