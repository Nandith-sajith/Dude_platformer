using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip jumpSound, playerHitSound, healthSound, GameWinSound, waterSound, playerDeathSound, coinSound;
    static AudioSource audioSource;

    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        playerHitSound = Resources.Load<AudioClip>("Hit");
        healthSound = Resources.Load<AudioClip>("Health");
        GameWinSound = Resources.Load<AudioClip>("GameWin");
        waterSound = Resources.Load<AudioClip>("Water");
        //playerDeathSound = Resources.Load<AudioClip>("GameOver");
        coinSound = Resources.Load<AudioClip>("Coin");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "win":
                audioSource.PlayOneShot(GameWinSound);
                break;
            case "health":
                audioSource.PlayOneShot(healthSound);
                break;
            case "hit":
                audioSource.PlayOneShot(playerHitSound);
                break;
            case "water":
                audioSource.PlayOneShot(waterSound);
                break;
            case "coin":
                audioSource.PlayOneShot(coinSound);
                break;

        }
    }
}
