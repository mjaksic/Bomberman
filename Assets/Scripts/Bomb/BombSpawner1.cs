using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class BombSpawner1 : MonoBehaviour
{

    public Tilemap tilemap;
    public GameObject bombPrefab;
    public GameObject pivot;

    [SerializeField]
    private float cooldown;

    [SerializeField]
    private int bombCount;

    private int bombRemaining;
    private bool canBomb = true;

    private void Start()
    {
        bombRemaining = bombCount;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && canBomb == true)
        {
            Vector3 worldPos = pivot.transform.position;
            Vector3Int cell = tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
            StartCoroutine(SetCooldown());
        }
    }

    IEnumerator SetCooldown()
    {
        if (bombRemaining >= 1) { bombRemaining--; }

        if (bombRemaining == 0)
        {
            canBomb = false;
            yield return new WaitForSeconds(cooldown);
            canBomb = true;
            bombRemaining = bombCount;
        }
    }

    private void OnCollisionEnter2D(Collision2D powerUp)
    {
        if (powerUp.gameObject.tag == "bombCount") { bombCount++; Start(); }
    }
}
