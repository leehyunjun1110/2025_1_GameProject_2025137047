using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int Health = 100;

    [SerializeField]
    private float Timer = 1.0f;

    [SerializeField]
    private int AttackPoint = 50;
    private enum FSM
    {
        Idle,
        Walk,
        Attack
    }

    private FSM m_FSM;
    // ���� �������� ������Ʈ �Ǳ� �� �ѹ� ���� �ȴ�.
    void Start()
    {
        Health = 100;
        m_FSM = FSM.Idle;
    }

    // ���� �������� �� ������ ���� ȣ��ȴ�.
    void Update()
    {
        switch (m_FSM)
        {
            case FSM.Idle:
                if (m_FSM == FSM.Idle)
                {
                    m_FSM = FSM.Attack;
                    Debug.Log("Attack ���º���");
                }
                break;
            case FSM.Attack:
                if (m_FSM == FSM.Attack)
                {
                    m_FSM = FSM.Walk;
                    Debug.Log("Walk ���º���");
                }
                break;
            case FSM.Walk:
                if (m_FSM == FSM.Walk)
                {
                    m_FSM = FSM.Idle;
                    Debug.Log("Idle ���º���");
                }
                break;
            default:
                break;
        }

        CharacterHealthUp();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CharacterHit(AttackPoint);
        }
        CheckDeath();
    }

    void CharacterHealthUp()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Timer = 1.0f;
            Health += 10;
        }
    }
    public void CharacterHit(int Damage)
    {
        Health -= Damage;
    }

    void CheckDeath()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
