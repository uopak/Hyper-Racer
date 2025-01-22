using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMover : MonoBehaviour
{
    public float speed = 2f;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // 게임이 실행 중일 때만 가스 이동
        if (gameManager.IsGameRunning)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // 화면 아래로 사라지면 삭제
            if (transform.position.y < -6f)
            {
                Destroy(gameObject);
            }
        }
    }
}
