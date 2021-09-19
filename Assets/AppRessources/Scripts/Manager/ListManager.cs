using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using WebP;

public class ListManager : MonoSingleton<ListManager>
{
    #region Constants
    #region PATHES
    private readonly string IMAGE_CDN_PATH = "https://cdn.anisearch.de/images/{0}";
    #endregion

    #region REGEX
    private readonly string REGEX_MANGA_ID_FROM_IMG_PATH = @"(\d+).webp";
    #endregion
    #endregion

    [SerializeField]
    private Transform _searchResultListTransform;
    private Dictionary<string, GameObject> _resultListElems = new Dictionary<string, GameObject>();

    private string _searchTerm = "";
    private string _prevSearchTerm = "";

    public void Search() {
        if (_searchTerm.Length < 1 || _prevSearchTerm.Equals(_searchTerm))
            return;

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

                StartCoroutine(SetCoverByImageURL(listElemGO, listElemScript, imagePath));
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
    private IEnumerator SetCoverByImageURL(GameObject mangaListElemGO, ListElem mangaListElemScript, string url) {
        RawImage listElemImage = mangaListElemGO.GetComponent<RawImage>();

        using (var request = UnityWebRequestTexture.GetTexture(string.Format(IMAGE_CDN_PATH, url))) {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success) {
                Debug.LogError(request.error);
            } else {
                var textureBytes = request.downloadHandler.data;

                Texture2D cover = Texture2DExt.CreateTexture2DFromWebP(textureBytes, lMipmaps: true, lLinear: true, lError: out Error lError);
                listElemImage.texture = cover;

                mangaListElemScript.Cover = cover;
            }
        }
    }
    #endregion
}
