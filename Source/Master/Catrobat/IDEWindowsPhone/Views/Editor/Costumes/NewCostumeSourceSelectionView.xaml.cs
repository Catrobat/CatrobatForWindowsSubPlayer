﻿using System.ComponentModel;
using System.Windows.Navigation;
using Catrobat.IDEWindowsPhone.ViewModel.Editor.Costumes;
using Microsoft.Phone.Controls;
using Microsoft.Practices.ServiceLocation;

namespace Catrobat.IDEWindowsPhone.Views.Editor.Costumes
{
    public partial class NewCostumeSourceSelectionView : PhoneApplicationPage
    {
        private readonly AddNewCostumeViewModel _viewModel = ServiceLocator.Current.GetInstance<AddNewCostumeViewModel>();

        public NewCostumeSourceSelectionView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _viewModel.ResetViewModelCommand.Execute(null);
            base.OnNavigatedTo(e);
        }
    }
}