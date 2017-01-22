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
        public Player[] playerList;

        public int[] scores = { 0, 0, 0, 0 };
		public int[] misses = { 0, 0, 0, 0 };
		public int[] hits = { 0, 0, 0, 0 };
        private int[] gauge = { 0, 0, 0, 0 };
        private GameplayManager mGameplayManager;
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
            scores = new [] { 0, 0, 0, 0 };
            gauge = new[] { 0, 0, 0, 0 };
			hits = new[] { 0, 0, 0, 0 };
			misses = new[] { 0, 0, 0, 0 };
            lamaContainer.transform.DOLocalMoveY(-15f, 0f);
        }

        void OnDisable()
        {
            lamaContainer.transform.DOLocalMoveY(-15f, 0f);
            foreach (var player in playerList)
            {
                player.ToggleAnimation(false);
            }

            foreach (Transform score in bottomUiView.scoreContainers)
                score.gameObject.SetActive(false);

            lamaContainer.SetActive(false);
        }

        public void InitPlayers(Dictionary<int, int> players)
        {
            float first = 0f;

            switch (players.Count)
            {
                case 2:
                    first = -2.5f;
                    break;
                case 3:
                    first = -4f;
                    break;
                case 4:
                    first = -6.5f;
                    break;
            }

            playerList = new Player[players.Count];

            lamaContainer.transform.DOKill();
            lamaContainer.transform.DOLocalMoveY(-3f, 5f).OnComplete(() =>
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

                Transform score = bottomUiView.scoreContainers[val.Value];
                score.gameObject.SetActive(true);
                score.transform.DOMoveX(position.x, 0f);
            }

            bottomUiView.ResetScore();
        }

        public void Score(int player, ScoreType type)
        {
            if (mGameplayManager.smashMode)
                type = ScoreType.Good;

            ShowLamaResult(player, type);

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

			if (type == ScoreType.Miss)
				misses[player]++;
			else
				hits[player]++;

            //Debug.Log("Player: " + player + " - Score: " + scores[player] + " - Gauge: " + gauge[player]);
        }

        public void ShowLamaResult(int lamaPlayer, ScoreType resultType)
        {
            lamaResultsControllers[lamaPlayer].ShowMessage(resultType);
        }

        public int PlayerCount()
        {
            return playerList.Length;
        }
    }
}