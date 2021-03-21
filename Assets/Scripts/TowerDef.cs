using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDef : MonoBehaviour
{
    public Transform ball;
    public Transform shootPoint;

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
        if(target != null) { return;}
        
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
        if( countTime >= timeRange)
        {
            if(Vector3.Distance(transform.position, target.position) <= range)
            { 
                Shoot();
            }else
            {
                target = null;
            }

            countTime = 0;
        }
    }

    private void Shoot()
    {
        if(target == null) { return;}
        var bal = Instantiate(ball,shootPoint.position,Quaternion.identity);
        bal.GetComponent<Bullet>().InitializeBullet(target,forceDamag);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
}
