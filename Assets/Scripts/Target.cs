using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    private Rigidbody _rb;
    private float _minSpeed = 12;
    private float _maxSpeed = 16;
    private float _Torque = -10;
    private float _xRange = 4;
    private float ySpawnPos = -0.5f;

    private GameManager gameManager;
    public int objectScore;

    public ParticleSystem explosionParticle;

    void Start()
    {
        Spawn();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Spawn()
    {
        transform.position = RandomSpawnPos();
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(RandomForce(), ForceMode.Impulse);
        _rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        if (!gameManager.gameOver)
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.UpdateLifes(1);
            }
            gameManager.UpdateScore(objectScore);
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameManager.gameOver)
        {
            if (!other.gameObject.CompareTag("Bad"))
            {
                gameManager.UpdateScore(-objectScore);
            }
        }
        Destroy(gameObject);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), ySpawnPos);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-_Torque, _Torque);
    }
}
