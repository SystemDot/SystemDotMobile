using System;
using System.Collections.Generic;
using SystemDot.Core;
using Cirrious.MvvmCross.ViewModels;

namespace SystemDot.Mobile.Mvvm
{
    public class ViewModelLocator
    {
        readonly Dictionary<Type, MvxViewModel> viewModels;

        public ViewModelLocator()
        {
            viewModels = new Dictionary<Type, MvxViewModel>();
        }

        public void SetLocation<TViewModel>(ViewModel<TViewModel> viewModel) 
            where TViewModel : ViewModel<TViewModel>
        {
            viewModels.Add(typeof(TViewModel), viewModel);
        }

        public TViewModel Locate<TViewModel>()
            where TViewModel : ViewModel<TViewModel>
        {
            return viewModels[typeof(TViewModel)].As<TViewModel>();
        }
    }
}