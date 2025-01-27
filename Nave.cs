using UnityEngine;

public class NaveP : MonoBehaviour
{
    public float Speed = 5f;
    public float RotationSpeed = 100f;
    private Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>(); // Corrigido: "Rigidibody" para "Rigidbody"
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float f = Input.GetAxis("Jump");

        // Movimento
        Vector3 movement = new Vector3(h, 0, v) * Speed; // Corrigido: movimento no plano horizontal (x e z)
        Rb.linearVelocity = transform.TransformDirection(movement); // Corrigido: "linearVelocity" para "velocity"

        //Rotação para seguir o cursor do mouse

  


        // Rota��o
        float rotation = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right, rotation * RotationSpeed * Time.deltaTime); // Corrigido: "Time.delta" para "Time.deltaTime"
    }
}