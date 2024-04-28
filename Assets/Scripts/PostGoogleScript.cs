using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostGoogleScript : MonoBehaviour
{
    public InputField inputF;
    
    public void PostDataToExcel()
    {
        StartCoroutine(PostData());
    }

    IEnumerator PostData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", inputF.text);
        //form.AddField("欄位命名", "欄位資料"); 要幾種資料就要輸入幾行，並且命名，命名是為了給Google Apps Script讀取

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycby5GuMpVVMLm7WwyX1kTkSO9JJfVEYEty5ZVpxd6dPeJCNn4qW1z86IFZW7QgKsvkbF/exec", form))
        {
            yield return www.SendWebRequest();

        }
    }
}
