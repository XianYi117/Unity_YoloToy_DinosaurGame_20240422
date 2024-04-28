using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PostGoogleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PostData());
    }

    IEnumerator PostData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", 100);
        //form.AddField("欄位命名", "欄位資料"); 要幾種資料就要輸入幾行，並且命名，命名是為了給Google Apps Script讀取

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycby5GuMpVVMLm7WwyX1kTkSO9JJfVEYEty5ZVpxd6dPeJCNn4qW1z86IFZW7QgKsvkbF/exec", form))
        {
            yield return www.SendWebRequest();
        }
    }
}
