using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Finish : MonoBehaviour
{
    public Text text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("dfgdg");
            Debug.Log("dfgdg");
            text.gameObject.SetActive(true);
        }
    }

}
