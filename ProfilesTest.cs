using BionicApp.Components;
using BionicApp.Data;
using BionicApp.Pages.Add_Device.My_Devices.DeviceProfiles;
using Bunit;
using MudBlazor;
using System.Reflection;
using Xunit;
using Color = MudBlazor.Color;

namespace BionicAppTestRunner.BionicAppUi
{
    public class ProfilesTest : BionicAppUiTestBase
    {
        [Fact]
        public void MudStack1_Test()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();
            var stack = comp.FindComponents<MudStack>()[0];

            Assert.Equal(2, stack.Instance.Spacing);
            Assert.Equal("pa-2", stack.Instance.Class);
            Assert.False(stack.Instance.Row);
            Assert.NotNull(stack);
        }

        [Fact]
        public void GridAnd_Icon()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();
            var grid = comp.FindComponents<MudGrid>()[0];
            var iconbutn = grid.FindComponent<MudIconButton>();

            Assert.NotNull(grid);
            Assert.Equal(Justify.FlexStart, grid.Instance.Justify);
            Assert.Equal(2, grid.Instance.Spacing);

            Assert.NotNull(iconbutn);
            Assert.Equal(Icons.Material.Filled.ArrowBack, iconbutn.Instance.Icon);
        }

        [Fact]
        public void TextDisplay()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();
            var mudtext = comp.FindComponents<MudText>()[0];

            Assert.NotNull(mudtext);
            Assert.Equal("pa-2", mudtext.Instance.Class);
            Assert.Equal(Align.Center, mudtext.Instance.Align);
            Assert.Equal(Typo.h6, mudtext.Instance.Typo);
            mudtext.MarkupMatches("<h6 class=\"mud-typography mud-typography-h6 mud-typography-align-center pa-2\">390775</h6>");
        }

        [Fact]
        public void MyProfileText_Test()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();
            var stack = comp.FindComponents<MudStack>()[1];
            var mudtext = comp.FindComponents<MudText>()[1];


            Assert.Equal("ma-4", stack.Instance.Class);
            Assert.NotNull(stack);

            Assert.Equal("pl-2", mudtext.Instance.Class);
            Assert.Equal(Typo.h5, mudtext.Instance.Typo);
            Assert.Equal(Align.Left, mudtext.Instance.Align);
            mudtext.MarkupMatches("<h5 class=\"mud-typography mud-typography-h5 mud-typography-align-left pl-2\"><b>myprofiles_ua</b></h5>");
        }

        [Fact]
        public void test_grid()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();
            var grid = comp.FindComponents<MudGrid>()[1];

            Assert.NotNull(grid);
            Assert.Equal(2, grid.Instance.Spacing);
        }

        [Fact]
        public void Test_ProfilesCount()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();

            var ProfilesProp = comp.Instance.GetType().GetField("profiles", BindingFlags.NonPublic | BindingFlags.Instance);
            var ProfileOptions = (List<TabView>)ProfilesProp.GetValue(comp.Instance);

            Assert.NotNull(ProfileOptions);
            Assert.Equal(4, ProfileOptions.Count);
            Assert.Equal(100, comp.Instance.cardImageSize);
        }

        [Fact]
        public void Test_ProfilePaper()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();
            var paper = comp.FindComponent<MudPaper>();

            Assert.NotNull(paper);
            Assert.Equal("d-flex align-center justify-center mud-width-full py-8", paper.Instance.Class);
            Assert.False(paper.Instance.Outlined);
            Assert.Equal(1, paper.Instance.Elevation);
        }

        [Fact]
        public void Test_ProfileImage()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();
            var image = comp.FindComponent<CustomImage>();

            Assert.NotNull(image);
            Assert.Equal(ObjectFit.Fill, image.Instance.ObjectFit);
            Assert.Equal("/images/logo.png", image.Instance.Src);
            Assert.Equal("Ossur Icon", image.Instance.Alt);
            Assert.Equal(ObjectPosition.Center, image.Instance.ObjectPosition);
            Assert.Equal(100, image.Instance.Width);
            Assert.Equal(100, image.Instance.Height);
        }

        [Fact]
        public void Test_StackAnd_Button()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();
            var stack = comp.FindComponents<MudStack>()[2];
            var button = comp.FindComponent<MudButton>();

            Assert.NotNull(stack);
            Assert.Equal(Justify.Center, stack.Instance.Justify);
            Assert.Equal("ml-2 mr-2", stack.Instance.Class);
            Assert.Equal("height: 50px;", stack.Instance.Style);

            Assert.NotNull(button);
            Assert.Equal("text-transform:none;", button.Instance.Style);
            Assert.Equal(Variant.Filled, button.Instance.Variant);
            Assert.Equal("ml-auto", button.Instance.Class);
            Assert.Equal(Color.Primary, button.Instance.Color);
            Assert.True(button.Instance.FullWidth);
            button.MarkupMatches("<button blazor:onclick=\"1\" type=\"button\" class=\"mud-button-root mud-button mud-button-filled mud-button-filled-primary mud-button-filled-size-medium mud-width-full mud-ripple ml-auto\" style=\"text-transform:none;\" blazor:onclick:stopPropagation blazor:elementReference=\"\"><span class=\"mud-button-label\">createprofile_ua</span></button>");
        }

        [Fact]
        public void Test_ProfilesNames()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();

            var ProfilesProp = comp.Instance.GetType().GetField("profiles", BindingFlags.NonPublic | BindingFlags.Instance);
            var ProfileOptions = (List<TabView>)ProfilesProp.GetValue(comp.Instance);

            Assert.Equal("Profile1", ProfileOptions[0].Name);
            Assert.Equal("Profile2", ProfileOptions[1].Name);
            Assert.Equal("Profile3", ProfileOptions[2].Name);
            Assert.Equal("Profile4", ProfileOptions[3].Name);

        }

        [Fact]
        public void Test_Profilesimages()
        {
            Mydevicemethod2();
            var comp = RenderComponent<Profiles>();

            var ProfilesProp = comp.Instance.GetType().GetField("profiles", BindingFlags.NonPublic | BindingFlags.Instance);
            var ProfileOptions = (List<TabView>)ProfilesProp.GetValue(comp.Instance);

            Assert.Equal(Icons.Material.Filled.Person, ProfileOptions[0].ImageURL);
            Assert.Equal(Icons.Material.Filled.Person, ProfileOptions[1].ImageURL);
            Assert.Equal(Icons.Material.Filled.Person, ProfileOptions[2].ImageURL);
            Assert.Equal(Icons.Material.Filled.Person, ProfileOptions[3].ImageURL);
        }


    }
}
