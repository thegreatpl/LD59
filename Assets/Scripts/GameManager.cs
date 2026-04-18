using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public MapSpriteMatrix MapSpriteMatrix; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
            return; 
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
