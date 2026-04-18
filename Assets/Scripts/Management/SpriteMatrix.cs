using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class SpriteMatrix
{
    public string Name { get { return FloorSprite.name; } }

    public Sprite FloorSprite; 

    public Sprite RoofSprite;

    public Sprite[] WallSprites; 


}
