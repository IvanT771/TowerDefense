using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemu : MonoBehaviour
{
    [Header("Atribute")]
    public float speed = 10f;


    private Transform target = null;
    private int currentIndexTarget = 0;



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
