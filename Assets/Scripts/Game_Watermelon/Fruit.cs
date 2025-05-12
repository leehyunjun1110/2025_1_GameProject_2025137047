using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour // �� ���� ������Ʈ�� �����Ǵ� ��ũ��Ʈ
{
    //���� Ÿ�� (0: ���, 1 : ���踮, 2 : ���ڳ� ......) int �� �����.
    public int fruitType;

    //������ �̹� ���������� Ȯ���ϴ� �÷���
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
