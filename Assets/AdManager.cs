using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private readonly string playStoreID = "3657126";
    private readonly string appStoreID = "3657126";

    private readonly string interstitialAd = "video";
    private readonly string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlaystore;
    public bool isTestAd;

    // Start is called before the first frame update
    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAd();
    }

    private void InitializeAd()
    {
        if (isTargetPlaystore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
        else
        {
            Advertisement.Initialize(appStoreID, isTestAd);
        }
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewaredVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }

        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    Debug.Log("Reward the player");
                }
                break;
        }
    }
}
