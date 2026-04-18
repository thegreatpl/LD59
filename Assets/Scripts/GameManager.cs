using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public MapSpriteMatrix MapSpriteMatrix;

    public EntityController EntityController;


    public MapScript CurrentMap; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
            return; 
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        EntityController = GetComponent<EntityController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Camera GetCurrentCamera()
    {
        return Camera.main;
    }



    public void LoadLevel(string levelname, string startpos)
    {
        StartCoroutine(LoadLevelCo(levelname, startpos)); 
    }


    IEnumerator LoadLevelCo(string levelname, string startpos)
    {
        SceneManager.LoadScene(levelname, LoadSceneMode.Single); 
        yield return null;
        CurrentMap = FindAnyObjectByType<MapScript>(FindObjectsInactive.Include);
        yield return null;
        //set player location here. 
    }
}
