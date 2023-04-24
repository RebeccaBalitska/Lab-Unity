using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField] float rotateSpead;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, rotateSpead * Time.deltaTime, 0);
    }
}
