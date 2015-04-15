﻿using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catrobat.IDE.Core.Models;
using Catrobat.IDE.Core.Services;
using Catrobat.IDE.Core.Tests.Services;
using Catrobat.IDE.Core.Tests.Services.Storage;
using Catrobat.IDE.Core.Resources;
using Catrobat.IDE.Core.ViewModels;
using Catrobat.IDE.Core.ViewModels.Main;
using Catrobat.IDE.Core.ViewModels.Service;
using Catrobat.IDE.Core.ViewModels.Settings;
using Catrobat.IDE.Core.CatrobatObjects;
using Catrobat.IDE.Core.Tests.SampleData;
using System;
using Catrobat.IDE.Core.Resources.Localization;

namespace Catrobat.IDE.Core.Tests.Tests.ViewModels.Main
{
    [TestClass]
    public class OnlineProgramViewModelTests
    {
        private LocalProgramHeader _currentProgramHeader;

        [ClassInitialize]
        public static void TestClassInitialize(TestContext testContext)
        {
            ServiceLocator.NavigationService = new NavigationServiceTest();
            ServiceLocator.UnRegisterAll();
            ServiceLocator.Register<NotificationServiceTest>(TypeCreationMode.Normal);
            //ServiceLocator.Register<StorageFactoryTest>(TypeCreationMode.Normal);
            //ServiceLocator.Register<StorageTest>(TypeCreationMode.Normal);
            //ServiceLocator.Register<ResourceLoaderFactoryTest>(TypeCreationMode.Normal);
        }

        [TestMethod, TestCategory("ViewModels.Main")]
        public void OpenProgramCommandActionTest()
        {
            Messenger.Default.Register<GenericMessage<LocalProgramHeader>>(this,
                 ViewModelMessagingToken.CurrentProgramHeaderChangedListener, CurrentProgramHeaderChangedMessageAction);
            
            var navigationService = (NavigationServiceTest)ServiceLocator.NavigationService;
            navigationService.PageStackCount = 1;
            navigationService.CurrentNavigationType = NavigationServiceTest.NavigationType.Initial;
            navigationService.CurrentView = typeof(MainViewModel);

            var localProgramHeader = new LocalProgramHeader
            {
                ProjectName = "TestProgram"
            };
            var viewModel = new MainViewModel();
            viewModel.OpenProgramCommand.Execute(localProgramHeader);

            Assert.AreEqual(localProgramHeader, _currentProgramHeader);
            Assert.AreEqual(NavigationServiceTest.NavigationType.NavigateTo, navigationService.CurrentNavigationType);
            Assert.AreEqual(typeof(ProgramDetailViewModel), navigationService.CurrentView);
            Assert.AreEqual(2, navigationService.PageStackCount);
        }

        [TestMethod, TestCategory("ViewModels.Main"), TestCategory("ExcludeGated")]
        public void DeleteLocalProgramActionTest()
        {
            // unchecked private members and unchecked callback-action result
            Assert.AreEqual(0, "result of MessageCallbackAction should be tested - involvs app.savecontext");

            var notificationService = (NotificationServiceTest)ServiceLocator.NotifictionService;
            notificationService.SentMessageBoxes = 0;
            notificationService.SentToastNotifications = 0;
            notificationService.NextMessageboxResult = MessageboxResult.Cancel; //.OK to execute callback

            var viewModel = new MainViewModel();
            string projectName = "TestProgram";
            viewModel.DeleteLocalProgramCommand.Execute(projectName);

            Assert.AreEqual(1, notificationService.SentMessageBoxes);
            Assert.AreEqual(0, notificationService.SentToastNotifications);
        }

        [TestMethod, TestCategory("ViewModels.Main"), TestCategory("ExcludeGated")]
        public void CopyLocalProgramActionTest()
        {
            // unchecked private members and unchecked callback-action result
            Assert.AreEqual(0, "result of MessageCallbackAction should be tested - involvs app.savecontext");

            var notificationService = (NotificationServiceTest)ServiceLocator.NotifictionService;
            notificationService.SentMessageBoxes = 0;
            notificationService.SentToastNotifications = 0;
            notificationService.NextMessageboxResult = MessageboxResult.Cancel; //.OK to execute callback

            var viewModel = new MainViewModel();
            string projectName = "TestProgram";
            viewModel.CopyLocalProgramCommand.Execute(projectName);

            Assert.AreEqual(1, notificationService.SentMessageBoxes);
            Assert.AreEqual(0, notificationService.SentToastNotifications);
        }

        [TestMethod, TestCategory("ViewModels.Main")]
        public void CreateNewProgramActionTest()
        {
            var navigationService = (NavigationServiceTest)ServiceLocator.NavigationService;
            navigationService.PageStackCount = 1;
            navigationService.CurrentNavigationType = NavigationServiceTest.NavigationType.Initial;
            navigationService.CurrentView = typeof(MainViewModel);

            var viewModel = new MainViewModel();
            viewModel.CreateNewProgramCommand.Execute(null);

            Assert.AreEqual(NavigationServiceTest.NavigationType.NavigateTo, navigationService.CurrentNavigationType);
            Assert.AreEqual(typeof(AddNewProgramViewModel), navigationService.CurrentView);
            Assert.AreEqual(2, navigationService.PageStackCount);
        }

        [TestMethod, TestCategory("ViewModels.Main")]
        public void SettingsActionTest()
        {      
            var navigationService = (NavigationServiceTest)ServiceLocator.NavigationService;
            navigationService.PageStackCount = 1;
            navigationService.CurrentNavigationType = NavigationServiceTest.NavigationType.Initial;
            navigationService.CurrentView = typeof(MainViewModel);

            var viewModel = new MainViewModel();
            viewModel.SettingsCommand.Execute(null);

            Assert.AreEqual(NavigationServiceTest.NavigationType.NavigateTo, navigationService.CurrentNavigationType);
            Assert.AreEqual(typeof(SettingsViewModel), navigationService.CurrentView);
            Assert.AreEqual(2, navigationService.PageStackCount);
        }

        [TestMethod, TestCategory("ViewModels.Main")]
        public void OnlineProgramTapActionTest()
        {
            var navigationService = (NavigationServiceTest)ServiceLocator.NavigationService;
            navigationService.PageStackCount = 1;
            navigationService.CurrentNavigationType = NavigationServiceTest.NavigationType.Initial;
            navigationService.CurrentView = typeof(MainViewModel);

            var onlineProgramHeader = SampleLoader.GetSampleOnlineProjectHeader();
            var viewModel = new MainViewModel();
            viewModel.OnlineProgramTapCommand.Execute(onlineProgramHeader);

            Assert.AreEqual(viewModel.SelectedOnlineProgram, onlineProgramHeader);
            Assert.AreEqual("5", viewModel.SelectedOnlineProgram.Downloads);
            Assert.AreEqual(ApplicationResources.POCEKTCODE_BASE_ADDRESS + "resources/thumbnails/1769_small.png", viewModel.SelectedOnlineProgram.ScreenshotSmall);
            Assert.AreEqual(NavigationServiceTest.NavigationType.NavigateTo, navigationService.CurrentNavigationType);
            Assert.AreEqual(typeof(OnlineProgramViewModel), navigationService.CurrentView);
            Assert.AreEqual(2, navigationService.PageStackCount);
        }

        [TestMethod, TestCategory("ViewModels.Main")]
        public void LicenseActionTest()
        {
            var navigationService = (NavigationServiceTest)ServiceLocator.NavigationService;
            navigationService.PageStackCount = 1;
            navigationService.CurrentNavigationType = NavigationServiceTest.NavigationType.Initial;
            navigationService.CurrentView = typeof(MainViewModel);

            var viewModel = new MainViewModel();
            viewModel.LicenseCommand.Execute(null);

            Assert.AreEqual(NavigationServiceTest.NavigationType.NavigateTo, navigationService.CurrentNavigationType);
            Assert.AreEqual(typeof(InformationViewModel), navigationService.CurrentView);
            Assert.AreEqual(2, navigationService.PageStackCount);
        }

        [TestMethod, TestCategory("ViewModels.Main")]
        public void AboutActionTest()
        {
            var navigationService = (NavigationServiceTest)ServiceLocator.NavigationService;
            navigationService.PageStackCount = 1;
            navigationService.CurrentNavigationType = NavigationServiceTest.NavigationType.Initial;
            navigationService.CurrentView = typeof(MainViewModel);

            var viewModel = new MainViewModel();
            viewModel.AboutCommand.Execute(null);

            Assert.AreEqual(NavigationServiceTest.NavigationType.NavigateToWebPage, navigationService.CurrentNavigationType);
            Assert.AreEqual("http://www.catrobat.org/", navigationService.CurrentView);
            Assert.AreEqual(1, navigationService.PageStackCount);
        }

        [TestMethod, TestCategory("ViewModels.Main")]
        public void ShowMessagesActionDownloadMessageTest()
        {
            var notificationService = (NotificationServiceTest)ServiceLocator.NotifictionService;
            notificationService.SentMessageBoxes = 0;
            notificationService.SentToastNotifications = 0;

            var viewModel = new MainViewModel();
            string programName = "TestProgram";
            var messageContext = new GenericMessage<string>(programName);
            Messenger.Default.Send(messageContext, ViewModelMessagingToken.DownloadProgramStartedListener);

            viewModel.ShowMessagesCommand.Execute(null);

            Assert.AreEqual(0, notificationService.SentMessageBoxes);
            Assert.AreEqual(1, notificationService.SentToastNotifications);
            Assert.AreEqual(String.Format(AppResources.Main_DownloadQueueMessage, programName), notificationService.LastNotificationMessage);
        }

        [TestMethod, TestCategory("ViewModels.Main"), TestCategory("ExcludeGated")]
        public void ShowMessagesActionUploadMessageTest()
        {
            var notificationService = (NotificationServiceTest)ServiceLocator.NotifictionService;
            notificationService.SentMessageBoxes = 0;
            notificationService.SentToastNotifications = 0;

            var viewModel = new MainViewModel();
            string programName = "TestProgram";
            var messageContext = new GenericMessage<string>(programName);
            Messenger.Default.Send(messageContext, ViewModelMessagingToken.UploadProgramStartedListener);

            viewModel.ShowMessagesCommand.Execute(null);

            Assert.AreEqual(0, notificationService.SentMessageBoxes);
            Assert.AreEqual(1, notificationService.SentToastNotifications);
            Assert.AreEqual(String.Format(AppResources.Main_UploadQueueMessage, programName), notificationService.LastNotificationMessage);
        }

        [TestMethod, TestCategory("ViewModels.Main")]
        public void GoBackActionTest()
        {
            var navigationService = (NavigationServiceTest)ServiceLocator.NavigationService;
            navigationService.PageStackCount = 1;
            navigationService.CurrentNavigationType = NavigationServiceTest.NavigationType.Initial;
            navigationService.CurrentView = typeof(MainViewModel);

            var viewModel = new MainViewModel();
            viewModel.GoBackCommand.Execute(null);

            Assert.AreEqual(NavigationServiceTest.NavigationType.NavigateBack, navigationService.CurrentNavigationType);
            Assert.AreEqual(null, navigationService.CurrentView);
            Assert.AreEqual(0, navigationService.PageStackCount);
        }


        #region MessageActions
        private void CurrentProgramHeaderChangedMessageAction(GenericMessage<LocalProgramHeader> message)
        {
            _currentProgramHeader = message.Content;
        }

        #endregion
    }
}
