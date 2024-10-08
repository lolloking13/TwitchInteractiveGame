using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterCombactSystem : MonoBehaviour
{
    public Animator animator;

    [Header("Combat System")]
    public float combatTime = 3;
    public bool canCombat = true;
    public float combatRadious = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            if (!canCombat) return;

            StartCoroutine(CombatTime());

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, combatRadious);

            foreach (var hitCollider in hitColliders) {
                EntityLifeSystem els = hitCollider.transform.root.GetComponent<EntityLifeSystem>();
                if (els) els.AddDamage(-500);

                Rigidbody rigid = hitCollider.GetComponent<Rigidbody>();
                if (rigid) rigid.AddExplosionForce(1000f, transform.position, 50f);
            }

            animator.Play("Attack" + Random.Range(0, 4), 1);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1,1,1, 0.1f);
        Gizmos.DrawSphere(transform.position, combatRadious);
    }

    IEnumerator CombatTime() {
        canCombat = false;
        yield return new WaitForSeconds(combatTime);
        canCombat = true;
    }
}
