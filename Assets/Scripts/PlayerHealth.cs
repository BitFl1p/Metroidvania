using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : Health
{
    Volume vol;
    public Slider healthSlider;
    public override void Damage(int damage, Collider2D dealer, float knockback)
    {
        health -= damage;
        var instance = Instantiate(indicator);
        instance.SetText(damage.ToString());
        instance.transform.position = transform.position;
        rb.velocity = new Vector2((transform.position * 10 - dealer.transform.position * 10).normalized.x > 0 ? 1 : -1, 2) * knockback;
        StartCoroutine(InvincibilityFrames(1, 9));
    }
    protected override void Start()
    {
        base.Start();
        vol = FindObjectOfType<Volume>();
    }
    protected override void Update()
    {
        base.Update();
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;
        vol.profile.TryGet(out Vignette vig);
        vol.profile.TryGet(out ChromaticAberration ab);
        vol.profile.TryGet(out FilmGrain grain);
        vig.intensity.value = 1 - (health / maxHealth);
        ab.intensity.value = (1f - (health / maxHealth)) - ((1f - (health / maxHealth)) * UnityEngine.Random.Range(0, 0.5f));
        grain.intensity.value = 1 - (health / maxHealth);
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
