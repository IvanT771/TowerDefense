using UnityEngine;

public class PointsMove : MonoBehaviour
{
    public static Transform[] pointsMov;
    private void Awake()
    {
        pointsMov = new Transform[transform.childCount];

        for (int i = 0; i < pointsMov.Length; i++)
        {
            pointsMov[i] = transform.GetChild(i);
        }
    }
}
