﻿using System.Windows.Input;
using Catrobat.IDE.Core.CatrobatObjects;
using Catrobat.IDE.Core.Models;
using Catrobat.IDE.Core.Resources;
using Catrobat.IDE.Core.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Catrobat.IDE.Core.ViewModels.Main
{
    public class InformationViewModel : ViewModelBase
    {
        #region Private Members

        #endregion

        #region Properties

        #endregion

        #region Commands and Actions

        public ICommand LicenseCommand { get; private set; }
        private void LicenseAction()
        {
            ServiceLocator.NavigationService.NavigateToWebPage(
                ApplicationResources.CATROBAT_LICENSES_URL);
        }

        public ICommand TouCommand { get; private set; }
        private void TouAction()
        {
            ServiceLocator.NavigationService.NavigateToWebPage(
                ApplicationResources.CATROBAT_TOU_URL);
        }

        #endregion

        #region CommandCanExecute

        #endregion

        #region Message Actions

        #endregion

        public InformationViewModel()
        {
            LicenseCommand = new RelayCommand(LicenseAction);
            TouCommand = new RelayCommand(TouAction);
        }
    }
}