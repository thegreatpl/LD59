using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileFire : MonoBehaviour
{

    public GameObject BulletPrefab;

    public Transform FirePos;


    public float BulletTime = 10f;


    public float BulletSpeed = 50f;


    InputAction FireB; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FireB = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (FireB.WasPressedThisFrame())
            Fire(); 
    }



    public void Fire()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Vector3 target; 
        
        if (Physics.Raycast(ray, out hit))
            target = hit.point;
        else 
            target = ray.GetPoint(1000);

        CreateProjectile(target);
    }

    void CreateProjectile(Vector3 target)
    {
        var bulletobj = Instantiate(BulletPrefab, FirePos.position, BulletPrefab.transform.rotation); 
        Destroy(bulletobj, BulletTime);
        bulletobj.GetComponent<Bullet>().Parent = gameObject; 
        bulletobj.GetComponent<Rigidbody>().AddForce(
            (target - bulletobj.transform.position).normalized * BulletSpeed, ForceMode.Impulse);

    }
}
