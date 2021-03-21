using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemu : MonoBehaviour
{
    public Transform enemu;
    public int[] countWave;
    public float timeBeetwenWave = 6f; //Задержка между волнами

    private int currentWave = 0;
    private float countTime = 3f;

   

    IEnumerator Spawn()
    {
        if (currentWave >= countWave.Length || enemu == null) {yield return null;}
        for (int i = 0; i < countWave[currentWave]; i++)
        {
            Instantiate(enemu,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        currentWave++;
    }

    private void Update()
    {
        if (countTime >= timeBeetwenWave)
        {
           
            countTime = 0;
            if (currentWave >= countWave.Length)
            {
                return;
            }
            StartCoroutine(Spawn());
        }
        countTime+=Time.deltaTime;
    }
}
