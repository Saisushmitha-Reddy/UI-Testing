using AngleSharp.Css.Values;
using BionicApp.Pages.Add_Device.My_Devices.DeviceSettings;
using BionicApp.Services;
using Bunit;
using MudBlazor;
using Ossur.Bionics.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class AnkleAlignmentUi : BionicAppUiTestBase
    {
        [Fact]
        public void checkMudStack()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            Assert.Equal(4, mudStack.Instance.Spacing);
        }
        [Fact]
        public void checkMudGrid()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudGrid = mudStack.FindComponent<MudGrid>();
            Assert.Equal(2, mudGrid.Instance.Spacing);
            Assert.Equal(Justify.FlexStart, mudGrid.Instance.Justify);
        }
        [Fact]
        public void checkArrowBack()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudGrid = mudStack.FindComponent<MudGrid>();
            var IconButton = mudGrid.FindComponent<MudIconButton>();
            Assert.Equal(Icons.Material.Filled.ArrowBack, IconButton.Instance.Icon);
        }
        [Fact]
        public async void checkAnkleAlignmentText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudGrid = mudStack.FindComponent<MudGrid>();
            var mudText = mudGrid.FindComponent<MudText>();
            Assert.Equal("pa-2", mudText.Instance.Class);
            Assert.Equal(Align.Center, mudText.Instance.Align);
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-h6 mud-typography-align-center pa-2\">Ankle Alignment</h6>");
        }
        [Fact]
        public void checkImage()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudpaper = mudStack.FindComponent<MudPaper>();
            Assert.Equal("d-flex justify-center", mudpaper.Instance.Class);
            var MudImage = mudpaper.FindComponent<MudImage>();
            Assert.Equal(ObjectFit.Fill, MudImage.Instance.ObjectFit);
            Assert.Equal("/images/logo.png", MudImage.Instance.Src);
            Assert.Equal(0, MudImage.Instance.Elevation);
            Assert.True(MudImage.Instance.Fluid);
        }
        [Fact]
        public async void checkAnkleDiscriptionText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudText = Component.FindComponents<MudText>()[1];
            Assert.Equal("pl-3", mudText.Instance.Class);
            Assert.Equal(Typo.body1, mudText.Instance.Typo);
            mudText.MarkupMatches("<p class=\"mud-typography mud-typography-body1 pl-3\">Description text, max 3 lines if more trunctuate the text. Relax mode lorem ipsum dolor  ... more</p>");
        }
        [Fact]
        public async void checkAutoText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudText = Component.FindComponents<MudText>()[2];
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6\">Automatic</h6>");
        }
        [Fact]
        public void checkmudpaperinMudItem()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudItem = mudStack.FindComponents<MudItem>()[2];
            var mudPaper = mudItem.FindComponent<MudPaper>();
            Assert.Equal("d-flex align-center justify-content-between", mudPaper.Instance.Class);
            Assert.Equal("Auto", mudPaper.Instance.MaxWidth);
            Assert.Equal(0, mudPaper.Instance.Elevation);
        }
        [Fact]
        public async void checkStartText()
        {
            Mydevicemethod2();
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudItem = mudStack.FindComponents<MudItem>()[2];
            var mudPaper = mudItem.FindComponent<MudPaper>();
            var mudText = mudPaper.FindComponent<MudText>();
            Assert.Equal("pl-3", mudText.Instance.Class);
            Assert.Equal(Typo.body1, mudText.Instance.Typo);
            mudText.MarkupMatches("<p class=\"mud-typography mud-typography-body1 pl-3\">Start</p>");
        }
        [Fact]
        public async void checkmudRadioGroupinMudItem()
        {
            Mydevicemethod2();
            var dataAdapter = Services.GetService<DataCollectionAdapter>();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var mudItem = mudStack.FindComponents<MudItem>()[2];
            var mudRadioGroup = mudItem.FindComponent<MudRadioGroup<bool>>();
            var mudRadio = mudRadioGroup.FindComponent<MudRadio<bool>>();
            Assert.True(mudRadio.Instance.Option);
            Assert.True(mudRadio.Instance.Disabled);
            Component.InvokeAsync(() => mudRadioGroup.Instance.SelectedOption = true);
            Assert.True(mudRadioGroup.Instance.SelectedOption);
            
        }
        
        [Fact]
        public async void checkMannualText()
        {
            Mydevicemethod2();
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var InnermudStack = mudStack.FindComponent<MudStack>();
            Assert.Equal(1, InnermudStack.Instance.Spacing);
            var mudText = InnermudStack.FindComponent<MudText>();
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6\">Manual</h6>");
        }
        [Fact]
        public void checkInnerMudStackinInnerMudStack()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var InnermudStack = mudStack.FindComponent<MudStack>();
            var mudStackInner = InnermudStack.FindComponent<MudStack>();
            Assert.Equal(2, mudStackInner.Instance.Spacing);
            Assert.Equal(Justify.SpaceBetween, mudStackInner.Instance.Justify);
            Assert.Equal(AlignItems.Center, mudStackInner.Instance.AlignItems);
            Assert.True(mudStackInner.Instance.Row);
        }
        [Fact]
        public void checkMudSlider()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var InnermudStack = mudStack.FindComponent<MudStack>();
            var mudStackInner = InnermudStack.FindComponent<MudStack>();
            var mudSlider = mudStackInner.FindComponent<MudSlider<double>>();
            Assert.True(mudSlider.Instance.Disabled);
            Assert.Equal(0, mudSlider.Instance.Value);
            Assert.False(mudSlider.Instance.Immediate);
            Assert.Equal(0, mudSlider.Instance.Min);
            Assert.Equal(14.0, mudSlider.Instance.Max);
            Assert.Equal(0.1, mudSlider.Instance.Step);
            Assert.Equal(MudBlazor.Size.Medium, mudSlider.Instance.Size);
        }
        [Fact]
        public void checkAnkleValue()
        {
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var InnermudStack = mudStack.FindComponent<MudStack>();
            var mudStackInner = InnermudStack.FindComponent<MudStack>();
            var mudText = mudStackInner.FindComponent<MudText>();
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1\">0°</h6>");
        }
        [Fact]
        public async void checkHistory()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var Component = RenderComponent<Ankle_Alignment>();
            var mudStack = Component.FindComponent<MudStack>();
            var InnermudStack = mudStack.FindComponents<MudStack>()[2];
            var mudText = InnermudStack.FindComponent<MudText>();
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6\">History</h6>");
        }
    }
}
