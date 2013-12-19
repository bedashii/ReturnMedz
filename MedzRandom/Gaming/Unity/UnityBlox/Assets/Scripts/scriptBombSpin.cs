using UnityEngine;
using System.Collections;

public class scriptBombSpin : MonoBehaviour
{
    public int RotationRate = 10;

    void Update()
    {
        transform.Rotate(-RotationRate, 0, 0);
    }
}
