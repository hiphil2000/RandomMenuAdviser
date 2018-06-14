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
        string ret = "";
        string category;
        string menu = null;
        DateTime now = DateTime.Now;
        int date;

        public FoodData Random()
        {
            DataTable menuTable = db.GetFoodData();                 
            DataTable latelyTable = db.GetRandomRequestedData(1);   
            DataTable percentageTable = db.GetPercentageData(ret);       
            int Ran = r.Next(0,menuTable.Rows.Count);              
            FoodData resultFood = new FoodData();

            date = latelyTable.Rows.Count;
                
            // 음식 랜덤을 돌리는 알고리즘입니다.
            while (true)
            {
                 // 5개 이상의 데이터가 있을 때, 조건과 비교하는 알고리즘 입니다.
                if (date > 5)
                {

                    // 최근 메뉴와 랜덤 메뉴 값을 비교합니다.
                    if (!menuTable.Rows[Ran]["음식 명"].ToString().Equals(latelyTable.Rows[0]["음식 명"].ToString()))
                    {
                        // 퍼센트 값을 비교합니다.                        
                        if (int.Parse(percentageTable.Rows[Ran]["PERCENT"].ToString()) > 30)
                        {
                            menu = menuTable.Rows[Ran]["음식 명"].ToString();
                            category = menuTable.Rows[Ran]["카테고리 명"].ToString();

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
                    if (!menuTable.Rows[Ran]["음식 명"].ToString().Equals(latelyTable.Rows[0]["음식 명"].ToString()))
                    {

                        menu = menuTable.Rows[Ran]["음식 명"].ToString();
                        category = menuTable.Rows[Ran]["카테고리 명"].ToString();

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
