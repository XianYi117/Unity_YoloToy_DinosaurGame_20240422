using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostGoogleScript : MonoBehaviour
{
    public InputField inputN;
    public InputField inputI;
    public InputField inputP;

    public void PostDataToExcel()
    {
        StartCoroutine(PostData());
    }

    IEnumerator PostData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", inputN.text);
        form.AddField("id", inputI.text);
        form.AddField("phone",inputP.text);
        //form.AddField("欄位命名", "欄位資料"); 要幾種資料就要輸入幾行，並且命名，命名是為了給Google Apps Script讀取

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbyEeIuTNhGZHwuzjOSLK2t9z0UWx98A0Yqkz_lJLZF5DxJTUUfIKQPu2u54JKNCCR-L/exec", form))
        {
            yield return www.SendWebRequest();

        }
    }
}
