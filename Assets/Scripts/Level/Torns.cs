using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torns : MonoBehaviour, IExploding
{
    private Coroutine playerFolowing;
    [SerializeField] bool isFolowingPlayer;
    [SerializeField] float followingSpeed;

    public void Explode()
    {
        Destroy(this.gameObject, 0.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable victim = collision.gameObject.GetComponent<IDamagable>();
        if (victim != null)
        {
            victim.Damage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFolowingPlayer)
        {
            if (other.CompareTag("Player"))
            {
                playerFolowing = StartCoroutine(FolowPlayer(other.transform));
            }
            else if (other.CompareTag("Environment"))
            {
                if (playerFolowing != null) StopCoroutine(playerFolowing);
            }
        }
    }

    IEnumerator FolowPlayer(Transform playerTransform)
    {
        while (true)
        {
            Vector3 target = new Vector3(playerTransform.position.x,
                                                transform.position.y,
                                                transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, Time.fixedDeltaTime * followingSpeed);

            yield return new WaitForFixedUpdate();
        }
        
    }
}
