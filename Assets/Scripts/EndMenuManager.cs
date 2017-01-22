using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndMenuManager : MonoBehaviour
{
    public EndMenuView endView;

    private Vector3 originalPosition;

    void OnEnable()
    {
        endView.gameObject.SetActive(true);
        originalPosition = endView.transform.position;
    }

    void OnDisable()
    {
        endView.gameObject.SetActive(false);
        endView.transform.position = originalPosition;
    }

    public void SetInfo(Player[] players, int[] score, int[] misses, int[] hits)
    {
        int winner = 0;
        int max = score[0];

        for (int i = 0; i < players.Length; ++i)
        {
            if (max < score[i])
            {
                winner = i;
                max = score[i];
            }

            endView.SetScore(i, score[i]);
            endView.SetMisses(i, misses[i]);
            endView.SetHits(i, hits[i]);
        }

        for (int i = 0; i < players.Length; ++i)
        {
            endView.ShowScoreWall(i, winner == i, players[i].transform.position);
        }

        Vector3 localPosition = endView.transform.localPosition;
        endView.transform.localPosition = localPosition;
        endView.transform.DOLocalMoveY(0f, 3f);
    }
}
