﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public ViewModelBase? CurrentMainContentViewModel => new LayoutViewModel();
    }
}
