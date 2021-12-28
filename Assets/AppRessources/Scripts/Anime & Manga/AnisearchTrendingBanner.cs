using UnityEngine;
using UnityEngine.UI;

public class AnisearchTrendingBanner : MonoBehaviour
{
    [SerializeField]
    private RawImage _trendingAnime;

    [SerializeField]
    private RawImage _trendingManga;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WebpUtility.DownloadWebpImage_Coroutine(
            "https://api.anisearch.de/v1/trending/anime/2021-51.webp",
            (animeBanner) => _trendingAnime.texture = animeBanner
        ));
    }
}
