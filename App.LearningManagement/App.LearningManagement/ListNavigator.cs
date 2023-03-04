using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public class ListNavigator<T>
    {
        private int pageSize;
        private int currentPage;
        private List<T> state;
        private int lastPage
        {
            get
            {
                var val = state.Count / pageSize;

                if (state.Count % pageSize > 0)
                {
                    //if there is a partial page at the end, that is the actual last page.
                    val++;
                }

                return val;
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return currentPage > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return currentPage < lastPage;
            }

        }
        public ListNavigator(List<T> list, int pageSize = 5)
        {
            this.pageSize = pageSize;
            this.currentPage = 1;
            state = list;
        }

        public Dictionary<int, T> GoForward()
        {
            if(currentPage + 1 > lastPage)
            {
                throw new PageFaultException("Cannot navigate to the right of the last page in the list!");
            }
            currentPage++;
            return GetWindow();
        }

        public Dictionary<int, T> GoBackward()
        {
            if(currentPage - 1 <= 0)
            {
                throw new PageFaultException("Cannot navigate to the left of the first page in the list!");
            }
            currentPage--;
            return GetWindow();
        }

        public Dictionary<int, T> GoToPage(int page)
        {
            if(page <= 0 || page > lastPage)
            {
                throw new PageFaultException("Cannot navigate to a page outside of the bounds of the list!");
            }
            currentPage = page;
            return GetWindow();
        }

        public Dictionary<int, T> GetCurrentPage()
        {
            return GoToPage(currentPage);
        }

        public Dictionary<int, T> GoToFirstPage()
        {
            currentPage = 1;
            return GetWindow();
        }

        public Dictionary<int, T> GoToLastPage()
        {
            currentPage = lastPage;
            return GetWindow();
        }

        private Dictionary<int, T> GetWindow()
        {//(currentPage*pageSize) + pageSize
            var window = new Dictionary<int, T>();
            for (int i = (currentPage - 1) * pageSize; i < (currentPage - 1) * pageSize + pageSize && i < state.Count; i++)
            {
                window.Add(i + 1, state[i]);
            }

            return window;
        }
    }

    public class PageFaultException : Exception {
        public PageFaultException(string message) : base(message)
        {

        }
    }
}
