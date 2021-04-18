using System;
using System.Windows;
using System.Windows.Controls;

namespace PaginationWPF.pg
{
    /// <summary>
    /// Interaction logic for PaginationVW.xaml
    /// </summary>
    public partial class PaginationVW : UserControl
    {
        public PaginationVW()
        {
            InitializeComponent();
        }

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number;
                bool success = Int32.TryParse(((TextBox)sender).Text, out number);
                if (success)
                {
                    ((PgVM)this.DataContext).RecalculatePagination();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
