using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace LamaWaves.Scripts
{
    public enum ScoreType
    {
        Miss,
        Bad,
        Ok,
        Good,
        Perfect
    }

    public class PlayerManager : MonoBehaviour
    {
        public BottomUiView bottomUiView;
        public GameObject lamaContainer;

        private int[] scores = { 0, 0, 0, 0 };
        private int[] gauge = { 0, 0, 0, 0 };
        private GameplayManager mGameplayManager;
        private Player[] playerList;
        public int gauge_bonus = 2;

        public LamaResultsController[] lamaResultsControllers = new LamaResultsController[4];

        void Start()
        {
            mGameplayManager = FindObjectOfType<GameplayManager>();
            //StartCoroutine(mGameplayManager.CountdownStartGame()); //just for test
        }

        void OnEnable()
        {
            lamaContainer.SetActive(true);
            lamaContainer.transform.DOLocalMoveY(-15f, 0f);
        }

        void OnDisable()
        {
            lamaContainer.transform.DOLocalMoveY(-15f, 0f);
            foreach (var player in playerList)
            {
                player.ToggleAnimation(false);
            }
            lamaContainer.SetActive(false);
        }

        public void InitPlayers(Dictionary<int, int> players)
        {
            float first = ((players.Count % 2) == 0 ? -2.5f : -4) * (players.Count - 1);
            playerList = new Player[players.Count];

            lamaContainer.transform.DOKill();
            lamaContainer.transform.DOLocalMoveY(-2f, 5f).OnComplete(() =>
            {
                foreach (var player in playerList)
                {
                    player.ToggleAnimation(true);
                }
            });

            foreach (KeyValuePair<int, int> val in players)
            {
                LamaResultsController controller = lamaResultsControllers[val.Value]; // TODO: place controller

                Player player = controller.GetComponent<Player>();
                playerList[val.Value] = player;
                Vector3 position = player.transform.localPosition;
                position.x = first + (4 * val.Value);
                player.transform.localPosition = position;
                player.playerNumber = val.Value;
                player.inputNumber = val.Key;
                player.gameObject.SetActive(true);
            }
        }

        public void Score(int player, ScoreType type)
        {
            ShowLamaResult(player, type);

            if (mGameplayManager.smashMode)
                type = ScoreType.Good;

            if (gauge[player] >= 1000)
            {
                if (type != 0)
                    scores[player] += 50 * (int)type * gauge_bonus;
                else
                    gauge[player] -= 100;
            }
            else
            {
                scores[player] += 50 * (int)type;
                gauge[player] += 20 * (int)type - 1;
            }

            gauge[player] = Mathf.Clamp(gauge[player], 0, 1000);

            bottomUiView.SetScoreText(player, scores[player]);
            bottomUiView.SetGauge(player, gauge[player]);

            //Debug.Log("Player: " + player + " - Score: " + scores[player] + " - Gauge: " + gauge[player]);
        }

        public void ShowLamaResult(int lamaPlayer, ScoreType resultType)
        {
            lamaResultsControllers[lamaPlayer].ShowMessage(resultType);
        }
    }
}