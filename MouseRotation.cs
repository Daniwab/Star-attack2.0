using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public float sensitivityX = 100f; // Sensibilidade para o eixo X (vertical)
    public float sensitivityY = 100f; // Sensibilidade para o eixo Y (horizontal)
    public float sensitivityZ = 100f; // Sensibilidade para o eixo Z (inclina��o)
    public float MoveSpeed = 10f; // Velocidade da nave
    public float BoostSpeed = 1000f;

    private float xRotation = 0f; // Rota��o acumulada no eixo X
    private float yRotation = 0f; // Rota��o acumulada no eixo Y
    private float zRotation = 0f; // Rota��o acumulada no eixo Z
   

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

        // Calcula a rota��o no eixo X (vertical)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita o �ngulo vertical para evitar virar de cabe�a para baixo

        // Calcula a rota��o no eixo Y (horizontal)
        yRotation += mouseX;
        yRotation = Mathf.Repeat(yRotation, 360f); // Mant�m a rota��o dentro de um intervalo v�lido

        // Calcula a rota��o no eixo Z (inclina��o, opcionalmente baseada no movimento horizontal)
        zRotation += mouseX; // Opcional: pode ajustar essa l�gica se o eixo Z for baseado em outro controle
        zRotation = Mathf.Repeat(zRotation, 360f); // Mant�m a rota��o dentro de um intervalo v�lido

        // Aplica as rota��es nos eixos X, Y e Z
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