using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : BaseMapObject
{
    public MapScript map; 

    public List<WaypointScript> Neighbours = new List<WaypointScript>(); 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CalculateNeighbours();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void RegisterMapObject(MapScript mapScript)
    {
        mapScript.Waypoints.Add(this);
        map = mapScript; 
    }


    public void CalculateNeighbours()
    {
        Neighbours.Clear();
        foreach(var waypoint in map.Waypoints)
        {
            if (waypoint == this)
                continue; 

            RaycastHit hit;
            if (!Physics.Linecast(transform.position, waypoint.transform.position, out  hit, 1 << 9))
            {
                Neighbours.Add(waypoint);
            }
        }
    }
}
