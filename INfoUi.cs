using BionicApp.Pages.Add_Device.App_Info;
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
    public class INfoUi : BionicAppUiTestBase
    {
        [Fact]
        public async void checkThirdPartyText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Info>();
            var stack = component.FindComponents<MudStack>()[6];
            Assert.Equal("ma-0 pa-0", stack.Instance.Class);
            var List = stack.FindComponent<MudList>();
            Assert.False(List.Instance.Clickable);
            Assert.True(List.Instance.Dense);
            Assert.True(List.Instance.DisableGutters);
            var text = List.FindComponent<MudText>();
            Assert.Equal(Align.Left, text.Instance.Align);
            Assert.Equal(Typo.subtitle1, text.Instance.Typo);
            text.Find("b").MarkupMatches("<b>Third Party Libraries</b>");
        }
        [Fact]
        public async void checkMudBlazorText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Info>();
            var stack = component.FindComponents<MudStack>()[6];
            var List = stack.FindComponent<MudList>();
            var mudlistItem = List.FindComponent<MudListItem>();
            Assert.Equal(Icons.Material.Filled.DesignServices, mudlistItem.Instance.Icon);
            Assert.Equal("", mudlistItem.Instance.ExpandLessIcon);
            Assert.Equal("", mudlistItem.Instance.ExpandMoreIcon);
            Assert.Equal("font-size:medium", mudlistItem.Instance.Style);
            Assert.True(mudlistItem.Instance.InitiallyExpanded);
            mudlistItem.Find("a").MarkupMatches("<a href=\"https://mudblazor.com/docs/overview\" blazor:onclick=\"15\" class=\"mud-typography mud-link mud-primary-text mud-link-underline-hover mud-typography-body1\" style=\"font-size:smaller\">Document link</a>");
        }
        [Fact]
        public async void checkDesigningText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Info>();
            var stack = component.FindComponents<MudStack>()[6];
            var List = stack.FindComponent<MudList>();
            var nestedList = List.FindComponents<MudListItem>()[1];
            Assert.Equal(Icons.Material.Filled.ArrowForward, nestedList.Instance.Icon);
            var text = nestedList.FindComponent<MudText>();
            Assert.Equal(Align.Inherit, text.Instance.Align);
 //           Assert.Equal("font-size:smaller", text.Instance.Style);
            text.MarkupMatches("<p class=\"mud-typography mud-typography-body2\"><p class=\"mud-typography mud-typography-body1 mud-typography-align-left\" style=\"font-size:smaller\">Used for Designing the components</p></p>");
        }
        [Fact]
        public async void checkDoccumentTextLink()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Info>();
            var stack = component.FindComponents<MudStack>()[6];
            var List = stack.FindComponent<MudList>();
            var nestedList = List.FindComponents<MudListItem>()[2];
            Assert.Equal(Icons.Material.Filled.ArrowForward, nestedList.Instance.Icon);
           // Assert.Equal("https://mudblazor.com/docs/overview", nestedList.Instance.Href);
            nestedList.Find("a").MarkupMatches("<a href=\"https://mudblazor.com/docs/overview\" blazor:onclick=\"15\" class=\"mud-typography mud-link mud-primary-text mud-link-underline-hover mud-typography-body1\" style=\"font-size:smaller\">Document link</a>");
        }
        [Fact]
        public async void checkPluginBleText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Info>();
            var stack = component.FindComponents<MudStack>()[6];
            var List = stack.FindComponent<MudList>();
            var mudlistItem = List.FindComponents<MudListItem>()[3];
            Assert.Equal(Icons.Material.Filled.DesignServices, mudlistItem.Instance.Icon);
            Assert.Equal("", mudlistItem.Instance.ExpandLessIcon);
            Assert.Equal("", mudlistItem.Instance.ExpandMoreIcon);
            Assert.Equal("font-size:medium", mudlistItem.Instance.Style);
            Assert.True(mudlistItem.Instance.InitiallyExpanded);
            mudlistItem.Find("a").MarkupMatches("<a href=\"https://github.com/dotnet-bluetooth-le/dotnet-bluetooth-le\" blazor:onclick=\"16\" class=\"mud-typography mud-link mud-primary-text mud-link-underline-hover mud-typography-body1\" style=\"font-size:smaller\">Document link</a>");
        }
        [Fact]
        public async void checkConnectBluetoothText()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Info>();
            var stack = component.FindComponents<MudStack>()[6];
            var List = stack.FindComponent<MudList>();
            var nestedList = List.FindComponents<MudListItem>()[4];
            Assert.Equal(Icons.Material.Filled.ArrowForward, nestedList.Instance.Icon);
            var text = nestedList.FindComponent<MudText>();
            Assert.Equal(Align.Inherit, text.Instance.Align);
       //     Assert.Equal("font-size:smaller", text.Instance.Style);
            text.MarkupMatches("<p class=\"mud-typography mud-typography-body2\"><p class=\"mud-typography mud-typography-body1 mud-typography-align-left\" style=\"font-size:smaller\">Used for connect Bluetooth devices</p></p>");
        }
        [Fact]
        public async void check2DoccumentTextLink()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<Info>();
            var stack = component.FindComponents<MudStack>()[6];
            var List = stack.FindComponent<MudList>();
            var nestedList = List.FindComponents<MudListItem>()[5];
            Assert.Equal(Icons.Material.Filled.ArrowForward, nestedList.Instance.Icon);
  //          Assert.Equal("https://github.com/dotnet-bluetooth-le/dotnet-bluetooth-le", nestedList.Instance.Href);
            nestedList.Find("a").MarkupMatches("<a href=\"https://github.com/dotnet-bluetooth-le/dotnet-bluetooth-le\" blazor:onclick=\"16\" class=\"mud-typography mud-link mud-primary-text mud-link-underline-hover mud-typography-body1\" style=\"font-size:smaller\">Document link</a>");
        }
    } 
}
