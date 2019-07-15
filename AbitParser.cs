using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace Parser.Core
{
    class AbitParser : IParser<string[]>
    {
        private string ourScore = "187.4";
        public static int amountOfStudentsFirst = 0;

        public string[] Parse(IHtmlDocument document, string prio)
        {
            //TODO 
            string searchQuery = "application-status application-status-";
            var list = new List<string>();
            
            for (int i=6;i>=1;i--)
            {
                bool checkedInt = false;
                string currentSearchQuery = searchQuery + i.ToString();
                var allInfo = document.QuerySelectorAll("tr").Where(number => number.ClassName != null && number.ClassName.Contains(currentSearchQuery));

                
                foreach (var number in allInfo)
                {
                    var temporary = number.QuerySelectorAll("td");
                    int counter = 0;
                    string priority = "0";
                    string username = "";

                    foreach (var item in temporary)
                    {
                        if (counter == 1)
                        {
                            username = item.TextContent.Trim();
                        }
                        if (counter == 2)
                        {
                            priority = item.TextContent.Trim();
                        }
                        if (counter == 3)
                        {
                            string score = item.TextContent.Trim();
                            int compare = score.CompareTo(ourScore);
                            bool result = compare > 0 ? true : false;
                            if (priority == prio && result)
                            {
                                if (!checkedInt)
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            list.Add("Статус: Заява надійшла з сайту");
                                            break;
                                        case 5:
                                            list.Add("Статус: Зареєстровано");
                                            break;
                                        case 6:
                                            list.Add("Статус: Допущено");
                                            break;
                                    }
                                    checkedInt = true;
                                }
                                
                                string newString = "";
                                newString += Convert.ToString(amountOfStudentsFirst + 1) + "\t      ";
                                newString += priority + "\t          ";
                                newString += score + "\t";
                                newString += username + "\t";
                                list.Add(newString);
                                amountOfStudentsFirst++;
                            }
                        }
                        counter++;
                    }

                }
                
            }
            return list.ToArray();
        }
    }
}
