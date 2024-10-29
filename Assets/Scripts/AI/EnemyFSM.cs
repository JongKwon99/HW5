using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBase;
    public GameObject enemyBase;

    public EnemyState currentState;

    public enum EnemyState
    {
        GoToEnemyBase,
        AttackPlayerBase,
        ChasePlayer,
        AttackPlayer
    }

    private void Update()
    {
        if (currentState == EnemyState.GoToEnemyBase) { GoToEnemyBase(); }
        else if (currentState == EnemyState.AttackPlayerBase) { AttackPlayerBase(); }
        else if (currentState == EnemyState.ChasePlayer) { ChasePlayer(); }
        else { AttackPlayer(); }
    }

    void GoToEnemyBase()
    {

    }

    void AttackPlayerBase()
    {

    }

    void ChasePlayer()
    {

    }

    void AttackPlayer()
    {

    }
}
