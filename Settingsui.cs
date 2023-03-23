using AngleSharp.Css.Values;
using BionicApp.Data;
using BionicApp.Pages.Add_Device.My_Devices.DeviceSettings;
using BionicApp.Services;
using Bunit;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Ossur.Bionics.Common;
using System.Globalization;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class Settingsui : BionicAppUiTestBase
    {
        [Fact]
        public void checkmainStack()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            Assert.Equal(2, mudStack.Instance.Spacing);
            Assert.Equal("pa-4",mudStack.Instance.Class);
            Assert.False(mudStack.Instance.Row);
        }
        [Fact]
        public void checkMudGrid()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudGrid = mudStack.FindComponent<MudGrid>();
            Assert.Equal(2, mudGrid.Instance.Spacing);
            Assert.Equal(Justify.FlexStart, mudGrid.Instance.Justify);
        }
        [Fact]
        public void check1stMudItemInMudGrid()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudGrid = mudStack.FindComponent<MudGrid>();
            var mudItem = mudGrid.FindComponent<MudItem>();
            var MudIconBut = mudItem.FindComponent<MudIconButton>();
            Assert.Equal("<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M20 11H7.83l5.59-5.59L12 4l-8 8 8 8 1.41-1.41L7.83 13H20v-2z\"/>", MudIconBut.Instance.Icon);
            var nav =MudIconBut.Services.GetRequiredService<NavigationManager>();
            Assert.Equal("http://localhost/", nav.Uri);
        }

        [Fact]
        public void checkDeviceDisplayName()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudGrid = mudStack.FindComponent<MudGrid>();
            var mudItem = mudGrid.FindComponents<MudItem>()[1];
            var MudText = mudItem.FindComponent<MudText>();
            Assert.Equal("pa-2", MudText.Instance.Class);
            Assert.Equal("text-overflow:ellipsis;", MudText.Instance.Style);
            Assert.Equal(Align.Center,MudText.Instance.Align);
            Assert.Equal(Typo.h6, MudText.Instance.Typo);
            MudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-h6 mud-typography-align-center pa-2\" style=\"text-overflow:ellipsis;\">390775</h6>");
        }
        [Fact]
        public async void checkSettingText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudText = mudStack.FindComponents<MudText>()[1];
            Assert.Equal("pl-2", MudText.Instance.Class);
            Assert.Equal(Align.Left, MudText.Instance.Align);
            Assert.Equal(Typo.h5, MudText.Instance.Typo);
            MudText.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left pl-2\"><b>Settings</b></h5>");
        }
        [Fact]
        public void Check1stMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[0];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
        }
        [Fact]
        public async void CheckDisplayname()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[0];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            mudText.Find("p").MarkupMatches("<p class=\"mud-typography mud-typography-body1 mud-text pl-2\">Display Name</p>");
        }
        [Fact]
        public void CheckDevicenameinMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[0];
            var mudInput = MudPaper.FindComponent<MudInput<string>>();
            Assert.Equal("deviceName pl-2 pr-2",mudInput.Instance.Class);
            Assert.Equal("390775", mudInput.Instance.Value);
            Assert.True(mudInput.Instance.DisableUnderLine);
        }
        [Fact]
        public async void checkPreferencesText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudText = mudStack.FindComponents<MudText>()[3];
            Assert.Equal("mud-text pl-2 ma-2", MudText.Instance.Class);
            Assert.Equal(Align.Left, MudText.Instance.Align);
            Assert.Equal(Typo.h5, MudText.Instance.Typo);
            MudText.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left mud-text pl-2 ma-2\">Preferences</h5>");
        }
        [Fact]
        public void Check2ndMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[1];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckAutoConnectText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[1];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pl-2\">Autoconnect</h6>");
        }
        [Fact]
        public void CheckAutoConnectSwitch()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[1];
            var mudSwitch = MudPaper.FindComponent<MudSwitch<bool>>();
            Assert.Equal("pa-0 ma-0", mudSwitch.Instance.Class);
            Assert.Equal(MudBlazor.Color.Primary, mudSwitch.Instance.Color);
            mudSwitch.Instance.Checked = true;
            Assert.True(mudSwitch.Instance.Checked);
        }
        [Fact]
        public void Check3rdMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[2];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckRelaxmodeText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[2];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pl-2\">Relax Mode</h6>");
        }
        [Fact]
        public void CheckRelaxModeSwitch()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[2];
            var mudSwitch = MudPaper.FindComponent<MudSwitch<bool>>();
            Assert.Equal("pa-0 ma-0", mudSwitch.Instance.Class);
            Assert.Equal(MudBlazor.Color.Primary, mudSwitch.Instance.Color);
            Assert.False(mudSwitch.Instance.Checked);
            mudSwitch.Instance.Checked = true;
            Assert.True(mudSwitch.Instance.Checked);
        }
        [Fact]
        public void Check4thMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[3];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckChairexitText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[3];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pl-2\">Chair Exit Mode</h6>");
        }
        [Fact]
        public void CheckChairexitSwitch()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[3];
            var mudSwitch = MudPaper.FindComponent<MudSwitch<string>>();
            Assert.Equal("pa-0 ma-0", mudSwitch.Instance.Class);
            Assert.Equal(MudBlazor.Color.Primary, mudSwitch.Instance.Color);
            Assert.Null(mudSwitch.Instance.Checked);
            mudSwitch.Instance.Checked = "true";
            Assert.Equal("true", mudSwitch.Instance.Checked);
        }
        [Fact]
        public void Check5thMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[4];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckVibrationText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[4];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pa-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pa-2\">Vibration Feedback</h6>");
        }
        [Fact]
        public void CheckVibrationValueText()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[4];
            var mudText = MudPaper.FindComponents<MudText>()[1];
            Assert.Equal("mud-text pa-2 mr-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pa-2 mr-2\">50%</h6>");
        }
        [Fact]
        public void Check6thMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[5];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckAnkleAlignmnetText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[5];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pa-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pa-2\">Ankle Alignment</h6>");
        }
        [Fact]
        public void CheckAnkleValueText()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[5];
            var mudText = MudPaper.FindComponents<MudText>()[1];
            Assert.Equal("mud-text pa-2 mr-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pa-2 mr-2\">0°</h6>");
        }
        [Fact]
        public async void checkOperationsText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudText = mudStack.FindComponents<MudText>()[11];
            Assert.Equal("mud-text pl-2 ma-2", MudText.Instance.Class);
            Assert.Equal(Align.Left, MudText.Instance.Align);
            Assert.Equal(Typo.h5, MudText.Instance.Typo);
            MudText.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left mud-text pl-2 ma-2\">Operations</h5>");
        }
        [Fact]
        public void Check7thMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[6];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckName1Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[6];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pl-2\">Name 1</h6>");
        }
        [Fact]
        public void CheckName1Switch()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[6];
            var mudSwitch = MudPaper.FindComponent<MudSwitch<string>>();
            Assert.Equal("pa-0 ma-0", mudSwitch.Instance.Class);
            Assert.Equal(MudBlazor.Color.Primary, mudSwitch.Instance.Color);
            Assert.Null(mudSwitch.Instance.Checked);
            mudSwitch.Instance.Checked = "true";
            Assert.Equal("true", mudSwitch.Instance.Checked);
        }
        [Fact]
        public void Check8thMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[7];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckName2Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[7];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pl-2\">Name 2</h6>");
        }
        [Fact]
        public void CheckName2Switch()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[7];
            var mudSwitch = MudPaper.FindComponent<MudSwitch<string>>();
            Assert.Equal("pa-0 ma-0", mudSwitch.Instance.Class);
            Assert.Equal(MudBlazor.Color.Primary, mudSwitch.Instance.Color);
            Assert.Null(mudSwitch.Instance.Checked);
            mudSwitch.Instance.Checked = "true";
            Assert.Equal("true", mudSwitch.Instance.Checked);
        }
        [Fact]
        public async void checkAdvanceText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudText = mudStack.FindComponents<MudText>()[14];
            Assert.Equal("mud-text pl-2 ma-2", MudText.Instance.Class);
            Assert.Equal(Align.Left, MudText.Instance.Align);
            Assert.Equal(Typo.h5, MudText.Instance.Typo);
            MudText.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left mud-text pl-2 ma-2\">Advanced Settings</h5>");
        }
        [Fact]
        public void Check9thMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[8];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckRampAdpText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[8];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pl-2\">Ramp Adaption</h6>");
        }
        [Fact]
        public void CheckRampAdapInnerpaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[8];
            var Innerpaper = MudPaper.FindComponent<MudPaper>();
            Assert.Equal(0, Innerpaper.Instance.Elevation);
            Assert.False(Innerpaper.Instance.Outlined);
        }
        [Fact]
        public void CheckRampAdapInnerpaperInnerStack()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[8];
            var Innerpaper = MudPaper.FindComponent<MudPaper>();
            var Innerstack = Innerpaper.FindComponent<MudStack>();
            Assert.Equal(0, Innerstack.Instance.Spacing);
            Assert.False(Innerstack.Instance.Row);
        }
        [Fact]
        public async void CheckDeclineText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[8];
            var Innerpaper = MudPaper.FindComponent<MudPaper>();
            var Innerstack = Innerpaper.FindComponent<MudStack>();
            var mudText = Innerstack.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.body1, mudText.Instance.Typo);
            mudText.MarkupMatches("<p class=\"mud-typography mud-typography-body1 mud-text pl-2\">Decline: 50%\r\n                    </p>");
        }
        [Fact]
        public async void CheckInclineText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[8];
            var Innerpaper = MudPaper.FindComponent<MudPaper>();
            var Innerstack = Innerpaper.FindComponent<MudStack>();
            var mudText = Innerstack.FindComponents<MudText>()[1];
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.body1, mudText.Instance.Typo);
            mudText.MarkupMatches("<p class=\"mud-typography mud-typography-body1 mud-text pl-2\">Incline: 95%\r\n                    </p>");
        }
        [Fact]
        public void Check10thMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[10];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }

        [Fact]
        public async void Check2ndName2Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[10];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pl-2\">Name 2</h6>");
        }
        [Fact]
        public void Check2ndName2Switch()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[10];
            var mudSwitch = MudPaper.FindComponent<MudSwitch<string>>();
            Assert.Equal("pa-0 ma-0", mudSwitch.Instance.Class);
            Assert.Equal(MudBlazor.Color.Primary, mudSwitch.Instance.Color);
            Assert.Null(mudSwitch.Instance.Checked);
            mudSwitch.Instance.Checked = "true";
            Assert.Equal("true", mudSwitch.Instance.Checked);
        }
        [Fact]
        public void Check11thMudPaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[11];
            Assert.Equal("d-flex align-items-center justify-space-between border rounded-0 pa-0 ma-0", MudPaper.Instance.Class);
            Assert.Equal(0, MudPaper.Instance.Elevation);
            Assert.True(MudPaper.Instance.Outlined);
        }
        [Fact]
        public async void CheckStairAdpText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[11];
            var mudText = MudPaper.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-text pl-2\">Stair Adaption</h6>");
        }
        [Fact]
        public void CheckStairAdpInnerpaper()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[11];
            var Innerpaper = MudPaper.FindComponent<MudPaper>();
            Assert.Equal(0, Innerpaper.Instance.Elevation);
            Assert.False(Innerpaper.Instance.Outlined);
            Assert.Equal("ml-2 mr-2", Innerpaper.Instance.Class);
        }
        [Fact]
        public void CheckStairAdpInnerpaperInnerStack()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[11];
            var Innerpaper = MudPaper.FindComponent<MudPaper>();
            var Innerstack = Innerpaper.FindComponent<MudStack>();
            Assert.Equal(0, Innerstack.Instance.Spacing);
            Assert.False(Innerstack.Instance.Row);
        }
        [Fact]
        public async void CheckDescentText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[11];
            var Innerpaper = MudPaper.FindComponent<MudPaper>();
            var Innerstack = Innerpaper.FindComponent<MudStack>();
            var mudText = Innerstack.FindComponent<MudText>();
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.body1, mudText.Instance.Typo);
            mudText.MarkupMatches("<p class=\"mud-typography mud-typography-body1 mud-text pl-2\">Descent: 0°\r\n                    </p>");
        }
        [Fact]
        public async void CheckAscentText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Settings>();
            var mudStack = Component.FindComponent<MudStack>();
            var MudPaper = mudStack.FindComponents<MudPaper>()[11];
            var Innerpaper = MudPaper.FindComponent<MudPaper>();
            var Innerstack = Innerpaper.FindComponent<MudStack>();
            var mudText = Innerstack.FindComponents<MudText>()[1];
            Assert.Equal("mud-text pl-2", mudText.Instance.Class);
            Assert.Equal(Typo.body1, mudText.Instance.Typo);
            mudText.MarkupMatches("<p class=\"mud-typography mud-typography-body1 mud-text pl-2\">Ascent: 0°\r\n                    </p>");
        }
        
    }
}
