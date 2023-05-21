using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHit : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject hitbox_Left;
    [SerializeField] private GameObject hitbox_Right;

    public void EnableHitbox()
    {
        if (spriteRenderer.flipX == true)
        {
            hitbox_Right.SetActive(true);
        }
        else
        {
            hitbox_Left.SetActive(true);
        }
    }

    public void DisableHitbox()
    {
        hitbox_Right.SetActive(false);
        hitbox_Left.SetActive(false);
    }
}
