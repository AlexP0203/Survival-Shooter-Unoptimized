using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] ScoreStats sStats;
    
    public static int score;

    void Awake ()
    {
        score = 0;
    }

    void Update ()
    {
        sStats.score = score;
    }
}
