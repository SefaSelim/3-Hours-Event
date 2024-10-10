using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float hardness;
    public float spawnTime;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private TextMeshProUGUI _scoreText;
    private int score = 0;
    private float timer = 5;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0;
            score++;
            _scoreText.text = score.ToString();
            if (spawnTime>0)
            {
                spawnTime -= hardness;
            }
            Vector3 Position = new Vector3(Random.Range(-2f, 2f), 7f, 0f);
            Instantiate(_gameObject, Position, _spawnPoint.rotation);
        }
    }
}
