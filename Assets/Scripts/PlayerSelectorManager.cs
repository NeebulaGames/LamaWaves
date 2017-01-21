using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectorManager : MonoBehaviour
{
    public GameObject playerSelector;
    public Image[] lamas;

    public Dictionary<int, int> associations;
    private int nextPlayer = 1;

    void Awake()
    {
        associations = new Dictionary<int, int>(4);
        associations[0] = 0;

        Sprite bw = Resources.Load<Sprite>("lama_bw");

        for (int i = 1; i < lamas.Length; ++i)
        {
            lamas[i].sprite = bw;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Start2") && !associations.ContainsKey(1))
        {
            associations[1] = nextPlayer;
            ActivatePlayer(nextPlayer);
            ++nextPlayer;
        }
        if (Input.GetButtonDown("Start3") && !associations.ContainsKey(2))
        {
            associations[2] = nextPlayer;
            ActivatePlayer(nextPlayer);
            ++nextPlayer;
        }
        if (Input.GetButtonDown("Start4") && !associations.ContainsKey(3))
        {
            associations[3] = nextPlayer;
            ActivatePlayer(nextPlayer);
            ++nextPlayer;
        }
    }

    void ActivatePlayer(int player)
    {
        Sprite image = Resources.Load<Sprite>("lama_" + player);
        lamas[player].sprite = image;
    }

    void OnEnable()
    {
        playerSelector.SetActive(true);
    }

    void OnDisable()
    {
        playerSelector.SetActive(false);
    }
}
