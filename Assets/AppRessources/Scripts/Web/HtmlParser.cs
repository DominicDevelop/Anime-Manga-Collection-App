using Extensions;
using HtmlAgilityPack;
using UnityEngine;

public static class HtmlParser
{
    private static readonly HtmlWeb WEB = new HtmlWeb();

    #region XPATH
    private static readonly string XPATH_FIND_MANGA_LISTELEM = "/html/body/main[@id='content']/div[@class='pagewidth']/div[@id='content-outer']/div[@id='content-inner']/ul[@class='covers']/li/a/@data-title";

    private static readonly string XPATH_FIND_BASIC_TITLE_INFO = "//div[@class='title'][@lang='de']/..";

    private static readonly string XPATH_FIND_DESCRIPTION = "//div[@lang='de'][@class='textblock details-text']";
    #endregion

    #region Manga
    public static HtmlNodeCollection GetMangaSearchResult(string mangaTitle) {
        var searchUrl = string.Format(@"https://www.anisearch.de/manga/index?char=all&text={0}&smode=1&region=de&sort=title&order=asc&view=4&limit=100&title=de&titlex=&hentai=no", mangaTitle);

        return ParseHtmlByXPATH(searchUrl, XPATH_FIND_MANGA_LISTELEM);
    }

    public static HtmlNodeCollection GetBasicMangaInformation(string mangaId) {
        var mangaUrl = string.Format(@"https://www.anisearch.de/manga/{0}", mangaId);

        return ParseHtmlByXPATH(mangaUrl, string.Format(XPATH_FIND_BASIC_TITLE_INFO, "manga", "de"));
    }

    public static string GetMangaDescription(string mangaId) {
        var mangaUrl = string.Format(@"https://www.anisearch.de/manga/{0}", mangaId);

        var nodes = ParseHtmlByXPATH(mangaUrl, string.Format(XPATH_FIND_DESCRIPTION, "manga", "de"));

        return nodes[0].InnerHtml.ReplaceHtmlTags();
    }
    #endregion

    #region Anime
    public static HtmlNodeCollection GetBasicAnimeInformation(string mangaId) {
        var mangaUrl = string.Format(@"https://www.anisearch.de/manga/{0}", mangaId);

        return ParseHtmlByXPATH(mangaUrl, string.Format(XPATH_FIND_BASIC_TITLE_INFO, "anime", "de"));
    }
    #endregion

    #region Private methods
    private static HtmlNodeCollection ParseHtmlByXPATH(string url, string XPATH) {
        var htmlDoc = WEB.Load(url);

        var nodes = htmlDoc.DocumentNode.SelectNodes(XPATH);

        return nodes;
    }
    #endregion
}
