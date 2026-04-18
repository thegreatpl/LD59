using UnityEngine;
using UnityEngine.Diagnostics;

public class Bullet : MonoBehaviour
{

    public GameObject Parent;

    public float Damage; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != Parent)
        {
            Destroy(gameObject);

            var attri = collision.gameObject.GetComponent<Attributes>();
            if (attri != null) 
            {
               attri.TakeDamage(Damage); 
            }
        }
    }
}
