using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetactPlayer : MonoBehaviour
{
    public float detactRange;
    public LayerMask playerLayer;
    private bool playerDetacted;
    private EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDetacted = Physics2D.OverlapCircle(transform.position, detactRange, playerLayer);

        if (playerDetacted == true)
        {
            enemyMovement.canChasePlayer = true;
        }
        else
        {
            enemyMovement.canChasePlayer = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detactRange);
    }
}
