using System.Collections.Generic;

namespace DiablerieLoot
{
    public static class ListExtensions
    {

        // A bad hack. This program was first written in Python, which has a "Extend" function that I used. 
        // I didn't want to fix my bad and lazy implementation, so I made the extend name available here as well
        public static void Extend<T>(this List<T> list, List<T> addList, int n)
        {
            for (int i = 0; i < n; i++)
            {
                list.AddRange(addList);
            }
        }
    }
}
