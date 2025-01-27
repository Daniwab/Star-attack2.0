using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public float sensitivityX = 100f; // Sensibilidade para o eixo X (vertical)
    public float sensitivityY = 100f; // Sensibilidade para o eixo Y (horizontal)
    public float sensitivityZ = 100f; // Sensibilidade para o eixo Z (inclinação)
    public float MoveSpeed = 10f; // Velocidade da nave
    public float BoostSpeed = 1000f;

    private float xRotation = 0f; // Rotação acumulada no eixo X
    private float yRotation = 0f; // Rotação acumulada no eixo Y
    private float zRotation = 0f; // Rotação acumulada no eixo Z
   

    void Start()
    {
        // Trava o cursor no centro da tela e o oculta
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 InitialRotation = transform.localRotation.eulerAngles;
        xRotation = InitialRotation.x;
        yRotation = InitialRotation.y;
    }

    void Update()
    {
        // Captura o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivityY * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityX * Time.deltaTime;

        // Calcula a rotação no eixo X (vertical)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita o ângulo vertical para evitar virar de cabeça para baixo

        // Calcula a rotação no eixo Y (horizontal)
        yRotation += mouseX;
        yRotation = Mathf.Repeat(yRotation, 360f); // Mantém a rotação dentro de um intervalo válido

        // Calcula a rotação no eixo Z (inclinação, opcionalmente baseada no movimento horizontal)
        zRotation += mouseX; // Opcional: pode ajustar essa lógica se o eixo Z for baseado em outro controle
        zRotation = Mathf.Repeat(zRotation, 360f); // Mantém a rotação dentro de um intervalo válido

        // Aplica as rotações nos eixos X, Y e Z
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);

        //define velocidade atual da nave
        float currentSpeed = Input.GetKey(KeyCode.T) ? BoostSpeed : MoveSpeed;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += -transform.forward * currentSpeed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.T)){
            transform.position += -transform.forward * currentSpeed;
        }

      }
}