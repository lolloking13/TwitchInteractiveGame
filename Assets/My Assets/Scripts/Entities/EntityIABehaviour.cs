using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityIABehaviour : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public EntityLifeSystem lifeSystem;
    public Animator animator;

    [Header("Combat System")]
    public float combatTime = 3;
    public bool canCombat = true;
    public float combatRadious = 2f;

    private void Update() {
        if (lifeSystem.life > 0){
            agent.SetDestination(target.position);

            if (Vector3.Distance(transform.position, target.position) > 1f) {
                animator.SetBool("Walking", true);
            }
            else {
                animator.SetBool("Walking", false);

                //combat
                {
                    if (!canCombat) return;

                    StartCoroutine(CombatTime());

                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, combatRadious);

                    foreach (var hitCollider in hitColliders) {
                        Debug.Log(hitCollider.transform.root.name);
                        MainCharacterLifeSystem els = hitCollider.transform.root.GetComponent<MainCharacterLifeSystem>();
                        if (els) els.ManageLife(-1);
                    }

                    animator.Play("Attack" + Random.Range(0, 4), 1);
                }
            }
        }
    }

    IEnumerator CombatTime() {
        canCombat = false;
        yield return new WaitForSeconds(combatTime);
        canCombat = true;
    }
}
