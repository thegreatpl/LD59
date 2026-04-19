using System.Net;
using UnityEngine;

public class MedkitPickup : MonoBehaviour
{

    public float Health; 

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
        var attri = other.gameObject.GetComponent<Attributes>();
        if (attri != null)
        {
            if (attri.CurrentHp == attri.MaxHP)
                return; 

            attri.CurrentHp += Health; 
            if (attri.CurrentHp > attri.MaxHP)
            {
                attri.CurrentHp = attri.MaxHP;
            }
            Destroy(gameObject);
        }
    }
}
