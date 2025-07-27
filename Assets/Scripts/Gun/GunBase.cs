using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot = 0.1f;
    private Coroutine _currentCoroutine;
    public Transform playerSideReference;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
     {
         var projectile = Instantiate(prefabProjectile);
         projectile.transform.position = positionToShoot.position;
         projectile.side = playerSideReference.transform.localScale.x;
     }
   
    private void Start()
    {
        // Tenta atribuir automaticamente a referência do player se estiver vazia
        if (playerSideReference == null)
            playerSideReference = transform.root; // ou use transform.parent, se preferir
    }

}