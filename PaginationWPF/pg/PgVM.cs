using System;
using System.Windows.Input;

namespace PaginationWPF.pg
{
    public class PgVM : ChangeNotifierPG
    {
        public PgVM()
        {
            ChangePageCommand = new ChangePageCommand(ChangePage);
        }

        public ICommand ChangePageCommand { get; set; }

        private PgModel pgModel;

        public PgModel PgModel
        {
            get { return pgModel; }
            set { pgModel = value; OnPropertyChanged(); }
        }



        public void ChangePage(object obj)
        {
            int newpage = PgModel.CurrentPage;
            try
            {
                int param = int.Parse((string)obj);
                
                switch (param)
                {
                    case 0:
                        newpage--;
                        if (newpage <  2)
                        {
                            newpage = 1;
                        }
                        break;
                    case 1:
                        newpage++;
                        if (newpage > PgModel.TotalPages)
                        {
                            newpage = PgModel.TotalPages;
                        }
                        break;
                    default:                        
                        break;
                }
            }
            catch (Exception)
            {

                
            }
            PgModel.CurrentPage = newpage;
        }



        public void RecalculatePagination()
        {
            try
            {
                
                if (PgModel.PerPage < 1)
                {
                    PgModel.PerPage = 1;
                }

                if (PgModel.PerPage > PgModel.TotalItems)
                {
                    PgModel.PerPage = PgModel.TotalItems;
                }
                
                PgModel.TotalPages = PgModel.TotalItems / PgModel.PerPage;

                if (PgModel.CurrentPage > PgModel.TotalPages)
                {
                    PgModel.CurrentPage = PgModel.TotalPages;
                }
            }
            catch (Exception)
            {

                
            }
        }


        public void seed(PgModel PG)
        {
            PgModel = PG;
        }



    }
}
