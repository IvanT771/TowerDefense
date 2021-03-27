using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPull : MonoBehaviour
{
    public ParticleSystem pullEffect;
    private void OnMouseDown()
    {
        pullEffect.Play();
        pullEffect.transform.parent = null;
        Destroy(pullEffect.gameObject, pullEffect.main.startLifetimeMultiplier);
        Destroy(gameObject);
        Debug.Log("Add coin");
    }
}
