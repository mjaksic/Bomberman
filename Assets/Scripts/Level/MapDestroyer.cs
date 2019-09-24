using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour {

    public GameObject bombCount;
    public GameObject speedUp;
    public GameObject blank;
    public GameObject explosionPrefab;

    public Tilemap tilemap;
    public Tile wallTile_1;
    public Tile wallTile_2;
    public Tile wallTile_3;
    public Tile destructibleTile;

    private GameObject prefab;
    private GameObject[] arrayPowerup;
    private GameObject powerUp;

    private void Start()
    {
        arrayPowerup = new GameObject[] { bombCount, speedUp, blank };
    }

    void Update()
    {
        powerUp = arrayPowerup[Random.Range(0, arrayPowerup.Length)];
    }

    public void Explode(Vector2 worldPos)
	{
		Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);

		if (ExplodeCell(originCell + new Vector3Int(1, 0, 0)))
		{
			//ExplodeCell(originCell + new Vector3Int(2, 0, 0));
        }
		
		if (ExplodeCell(originCell + new Vector3Int(0, 1, 0)))
		{
            //ExplodeCell(originCell + new Vector3Int(0, 2, 0));
        }

        if (ExplodeCell(originCell + new Vector3Int(-1, 0, 0)))
		{
            //ExplodeCell(originCell + new Vector3Int(-2, 0, 0));
        }

        if (ExplodeCell(originCell + new Vector3Int(0, -1, 0)))
		{
            //ExplodeCell(originCell + new Vector3Int(0, -2, 0));
        }

    }

	bool ExplodeCell (Vector3Int cell)
	{
		Tile tile = tilemap.GetTile<Tile>(cell);

		if (tile == wallTile_1 || tile == wallTile_2 || tile == wallTile_3)
		{
			return false;
		}

		if (tile == destructibleTile)
		{
			tilemap.SetTile(cell, null);
            Instantiate(powerUp, tilemap.GetCellCenterWorld(cell), Quaternion.identity);
        }

		Vector3 pos = tilemap.GetCellCenterWorld(cell);
		prefab = Instantiate(explosionPrefab,pos, Quaternion.identity);
        Destroy(prefab, 0.35f);

		return true;
	}

}