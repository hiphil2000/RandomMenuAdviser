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
        string d;
 

        public string Random()
        {
            DataTable Menu = db.GetFoodData();
            DataTable Yesturday = db.GetFoodData();
            DataTable Percentage =db.GetPercentageData(d);
           
            while (true)
            {
                if(Menu != Yesturday)
                {
                    if(int.Parse(Percentage.Rows[0]["PERCENT"].ToString()) > 30)
                    {
                        return d;
                    }
                }
                //int.parse(dt.columns[0])
            }
        }
        
            //여기에 알고리즘 추가.
            
    }

}
