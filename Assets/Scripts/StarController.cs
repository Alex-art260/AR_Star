using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarController : MonoBehaviour
{
    [SerializeField] private ScoreCount _checkScore;
    [SerializeField] private GameObject _textScore;
    [SerializeField] private GameObject _buttonRestart;

    public float speedRotation;

    void Update()
    {
        transform.Rotate(0f, speedRotation * Time.deltaTime, 0f);

        if(ScoreCount.checkBoss == true)
        {
            _buttonRestart.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        _textScore.SetActive(true);
        _buttonRestart.SetActive(false);
        ScoreCount.checkBoss = false;
    }
}
