using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityLifeSystem : MonoBehaviour
{
    public Animator animator;
    public int life = 100;

    [ContextMenu("Freeze Ragdolls")]
    public void Freezeragdolls() {
        ManageRagdolls(true);
    }

    public void ManageRagdolls(bool b) {
        Rigidbody[] rigids = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody i in rigids) {
            i.isKinematic = b;
        }
    }

    public void AddDamage(int i) {
        life += i;

        if (life < 0) {

            animator.enabled = false;

            ManageRagdolls(false);

            Destroy(gameObject, 5f);
        }
    }
}
