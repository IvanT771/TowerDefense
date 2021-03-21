using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemu : MonoBehaviour
{
    [Header("Atribute")]
    public float speed = 10f;
    public int hp = 100;
    public Image healthBar;

    public Transform body;
    private Transform target = null;
    private int currentIndexTarget = 0;


    public void Damage(int damag)
    {
        hp-=damag;
        healthBar.fillAmount = ((float)hp)/100f;
        if (hp < 70)
        {
            healthBar.color = new Color(255,138,0);
            if (hp < 40)
            {
                healthBar.color = Color.red;
            }
        }

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
            transform.Translate(dir.normalized * speed*Time.deltaTime);

            //look 
            Quaternion look = Quaternion.LookRotation(dir);
            Vector3 rot = look.eulerAngles;
            body.transform.eulerAngles = new Vector3(0,rot.y,0);

            if(Vector3.Distance(target.position,transform.position) < 0.25f)
            {
                SetTarget();
            }

        }


    }


}
