using UnityEngine;


[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(Attributes))]
public class BaseAI : MonoBehaviour
{

    public MovementController Movement;

    public Attributes Attributes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BaseStart();
    }

    protected void BaseStart()
    {
        Movement = GetComponent<MovementController>();
        Attributes = GetComponent<Attributes>();
        Attributes.OnDeath += () =>
        {
            for (int idx = 0; idx < Random.Range(2, 5); idx++)
            {
                Instantiate(GameManager.Instance.GibsPrefabs.RandomElement(), transform.position, Quaternion.identity); 
            }

            Destroy(gameObject);
        }; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void MoveTowardsLocation(Vector3 location)
    {
        transform.LookAt(location);
        Vector3 euler = transform.eulerAngles;
        euler.x = 0f; 
        euler.z = 0f;
        transform.rotation = Quaternion.Euler(euler);

        Movement.Movement = Vector2.up; 
    }


    protected void LookTowards(Vector3 location)
    {
        transform.LookAt(location);
        //Vector3 euler = transform.eulerAngles;
        //euler.x = 0f;
        //euler.z = 0f;
        //transform.rotation = Quaternion.Euler(euler);
    }

    protected bool CanSee(GameObject gameObject)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, gameObject.transform.position - transform.position, out hit, Attributes.MaxSightDistance);
        if (hit.transform?.gameObject == gameObject)
        {
            return true;
        }
        return false;
    }

    protected bool AnythingInTheWay(Vector3 location)
    {
        return !Physics.Linecast(transform.position, location); 
    }
}
