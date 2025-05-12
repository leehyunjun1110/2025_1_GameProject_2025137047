using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour // 각 과일 오브젝트에 부착되는 스크립트
{
    //과일 타입 (0: 사과, 1 : 블루배리, 2 : 코코넛 ......) int 로 만든다.
    public int fruitType;

    //과일이 이미 합쳐졌는지 확인하는 플레그
    public bool hasMerged = false;

    private FruitGame gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<FruitGame>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMerged)
            return;

        Fruit otherFruit  = collision.gameObject.GetComponent<Fruit>();
        if (otherFruit != null && !otherFruit.hasMerged && otherFruit.fruitType == fruitType)
        {
            hasMerged = true;
            otherFruit.hasMerged = true;

            Vector3 mergePosition = (transform.position + otherFruit.transform.position) / 2f;

            if(gameManager != null)
            {
                gameManager.MergeFruits(fruitType, mergePosition);
            }

            Destroy(otherFruit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
