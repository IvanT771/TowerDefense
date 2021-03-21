using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDef : MonoBehaviour
{
    public Transform ball;
    public Transform shootPoint;

    public Transform target;
    public float range = 15f;

    void FindEnemu()
    {
        var enemus = GameObject.FindGameObjectsWithTag("Enemu");
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
}
