using System;

namespace PaginationWPF.pg
{
    public class PgModel : ChangeNotifierPG
    {
        private int currentPage;

        public int CurrentPage
        {
            get { return currentPage; }
            set 
            {
                if (!(value > TotalPages && value < 1))
                {
                    currentPage = value;
                    OnPropertyChanged();
                }
            }
        }


        private int totalPages;

        public int TotalPages
        {
            get { return totalPages; }
            set { totalPages = value; OnPropertyChanged(); }
        }


        private int perPage;

        public int PerPage
        {
            get { return perPage; }
            set { perPage = value; OnPropertyChanged(); }
        }


        private int totalItems;

        public int TotalItems
        {
            get { return totalItems; }
            set { totalItems = value; OnPropertyChanged(); }
        }



        public PgModel(int perpage, int total)
        {
            intiate(perpage, total);
        }

        private void intiate(int perpage, int total)
        {
            CurrentPage = 1;
            PerPage = perpage;
            TotalItems = total;
            
            int remainder;
            TotalPages = TotalItems / PerPage;
            Math.DivRem(TotalItems, PerPage, out remainder);
            if (remainder > 0)
            {
                TotalPages += 1;
            }
        }
    }
}
