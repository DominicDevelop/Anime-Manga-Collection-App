using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using WebP;

public class ListManager : MonoSingleton<ListManager>
{
    #region Constants
    private readonly string IMAGE_CDN_PATH = "https://cdn.anisearch.de/images/{0}";
    #endregion

    [SerializeField]
    private Transform _searchResultList;
    private List<GameObject> _resultListElems = new List<GameObject>();

    private string _searchTerm = "";

    public void Search() {
        if (_searchTerm.Length < 1)
            return;

        foreach (var elem in _resultListElems) {
            GameObject.Destroy(elem);
        }

        var listElems = HtmlParser.SendMangaSearchRequest(_searchTerm);

        if (listElems.Count > 0) {
            foreach (var elem in listElems) {
                GameObject listElem = PrefabManager.Instance.GetMangaListElem(_searchResultList);
                _resultListElems.Add(listElem);
                StartCoroutine(SetCoverByImageURL(listElem, elem.Attributes["data-bg"].Value));
            }
        }
    }

    public void OnSearchTermValueChanged(string value) {
        _searchTerm = value;
    }

    #region Private Methohds
    private IEnumerator SetCoverByImageURL(GameObject mangaListElem, string url) {
        RawImage listElemImage = mangaListElem.GetComponent<RawImage>();

        using (var request = UnityWebRequestTexture.GetTexture(string.Format(IMAGE_CDN_PATH, url))) {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success) {
                Debug.LogError(request.error);
            } else {
                var textureBytes = request.downloadHandler.data;

                listElemImage.texture = Texture2DExt.CreateTexture2DFromWebP(textureBytes, lMipmaps: true, lLinear: true, lError: out Error lError);
            }
        }
    }
    #endregion
}
