using UnityEngine;
using UnityEngine.Tilemaps;

public class MapScript : MonoBehaviour
{
    //local copy of the GameManager. 
    public GameManager GameManager;

    public Tilemap Tilemap;

    public GameObject MapObjects; 

    public GameObject FloorPrefab;

    public GameObject WallXPrefab; 

    public GameObject WallZPrefab;

    public GameObject CeilingPrefab; 

    public int WallHeight = 2; 

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = GameManager.Instance;

        Tilemap.GetComponent<TilemapRenderer>().enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public TileBase GetTile(Vector3Int position)
    {
        return Tilemap?.GetTile(position);
    }

    public Sprite GetRoofSprite(Sprite floorSprite)
    {
        return GameManager.MapSpriteMatrix.GetSpriteMatrix(floorSprite.name)?.RoofSprite; 
    }

    public Sprite GetAppropriateWallSprite(Sprite floorSprite, int height)
    {
        var matrix = GameManager.MapSpriteMatrix.GetSpriteMatrix(floorSprite.name);
        if (matrix == null || matrix.WallSprites.Length <= height)
            return null;
        return matrix.WallSprites[height];  
    }
}
