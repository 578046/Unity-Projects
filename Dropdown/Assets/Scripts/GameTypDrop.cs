using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class GameTypDrop : MonoBehaviour
{
    public Dropdown gameDrop;
    public gameType gameType;

    const string prefGametyp = "Gametype";

    void Awake()
    {
        gameDrop = GetComponent<Dropdown>();

        gameDrop.onValueChanged.AddListener(new UnityAction<int>(indexer =>
        {
            PlayerPrefs.SetInt(prefGametyp, gameDrop.value);
            PlayerPrefs.Save();
        }));
    }

    // Start is called before the first frame update
    void Start()
    {
        gameDrop.value = PlayerPrefs.GetInt(prefGametyp, 0);
        GameTypList();
        
    }

    void GameTypList()
    {
        string[] enumGameTypes = Enum.GetNames(typeof(gameType));
        List<string> gametpys = new List<string>(enumGameTypes);
        gameDrop.AddOptions(gametpys);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum gameType
{
    LONGEST,
    TOTAL,
    NAIVE
}
