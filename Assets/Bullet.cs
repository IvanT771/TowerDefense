using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;

    private Transform target=null;
    private int forceDanage = 1;
    public float speed = 10f;

    public void InitializeBullet(Transform _target,int _forceDamage)
    {
        target = _target;
        forceDanage=_forceDamage;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed*Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame);
    }

    private void HitTarget()
    {
        GameObject ef = Instantiate(impactEffect,transform.position,Quaternion.identity); 
        Destroy(ef,3f);

        target.GetComponent<Enemu>().Damage(forceDanage);
        Destroy(gameObject);
    }
}
