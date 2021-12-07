using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerPresenter))]
public class PlayerDeathEffect : MonoBehaviour
{
    [SerializeField ]private ParticleSystem[] deathEffect;    
    private MeshRenderer mesh;

    private void Start()
    {
        GetComponent<PlayerPresenter>().playerModel.Death += DeathEffectPlay;
        mesh = GetComponent<MeshRenderer>();
    }


    private void DeathEffectPlay(string text)
    {
        deathEffect[0].Play();
        deathEffect[1].Play();
        mesh.enabled = false;
    }
}
