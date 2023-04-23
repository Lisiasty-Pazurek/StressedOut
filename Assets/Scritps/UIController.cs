using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject startgameCanvas;
    public GameObject gameplayCanvas;
    public GameObject levelpickerCanvas;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    public Slider stressSlider;
    public Slider progressSlider;

    public Animator walkerAnimator;
    public Animator stressBarTopAnimator;
    public Animator stressedOutAnimator;
    public LevelController lvlController;

    public List<GameObject> levels = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stressSlider.value = lvlController.stressLevel;
        progressSlider.value = lvlController.progressLevel;
        walkerAnimator.SetFloat("stressLevel",(lvlController.stressLevel));
        stressedOutAnimator.SetFloat("stressLevel",(lvlController.stressLevel));
        stressBarTopAnimator.SetFloat("stressLevel",(lvlController.stressLevel));
    }

    public void StartLevel(GameObject level)
    {
        lvlController.ResetProgress();
        gameplayCanvas.SetActive(true);
        levelpickerCanvas.SetActive(false);
        level.SetActive(true);
        lvlController.currentLevel = level;
    }

    public void RestartLevel()
    {
        lvlController.ResetProgress();
        gameplayCanvas.SetActive(true);
        loseCanvas.SetActive(false);
        lvlController.currentLevel.SetActive(true) ;
    }
    

    public void NextLevel()
    {
        lvlController.ResetProgress();
        gameplayCanvas.SetActive(true);
        winCanvas.SetActive(false);
        int position = levels.IndexOf(lvlController.currentLevel);
        levels[position + 1].SetActive(true);
        lvlController.currentLevel = levels[position + 1];
    }


    public void EndLevel(bool win)
    {
        loseCanvas.SetActive(!win);
        winCanvas.SetActive(win);
        lvlController.currentLevel.SetActive(false);
    }


}
