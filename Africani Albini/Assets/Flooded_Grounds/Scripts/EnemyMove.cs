using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2;
    [SerializeField] Transform Target3;

    private Transform TargetPosition;

    [SerializeField] int CurrentTarget = 1;

    [SerializeField] int waitTime = 0;

    private bool Contact = false;

    private int lastTarget = 1;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        TargetPosition = Target1;
        MoveToTarget();
        lastTarget = CurrentTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemieTarget")) {
            if(Contact == false)
            {
                Contact = true;
                CurrentTarget = Random.Range(1, 4);

                if(CurrentTarget == lastTarget)
                {
                    TryAgain();
                }
                else
                {
                    StartCoroutine(Wait());
                }

                

                
            }
        }
    }

    private void TryAgain()
    {
            if(lastTarget==1)
        {
            CurrentTarget = lastTarget + 1;
        }
            else if(lastTarget>1)
        {
            CurrentTarget = lastTarget -1;
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        anim.SetInteger("State", 1);
        yield return new WaitForSeconds(waitTime);
        anim.SetInteger("State", 0);
        Contact = false;
        MoveToTarget();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveToTarget()
    {
        if(CurrentTarget==1)
        {
            TargetPosition = Target1;
        }
        if (CurrentTarget == 2)
        {
            TargetPosition = Target2;
        }
        if (CurrentTarget == 3)
        {
            TargetPosition = Target3;
        }
        GetComponent<NavMeshAgent>().destination = TargetPosition.position;

        lastTarget = CurrentTarget;

        Contact = false;
    }
}
