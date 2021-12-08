using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public List<Stompy> hands;
    public float shootTimer, actualShooting, shootSpeed, shotCount; 
    public int damage, knockback;
    float shootCount, shooting;
    bool start;
    public Projectile shootie;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        shootCount = shootTimer;
        shooting = actualShooting;
    }
    private void Update()
    {
        anim.SetBool("Shooting", shooting > 0 ? true : false);
        if (shooting > 0)
        {
            shootCount = shootTimer;
            shooting -= Time.deltaTime;
            foreach (Stompy hand in hands) hand.allowedToStomp = false;
            if (start && shooting < 1) 
            {
                start = false;
                StartCoroutine(Shoot()); 
            }
        }
        else if (shootCount > 0)
        {
            shootCount -= Time.deltaTime;
            foreach (Stompy hand in hands) hand.allowedToStomp = true;
        }
        else
        {
            start = true;
            shooting = actualShooting;
        }
        
        
    }
    public IEnumerator Shoot()
    {
        float count = 1;
        while(count <= shotCount)
        {
            count++;
            Projectile instance = Instantiate(shootie);
            instance.transform.position = transform.position;
            instance.Shoot(new Vector2(Random.Range(-0.3f, 0.3f), -1), shootSpeed, damage, knockback, 4);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
