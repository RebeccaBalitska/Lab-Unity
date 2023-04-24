using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private float positionX;
    private float positionZ;

    [SerializeField] private float moveSpeed = 5;
    private CharacterController controller;

    private Vector3 move;
    private int coinsCount;
    [SerializeField] private Text coinsText;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {

        positionX = Input.GetAxis("Horizontal");
        positionZ = Input.GetAxis("Vertical");

        move = transform.right * positionX + transform.forward * positionZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        coinsText.text = $"Coin: {coinsCount}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CoinRotate coin))
        {
            coinsCount++;
            Destroy(other.gameObject);
        }
    }
}
