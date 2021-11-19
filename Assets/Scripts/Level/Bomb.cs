using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject bombMesh;
    [SerializeField] GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        IExploding victim = collision.gameObject.GetComponent<IExploding>();
        if (victim != null)
        {
            victim.Explode();
            bombMesh.SetActive(false);
            explosionEffect.SetActive(true);
        }
    }
}
