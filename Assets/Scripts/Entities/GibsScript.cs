using UnityEngine;

public class GibsScript : MonoBehaviour
{

    public float MinForce = 10f;

    public float MaxForce = 20f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var Rigidbody = GetComponent<Rigidbody>();

        Rigidbody.AddForce(new Vector3(Random.Range(-MaxForce, MaxForce), 
            Random.Range(-MaxForce, MaxForce), 
            Random.Range(-MaxForce, MaxForce)));
        Rigidbody.AddTorque(1, 10, 10);


        Destroy(gameObject, 5f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
