using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerController playerMovement;
    private float cooldownTimer = Mathf.Infinity;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
}
