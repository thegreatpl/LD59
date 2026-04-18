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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Attributes = GetComponent<Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (FireCooldown > 0)
        {
            FireCooldown--;
        }
    }



    public bool Fire()
    {
        if (FireCooldown > 0)
            return false; 

        Ray ray = new Ray(transform.position, transform.forward);
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
}
