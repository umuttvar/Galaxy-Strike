using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreBoardText;
    int score = 0;

    public void ScoreProcess(int amount)
    {
        score += amount;
        scoreBoardText.text = score.ToString("D6");
    }


}
