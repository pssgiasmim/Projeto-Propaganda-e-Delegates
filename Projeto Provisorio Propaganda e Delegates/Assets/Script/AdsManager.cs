using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

// Classe que faz as propagandas aparecerem na tela.
public class AdsManager : MonoBehaviour , IUnityAdsInitializationListener, IUnityAdsShowListener
{
    public string projetoID = "5721741"; //ID do projeto
    public string bannerID = "Banner_Android"; //ID do Banner
    public string interstitialID = "Interstitial_Android"; //ID do Interstitial
    public string recompensaID = "Recompensa_Android"; //ID da recompensa

    [SerializeField] TextMeshProUGUI pontosDoJogador; //Vari�vel que armazena os pontos do jogador.
    public int pontos; //Vari�vel que armazena os pontos do jogador.

    // Faz a propaganda banner estar na tela
    public void Start()
    {
        Advertisement.Initialize(projetoID, true, this); //Inicial o Unity Ads, preparando o servi�o para exibir an�ncios no jogo.
    }

    //M�todo que faz o Interstitial aparecer na tela com base do clique do bot�o.
    public void MostrarInterstitial()
    {
        Advertisement.Show("Interstitial_Android", this); //Exibe um interstitial para o jogador.

        Advertisement.Banner.Hide(); //O banner se esconde quando o interstitial aparecer.
    }

    //M�todo que mostra a propaganda de recompensa com base no clique de um bot�o.
    public void MostrarRecompensa()
    {
        Advertisement.Show("Recompensa_Android", this); //Exibe uma propaganda de recompensa para o jogador.

        Advertisement.Banner.Hide(); //O banner se esconde quando a recompensa aparecer.
       
    }


    public delegate void ValoresDoJogador(int valor); //Delegate dos valores do jogador.
    public ValoresDoJogador valores; //Vari�vel valores baseada no delegate ValoresDoJogador.

    //M�todos do delegate de valores.

    //M�todo do valor caso o jogador pule a propaganda.
    public void ValorSkippado(int valor)
    {
        
        Debug.Log("Valor recebido: " + pontos);
        pontos += valor;
        pontosDoJogador.text = pontos.ToString();
        
    }
    //M�todo do valor caso o jogador assista por completo a propaganda.
    public void ValorCompleto(int valor)
    {
        Debug.Log("Valor dobrado: " + pontos);
        pontos  += valor * 2; 
        pontosDoJogador.text = pontos.ToString();
    }


    //M�todo com Delegate de valor  que recebe mais valor se a propaganda foi assistida e menos valor se ela foi pulada. A cada propaganda fechada, sendo interstitial ou recompensa, o banner reaparece.
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Advertisement.Banner.Show("Banner_Android"); //Chama o banner para ele aparecer.

        //Condi��o que verifica se a propaganda � de recompensa
        if (placementId == "Recompensa_Android")
        {
            //Condi��o que verifica se o estado da propaganda recompensa � completa.
            if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
            {
                Debug.Log("Jogador ganhou a recompensa!");
                valores = ValorCompleto;
            }

            //Caso o jogador pule a propaganda de recompensa.
            else if (showCompletionState == UnityAdsShowCompletionState.SKIPPED)
            {
                Debug.Log("Jogador pulou o an�ncio!");
                valores = ValorSkippado;
            }
            valores(5);
        }
        
    }

    //M�todo para quando o initialize do start funcionar. 
    public void OnInitializationComplete()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);//Configura o banner na posi��o superior da tela.

        Advertisement.Banner.Show("Banner_Android"); //Exibe um banner na posi��o definida pelo SetPosition
    }

    //M�todo para caso ocorra um erro no initialize
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ops! Parece que ocorreu um erro... " + error);
    }

    //M�todo que leva a pessoa ao site, caso a propaganda seja clicada.
    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Teste");
    }

    //M�todo para caso ocorra um erro com as propagandas.
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Ops! Ocorreu um erro com a propaganda. " + error);
    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }
    
}
