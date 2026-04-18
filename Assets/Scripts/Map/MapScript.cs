using UnityEngine;
using UnityEngine.Tilemaps;

public class MapScript : MonoBehaviour
{

    public Tilemap Tilemap;

    public GameObject FloorPrefab;

    public GameObject WallXPrefab; 

    public GameObject WallZPrefab;

    public GameObject CeilingPrefab; 

    public int WallHeight = 2; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public TileBase GetTile(Vector3Int position)
    {
        return Tilemap?.GetTile(position);
    }
}
