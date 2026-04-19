using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Attributes))]
public class ProjectileFire : MonoBehaviour
{

    public GameObject BulletPrefab;

    public Transform FirePos;

    public Attributes Attributes;


    public float BulletTime = 10f;

    public float BulletDmg = 1f; 


    public float BulletSpeed = 50f;

    public int FireRate = 10;

    public int FireCooldown = 0;



    public bool HasGun = true; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Attributes = GetComponent<Attributes>();
        StartCoroutine(Cooldown()); 
    }

    // Update is called once per frame
    void Update()
    {
        

        //if (FireCooldown > 0)
        //{
        //    FireCooldown--;
        //}
    }


    public bool Fire()
    {
        return Fire(transform.forward); 
    }

    public bool Fire(Vector3 Foreward)
    {
        if (FireCooldown > 0 || !HasGun)
            return false; 

        Ray ray = new Ray(transform.position, Foreward);
        RaycastHit hit;
        Vector3 target; 
        
        if (Physics.Raycast(ray, out hit))
            target = hit.point;
        else 
            target = ray.GetPoint(1000);

        CreateProjectile(target);

        FireCooldown = FireRate; 
        return true;
    }

    void CreateProjectile(Vector3 target)
    {
        var bulletobj = Instantiate(BulletPrefab, FirePos.position, BulletPrefab.transform.rotation); 
        Destroy(bulletobj, BulletTime);
        var bull = bulletobj.GetComponent<Bullet>();
        bull.Parent = gameObject;
        bull.Damage = BulletDmg; 
        bulletobj.GetComponent<Rigidbody>().AddForce(
            (target - bulletobj.transform.position).normalized * BulletSpeed, ForceMode.Impulse);

    }


    IEnumerator Cooldown()
    {
        var ratefiresecs = FireRate * 0.01f; 
        while(true)
        {
            if (FireCooldown > 0)
            {
                yield return new WaitForSeconds(ratefiresecs);
                FireCooldown = 0; 
            }

            yield return null;
        }
    }
}
