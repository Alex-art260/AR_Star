using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Asteroids : MonoBehaviour
{
    [SerializeField] ScoreCount _checkScore;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject [] _asteroidsSmall = new GameObject[3];
    [SerializeField] private GameObject [] _asteroidsMiddle = new GameObject[3];
    [SerializeField] private GameObject[] _asteroidsBig = new GameObject[3];
    [SerializeField] private Camera ARCamera;

    private UnityEngine.Object _explosionSmall;
    private UnityEngine.Object _explosionMiddle;
    private UnityEngine.Object _explosionBig;

    public float speedSmallAsteroids;
    public float speedMiddleAsteroids;
    public float speedBigAsteroids;

    public float speedRotationSmallAsteroids;
    public float speedRotationMiddleAsteroids;
    public float speedRotationBigAsteroids;

    private void Start()
    {
        _explosionSmall = Resources.Load("AsteroidsSmall");
        _explosionMiddle = Resources.Load("AsteroidsMiddle");
        _explosionBig = Resources.Load("AsteroidsBig");
    }

    void Update()
    {
        for (int i = 0; i < _asteroidsSmall.Length; i++)
        {
            _asteroidsSmall[i].transform.Rotate(0f, 0f, speedRotationSmallAsteroids * Time.deltaTime);
            _asteroidsSmall[i].transform.RotateAround(_target.transform.position, Vector3.up, speedSmallAsteroids * Time.deltaTime);
        }
        for (int i = 0; i < _asteroidsMiddle.Length; i++)
        {
            _asteroidsMiddle[i].transform.Rotate(0f, 0f, speedRotationMiddleAsteroids * Time.deltaTime);
            _asteroidsMiddle[i].transform.RotateAround(_target.transform.position, Vector3.up, speedMiddleAsteroids * Time.deltaTime);
        }
        for (int i = 0; i < _asteroidsBig.Length; i++)
        {
            _asteroidsBig[i].transform.Rotate(0f, 0f, speedRotationBigAsteroids * Time.deltaTime);
            _asteroidsBig[i].transform.RotateAround(_target.transform.position, Vector3.up, speedBigAsteroids * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {

            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "AsteroidSmall")
                {
                    hit.collider.gameObject.SetActive(false);

                    _checkScore.ScoreSmallAsteroid();

                    for (int i = 0; i < _asteroidsSmall.Length; i++)
                    {
                        GameObject explosionRefSmall = (GameObject)Instantiate(_explosionSmall);
                        explosionRefSmall.transform.position = new Vector3(_asteroidsSmall[i].transform.position.x, _asteroidsSmall[i].transform.position.y, _asteroidsSmall[i].transform.position.z);
                    }
                }

                if (hit.collider.gameObject.tag == "AsteroidMiddle")
                {
                    hit.collider.gameObject.SetActive(false);

                    _checkScore.ScoreMiddleAsteroid();

                    for (int i = 0; i < _asteroidsMiddle.Length; i++)
                    {
                        GameObject explosionRefMiddle = (GameObject)Instantiate(_explosionMiddle);
                        explosionRefMiddle.transform.position = new Vector3(_asteroidsMiddle[i].transform.position.x, _asteroidsMiddle[i].transform.position.y, _asteroidsMiddle[i].transform.position.z);
                    }
                }

                if (hit.collider.gameObject.tag == "AsteroidBig")
                {
                    hit.collider.gameObject.SetActive(false);

                    _checkScore.ScoreBigAsteroid();

                    for (int i = 0; i < _asteroidsBig.Length; i++)
                    {
                        GameObject explosionRefBig = (GameObject)Instantiate(_explosionBig);
                        explosionRefBig.transform.position = new Vector3(_asteroidsBig[i].transform.position.x, _asteroidsBig[i].transform.position.y, _asteroidsBig[i].transform.position.z);
                    }
                }
            }
        }
    }
}
