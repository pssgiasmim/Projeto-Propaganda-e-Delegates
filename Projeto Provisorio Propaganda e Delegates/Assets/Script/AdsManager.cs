using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour , IUnityAdsInitializationListener, IUnityAdsShowListener
{
    public string projetoID = "5721741";
    public string bannerID = "Banner_Android";
    
    public void OnInitializationComplete()
    {
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    
    


    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(projetoID, true, this);
        Advertisement.Banner.Show("Banner_Android");

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
