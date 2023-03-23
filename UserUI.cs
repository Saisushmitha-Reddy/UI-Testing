using BionicApp.Services;
using Bunit;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Ossur.Bionics.Common;
using Ossur.Bionics.Common.Models;
using System.Data;
using System.Globalization;
using Xunit;
using User = BionicApp.Pages.Add_Device.User;

namespace BionicAppTestRunner.BionicAppUi
{
    public class UserUI : BionicAppUiTestBase
    {
        [Fact]
        public void checkmainStackPro()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            Assert.Equal("ma-2 pa-3 stackLayout", mudStack.Instance.Class);

        }
        [Fact]
        public void checkNumberOfMudstack()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var countStack = mudStack.FindComponents<MudStack>().Count();
            Assert.Equal(5, countStack);
        }

        [Fact]
        public void check1stMudstackProperty()
        {
            var component = RenderComponent<User>();
            var Stack = component.FindComponent<MudStack>();
            var firstStack = Stack.FindComponent<MudStack>();
            Assert.Equal(AlignItems.Center, firstStack.Instance.AlignItems);
            Assert.Equal(Justify.Center, firstStack.Instance.Justify);
            Assert.Equal(2, firstStack.Instance.Spacing);
        }

        [Fact]
        public async void checkMudTextin1stmudStack()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            var Stack = component.FindComponent<MudStack>();
            var firstStack = Stack.FindComponent<MudStack>();
            var mudText = firstStack.FindComponent<MudText>();
            Assert.Equal(Align.Center, mudText.Instance.Align);
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.Find("b").MarkupMatches("<b>User</b>");

        }
        [Fact]
        public void checkMudAvtar()
        {
            var component = RenderComponent<User>();
            var avtar = component.FindComponent<MudAvatar>();
            Assert.NotNull(avtar);
            Assert.Equal(MudBlazor.Color.Primary, avtar.Instance.Color);
            Assert.Equal(MudBlazor.Size.Large, avtar.Instance.Size);
        }
        [Fact]
        public async void CheckAvtarTest()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            var component = RenderComponent<User>();
            var mudavatar = component.FindComponent<MudAvatar>();
            mudavatar.Find("div").MarkupMatches("<div class=\"mud-avatar mud-avatar-large mud-avatar-outlined mud-avatar-outlined-primary mud-elevation-0\" style=\"\">T</div>");

        }

        [Fact]
        public void checkSecondMudStackPro()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[1];
            Assert.Equal(0, secondStack.Instance.Spacing);
        }

        [Fact]
        public async void checkNameMudField()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            var name = component.FindComponent<MudField>();
            Assert.Equal("Name", name.Instance.Label);
            Assert.NotNull(name.Instance.Label);
            Assert.Equal(Variant.Text, name.Instance.Variant);
        }

        [Fact]
        public async void checkEmailMudField()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            var email = component.FindComponents<MudField>()[1];
            Assert.Equal("Email", email.Instance.Label);
            Assert.NotNull(email.Instance.Label);
            Assert.Equal(Variant.Text, email.Instance.Variant);
        }

        [Fact]
        public async void checkRoleMudField()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            var role = component.FindComponents<MudField>()[2];
            Assert.Equal("Role", role.Instance.Label);
            Assert.NotNull(role.Instance.Label);
            Assert.Equal(Variant.Text, role.Instance.Variant);
        }


        [Fact]
        public async void NameTest()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            var component = RenderComponent<User>();
            var mudfield = component.FindComponent<MudField>();
            var mudtext = mudfield.FindComponent<MudText>();
            mudtext.Find("p").MarkupMatches("<p class=\"mud-typography mud-typography-body2\">Test User Admin</p>");
        }


        [Fact]
        public async void EmailTest()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            var component = RenderComponent<User>();
            var mudfield = component.FindComponents<MudField>()[1];
            var mudtext = mudfield.FindComponent<MudText>();
            mudtext.Find("p").MarkupMatches("<p class=\"mud-typography mud-typography-body2\">TST_ADMIN@EXAMPLE.COM</p>");
        }

        [Fact]
        public async void RoleTest()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            var component = RenderComponent<User>();
            var mudfield = component.FindComponents<MudField>()[2];
            var mudtext = mudfield.FindComponent<MudText>();
            mudtext.Find("p").MarkupMatches("<p class=\"mud-typography mud-typography-body2\">Admin,LogicExpert,LogicUser</p>");
        }

        [Fact]
        public void checkthirdMudStackPro()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            Assert.Equal(2, secondStack.Instance.Spacing);
        }
        [Fact]
        public async void MudTextpropertythirdStack()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudtext = secondStack.FindComponent<MudText>();
            Assert.Equal(Typo.h6, mudtext.Instance.Typo);
            mudtext.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-h6\">Settings and preferences</h6>");

        }
        [Fact]
        public void MudstackpropertythirdStack()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudStackinner = secondStack.FindComponent<MudStack>();
            Assert.Equal(AlignItems.Center, mudStackinner.Instance.AlignItems);
            Assert.True(mudStackinner.Instance.Row);
        }
        [Fact]
        public async void MudtextpropertythirdStack_stack()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudStackinner = secondStack.FindComponent<MudStack>();
            var mudtext = mudStackinner.FindComponent<MudText>();
            Assert.Equal(Align.Center, mudtext.Instance.Align);
            Assert.Equal(Typo.body2, mudtext.Instance.Typo);
            mudtext.Find("p").MarkupMatches("<p class=\"mud-typography mud-typography-body2 mud-typography-align-center\">Language</p>");
        }
        [Fact]
        public async void checkMudSelectlan()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            var component = RenderComponent<User>();
            var LanSelect = component.FindComponent<MudSelect<Language>>();
            Assert.NotNull(LanSelect);
            Assert.False(LanSelect.Instance.MultiSelection);
            Assert.Equal(Variant.Outlined, LanSelect.Instance.Variant);
            Assert.Equal(Origin.BottomCenter, LanSelect.Instance.AnchorOrigin);
            Assert.False(LanSelect.Instance.MultiSelection);
            Assert.Equal("English", LanSelect.Instance.Value.Name);
        }
        public Language selectedLanguage;
        [Fact]
        public async void checkMudSelectItemLan()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            var dataAdapter = new DataCollectionAdapter();
            var code = Manager.Instance.GetUserLanguageCode();
            const string key = "TranslationCutoffDate";
            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            if (dataAdapter.SupportedLanguages.Any(a => a.Id.Equals(code)))
            {
                selectedLanguage = dataAdapter.SupportedLanguages.Where(a => a.Id.Equals(code)).FirstOrDefault();
            }
            else
            {
                selectedLanguage = dataAdapter.SupportedLanguages.ToList().Find(a => a.Id.Equals("en"));
            }
            dataAdapter.SupportedLanguages = dataAdapter.SupportedLanguages.OrderBy(a => a.Name).ToList();


            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudStackinner = secondStack.FindComponents<MudStack>()[0];
            var LanSelect = mudStackinner.FindComponent<MudSelect<Language>>();
            var count = 0;
            foreach (Language language in dataAdapter.SupportedLanguages)
            {
                var selectItem = LanSelect.FindComponents<MudSelectItem<Language>>();
                count++;
            }
            Assert.Equal(19, count);
            Assert.Equal("Chinese", dataAdapter.SupportedLanguages[0].Name);
        }


        [Fact]
        public void SecondMudstackpropertythirdStack()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudStackinner = secondStack.FindComponents<MudStack>()[1];
            Assert.Equal(AlignItems.Center, mudStackinner.Instance.AlignItems);
            Assert.True(mudStackinner.Instance.Row);
        }
        [Fact]
        public async void MudtextpropertythirdStack_Secondstack()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudStackinner = secondStack.FindComponents<MudStack>()[1];
            var mudtext = mudStackinner.FindComponent<MudText>();
            Assert.Equal(Align.Center, mudtext.Instance.Align);
            Assert.Equal(Typo.body2, mudtext.Instance.Typo);
            mudtext.Find("p").MarkupMatches("<p class=\"mud-typography mud-typography-body2 mud-typography-align-center\">Units</p>");
        }
        [Fact]
        public void MudSelectpropertythirdStack_Secondstack()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudStackinner = secondStack.FindComponents<MudStack>()[1];
            var mudselect = mudStackinner.FindComponent<MudSelect<string>>();
            Assert.Equal(Variant.Outlined, mudselect.Instance.Variant);
            Assert.Equal(Origin.BottomCenter, mudselect.Instance.AnchorOrigin);

        }
        [Fact]
        public void CheckMudSelectItem1()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudStackinner = secondStack.FindComponents<MudStack>()[1];
            var mudselect = mudStackinner.FindComponent<MudSelect<string>>();
            var mudselit = mudselect.FindComponent<MudSelectItem<string>>();
            Assert.Equal("Metric", mudselit.Instance.Value);
        }

        [Fact]
        public void CheckMudSelectItem2()
        {
            var component = RenderComponent<User>();
            var mudStack = component.FindComponent<MudStack>();
            var secondStack = mudStack.FindComponents<MudStack>()[2];
            var mudStackinner = secondStack.FindComponents<MudStack>()[1];
            var mudselect = mudStackinner.FindComponent<MudSelect<string>>();
            var mudselit = mudselect.FindComponents<MudSelectItem<string>>()[1];
            Assert.Equal("Imperial", mudselit.Instance.Value);
        }

        [Fact]
        public async void checkLogoutButtonProperty()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            var component = RenderComponent<User>();
            var LogoutButton = component.FindComponent<MudButton>();
            Assert.NotNull(LogoutButton);
            Assert.Equal(MudBlazor.Color.Primary, LogoutButton.Instance.Color);
            Assert.Equal(" height:52px; text-transform:none;", LogoutButton.Instance.Style);
            LogoutButton.Find("span").MarkupMatches("<span class=\"mud-button-label\">Log out</span>");
        }
        [Fact]
        public void CheckButtonNevigation()
        {
            var component = RenderComponent<User>();
            var nav = component.Services.GetRequiredService<NavigationManager>();
            var button = component.FindComponent<MudButton>();
            var buttonclick = button.Instance.OnClick;
            Assert.Equal("http://localhost/", nav.Uri);
        }



    }
}
