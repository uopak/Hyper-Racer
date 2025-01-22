using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            float horizontal = 0f;

            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                if (mousePos.x < Screen.width / 2)
                    horizontal = -1f; // 왼쪽으로 이동
                else
                    horizontal = 1f; // 오른쪽으로 이동
            }

            Vector3 movement = new Vector3(horizontal * speed * Time.deltaTime, 0, speed * Time.deltaTime);
            transform.Translate(movement);
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gas"))
        {
            FindObjectOfType<GameManager>().AddGas(30);
            Destroy(other.gameObject);
        }
    }
}