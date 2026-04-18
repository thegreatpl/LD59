using UnityEditor;
using UnityEngine;

public class EditorMapScripts : MonoBehaviour
{
    [MenuItem("Level/GenerateWalls")]
    static void GenerateWalls()
    {
        var editorMap = SceneAsset.FindAnyObjectByType<MapScript>();

        var bounds = editorMap.Tilemap.cellBounds; 

        for (int xdx = bounds.xMin; xdx < bounds.xMax; xdx++)
        {
            for (int ydx = bounds.yMin; ydx < bounds.yMax; ydx++)
            {
                var loc = new Vector3Int(xdx, ydx);

                var tile = editorMap.GetTile(loc);
                if (tile == null)
                    continue;

                GenerateWallsOnTiles(editorMap, loc); 

            }
        }
    }


    static void GenerateWallsOnTiles(MapScript mapScript, Vector3Int location)
    {
        var worldPos = mapScript.Tilemap.GetCellCenterWorld(location);
        var tileSize = mapScript.Tilemap.cellSize;
        var floorSprite = mapScript.Tilemap.GetSprite(location);

        var floor = PrefabUtility.InstantiatePrefab(mapScript.FloorPrefab) as GameObject;
        floor.transform.position = worldPos;
        floor.GetComponent<SpriteRenderer>().sprite = floorSprite; 
        
        var roof = PrefabUtility.InstantiatePrefab(mapScript.FloorPrefab) as GameObject;
        roof.transform.position = new Vector3(worldPos.x, worldPos.y + (tileSize.z * mapScript.WallHeight), worldPos.z);

        if (mapScript.GetTile(new Vector3Int(location.x + 1, location.y)) == null)
        {
            for (int idx = 0; idx < mapScript.WallHeight; idx++)
            {
                var wall = PrefabUtility.InstantiatePrefab(mapScript.WallXPrefab) as GameObject;
                wall.transform.position = new Vector3(worldPos.x + tileSize.x / 2, worldPos.y + (tileSize.z/2) + idx, worldPos.z);
            }
        }


        if (mapScript.GetTile(new Vector3Int(location.x - 1, location.y)) == null)
        {
            for (int idx = 0; idx < mapScript.WallHeight; idx++)
            {
                var wall = PrefabUtility.InstantiatePrefab(mapScript.WallXPrefab) as GameObject;
                wall.transform.position = new Vector3(worldPos.x - tileSize.x / 2, worldPos.y + (tileSize.z / 2) + idx, worldPos.z);
            }
        }

        if (mapScript.GetTile(new Vector3Int(location.x, location.y + 1)) == null)
        {
            for (int idx = 0; idx < mapScript.WallHeight; idx++)
            {
                var wall = PrefabUtility.InstantiatePrefab(mapScript.WallZPrefab) as GameObject;
                wall.transform.position = new Vector3(worldPos.x, worldPos.y + (tileSize.z / 2) + idx, worldPos.z +tileSize.y / 2);
            }
        }

        if (mapScript.GetTile(new Vector3Int(location.x, location.y - 1)) == null)
        {
            for (int idx = 0; idx < mapScript.WallHeight; idx++)
            {
                var wall = PrefabUtility.InstantiatePrefab(mapScript.WallZPrefab) as GameObject;
                wall.transform.position = new Vector3(worldPos.x, worldPos.y + (tileSize.z / 2) + idx, worldPos.z - tileSize.y / 2);
            }
        }
    }

}
