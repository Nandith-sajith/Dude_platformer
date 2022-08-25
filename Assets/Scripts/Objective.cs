using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    
    public string levelToLoad;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SoundManagerScript.PlaySound("win");
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
