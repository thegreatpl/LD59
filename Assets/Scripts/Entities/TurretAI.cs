using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ProjectileFire))]
public class TurretAI : BaseAI
{
    public ProjectileFire Gun;

    public GameObject Target;

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

        }
        else
        {
            Target = (from t in GameManager.Instance.EntityController.GetEnemyEntities(Attributes.Faction)
                      where Vector3.Distance(transform.position, t.gameObject.transform.position) < Attributes.MaxSightDistance
                      && CanSee(t.gameObject) 
                      orderby Vector3.Distance(transform.position, t.gameObject.transform.position) ascending
                      select t).FirstOrDefault()?.gameObject;
            Animator.SetFloat("IsAttacking", 1);
        }
    }
}
