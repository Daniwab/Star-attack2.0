using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string NomeDoLevel;
    [SerializeField] private GameObject PainelMenu;
    [SerializeField] private GameObject PainelOpc;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevel);
    }
    public void AbrirOpcoes()
    {
        PainelMenu.SetActive(false);
        PainelOpc.SetActive(true);
    }
    public void FecharOpcoes()
    {
        PainelOpc.SetActive(false);
        PainelMenu.SetActive(true);
    }
    public void Sair()
    {
        Debug.Log("Sair Do Jogo");
        Application.Quit();
    }
}
