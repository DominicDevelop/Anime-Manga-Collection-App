using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoSingleton<PrefabManager>
{
    [SerializeField]
    private GameObject _mangaListElemPrefab;

    public GameObject GetMangaListElem(Transform parent = null) {
        GameObject elem;

        if (parent == null)
            elem = GameObject.Instantiate(_mangaListElemPrefab);
        else
            elem = GameObject.Instantiate(_mangaListElemPrefab, parent);

        return elem;
    }
}
