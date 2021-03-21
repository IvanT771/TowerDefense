using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDef : MonoBehaviour
{
   // public Transform ball;
  //  public Transform shootPoint;

    private Transform target;
    public float range = 15f;

    public int forceDamag = 35;

    public float timeRange = 2f;
    private float countTime = 0;

    private void Start()
    {
        InvokeRepeating("FindEnemu",0,0.5f);
    }
    void FindEnemu()
    {
        
        GameObject[] enemus = GameObject.FindGameObjectsWithTag("Enemu");
        Transform enemu = null;
        float distant = Mathf.Infinity;

        foreach (var item in enemus)
        {
            float dis = Vector3.Distance(transform.position, item.transform.position);
            if (distant > dis)
            {
                
                enemu = item.transform;
                distant = dis;
            }
        }

        if(enemu != null)
        {
            target = enemu;
        }
    }

    private void Update()
    {
        if (target == null) { return;}

        countTime+=Time.deltaTime;
        if(Vector3.Distance(transform.position, target.position) <= range && countTime >= timeRange)
        {
            Shoot();
            countTime = 0;
        }
    }

    private void Shoot()
    {
        Debug.Log("SHOOT!");
        if (target.CompareTag("Enemu"))
        {
            var en = target.GetComponent<Enemu>();
            if(en != null)
            {
                en.Damage(forceDamag);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
}
