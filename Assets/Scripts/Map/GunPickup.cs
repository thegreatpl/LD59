using UnityEngine;

public class GunPickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var fire = other.gameObject.GetComponent<ProjectileFire>();
            fire.HasGun = true; 
        }
    }
}
