using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTriggerAnimation : MonoBehaviour
{
    [SerializeField] Animator[] animator;

    void FixedUpdate()
    {
        foreach (var animation in animator) //рандомим сразу все переданные аниматоры
        {
            int rand = Random.Range(1, 4);
            animation.SetInteger("Random", rand);
        }
    }
}
