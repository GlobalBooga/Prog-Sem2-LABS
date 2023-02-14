using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public TextMeshProUGUI countDown;
    public List<NPC> npcs;
    public static PlayerController player;
    public static int matchesWon;
    public static int matchesLost;
    public static int winStreak;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public static void StartDuel(NPC opponent)
    {
        if (winStreak < 3) opponent.DuelEasy();
    }

    private IEnumerator CountDown()
    {
        if (!countDown) yield break;

        countDown.enabled = true;

        for (int i = 3; i < 0; i--)
        {
            countDown.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
        countDown.text = "Duel!";

        yield return new WaitForSeconds(1);
    }


    public static void MatchWon()
    {
        matchesWon++;
        winStreak++;
    }


    public static void MatchLost()
    {
        matchesLost++;
        winStreak = 0;
    }


    public static PlayerController GetPlayer()
    {
        return player;
    }
}
