using Doozy.Runtime.Signals;
using Doozy.Runtime.UIManager.Containers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ListManager : MonoSingleton<ListManager>
{
    #region Constants
    #region PATHES
    private static readonly string IMAGE_CDN_PATH = "https://cdn.anisearch.de/images/{0}";
    #endregion

    #region REGEX
    private readonly string REGEX_MANGA_ID_FROM_IMG_PATH = @"(\d+).webp";
    #endregion

    #region Signals
    private readonly string CATEGORY_NAVIGATION = "Navigate";

    private readonly string SIGNAL_SHOW_SEARCH_RESULT_LIST = "ShowSearchResultList";
    #endregion
    #endregion

    [SerializeField]
    private Transform _searchResultListTransform;
    private Dictionary<string, GameObject> _resultListElems = new Dictionary<string, GameObject>();

    [SerializeField]
    private UIView _searchResultView;

    private string _searchTerm = "";
    private string _prevSearchTerm = "";

    public void Search() {
        if (_searchTerm.Length < 1 || (_prevSearchTerm.Equals(_searchTerm) && _searchResultView.isVisible))
            return;

        Signal.Send(SIGNAL_SHOW_SEARCH_RESULT_LIST, CATEGORY_NAVIGATION, "Show the result of a search in the Search List View");

        _prevSearchTerm = _searchTerm;

        #region Clear Search Results
        foreach (var elem in _resultListElems) {
            GameObject.Destroy(elem.Value);
        }

        _resultListElems.Clear();
        #endregion

        var listElems = HtmlParser.GetMangaSearchResult(_searchTerm);

        if (listElems != null && listElems.Count > 0) {
            foreach (var elem in listElems) {
                var imagePath = elem.Attributes["data-bg"].Value;

                GameObject listElemGO = PrefabManager.Instance.GetMangaListElem(_searchResultListTransform);
                ListElem listElemScript = listElemGO.GetComponent<ListElem>();

                //TODO: Performance check with Regex and replacing front and end part of the string with string.Empty
                var match = Regex.Match(imagePath, REGEX_MANGA_ID_FROM_IMG_PATH);
                string mangaId = match.Groups[0].Value.Split('.')[0];

                listElemScript.ID = mangaId;

                if (!_resultListElems.ContainsKey(mangaId)) {
                    _resultListElems.Add(mangaId, listElemGO);
                }

                RawImage imageToSet = listElemGO.GetComponentInChildren<RawImage>();

                StartCoroutine(WebpUtility.DownloadWebpImage_Coroutine(string.Format(IMAGE_CDN_PATH, imagePath), (cover) => {
                    imageToSet.texture = cover;
                    listElemScript.Cover = cover;
                }));

                
            }
        }
    }

    public void OnSearchTermValueChanged(string value) {
        _searchTerm = value;
    }

    public void DisableListView() {
        _searchResultListTransform.gameObject.SetActive(false);
    }

    #region Private Methohds
    private void SetCoverByImageURL(GameObject mangaListElemGO, ListElem mangaListElemScript, string url) {
        
    }
    #endregion
}
