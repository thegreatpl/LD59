using UnityEngine;
using UnityEngine.Rendering;


public delegate void OnDeath(); 

public class Attributes : MonoBehaviour
{

    public float MaxHP = 10;

    public float CurrentHp;

    public float Speed = 12f;

    public float JumpHeight = 3f;


    public float MaxSightDistance = 50f;


    public string Faction;


    public OnDeath OnDeath;

    private bool init = false;


    public bool Immune = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHp = MaxHP; 
    }


    // Update is called once per frame
    void Update()
    {
        if (!init)
        {
            GameManager.Instance.EntityController.RegisterEntity(this);
            init = true;
        }


        if (CurrentHp < 0)
        {
            //need to handle the player death better here. 
            OnDeath?.Invoke(); 
        }

       
    }


    public void TakeDamage(float damage)
    { 
        if (!Immune) 
            CurrentHp -= damage;
    }
}
