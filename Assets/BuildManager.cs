using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [Header("Towers")]
    public GameObject towerDef;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Build manager is presend this scene!!!");
        }
        instance = this;
    }

    public GameObject GetTowerDef()
    {
        return towerDef;
    }


}
