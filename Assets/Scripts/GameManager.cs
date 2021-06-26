using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ゲーム管理クラス
/// </summary>
public class GameManager : MonoBehaviour
{
    //ゲーム中のオブジェクトデータ
    [SerializeField] bool IsVersionUpFlag = false;
    [SerializeField] GameObject CardListRoot = null;
    [SerializeField] CardView CardView = null;

    //ゲーム中のマスターデータ
    List<CardData> cards = null;

    static public List<CardData> CardMaster => instance.cards;

    delegate void LoadMasterDataCallback<T>(T data);

    int LoadingCount = 0;
    int IsInit = 0;

    //とりあえずのシングルトン化
    static GameManager instance = null;
    static public GameManager Instance => instance;

    private void Awake()
    {
        instance = this;

        //カードデータ読み込み
        LoadCardData("CardData");
    }

    private void Update()
    {
        //マスタデータの読み込みが終わったらセットアップする
        if(LoadingCount == 0 && IsInit == 0)
        {
            var prefab = Resources.Load<GameObject>("Button");
            //foreach (var card in cardMaster.Data)
            //{
            //    {
            //        int id = card.Id;
            //        GameObject btn = GameObject.Instantiate(prefab, CardListRoot.transform);
            //        Button script = btn.GetComponent<Button>();
            //        TMPro.TMP_Text text = btn.GetComponentInChildren<TMPro.TMP_Text>();
            //        text.text = card.Name;
            //        script.onClick.AddListener(() =>
            //        {
            //            CardView.ViewData(id);
            //        });
            //    }
            //}

            foreach (var item in cards)
            {
                
                int id = item.Id;
                GameObject btn = GameObject.Instantiate(prefab, CardListRoot.transform);
                Button script = btn.GetComponent<Button>();
                TMPro.TMP_Text text = btn.GetComponentInChildren<TMPro.TMP_Text>();
                text.text = item.Name;
                script.onClick.AddListener(() => CardView.ViewData(id));
            }

            IsInit = 1;
        }
    }

    //マスタデータ読み込み関数
    //private void LoadMasterData<T>(string file, LoadMasterDataCallback<T> callback)
    //{
    //    var data = LocalData.Load<T>(file);
    //    if(data == null || IsVersionUpFlag)
    //    {
    //        LoadingCount++;
    //        Network.WebRequest.Request<Network.WebRequest.GetString>("https://script.google.com/macros/s/AKfycbwGRi22gwxUvdSzIpofH9xPiWStwiOafoGR8D_IJ_w8RmnPCq3nv7kZ4icBLKgfLLKc/exec?sheet=" + file, Network.WebRequest.ResultType.String, (string json) =>
    //        {
    //            var dldata = JsonUtility.FromJson<T>(json);
    //            LocalData.Save<T>(file, dldata);
    //            callback(dldata);
    //            Debug.Log("Network download. : " + file + " / " + json + "/" + dldata);
    //            --LoadingCount;
    //        });
    //    }
    //    else
    //    {
    //        Debug.Log("Local load. : " + file + " / " + data);
    //        callback(data);
    //    }
    //}

    private void LoadCardData(string file)
    {
        cards = new List<CardData>();
        for (int i = 1; true ; i++)
        {
            string pass = $"{file}{i}";
            CardData data = Resources.Load(pass) as CardData;
            if (data is null)
            {
                break;
            }
            else
            {
                cards.Add(data);
            }
        }
    }
}
