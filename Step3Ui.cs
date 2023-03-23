using BionicApp.Pages.Add_Device.Steps;
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
using Color = MudBlazor.Color;

namespace BionicAppTestRunner.BionicAppUi
{
    public class Step3Ui : BionicAppUiTestBase
    {
        [Fact]
        public async void CheckStepText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var step1 = RenderComponent<Step1>();
            step1.Find("button").Click();
            var step2 = RenderComponent<Step2>();
            step2.Find("button").Click();
            var component = RenderComponent<Step3>();
            var mudText = component.FindComponents<MudText>()[0];
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1\">Step 4/4</h6>");

        }

        [Fact]
        public async void CheckPairInfoText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step3>();
            var mudText = component.FindComponents<MudText>()[1];
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6\">Pairing Information</h6>");
        }
        [Fact]
        public async void checkPairInstText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step3>();
            var mudText = component.FindComponents<MudText>()[2];
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1\">To pair we need you to enter the 6 digits number found on the back of your device. Picture to explain:</h6>");
        }
        [Fact]
        public void CheckMudPaper()
        {
            var component = RenderComponent<Step3>();
            var mudPaper = component.FindComponent<MudPaper>();
            Assert.Equal(0, mudPaper.Instance.Elevation);
            Assert.True(mudPaper.Instance.Outlined);
            Assert.True(mudPaper.Instance.Square);
        }
        [Fact]
        public void CheckImg()
        {
            var component = RenderComponent<Step3>();
            var mudImage = component.FindComponent<MudImage>();
            Assert.Equal("/images/logo.png", mudImage.Instance.Src);
            Assert.Equal("Ossur Icon", mudImage.Instance.Alt);
            Assert.True(mudImage.Instance.Fluid);

        }
        [Fact]
        public async void checkPairInst2ndText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step3>();
            var mudText = component.FindComponents<MudText>()[3];
            Assert.Equal(Typo.subtitle1, mudText.Instance.Typo);
            mudText.MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1\">After pairing is completed connection will be established and the device dashboard will be displayed</h6>");
        }
        [Fact]
        public void Check2ndMudStack()
        {
            var component = RenderComponent<Step3>();
            var mudStack = component.FindComponents<MudStack>()[1];
            Assert.Equal("mt-6", mudStack.Instance.Class);
            Assert.Equal(Justify.FlexStart, mudStack.Instance.Justify);
            Assert.True(mudStack.Instance.Row);
        }
        [Fact]
        public async void CheckCancelBUtton()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step3>();
            var mudbutton = component.FindComponents<MudButton>()[0];
            Assert.Equal("ml-auto navButton",mudbutton.Instance.Class);
            Assert.Equal(" height:52px; text-transform:none;", mudbutton.Instance.Style);
            Assert.True(mudbutton.Instance.DisableElevation);
            Assert.Equal(Variant.Filled, mudbutton.Instance.Variant);
            Assert.Equal(Color.Transparent, mudbutton.Instance.Color);
            mudbutton.Find("span").MarkupMatches("<span class=\"mud-button-label\">Cancel</span>");
        }
        [Fact]
        public async void CheckNextBUtton()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step3>();
            var mudbutton = component.FindComponents<MudButton>()[1];
            Assert.Equal("ml-auto navButton", mudbutton.Instance.Class);
            Assert.Equal(" height:52px; text-transform:none;", mudbutton.Instance.Style);
            mudbutton.Find("span").MarkupMatches("<span class=\"mud-button-label\">Next</span>");
            Assert.False(mudbutton.Instance.Disabled);
        }
    }
}
