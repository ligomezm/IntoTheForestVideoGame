using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public GameObject soldiersInScene;

    private AudioSource deathSound;
    public AudioClip deathSoundClip;
    public GameObject gameOver;
    FPSController control;
    CameraController cameraController;


    void Start()
    {
        health = maxHealth;
        deathSound = GetComponent<AudioSource>();
        soldiersInScene = GameObject.FindGameObjectWithTag("Enemy");
        control = GetComponent<FPSController>();
        cameraController = GetComponent<CameraController>();
    }

    
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        
    }

    public void UpdateHealthUI()
    {
        float fillFront = frontHealthBar.fillAmount;
        float fillback = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;

        if (fillback > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillback, hFraction, percentComplete);
        }

        if (fillFront < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillFront, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;

        if (health <= 0)
        {
            gameOver.SetActive(true);
            deathSound.PlayOneShot(deathSoundClip);
            control.enabled = false;
            cameraController.enabled = false;
            //Invoke("RestartLevel", 1.5f);

        }
    }


    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        control.enabled = true;
        cameraController.enabled = true;
    }

}
