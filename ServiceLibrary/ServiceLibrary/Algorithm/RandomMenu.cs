using ServiceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Algorithm
{
    public class RandomMenu
    {
        Random r = new Random();
        Database db = new Database();
        string ret;
        string category;
        string menu = null;
        DateTime now = DateTime.Now;
        int date;

        public FoodData Random()
        {
            DataTable menuTable = db.GetFoodData();                     // 음식을 가져옵니다.
            DataTable latelyTable = db.GetRandomRequestedData(1);       // 어제 음식을 가져옵니다.
            DataTable percentageTable = db.GetPercentageData(ret);      // 카테고리의 퍼센트를 가져옵니다.
            DataTable categoryTable = db.GetCategoryData();             // 카테고리 리스트를 가져옵니다.
            int Ran = r.Next(0,10);    // 행을 기준으로 랜덤을 돌리고 변수에 저장합니다.
            FoodData resultFood = null;

            // 5개 이상의 데이터가 있는지 확인하는 반복문입니다.
            for (int j = 0; j <= 6; j++)
            {   
                int.Parse(latelyTable.Rows[j]["음식 명"].ToString());
                if (j < 6) { date = j; }
                else { date = 6; }
            }

            // 음식 랜덤을 돌리는 알고리즘입니다.
            while (true)
            {
                 // 5개 이상의 데이터가 있을 때, 조건과 비교하는 알고리즘 입니다.
                if (date > 6)
                {

                    // 최근 메뉴와 랜덤 메뉴 값을 비교합니다.
                    if (menuTable.Rows[Ran]["음식 명"] != latelyTable.Rows[0]["음식 명"])
                    {
                        // 퍼센트 값을 비교합니다.
                        
                            if (int.Parse(percentageTable.Rows[Ran]["PERCENT"].ToString()) > 30)
                            {


                                    menu = menuTable.Rows[Ran]["음식 명"].ToString();
                                    category = categoryTable.Rows[Ran]["category"].ToString();

                                    db.SetRandomRequestedData(now,category, menu);

                                    ret = category;
                                    resultFood.CategoryName = ret;
                                    resultFood.FoodName = menu;
                                    return resultFood;
                            }

                            else { }  

                    }
                }

                // 5개 이상의 데이터가 없을 때, 조건과 비교하는 알고리즘입니다.
                else
                {
                    // 최근 메뉴와 랜덤 메뉴 값을 비교합니다.
                    if (menuTable.Rows[Ran]["음식 명"] != latelyTable.Rows[0]["음식 명"])
                    {
                        db.SetRandomRequestedData(now, category, menu);

                        ret = category;
                        resultFood.CategoryName = ret;
                        resultFood.FoodName = menu;
                        return resultFood;
                    }
                    
                }

            }

        }

    }
}
