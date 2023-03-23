using BionicApp.Pages.Add_Device.Steps;
using BionicApp.Services;
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
    public class Step1UI : BionicAppUiTestBase
    {
        [Fact]
        public async void checkAddDeviceText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step1>();
            var mudtext = component.FindComponents<MudText>()[0];
            Assert.Equal(Typo.h5, mudtext.Instance.Typo);
            Assert.Equal(Align.Center, mudtext.Instance.Align);
            mudtext.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-center\">Add a device</h5>");
        }
        [Fact]
        public async void checkStep1Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step1>();
            var mudtext = component.FindComponents<MudText>()[1];
            Assert.Equal(Typo.subtitle1, mudtext.Instance.Typo);
            mudtext.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1\">Step 1/4</h6>");
        }
        [Fact]
        public void check1stMudPaper()
        {
            var component = RenderComponent<Step1>();
            var mudpaper = component.FindComponents<MudPaper>()[0];
            Assert.Equal(0, mudpaper.Instance.Elevation);
            Assert.True(mudpaper.Instance.Outlined);
            Assert.True(mudpaper.Instance.Square);
        }
        [Fact]
        public void CheckImage()
        {
            var component = RenderComponent<Step1>();
            var mudpaper = component.FindComponents<MudPaper>()[0];
            var mudImg = mudpaper.FindComponent<MudImage>();
            Assert.Equal("/images/logo.png", mudImg.Instance.Src);
            Assert.Equal("Ossur Icon", mudImg.Instance.Alt);
            Assert.True(mudImg.Instance.Fluid);
        }
        [Fact]
        public void check2stMudPaper()
        {
            var component = RenderComponent<Step1>();
            var mudpaper = component.FindComponents<MudPaper>()[1];
            Assert.Equal(0, mudpaper.Instance.Elevation);
        }
        [Fact]
        public async void checkStepInstructionText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step1>();
            var mudpaper = component.FindComponents<MudPaper>()[1];
            var mudtext = mudpaper.FindComponent<MudText>();
            Assert.Equal(Typo.body1, mudtext.Instance.Typo);
            Assert.Equal("mt-8 instruction-text ", mudtext.Instance.Class);
            mudtext.MarkupMatches("<p class=\"mud-typography mud-typography-body1 mt-8 instruction-text\">Icons of devices to explain how to connect. What buttons to turn on, where the pincodes are to connect and so on. Text explaining what you should do if your components won’t show up. Divide this process up to steps - for example 4 steps where this page is step 1 out of 4. We need to try to simplify this process for the user as much as possible.</p>");
        }
        [Fact]
        public void checkMudStack()
        {
            var component = RenderComponent<Step1>();
            var mudStack = component.FindComponent<MudStack>();
            Assert.Equal("ma-6", mudStack.Instance.Class);
            //Assert.Equal(0, mudStack.Instance.Elevation);
        }
        [Fact]
        public async void CheckLogoutButton()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Step1>();
            var mudStack = component.FindComponent<MudStack>();
            var Button = mudStack.FindComponent<MudButton>();
            Assert.Equal(" height:52px; text-transform:none;", Button.Instance.Style);
            Assert.Equal(Variant.Filled, Button.Instance.Variant);
            Assert.Equal(MudBlazor.Color.Primary, Button.Instance.Color);
            Assert.True(Button.Instance.FullWidth);
            Button.Find("span").MarkupMatches("<span class=\"mud-button-label\">Next</span>");
        }
        [Fact]
        public void CheckNextNevigation()
        {
            //var component = RenderComponent<Step1>();
            //component.carouselNavAdapter.NavigateNext();
        }
    }
}
