using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : Health
{
    Volume vol;
    public override void Damage(int damage, Collider2D dealer, float knockback)
    {
        health -= damage;
        var instance = Instantiate(indicator);
        instance.SetText(damage.ToString());
        instance.transform.position = transform.position;
        rb.velocity = new Vector2((transform.position - dealer.transform.position).normalized.x > 0 ? 1 : -1, 2) * knockback;
        StartCoroutine(InvincibilityFrames(1));
    }
    protected override void Start()
    {
        base.Start();
        vol = FindObjectOfType<Volume>();
    }
    protected override void Update()
    {
        base.Update();
        vol.profile.TryGet(out Vignette vig);
        vol.profile.TryGet(out ChromaticAberration ab);
        vol.profile.TryGet(out FilmGrain grain);
        vig.intensity.value = 1 - (health / maxHealth);
        ab.intensity.value = (1f - (health / maxHealth)) - ((1f - (health / maxHealth)) * UnityEngine.Random.Range(0,0.5f));
        grain.intensity.value = 1 - (health / maxHealth);
    }
    public IEnumerator InvincibilityFrames(float time)
    {
        gameObject.layer = 9;
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(time / 8);
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(time / 8);
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(time / 8);
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(time / 8);
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(time / 8);
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(time / 8); 
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(time / 8);
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>()) sprite.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(time / 8);
        gameObject.layer = 6;
    }
}
