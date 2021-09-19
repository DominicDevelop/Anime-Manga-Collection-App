using HtmlAgilityPack;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelManager : MonoSingleton<InfoPanelManager>
{
    #region Private fields
    [SerializeField]
    private GameObject _infoPanel;

    [SerializeField]
    private RawImage _cover;

    #region Basic Info
    [SerializeField]
    private Text _titleText;

    [SerializeField]
    private Text _statusText;

    [SerializeField]
    private Text _releaseDateText;

    [SerializeField]
    private Text _releasesText;

    [SerializeField]
    private Text _publisherText;
    #endregion

    [SerializeField]
    private TMP_Text _description;
    #endregion

    public void SetDataAndSetVisible(Texture2D cover, HtmlNodeCollection infoNodes, string description) {
        _cover.texture = cover;

        foreach (var infoNode in infoNodes) {
            switch (infoNode.Attributes["class"].Value) {
                case "title":
                    _titleText.text = infoNode.InnerText.Trim();
                    break;
                case "status":
                    _statusText.text = infoNode.InnerText.Trim();
                    break;
                case "released":
                    _releaseDateText.text = infoNode.InnerText.Trim();
                    break;
                case "releases":
                    _releasesText.text = infoNode.InnerText.Trim();
                    break;
                case "company":
                    _publisherText.text = infoNode.InnerText.Trim();
                    break;
                default:
                    Debug.LogError("Could not find fitting node..");
                    break;
            }
        }

        _description.text = description;

        ListManager.Instance.DisableListView();
        _infoPanel.SetActive(true);
    }
}
