using BionicApp.Pages.Add_Device.My_Devices.DeviceSettings;
using Bunit;
using MudBlazor;
using Ossur.Bionics.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class RampAdaptionUI : BionicAppUiTestBase
    {
        [Fact]
        public void checkmainStack()
        {
            Mydevicemethod2();
            var component = RenderComponent<RampAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            Assert.Equal(8, mudStack.Instance.Spacing);
            Assert.Equal("pa-4", mudStack.Instance.Class);
            Assert.False(mudStack.Instance.Row);
        }
        [Fact]
        public void checkbutton()
        {
            Mydevicemethod2();
            var component = RenderComponent<RampAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var mudtext = mudStack.FindComponent<MudText>();
            Assert.Equal(Align.Right, mudtext.Instance.Align);
            var mudButton = mudtext.FindComponent<MudButton>();
            Assert.Equal(" btn-close", mudButton.Instance.Class);
        }
        [Fact]
        public async void checkRampAdaptionText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var component = RenderComponent<RampAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var mudtext = mudStack.FindComponents<MudText>()[1];
            Assert.Equal(Align.Left, mudtext.Instance.Align);
            Assert.Equal(Typo.h5, mudtext.Instance.Typo);
            mudtext.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left\">Ramp Adaption</h5>");
        }
        [Fact]
        public void checkImage()
        {
            Mydevicemethod2();
            var component = RenderComponent<RampAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var mudPaper = mudStack.FindComponent<MudPaper>();
            Assert.Equal("d-flex justify-center", mudPaper.Instance.Class);
            Assert.Equal(0, mudPaper.Instance.Elevation);
            var mudImage = mudPaper.FindComponent<MudImage>();
            Assert.Equal(ObjectFit.Fill, mudImage.Instance.ObjectFit);
            Assert.Equal("/images/logo.png", mudImage.Instance.Src);
            Assert.Equal(0, mudImage.Instance.Elevation);
            Assert.True(mudImage.Instance.Fluid);
        }
        [Fact]
        public async void checkDeclindSlider()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var component = RenderComponent<RampAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var InnerStack = mudStack.FindComponents<MudStack>()[0];
            Assert.Equal(2, InnerStack.Instance.Spacing);
            Assert.True(InnerStack.Instance.Row);
            var mudSlider = InnerStack.FindComponent<MudSlider<double>>();
            Assert.Equal(0, mudSlider.Instance.Min);
            Assert.Equal(100, mudSlider.Instance.Max);
            var mudText = mudSlider.FindComponent<MudText>();
            Assert.Equal(Typo.body1, mudText.Instance.Typo);
            Assert.Equal(Align.Inherit, mudText.Instance.Align);
            mudText.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left\">Decline</h5>");
        }
        [Fact]
        public async void checkInclinedSlider()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var component = RenderComponent<RampAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var InnerStack = mudStack.FindComponents<MudStack>()[1];
            Assert.Equal(2, InnerStack.Instance.Spacing);
            Assert.True(InnerStack.Instance.Row);
            var mudSlider = InnerStack.FindComponent<MudSlider<double>>();
            Assert.Equal(0, mudSlider.Instance.Min);
            Assert.Equal(100, mudSlider.Instance.Max);
            var mudText = mudSlider.FindComponent<MudText>();
            Assert.Equal(Typo.body1, mudText.Instance.Typo);
            Assert.Equal(Align.Inherit, mudText.Instance.Align);
            mudText.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left\">Incline</h5>");
        }
        [Fact]
        public async void checkHistoryText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            Mydevicemethod2();
            var component = RenderComponent<RampAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var InnerStack = mudStack.FindComponents<MudStack>()[2];
            Assert.Equal(2, InnerStack.Instance.Spacing);
            Assert.False(InnerStack.Instance.Row);
            var mudText = InnerStack.FindComponent<MudText>();
            Assert.Equal(Typo.h5, mudText.Instance.Typo);
            Assert.Equal(Align.Left, mudText.Instance.Align);
            mudText.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left\">History</h5>");
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
            var component = RenderComponent<RampAdaption>();
            var mudStack = component.FindComponent<MudStack>();
            var InnerStack = mudStack.FindComponents<MudStack>()[2];
            var mudPaper = InnerStack.FindComponent<MudPaper>();
            Assert.Equal("d-flex justify-space-between", mudPaper.Instance.Class);
            Assert.Equal(0, mudPaper.Instance.Elevation);
            var mudText1 = mudPaper.FindComponents<MudText>()[0];
            Assert.Equal(Typo.body1, mudText1.Instance.Typo);
            mudText1.MarkupMatches("<p class=\"mud-typography mud-typography-body1\"></p>");
            var mudText2 = mudPaper.FindComponents<MudText>()[1];
            Assert.Equal(Typo.body1, mudText2.Instance.Typo);
            mudText2.MarkupMatches("<p class=\"mud-typography mud-typography-body1\"></p>");
        }
        
    }
}
