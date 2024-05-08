using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VarietyStoreManager : MonoBehaviour
{   
    

    private string con = "Server=localhost;Database=projfth;Uid=root;Pwd=1234;Charset=utf8mb4";

    
    public GameObject BuyListPrefab; // BUYList 이미지 프리팹 참조
    public GameObject buyList; // BUYList 이미지 참조
    public Transform buyListLayout; // BUYList들이 들어갈 레이아웃 참조
    private List<ItemListVO> ItemList;
    private int ITEMPR = 0;
    public GameObject BuySuccess;
    public GameObject BuyFail;
    public GameObject CheckBuyMenu;
    private VarietyStoreDAO varietystoreDao;




    public void Start()
    {
           ItemList = LoadData();
            varietystoreDao = GetComponent<VarietyStoreDAO>();
           
         foreach (var dic in ItemList)
            {
                // 이미지 프리팹 인스턴스화
                GameObject buyListInstance = Instantiate(BuyListPrefab, buyListLayout);
                buyListInstance.name = "itemlist" + dic.ITEMNO;
                // 이미지 오브젝트에 딕셔너리 값 설정
                Text textComponent = buyListInstance.GetComponentInChildren<Text>();
                if (textComponent!= null)
                {
                    textComponent.text =  dic.ITEMNO + " : " + dic.ITEMNAME;
                }
            }
            buyList.SetActive(false);        
    }

 public List<ItemListVO> LoadData()
    {
        List<ItemListVO> ItemList = new List<ItemListVO>();
        var sql = "SELECT SEQ, ITEMNAME, ITEMPR " +
                    "FROM varietystorebuylist ";
        using (MySqlConnection connection = new MySqlConnection(con))
        {   
            connection.Open();
            using (MySqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = sql;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       ItemListVO iv = new ItemListVO();
                        iv.ITEMNO = (int)reader["SEQ"];
                        iv.ITEMNAME = (string)reader["ITEMNAME"];
                        iv.ITEMPR = (int)reader["ITEMPR"];

                        ItemList.Add(iv);
                    }
                }
            }
        }
        // foreach(var list in ItemList)
        // {
        //     Debug.Log(list.ITEMNAME);
        //     Debug.Log(list.ITEMNAME);
        //     Debug.Log(list.ITEMPR);
        // }
        return ItemList;
                
    }




    public void GetListValue()
    {
    GameObject ListValue = EventSystem.current.currentSelectedGameObject;
    string objectName = ListValue.name;
    string indexString = objectName.Replace("itemlist", "");
    Debug.Log(indexString);
    int index = int.Parse(indexString);
    ItemListVO iv = ItemList[index-1];
         ITEMPR = iv.ITEMPR;
        Debug.Log("계산 금액 " + ITEMPR);
    }


    public void ProcessPayment()
    {
    int userCash = varietystoreDao.GetUserInfo();
    int NowCash = userCash - ITEMPR;
    Debug.Log("계산 금액 " + ITEMPR);

    Debug.Log("DB 유저 현금 " + userCash);
    Debug.Log("계산 후 금액 " + NowCash);
    if (NowCash > 0)
    {
        varietystoreDao.UpdateUserCash(NowCash);
        BuySuccessOn();
    }
    else
    {
        Debug.Log("Not enough cash!");
        BuyFailOn();

    }
    }



    public void OnClickReturn()
    {
        SceneManager.LoadScene("OutingScene");
    }


 public void OpenBuy()
   {
        ActivateBuyMenu(); // 구매 메뉴를 엶
    }

    public void CloseBuy()
   {
        DeactivateBuyMenu   (); // 구매 메뉴를 엶
    }

    public GameObject VarietyStoreBuyBackGround; // 설정 패널 오브젝트

    private void ActivateBuyMenu()    //작동시 활성화
    {
        VarietyStoreBuyBackGround.SetActive(true);
    }

    private void DeactivateBuyMenu()   //작동시 비활성화
    {
        VarietyStoreBuyBackGround.SetActive(false);
    }




      public void OpenSell()
    {
        ActivateSellMenu(); // 판매 메뉴를 엶
    }

    public void CloseSell()
    {
        DeactivateSellMenu(); // 판매 메뉴를 엶
    }

    public GameObject VarietyStoreSellBackGround; // 설정 패널 오브젝트

   
    private void ActivateSellMenu()    //작동시 활성화
    {
        VarietyStoreSellBackGround.SetActive(true);
    }

    private void DeactivateSellMenu()   //작동시 비활성화
    {
        VarietyStoreSellBackGround.SetActive(false);
    }


        public void OpenCheckBuy()
        {
         ActivateMenu(CheckBuyMenu);
        }
        public void CloseCheckBuy()
        {
         DeactivateMenu(CheckBuyMenu); 
        }

         public void BuySuccessOn()
        {
            ActivateMenu(BuySuccess);
        }

        public void BuySuccessOut()
        {
            DeactivateMenu(BuySuccess);
        }
        public void BuyFailOn()
        {
            ActivateMenu(BuyFail);
        }

        public void BuyFailOut()
        {
            DeactivateMenu(BuyFail);
        }
        private void ActivateMenu(GameObject menu)
        {
            menu.SetActive(true);
        }

        private void DeactivateMenu(GameObject menu)
        {
            menu.SetActive(false);
        }

    
}
    
    
