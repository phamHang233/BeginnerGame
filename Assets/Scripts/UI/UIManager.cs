using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour

{
    [SerializeField] private GameObject gameOverScene;
    [SerializeField] private AudioClip gameOverMusic;
    [SerializeField] private GameObject[] gamePlay;

    private void Awake()
    {
        gameOverScene.SetActive(false);
    }
    public void GameOver()
    {
        foreach (GameObject comp in gamePlay)
        {
            comp.SetActive(false);
        }
        // gamePlayScene.SetActive(false);

        gameOverScene.SetActive(true);
        SoundManager.instance.PlaySound(gameOverMusic);
    }
}
