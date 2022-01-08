using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torns : MonoBehaviour, IExploding
{
    private Coroutine playerFolowingCorotine;
    [SerializeField] bool isFolowingPlayer;
    [SerializeField] float followingSpeed;
    private bool isFollowingNow = false;

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
        if (collision.gameObject.CompareTag("Environment"))
        {
            if (playerFolowingCorotine != null)
            {
                StopCoroutine(playerFolowingCorotine);
                playerFolowingCorotine = null;
            }
               
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFolowingPlayer)
        {
            if (other.CompareTag("Player"))
            {
                if (playerFolowingCorotine == null) playerFolowingCorotine = StartCoroutine(FolowPlayer(other.transform));
            }
        }
    }

    
    IEnumerator FolowPlayer(Transform playerTransform)
    {
        while (true)
        {
            Vector3 target = new Vector3(playerTransform.localPosition.x,
                                                transform.localPosition.y,
                                                transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.fixedDeltaTime * followingSpeed);

            yield return new WaitForFixedUpdate();
        }
        
    }
}
