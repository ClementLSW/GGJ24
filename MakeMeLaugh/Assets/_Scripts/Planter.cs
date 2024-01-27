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

    public bool isPlanting = false;
    public Vector3Int plantPos = Vector3Int.zero;
    public int plantTargetHeight = 0;
    public int plantCurrentHeight = 0;
    public float growth_t = 0;
    public float growthDelay = 0.1f;

    private void Awake()
    {
        //tilemap = GetComponent<Tilemap>();
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
                    plantTargetHeight = 0;
                    growth_t = 0;
                }
                growth_t = growthDelay;
            }

            growth_t -= Time.deltaTime;
        }
    }
}