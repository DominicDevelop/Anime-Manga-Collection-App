using HtmlAgilityPack;
using UnityEngine;

public class ListElem : MonoBehaviour
{
    public bool IsManga { get; set; } = true;
    public string ID { get; set; }

    public Texture2D Cover { get; set; }

    public void OnListElemClicked() {
        //TODO: Check for cached data and load it if found. Then skip next part.

        HtmlNodeCollection basicInfoNodes;
        string desc = "";

        if (IsManga) {
            basicInfoNodes = HtmlParser.GetBasicMangaInformation(ID);
            desc = HtmlParser.GetMangaDescription(ID);
        } else {
            basicInfoNodes = HtmlParser.GetBasicAnimeInformation(ID);
        }

        if (basicInfoNodes.Count > 0) {
            InfoPanelManager.Instance.SetDataAndSetVisible(Cover, basicInfoNodes[0].ChildNodes, desc);
        }
    }
}
