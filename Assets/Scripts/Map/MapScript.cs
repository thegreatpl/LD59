using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapScript : MonoBehaviour
{
    //local copy of the GameManager. 
    public GameManager GameManager;

    public Tilemap Tilemap;

    public Tilemap Utility; 

    public GameObject MapObjects; 

    public GameObject FloorPrefab;

    public GameObject WallXPrefab; 

    public GameObject WallZPrefab;

    public GameObject CeilingPrefab; 

    public int WallHeight = 2;

    public string Music = "depths_1"; 

    public List<WaypointScript> Waypoints = new List<WaypointScript>();

    public List<Startposition> Startpositions = new List<Startposition>();

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = GameManager.Instance;

        Tilemap.GetComponent<TilemapRenderer>().enabled = false;
        Utility.GetComponent<TilemapRenderer>().enabled=false;
        //InitialiseMap(); 
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

    public Vector3 PlayerSpawnLoc(string spawnlocation)
    {
        var normal = Startpositions.FirstOrDefault(x => x.Name == spawnlocation);
        if (normal != null)
        {
            return normal.transform.position;
        }
        else if (Startpositions.Count > 0)
        {
            return Startpositions[0].transform.position;
        }
        return transform.position; 
    }


    public void InitialiseMap()
    {
        var bounds = Utility.cellBounds;

        for (int xdx = bounds.xMin; xdx < bounds.xMax; xdx++)
        {
            for (int ydx = bounds.yMin; ydx < bounds.yMax; ydx++)
            {
                var vector = new Vector3Int(xdx, ydx);
                if (Utility.GetTile(vector)!= null)
                {
                    var sprite = Utility.GetSprite(vector);
                    var obj = GameManager.MapSpriteMatrix.GetPrefab(sprite.name);

                    if (obj != null)
                    {
                        var worldpos = Utility.CellToWorld(vector); 
                        Instantiate(obj, new Vector3(worldpos.x, worldpos.y + 1, worldpos.z), obj.transform.rotation);
                    }
                }
            }
        }
    }
}
