using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemu : MonoBehaviour
{
    [Header("Atribute")]
    public float speed = 10f;
    public int hp = 100;


    private Transform target = null;
    private int currentIndexTarget = 0;


    public void Damage(int damag)
    {
        hp-=damag;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
       SetTarget();
    }

    private void SetTarget()
    {
        if (currentIndexTarget >= PointsMove.pointsMov.Length)
        {
            Destroy(gameObject);
            return;
        }
            

        target = PointsMove.pointsMov[currentIndexTarget];
        currentIndexTarget++;
    }
    private void Update()
    {
        if(target != null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized*speed*Time.deltaTime);

            if(Vector3.Distance(target.position,transform.position) < 0.25f)
            {
                SetTarget();
            }

        }


    }


}
