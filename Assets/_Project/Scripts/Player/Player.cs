using KBCore.Refs;
using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField, Self] Rigidbody2D rb;
    [SerializeField, Range(0, 10)] float moveSpeed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    PlayerInput input;

    private void Awake() {
        input = PlayerInput.Instance;
    }

    private void Start() {
        input.OnShoot += Handle_Shoot;
    }

    private void Handle_Shoot() {
        Debug.Log("Shooting");
        GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 shootDirection = transform.right;
        projectile.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
    }

    void FixedUpdate() {
        Vector2 movement = PlayerInput.Instance.MoveDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
