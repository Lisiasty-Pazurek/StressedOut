using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
//    public PlayerController pController;
    public AudioSource audioSource;
    public List<AudioClip> breathingSound = new List<AudioClip>();

    public bool lastBreathState;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerController.OnBreathChange += HandleBreathChange;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleBreathChange(bool deepBreath)
    {

        if (deepBreath && !audioSource.isPlaying && deepBreath != lastBreathState)
        {
            audioSource.clip = breathingSound[0];
            audioSource.Play();
            lastBreathState = deepBreath;
        }
        else if (!deepBreath && !audioSource.isPlaying && deepBreath != lastBreathState)
        {
            audioSource.clip = breathingSound[1];
            audioSource.Play();            
            lastBreathState = deepBreath;
        }

        else return;
    }


}
