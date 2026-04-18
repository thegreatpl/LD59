using UnityEngine;
using UnityEngine.Rendering;


public class Attributes : MonoBehaviour
{

    public float MaxHP = 10;

    public float CurrentHp;

    public float Speed = 12f;

    public float JumpHeight = 3f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHp = MaxHP; 
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHp < 0)
        {
            //need to handle the player death better here. 
            Destroy(gameObject);
        }
    }


    public void TakeDamage(float damage)
    {
        CurrentHp -= damage;
    }
}
