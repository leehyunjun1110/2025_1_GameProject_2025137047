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
    // 최초 프레임이 업데이트 되기 전 한번 실행 된다.
    void Start()
    {
        Health = 100;
        m_FSM = FSM.Idle;
    }

    // 게임 진행중인 매 프레임 마다 호출된다.
    void Update()
    {
        switch (m_FSM)
        {
            case FSM.Idle:
                if (m_FSM == FSM.Idle)
                {
                    m_FSM = FSM.Attack;
                    Debug.Log("Attack 상태변경");
                }
                break;
            case FSM.Attack:
                if (m_FSM == FSM.Attack)
                {
                    m_FSM = FSM.Walk;
                    Debug.Log("Walk 상태변경");
                }
                break;
            case FSM.Walk:
                if (m_FSM == FSM.Walk)
                {
                    m_FSM = FSM.Idle;
                    Debug.Log("Idle 상태변경");
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
