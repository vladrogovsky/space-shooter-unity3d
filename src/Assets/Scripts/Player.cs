using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Player Stat")]
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] int health = 200;
    [Header("Laser stat")]
    [SerializeField] AudioClip PlayerShooting;
    [SerializeField] AudioClip PlayerKilled;
    [SerializeField] GameObject Laser;
    [SerializeField] float LaserSpeed = 10f;
    [SerializeField] float projectileFireRate = 0.2f;
    [SerializeField] [Range(0, 1)] float PlayerShootingVolume = 0.3f;
    [SerializeField] [Range(0, 1)] float PlayerDeathVolume = 0.3f;
    Coroutine fireCourutine;
    float xMin, xMax, yMin, yMax;
	// Use this for initialization
	void Start () {
        LimitPlayerMovement(); //borders
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision) { return; }
        HitDetection(collision);
    }

    private void HitDetection(Collider2D Laser)
    {
            health -= Laser.GetComponent<DamageDealer>().GetDamage();
            //Destroy(Laser.gameObject);
            if (health <= 0)
            {
            AudioSource.PlayClipAtPoint(PlayerKilled, Camera.main.transform.position, PlayerDeathVolume);
            Destroy(gameObject);
            FindObjectOfType<Level>().LoadGameOver();
            }
    }

    private void LimitPlayerMovement()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x+(GetComponent<SpriteRenderer>().size.x*0.5f);
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - (GetComponent<SpriteRenderer>().size.x * 0.5f);
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + (GetComponent<SpriteRenderer>().size.y * 0.5f);
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - (GetComponent<SpriteRenderer>().size.y * 0.5f);
    }

    // Update is called once per frame
    void Update () {
        Mover();
        Fire();
	}

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCourutine = StartCoroutine(ContiniesFire());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCourutine);
        }
    }
    IEnumerator ContiniesFire()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(PlayerShooting, Camera.main.transform.position, PlayerShootingVolume);
            GameObject LaserHandler = Instantiate(Laser,
                              transform.position,
                              Quaternion.identity)
                              as GameObject;
            LaserHandler.GetComponent<Rigidbody2D>().velocity = new Vector2
                                                                (0, LaserSpeed);
            yield return new WaitForSeconds(projectileFireRate);
        }
    }
    private void Mover()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerSpeed; // frame rate independent
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * PlayerSpeed;
        var newYpos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        transform.position = new Vector2(newXpos,newYpos);
    }
}
