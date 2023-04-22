using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas startgameCanvas;
    public Canvas gameplayCanvas;

    public Slider stressSlider;
    public Slider progressSlider;

    public Animator walkerAnimator;
    public Animator stressBarTopAnimator;
    public Animator stressedOutAnimator;


    public LevelController lvlController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stressSlider.value = lvlController.stressLevel;
        progressSlider.value = lvlController.progressLevel;
        walkerAnimator.SetFloat("stressLevel",(lvlController.stressLevel/100));
    }
}
