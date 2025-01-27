using UnityEngine;

public class TiroXWing : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do tiro
    public Transform[] firePoints; // Array para os 4 pontos de disparo
    public float projectileSpeed = 20f; // Velocidade do projétil
    public float fireRate = 0.2f; // Taxa de disparo (1 tiro a cada 0.2 segundos)

    private float nextFireTime = 0f;

    void Update()
    {
        // Detecta o input para disparar
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) // "Fire1" é o botão de disparo padrão
        {
            nextFireTime = Time.time + fireRate; // Controla a taxa de disparo
            Shoot();
        }
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            // Instancia o projétil em cada FirePoint
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            // Adiciona velocidade ao projétil
            if (rb != null)
            {
                rb.linearVelocity = firePoint.forward * projectileSpeed;
            }

            // Destroi o projétil após 5 segundos
            Destroy(projectile, 5f);
        }
    }
}