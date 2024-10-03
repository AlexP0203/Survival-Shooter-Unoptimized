using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] ScoreStats sStats;

    void Update()
    {
        text.text = "Score: " + sStats.score;
    }
}
