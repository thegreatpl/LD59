using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapSpriteMatrix : MonoBehaviour
{

    public List<SpriteMatrix> spriteMatrices = new List<SpriteMatrix>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public SpriteMatrix GetSpriteMatrix(string spriteName)
    {
        return spriteMatrices.FirstOrDefault(x => x.Name == spriteName);
    }
}
