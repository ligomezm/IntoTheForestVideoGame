using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Puntaje puntaje;

    void Start()
    {
        puntaje = FindObjectOfType<Puntaje>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && puntaje.points == 1)
        {
            Invoke("GameCompleted", 2f);
        }
    }

    private void GameCompleted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
