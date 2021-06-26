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
    MasterData.MasterDataClass<MasterData.Card> cardMaster;
    MasterData.MasterDataClass<MasterData.Effect> effectMaster;
    [SerializeField] public CardData[] cardDatas;
    static public MasterData.Card[] CardMaster => Instance.cardMaster.Data;
    static public MasterData.Effect[] EffectMaster => Instance.effectMaster.Data;

    delegate void LoadMasterDataCallback<T>(T data);

    int LoadingCount = 0;
    int IsInit = 0;

    //とりあえずのシングルトン化
    static GameManager instance = null;
    static public GameManager Instance => instance;

    private void Awake()
    {
        instance = this;

        //マスタデータ読み込み
        LoadMasterData("Card", (MasterData.MasterDataClass<MasterData.Card> data) => cardMaster = data);
        LoadMasterData("Effect", (MasterData.MasterDataClass<MasterData.Effect> data) => effectMaster = data);
    }

    private void Update()
    {
        //マスタデータの読み込みが終わったらセットアップする
        //if(LoadingCount == 0 && IsInit == 0)
        //{
        //    var prefab = Resources.Load<GameObject>("Button");
        //    foreach (var card in cardMaster.Data)
        //    {
        //        {
        //            int id = card.Id;
        //            GameObject btn = GameObject.Instantiate(prefab, CardListRoot.transform);
        //            Button script = btn.GetComponent<Button>();
        //            TMPro.TMP_Text text = btn.GetComponentInChildren<TMPro.TMP_Text>();
        //            text.text = card.Name;
        //            script.onClick.AddListener(() =>
        //            {
        //                CardView.ViewData(id);
        //            });
        //        }
        //    }

        //    IsInit = 1;
        //}
        if (IsInit == 0)
        {
            var prefab1 = Resources.Load<GameObject>("Button1");
            foreach (var card in cardDatas)
            {
                {
                    int id = card.GetId;
                    GameObject btn = GameObject.Instantiate(prefab1, CardListRoot.transform);
                    Button script = btn.GetComponent<Button>();
                    TMPro.TMP_Text text = btn.GetComponentInChildren<TMPro.TMP_Text>();
                    text.text = card.GetName;
                    script.onClick.AddListener(() =>
                    {
                        CardView.ViewCardData(id);
                    });
                }
            }
        }
        
        IsInit = 1;

    }

    //マスタデータ読み込み関数
    private void LoadMasterData<T>(string file, LoadMasterDataCallback<T> callback)
    {
        var data = LocalData.Load<T>(file);
        if(data == null || IsVersionUpFlag)
        {
            LoadingCount++;
            Network.WebRequest.Request<Network.WebRequest.GetString>("https://script.google.com/macros/s/AKfycbwGRi22gwxUvdSzIpofH9xPiWStwiOafoGR8D_IJ_w8RmnPCq3nv7kZ4icBLKgfLLKc/exec?sheet=" + file, Network.WebRequest.ResultType.String, (string json) =>
            {
                var dldata = JsonUtility.FromJson<T>(json);
                LocalData.Save<T>(file, dldata);
                callback(dldata);
                Debug.Log("Network download. : " + file + " / " + json + "/" + dldata);
                --LoadingCount;
            });
        }
        else
        {
            Debug.Log("Local load. : " + file + " / " + data);
            callback(data);
        }
    }
}
