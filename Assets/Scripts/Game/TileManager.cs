using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Transform player;
    public Transform tileParent;
    public int tileSize = 4;
    public int viewDistance = 4;

    private Dictionary<Vector2Int, GameObject> tiles = new Dictionary<Vector2Int, GameObject>();
    private Vector2Int playerTilePosition;

    void Start()
    {
        UpdateTiles();
    }

    void Update()
    {
        Vector2Int newPlayerTilePosition = new Vector2Int(
            Mathf.FloorToInt(player.position.x / tileSize),
            Mathf.FloorToInt(player.position.z / tileSize)
            );

        if (newPlayerTilePosition != playerTilePosition)
        {
            playerTilePosition = newPlayerTilePosition;
            UpdateTiles();
        }
    }

    void UpdateTiles()
    {
        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int z = -viewDistance; z <= viewDistance; z++)
            {
                Vector2Int tilePosition = new Vector2Int(playerTilePosition.x + x, playerTilePosition.y + z);

                if (!tiles.ContainsKey(tilePosition))
                {
                    Vector3 tileWorldPosition = new Vector3(tilePosition.x * tileSize, -1, tilePosition.y * tileSize);
                    GameObject tile = Instantiate(GetRandomTilePrefab(), tileWorldPosition, Quaternion.identity);
                    tile.transform.SetParent(tileParent);
                    tiles[tilePosition] = tile;
                }
            }
        }
        List<Vector2Int> tilesToRemove = new List<Vector2Int>();
        foreach (var tile in tiles)
        {
            Vector2Int tilePosition = tile.Key;
            if (Mathf.Abs(tilePosition.x - playerTilePosition.x) > viewDistance || Mathf.Abs(tilePosition.y - playerTilePosition.y) > viewDistance)
            {
                tilesToRemove.Add(tilePosition);
            }
        }

        foreach (var tilePosition in tilesToRemove)
        {
            Destroy(tiles[tilePosition]);
            tiles.Remove(tilePosition);
        }
    }

    GameObject GetRandomTilePrefab()
    {
        int index = Random.Range(0, tilePrefabs.Length);
        return tilePrefabs[index];
    }
}