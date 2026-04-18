using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [HideInInspector]
    public List<Attributes> Entities = new List<Attributes>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Entities.RemoveAll(x => x == null); 
    }

    public List<Attributes> GetEnemyEntities(string faction)
    {
        return Entities.Where(x => x.Faction != faction).ToList();  
    }

    public void RegisterEntity(Attributes entity)
    {
        Entities.Add(entity);
    }
}
