using BionicApp.Pages.Add_Device.App_Info;
using Bunit;
using MudBlazor;
using Ossur.Bionics.Common;
using System.Globalization;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class InfoTest : BionicAppUiTestBase
    {
        [Fact]
        public async void Stack_Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");

            const string key = "TranslationCutoffDate";

            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");

            var comp = RenderComponent<Info>();
            var stack = comp.FindComponents<MudStack>()[0];
            var text = stack.FindComponents<MudText>()[0];


            Assert.NotNull(stack);
            Assert.Equal("ma-4 stackLayout", stack.Instance.Class);

            Assert.NotNull(text);
            Assert.Equal(Align.Center, text.Instance.Align);
            Assert.Equal(Typo.subtitle1, text.Instance.Typo);
            text.Find("b").MarkupMatches("<b>Info</b>");
        }



        [Fact]
        public async void Stack2_Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");

            const string key = "TranslationCutoffDate";

            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");

            var comp = RenderComponent<Info>();
            var stack = comp.FindComponents<MudStack>()[1];
            var text = stack.FindComponents<MudText>()[0];
            var text2 = stack.FindComponents<MudText>()[1];

            Assert.NotNull(stack);
            Assert.Equal("ma-0 pa-0", stack.Instance.Class);
            Assert.True(stack.Instance.Row);
            Assert.Equal(Justify.SpaceBetween, stack.Instance.Justify);
            Assert.Equal(0, stack.Instance.Spacing);

            Assert.NotNull(text);
            Assert.Equal(Typo.subtitle2, text.Instance.Typo);
            text.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle2\">Version</h6>");

            Assert.NotNull(text2);
            Assert.Equal(Typo.subtitle1, text2.Instance.Typo);
            text2.Find("b").MarkupMatches("<b>1.0</b>");

        }

        [Fact]
        public async void Stack3_Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");

            const string key = "TranslationCutoffDate";

            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");

            var comp = RenderComponent<Info>();
            var stack = comp.FindComponents<MudStack>()[2];
            var text = stack.FindComponents<MudText>()[0];
            var text2 = stack.FindComponents<MudText>()[1];

            Assert.NotNull(stack);
            Assert.Equal("ma-0 pa-0", stack.Instance.Class);
            Assert.True(stack.Instance.Row);
            Assert.Equal(Justify.SpaceBetween, stack.Instance.Justify);
            Assert.Equal(0, stack.Instance.Spacing);

            Assert.NotNull(text);
            Assert.Equal(Typo.subtitle2, text.Instance.Typo);
            text.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle2\">Client Id</h6>");

            Assert.NotNull(text2);
            Assert.Equal(Typo.subtitle1, text2.Instance.Typo);
            Assert.Equal("clientID", text2.Instance.Class);

        }

        [Fact]
        public async void Stack4_Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");

            const string key = "TranslationCutoffDate";

            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");

            var comp = RenderComponent<Info>();
            var stack = comp.FindComponents<MudStack>()[3];
            var text = stack.FindComponents<MudText>()[0];
            var text2 = stack.FindComponents<MudText>()[1];

            Assert.NotNull(stack);
            Assert.Equal("ma-0 pa-0", stack.Instance.Class);
            Assert.True(stack.Instance.Row);
            Assert.Equal(Justify.SpaceBetween, stack.Instance.Justify);
            Assert.Equal(0, stack.Instance.Spacing);

            Assert.NotNull(text);
            Assert.Equal(Typo.subtitle2, text.Instance.Typo);
            text.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle2\">Publish date</h6>");

            Assert.NotNull(text2);
            Assert.Equal(Typo.subtitle1, text2.Instance.Typo);
        }

        [Fact]
        public async void Stack5_Text()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");

            const string key = "TranslationCutoffDate";

            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");

            var comp = RenderComponent<Info>();
            var stack = comp.FindComponents<MudStack>()[4];
            var text = stack.FindComponents<MudText>()[0];
            var text2 = stack.FindComponents<MudText>()[1];

            Assert.NotNull(stack);
            Assert.Equal("ma-0 pa-0", stack.Instance.Class);
            Assert.True(stack.Instance.Row);
            Assert.Equal(Justify.SpaceBetween, stack.Instance.Justify);
            Assert.Equal(0, stack.Instance.Spacing);

            Assert.NotNull(text);
            Assert.Equal(Typo.subtitle2, text.Instance.Typo);
            text.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle2\">Client Type</h6>");

            Assert.NotNull(text2);
            Assert.Equal(Typo.subtitle1, text2.Instance.Typo);
            text2.Find("b").MarkupMatches("<b>Android</b>");

        }

        [Fact]
        public async void Test_List()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");

            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var comp = RenderComponent<Info>();
            var divider = comp.FindComponents<MudDivider>()[3];

            var stack = comp.FindComponents<MudStack>()[5];
            var list = comp.FindComponents<MudList>()[0];
            var sublist = list.FindComponents<MudListSubheader>()[0];
            var text = sublist.FindComponents<MudText>()[0];

            Assert.NotNull(divider);
            Assert.Equal("height:2px;", divider.Instance.Style);

            Assert.NotNull(stack);
            Assert.Equal("ma-0 pa-0", stack.Instance.Class);

            Assert.NotNull(list);
            Assert.True(list.Instance.Clickable);
            Assert.True(list.Instance.Dense);
            Assert.True(list.Instance.DisableGutters);

            Assert.NotNull(text);
            Assert.Equal(Align.Left, text.Instance.Align);
            Assert.Equal(Typo.subtitle1, text.Instance.Typo);

            text.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-subtitle1 mud-typography-align-left\"><b>Terms of Use Agreement</b></h6>");
        }

        [Fact]
        public void TcDisplay()
        {
            var comp = RenderComponent<Info>();
            var item = comp.FindComponents<MudListItem>()[0];
            var button = item.FindComponent<MudButton>();

            Assert.NotNull(item);
            Assert.NotNull(button);
            Assert.Equal(Variant.Text, button.Instance.Variant);
            Assert.Equal(Icons.Material.Filled.Feed, button.Instance.StartIcon);
            Assert.Equal(Icons.Material.Filled.NavigateNext, button.Instance.EndIcon);
            Assert.Equal("/termsandconditions", button.Instance.Href);
            button.MarkupMatches("<a blazor:onclick=\"8\" type=\"button\" href=\"/termsandconditions\" class=\"mud-button-root mud-button mud-button-text mud-button-text-default mud-button-text-size-medium mud-ripple\" blazor:elementReference=\"\"><span class=\"mud-button-label\"><span class=\"mud-button-icon-start mud-button-icon-size-medium\"><svg class=\"mud-icon-root mud-svg-icon mud-icon-size-medium\" focusable=\"false\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><g><path d=\"M0,0h24v24H0V0z\" fill=\"none\"/></g><g><path d=\"M16,3H5C3.9,3,3,3.9,3,5v14c0,1.1,0.9,2,2,2h14c1.1,0,2-0.9,2-2V8L16,3z M7,7h5v2H7V7z M17,17H7v-2h10V17z M17,13H7v-2h10 V13z M15,9V5l4,4H15z\"/></g></svg></span>Terms of Use Agreement<span class=\"mud-button-icon-end mud-button-icon-size-medium\"><svg class=\"mud-icon-root mud-svg-icon mud-icon-size-medium\" focusable=\"false\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z\"/></svg></span></span></a>");
            //button.Find("span").MarkupMatches("</span>termsofusa_ua<span class=\"mud-button-icon-end mud-button-icon-size-medium\">");

        }

        [Fact]
        public void PrivacyNotice_Display()
        {
            var comp = RenderComponent<Info>();
            var item = comp.FindComponents<MudListItem>()[1];
            var button = item.FindComponent<MudButton>();

            Assert.NotNull(item);
            Assert.NotNull(button);
            Assert.Equal(Variant.Text, button.Instance.Variant);
            Assert.Equal(Icons.Material.Filled.PrivacyTip, button.Instance.StartIcon);
            Assert.Equal(Icons.Material.Filled.NavigateNext, button.Instance.EndIcon);
            Assert.Equal("/termsandconditions", button.Instance.Href);
            //button.MarkupMatches("");

        }

        [Fact]
        public void UserGuide_Display()
        {
            var comp = RenderComponent<Info>();
            var item = comp.FindComponents<MudListItem>()[2];
            var button = item.FindComponent<MudButton>();

            Assert.NotNull(item);
            Assert.NotNull(button);
            Assert.Equal(Variant.Text, button.Instance.Variant);
            Assert.Equal(Icons.Material.Filled.PrivacyTip, button.Instance.StartIcon);
            Assert.Equal(Icons.Material.Filled.NavigateNext, button.Instance.EndIcon);
            Assert.Equal("/termsandconditions", button.Instance.Href);
            //button.MarkupMatches("");

        }





    }
}
