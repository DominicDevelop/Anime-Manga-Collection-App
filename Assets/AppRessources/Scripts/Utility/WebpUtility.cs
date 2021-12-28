using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using WebP;

public static class WebpUtility
{
    /// <summary>
    /// Download a Webp Image.
    /// </summary>
    /// <param name="url">URL to the Webp Image.</param>
    /// <param name="callback">Callback without any parameter and a Texture2D return-value which is the downloaded image.</param>
    public static IEnumerator DownloadWebpImage_Coroutine(string url, Action<Texture2D> callback) {
        using (var request = UnityWebRequestTexture.GetTexture(url)) {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success) {
                Debug.LogError(request.error);
            } else {
                var textureBytes = request.downloadHandler.data;

                Texture2D cover = Texture2DExt.CreateTexture2DFromWebP(textureBytes, lMipmaps: true, lLinear: true, lError: out Error lError);

                callback?.Invoke(cover);
            }
        }
    }
}
