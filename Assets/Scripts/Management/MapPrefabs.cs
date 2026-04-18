using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class MapPrefabs
{
    public string Name { get { return UtilitySprite.name; } } 

    public Sprite UtilitySprite;

    public GameObject Prefab; 
}

