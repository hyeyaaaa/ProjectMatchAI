namespace Script.UI.Outing
{
    using global::System;
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.SceneManagement;
    using UnityEngine.UIElements;

    public class RestaurantManager : MonoBehaviour
    {
        private static RestaurantManager instance; // ESC�޴��� �ν��Ͻ�
        public GameObject EatMenu; // �Ļ� �г� ������Ʈ
        public GameObject SellMenu; // �Ǹ� �г� ������Ʈ
        public GameObject BuyMenu; // ���� �г� ������Ʈ
        public GameObject ChiceUi; // ���� �г� ������Ʈ
     
        private bool EatMenuActive; // �Ļ� ȭ�� Ȱ��ȭ ����
        private bool SellMenuActive; // �Ǹ� ȭ�� Ȱ��ȭ ����
        private bool BuyMenuActive; // ���� ȭ�� Ȱ��ȭ ����

        public static RestaurantManager Instance
        {
            get
            {
                // �ν��Ͻ��� ���ٸ� ���� ����
                if (instance == null)
                {
                    instance = FindObjectOfType<RestaurantManager>();

                    // ���� �޴��� ���ٸ� ���� ����
                    if (instance == null)
                    {
                        var obj = new GameObject();
                        obj.name = "EatMenu";
                        obj.name = "SellMenu";
                        obj.name = "BuyMenu";
                        obj.name = "ChiceUi";

                        
                        instance = obj.AddComponent<RestaurantManager>();
                    }
                }

                return instance;
            }
        }
        public void OnClickReturn()
        {
            SceneManager.LoadScene("OutingScene");
        }
        public void OnClickEating()
        {

            ActivateEatMenu();
        }
        public void OnClickEatOuting()
            {
                DeactivateEatMenu();
            }

        
        public void OnClickSelling()
        {

            // �ǸŸ޴��� Ȱ��ȭ �Ǿ����� �ʴٸ�
          
                ActivateSellMenu();
            }
        public void OnClickSellOuting()

        {
            DeactivateSellMenu();
            }

        
        public void OnClickBuying()
        {
            // ���Ÿ޴��� Ȱ��ȭ �Ǿ����� �ʴٸ�
                ActivateBuyMenu();
            }
        public void OnClickBuyOuting()

        {
            DeactivateBuyMenu();
            }

        public void OnClickChiceUi()
        {

            // ���Ÿ޴��� Ȱ��ȭ �Ǿ����� �ʴٸ�
            ActivateChiceUi();

        }
        public void OnClickChiceUiOut()

        {
            DeactivateChiceUi();
        }

       
        




        private void ActivateEatMenu()
        {
            EatMenu.SetActive(true);
        }

        private void DeactivateEatMenu()
        {
            EatMenu.SetActive(false);
        }
        private void ActivateSellMenu()
        {
            SellMenu.SetActive(true);
        }

        private void DeactivateSellMenu()
        {
            SellMenu.SetActive(false);
        }
        private void ActivateBuyMenu()
        {
            BuyMenu.SetActive(true);
        }

        private void DeactivateBuyMenu()
        {
            BuyMenu.SetActive(false);
        }

        private void ActivateChiceUi()
        {
            ChiceUi.SetActive(true);
        }

        private void DeactivateChiceUi()
        {
            ChiceUi.SetActive(false);
        }
       
    }
}
