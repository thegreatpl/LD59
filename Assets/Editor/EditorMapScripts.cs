using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EditorMapScripts : MonoBehaviour
{
    [MenuItem("Level/CreateNew")]
    static void CreateNewLevel()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        scene.name = "NewLevel";

        var map = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/LevelEditing/Map.prefab"); 
        var localmap = PrefabUtility.InstantiatePrefab(map) as GameObject;
        PrefabUtility.UnpackPrefabInstance(localmap, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);

        var gameManager = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");
        var gm = PrefabUtility.InstantiatePrefab(gameManager) as GameObject;
        localmap.GetComponent<MapScript>().GameManager = gm.GetComponent<GameManager>(); 


    }


    [MenuItem("Level/GenerateWalls")]
    static void GenerateWalls()
    {
        var editorMap = SceneAsset.FindAnyObjectByType<MapScript>();

        var bounds = editorMap.Tilemap.cellBounds;

        //delete the old stuff. 
        for (int i = editorMap.MapObjects.transform.childCount; i > 0; --i)
            DestroyImmediate(editorMap.MapObjects.transform.GetChild(0).gameObject);

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
        floor.transform.parent = mapScript.MapObjects.transform; 
        
        var roof = PrefabUtility.InstantiatePrefab(mapScript.FloorPrefab) as GameObject;
        roof.transform.position = new Vector3(worldPos.x, worldPos.y + (tileSize.z * mapScript.WallHeight), worldPos.z);
        roof.GetComponent<SpriteRenderer>().sprite = mapScript.GetRoofSprite(floorSprite);
        roof.transform.parent = mapScript.MapObjects.transform;

        if (mapScript.GetTile(new Vector3Int(location.x + 1, location.y)) == null)
        {
            for (int idx = 0; idx < mapScript.WallHeight; idx++)
            {
                var wall = PrefabUtility.InstantiatePrefab(mapScript.WallXPrefab) as GameObject;
                wall.transform.position = new Vector3(worldPos.x + tileSize.x / 2, worldPos.y + (tileSize.z /2) + (tileSize.z * idx), worldPos.z);
                wall.GetComponent<SpriteRenderer>().sprite = mapScript.GetAppropriateWallSprite(floorSprite, idx); 
                wall.transform.parent = mapScript.MapObjects.transform;
            }
        }


        if (mapScript.GetTile(new Vector3Int(location.x - 1, location.y)) == null)
        {
            for (int idx = 0; idx < mapScript.WallHeight; idx++)
            {
                var wall = PrefabUtility.InstantiatePrefab(mapScript.WallXPrefab) as GameObject;
                wall.transform.position = new Vector3(worldPos.x - tileSize.x / 2, worldPos.y + (tileSize.z / 2) + +(tileSize.z * idx), worldPos.z);
                wall.GetComponent<SpriteRenderer>().sprite = mapScript.GetAppropriateWallSprite(floorSprite, idx);
                wall.transform.parent = mapScript.MapObjects.transform;
            }
        }

        if (mapScript.GetTile(new Vector3Int(location.x, location.y + 1)) == null)
        {
            for (int idx = 0; idx < mapScript.WallHeight; idx++)
            {
                var wall = PrefabUtility.InstantiatePrefab(mapScript.WallZPrefab) as GameObject;
                wall.transform.position = new Vector3(worldPos.x, worldPos.y + (tileSize.z / 2) + +(tileSize.z * idx), worldPos.z +tileSize.y / 2);
                wall.GetComponent<SpriteRenderer>().sprite = mapScript.GetAppropriateWallSprite(floorSprite, idx);
                wall.transform.parent = mapScript.MapObjects.transform;
            }
        }

        if (mapScript.GetTile(new Vector3Int(location.x, location.y - 1)) == null)
        {
            for (int idx = 0; idx < mapScript.WallHeight; idx++)
            {
                var wall = PrefabUtility.InstantiatePrefab(mapScript.WallZPrefab) as GameObject;
                wall.transform.position = new Vector3(worldPos.x, worldPos.y + (tileSize.z / 2) + +(tileSize.z * idx), worldPos.z - tileSize.y / 2);
                wall.GetComponent<SpriteRenderer>().sprite = mapScript.GetAppropriateWallSprite(floorSprite, idx);
                wall.transform.parent = mapScript.MapObjects.transform;
            }
        }
    }



    static void SetFogSetting()
    {
        //insert the fog stuff here if need be. 
    }

}
