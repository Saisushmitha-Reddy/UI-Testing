using BionicApp.Components;
using BionicApp.Data;
using BionicApp.Interface;
using BionicApp.Services;
using BionicApp.Utils;
using Bunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using Ossur.Bionics.Common;
using Ossur.Bionics.Common.Adapters;
using Ossur.Bionics.Common.Maui.Services;
using Ossur.Bionics.Common.Maui.Utils;
using Ossur.Bionics.Common.Models;
using Ossur.Bionics.Common.Services;
using System.Collections.ObjectModel;

namespace BionicAppTestRunner.BionicAppUi
{
    public class BionicAppUiTestBase : TestContext
    {
        public BionicAppUiTestBase()
        {

            Services.AddLocalization();
            var db = Path.Combine(FileSystem.Current.AppDataDirectory,
               "BionicAppTestRunner-" + BionicDbContext.DB_VERSION + ".db");
            Services.AddDbContext<UserAppDbContext>(options
                => options.UseSqlite($"Data Source = {db}"), ServiceLifetime.Transient);
            Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            Services.AddSingleton(Manager.Instance);
            Services.AddScoped<IAdapterOptions, AppAdapterOptions>();
            Services.AddSingleton<AppSettings>();
            Services.AddSingleton<IAdapter,BionicAdapter>();
            Services.AddSingleton<BluetoothConnection>();
            Services.AddSingleton<INavigationAdapter, NavigationAdapter>();
            Services.AddSingleton<DataCollectionAdapter>();
            Services.AddSingleton<CustomTheme>();
            Services.AddScoped<IWindowDimensionAdapter, WindowDimensionAdapter>();
            Services.AddSingleton<NetworkAdapter>();
            Services.AddSingleton<ICloudOperation, CloudOperation>();
            var hashService = Manager.Instance.ServiceProvider.GetService<IHashService>();
            Services.AddSingleton<ISocialSitesAuthentication, FBAuthenticationService>(_ => new FBAuthenticationService(hashService));
            Services.AddSingleton<INotificationService, NotificationSerivce>();
            Services.AddSingleton<IClientInfoService, Ossur.Bionics.Common.Maui.Services.MauiClientInfoService>();
            Services.AddSingleton<LocalizationAdapter>();
            Services.AddOssurBionicsCommon(config => config.UseDbContext<UserAppDbContext>());
            var jsRuntimeMock = new Mock<IJSRuntime>();
            Services.AddSingleton(p => jsRuntimeMock.Object);

        }

        public void mydevicemethod()
        {
            var service = Services.GetService<DataCollectionAdapter>();
            var periheral = new Ossur.Bionics.Common.Models.Peripherals.Peripheral("390775");
            periheral.Adapter = Services.GetService<IAdapter>();
            var model = new ConnectedDevicesModel
            {
                IsExpanded = true,
                Peripheral = periheral,
                TokenSource = new CancellationTokenSource(),
                Timer = new PeriodicTimer(TimeSpan.FromSeconds(5)),
                IsProcessing = true
                
            };
            service.ConnectedDevicesModels.Add(model);
        }

        public void Mydevicemethod2()
        {

            var service = Services.GetService<DataCollectionAdapter>();
            var periheral = new Ossur.Bionics.Common.Models.Peripherals.Peripheral("390775");
            periheral.Adapter = Services.GetService<Ossur.Bionics.Common.Adapters.IAdapter>();
            var model = new ConnectedDevicesModel
            {
                IsExpanded = true,
                Peripheral = periheral,
                TokenSource = new CancellationTokenSource(),
                Timer = new PeriodicTimer(TimeSpan.FromSeconds(5)),
                IsProcessing = true
            };
            service.ConnectedDevicesModels.Add(model);
            service.ConnectedSelectedItem = model;
            service.ConnectedSelectedItem.AnkleSettings ??= new AnkleAlignment
            {
                AnkleValue = 0,
                AngleHistory = new ObservableCollection<AnkleAlignmentHistory>()
            };
            service.ConnectedSelectedItem.StairSettings ??= new StairAlignment
            {
                AscentValue = "0",
                DecentValue = "0",
                AscentVariable = new Variable(),
                DecentVariable = new Variable(),
                StairAngleHistory = new ObservableCollection<StairAngleHistory>()
            };
            if (model.Peripheral.IsConnected())
            {
                model.Peripheral.GetVariable(BleConstants.STAIR_ADAPTION_DOWN, (oo, ee) =>
                {
                    if (ee.Exception == null)
                    {
                        service.ConnectedSelectedItem.StairSettings.DecentVariable = ee.Variable;
                        service.ConnectedSelectedItem.StairSettings.DecentValue = ee.Variable.StringValue;
                    }
                });

                model.Peripheral.GetVariable(BleConstants.STAIR_ADAPTION_UP, (oo, ee) =>
                {
                    if (ee.Exception == null)
                    {
                        service.ConnectedSelectedItem.StairSettings.AscentVariable = ee.Variable;
                        service.ConnectedSelectedItem.StairSettings.AscentValue = ee.Variable.StringValue;
                    }
                });
            }
        }
    }
}
