using UnityEngine;
using UnityEngine.UI;
using System;
public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
    }
}
