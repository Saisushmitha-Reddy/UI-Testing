using BionicApp.Pages.Add_Device.My_Devices.DeviceProfiles;
using BionicApp.Pages.Add_Device.My_Devices.DeviceSettings;
using Bunit;
using MudBlazor;
using Ossur.Bionics.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class StairAdaptionUi : BionicAppUiTestBase
    {
        [Fact]
        public async void CheckBackButtonandStairAdaption()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var component = RenderComponent<StairAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            Assert.Equal(4, mudStack.Instance.Spacing);
            var mudGrid = mudStack.FindComponent<MudGrid>();
            Assert.Equal(2, mudGrid.Instance.Spacing);
            Assert.Equal(Justify.FlexStart, mudGrid.Instance.Justify);
            var mudIconBut = mudGrid.FindComponent<MudIconButton>();
            Assert.Equal(Icons.Material.Filled.ArrowBack, mudIconBut.Instance.Icon);
            var mudText = mudGrid.FindComponent<MudText>();
            Assert.Equal("pa-2", mudText.Instance.Class);
            Assert.Equal(Align.Center, mudText.Instance.Align);
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6 mud-typography-align-center pa-2\">Stair Adaption</h6>");
        }
        [Fact]
        public void CheckImage()
        {
            Mydevicemethod2();
            var component = RenderComponent<StairAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var mudPaper = mudStack.FindComponent<MudPaper>();
            Assert.Equal("d-flex justify-center", mudPaper.Instance.Class);
            var mudImage = mudPaper.FindComponent<MudImage>();
            Assert.Equal(ObjectFit.Fill, mudImage.Instance.ObjectFit);
            Assert.Equal("/images/logo.png", mudImage.Instance.Src);
            Assert.Equal(0, mudImage.Instance.Elevation);
            Assert.True(mudImage.Instance.Fluid);
        }
        [Fact]
        public async void CheckDecentTextSlider()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var component = RenderComponent<StairAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var innerStack = mudStack.FindComponent<MudStack>();
            Assert.Equal(1, innerStack.Instance.Spacing);
            var mudText = innerStack.FindComponent<MudText>();
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6\">Decent Angle</h6>");
            var Stackinner = innerStack.FindComponent<MudStack>();
            Assert.Equal(2, Stackinner.Instance.Spacing);
            Assert.Equal(Justify.SpaceBetween, Stackinner.Instance.Justify);
            Assert.Equal(AlignItems.Center, Stackinner.Instance.AlignItems);
            Assert.True(Stackinner.Instance.Row);
            var Slider = Stackinner.FindComponent<MudSlider<double>>();
            Assert.True(Slider.Instance.Disabled);
            Assert.Equal(0, Slider.Instance.Value);
            Assert.False(Slider.Instance.Immediate);
            Assert.Equal(0, Slider.Instance.Min);
            Assert.Equal(6.0, Slider.Instance.Max);
            Assert.Equal(1, Slider.Instance.Step);
            Assert.Equal(MudBlazor.Size.Medium, Slider.Instance.Size);
            var text = Stackinner.FindComponent<MudText>();
            Assert.Equal(Typo.subtitle1, text.Instance.Typo);
            text.MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1\">0°</h6>");
        }
        [Fact]
        public async void CheckAscentTextSlider()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var component = RenderComponent<StairAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var innerStack = mudStack.FindComponents<MudStack>()[2];
            Assert.Equal(1, innerStack.Instance.Spacing);
            var mudText = innerStack.FindComponent<MudText>();
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6\">[ascentangle_ua:en]</h6>");
            var Stackinner = innerStack.FindComponent<MudStack>();
            Assert.Equal(2, Stackinner.Instance.Spacing);
            Assert.Equal(Justify.SpaceBetween, Stackinner.Instance.Justify);
            Assert.Equal(AlignItems.Center, Stackinner.Instance.AlignItems);
            Assert.True(Stackinner.Instance.Row);
            var Slider = Stackinner.FindComponent<MudSlider<double>>();
            Assert.True(Slider.Instance.Disabled);
            Assert.Equal(0, Slider.Instance.Value);
            Assert.False(Slider.Instance.Immediate);
            Assert.Equal(0, Slider.Instance.Min);
            Assert.Equal(6.0, Slider.Instance.Max);
            Assert.Equal(1, Slider.Instance.Step);
            Assert.Equal(MudBlazor.Size.Medium, Slider.Instance.Size);
            var text = Stackinner.FindComponent<MudText>();
            Assert.Equal(Typo.subtitle1, text.Instance.Typo);
            text.MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1\">0°</h6>");
        }
        [Fact]
        public async void CheckHistoryText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var component = RenderComponent<StairAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var innerStack = mudStack.FindComponents<MudStack>()[4];
            Assert.Equal(0, innerStack.Instance.Spacing);
            var mudText = innerStack.FindComponent<MudText>();
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6\">History</h6>");
        }
    }
}
