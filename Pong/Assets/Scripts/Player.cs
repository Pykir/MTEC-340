using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreUI;

    private int _score;

    public int Score
    {
        get => _score;

        set
        {
            _score = value;
            _scoreUI.SetText(Score.ToString());
        }
    }
}
