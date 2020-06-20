using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlRotation : MonoBehaviour
{
    [SerializeField]
    int rotateSpeed = 2;

    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * 360, Space.World);
    }
}
