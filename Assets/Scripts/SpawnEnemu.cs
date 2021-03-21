using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemu : MonoBehaviour
{
    public Transform enemu;
    public int[] countWave;
    public float timeBeetwenWave = 6f; //Задержка между волнами

    public float frequency = 2f;

    private int currentWave = 0;
    private float countTime = 3f;

   

    IEnumerator Spawn()
    {
        if (currentWave < countWave.Length) { 
        int count = countWave[currentWave];
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemu,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(frequency);
        }
        currentWave++; }
    }


    private void Update()
    {
        if (currentWave >= countWave.Length){return;}

        if (countTime >= timeBeetwenWave)
        {
           
            countTime = 0;
            StartCoroutine(Spawn());
        }
        countTime+=Time.deltaTime;
    }
}
