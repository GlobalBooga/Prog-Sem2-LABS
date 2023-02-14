using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;

    private const string duel_close = "NPC_Duel_Close";
    private const string duel_mid = "NPC_Duel_Mid";
    private const string duel_far = "NPC_Duel_Long";
    private const string patrol = "NPC_Patrolling";


    private void Start()
    {
        //countDown = GameObject.Find("CountDown").GetComponent<TextMeshProUGUI>();
    }

    public void DuelEasy()
    {
        if (animator) animator.Play(duel_close);
        Debug.Log("Challenge accepted");
    }

    public void DuelMedium()
    {
        if (animator) animator.Play(duel_mid);

    }

    public void DuelFar()
    {
        if (animator) animator.Play(duel_far);

    }


    public void EndMatch()
    {
        if (animator) animator.Play(patrol);

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
