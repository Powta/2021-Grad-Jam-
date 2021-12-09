using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTheme : MonoBehaviour
{
    private AudioSource gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<AudioSource>();
        gameOver.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
