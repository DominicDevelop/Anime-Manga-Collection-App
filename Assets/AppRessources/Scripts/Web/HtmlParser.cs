using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;
using System.Text;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;
using WebP;

public static class HtmlParser
{
    private static readonly HtmlWeb WEB = new HtmlWeb();

    #region XPATH
    private static readonly string FIND_MANGA_LISTELEM_XPATH = "/html/body/main[@id='content']/div[@class='pagewidth']/div[@id='content-outer']/div[@id='content-inner']/ul[@class='covers']/li/a/@data-title";
    #endregion

    public static HtmlNodeCollection SendMangaSearchRequest(string mangaTitle) {
        var searchUrl = string.Format(@"https://www.anisearch.de/manga/index?char=all&text={0}&smode=1&type=0&sort=title&order=asc&view=4&limit=100&title=de&titlex=1,2&hentai=no", mangaTitle);

        var htmlDoc = WEB.Load(searchUrl);

        var nodes = htmlDoc.DocumentNode.SelectNodes(FIND_MANGA_LISTELEM_XPATH);

        return nodes;
    }

}
