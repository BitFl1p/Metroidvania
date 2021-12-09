using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : Health
{
    Volume vol;
    public HealthAndManaManager healthSlider;
    float count = 0;
    public override void Damage(int damage, Collider2D dealer, float knockback)
    {
        StartCoroutine(Camera.main.GetComponent<CameraController>().Shake(0.25f, damage*3));
        StartCoroutine(InvincibilityFrames(1, 9));
        health -= damage;
        rb.velocity = new Vector2((transform.position * 10 - dealer.transform.position * 10).normalized.x > 0 ? 1 : -1, 2) * knockback;
        
        count = 0.25f;
    }
    protected override void Start()
    {
        base.Start();
        vol = FindObjectOfType<Volume>();
    }
    protected override void Update()
    {
        if (health > maxHealth) health = maxHealth;
        healthSlider.health = health;
        healthSlider.maxHealth = maxHealth;
        vol.profile.TryGet(out Vignette vig);
        vol.profile.TryGet(out ChromaticAberration ab);
        vol.profile.TryGet(out FilmGrain grain);
        if (health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        vig.intensity.value = Mathf.Clamp(count * 5, 0, 1);
        ab.intensity.value = Mathf.Clamp(count * 5, 0, 1);
        grain.intensity.value = Mathf.Clamp(count * 5, 0, 1);
        
        if (count > 0 && count < 0.2f)
        {
            Time.timeScale = 0.2f;
            count -= Time.unscaledDeltaTime;
        }
        else if (!PauseMenu.instance.paused)
        {
            count -= Time.unscaledDeltaTime;
            Time.timeScale = 1;
            
        }
        
    }
    public IEnumerator InvincibilityFrames(float time, int interval)
    {
        gameObject.layer = 9;
        
        
        for (int i = interval; i > 0; i--)
        {
            
            foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = i % 2 == 1 ? new Color(0.25f, 0.25f, 0.25f) : new Color(1, 1, 1);
            yield return new WaitForSeconds(time / interval);
        }
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(1, 1, 1);
        
        gameObject.layer = 6;
    }
}
