using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public player Player;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public float respawnInvulnerabilty = 3.0f;
    public int score = 0;
    public ParticleSystem explosion;
    public void Asteroiddestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        if(asteroid.size < 0.75f)
        {
            this.score += 100;

        } else if(asteroid.size < 1.20f)
        {
            this.score += 50;
        }
        else
        {
            this.score += 25;
        }

    }
    public void Playerdied()
    {
        this.explosion.transform.position = this.Player.transform.position;
        this.explosion.Play();
        this.lives--;
        if(this.lives <= 0)
        {
            Gameover();
        } 
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
         
    }

    private void Respawn()
    {
        this.Player.gameObject.layer = LayerMask.NameToLayer("Ignorecollisions");

        this.Player.transform.position = Vector3.zero;
        this.Player.gameObject.SetActive(true);
        Invoke(nameof(Turnoncollisions), this.respawnInvulnerabilty);
    
    
    }

    private void Turnoncollisions()
    {
        this.Player.gameObject.layer = LayerMask.NameToLayer("player");
    }

    private void Gameover()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);

    }
}
