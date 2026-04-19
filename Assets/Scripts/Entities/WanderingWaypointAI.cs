using System.Linq;
using UnityEngine;

public class WanderingWaypointAI : BaseAI
{
    public WaypointScript CurrentWaypoint;

    public GameObject Target;

    public ProjectileFire Gun;

    public Animator Animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BaseStart();
        Gun = GetComponent<ProjectileFire>();
        Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null && CanSee(Target))
        {
            LookTowards(Target.transform.position);
            if (Gun.Fire())
                Animator.SetFloat("IsAttacking", 0);
            else
                Animator.SetFloat("IsAttacking", 1);

            Movement.Movement = Vector2.zero; //make sure the enemy doesn't move. 

        }
        else
        {
            Target = (from t in GameManager.Instance.EntityController.GetEnemyEntities(Attributes.Faction)
                      where Vector3.Distance(transform.position, t.gameObject.transform.position) < Attributes.MaxSightDistance
                      && CanSee(t.gameObject)
                      orderby Vector3.Distance(transform.position, t.gameObject.transform.position) ascending
                      select t).FirstOrDefault()?.gameObject;
            Animator.SetFloat("IsAttacking", 1);

            if (Target == null)
            {
                if (CurrentWaypoint != null && Vector3.Distance(transform.position, CurrentWaypoint.transform.position) > 1)
                {
                    MoveTowardsLocation(CurrentWaypoint.transform.position);
                }
                else if (CurrentWaypoint != null)
                {
                    CurrentWaypoint = CurrentWaypoint.Neighbours.RandomElement(); 
                }
                else
                {
                    var potentials = GameManager.Instance.CurrentMap.Waypoints.Where(x => AnythingInTheWay(x.transform.position)).ToList();
                    CurrentWaypoint = potentials.RandomElement();
                }
            }

        }
    }
}
