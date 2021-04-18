﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PaginationWPF.pg
{
    public class ChangeNotifierPG : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
