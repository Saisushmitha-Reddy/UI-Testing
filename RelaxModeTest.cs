using BionicApp.Pages.Add_Device.My_Devices.DeviceSettings;
using Bunit;
using MudBlazor;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class RelaxModeTest : BionicAppUiTestBase
    {
        [Fact]
        public void MudStack_Test()
        {
            var comp = RenderComponent<RelaxMode>();
            var stack = comp.FindComponents<MudStack>()[0];

            Assert.Equal(4, stack.Instance.Spacing);
            Assert.Equal("pa-4", stack.Instance.Class);
            Assert.False(stack.Instance.Row);
            Assert.NotNull(stack);
        }

        [Fact]
        public void MudText_AndButton()
        {
            var comp = RenderComponent<RelaxMode>();
            var mudtext = comp.FindComponents<MudText>()[0];
            var button = comp.FindComponent<MudButton>();

            Assert.Equal(Align.Right, mudtext.Instance.Align);
            Assert.Equal(" btn-close", button.Instance.Class);
        }

        [Fact]
        public void Test_MudPaper()
        {
            var comp = RenderComponent<RelaxMode>();
            var paper = comp.FindComponents<MudPaper>()[0];

            Assert.NotNull(paper);
            Assert.Equal(0, paper.Instance.Elevation);
            Assert.Equal("d-flex justify-space-between", paper.Instance.Class);
        }

        [Fact]
        public void Test_RelaxModeSwitch_Text()
        {
            var comp = RenderComponent<RelaxMode>();
            var sw = comp.FindComponent<MudSwitch<bool>>();

            Assert.NotNull(sw);
            Assert.False(sw.Instance.Checked);
            //var changed = sw.Instance.CheckedChanged;
            //Assert.True(changed.HasDelegate);
            //Assert.True(sw.Instance.CheckedChanged);

        }

        [Fact]
        public void Test_PaperImage()
        {
            var comp = RenderComponent<RelaxMode>();
            var paper = comp.FindComponents<MudPaper>()[1];
            var image = comp.FindComponent<MudImage>();

            Assert.NotNull(paper);
            Assert.Equal("d-flex justify-center", paper.Instance.Class);
            Assert.Equal(0, paper.Instance.Elevation);

            Assert.NotNull(image);
            Assert.Equal(ObjectFit.Fill, image.Instance.ObjectFit);
            Assert.True(image.Instance.Fluid);
            Assert.Equal("/images/logo.png", image.Instance.Src);
            Assert.Equal(0, image.Instance.Elevation);
        }

        [Fact]
        public void MudStack_Test2()
        {
            var comp = RenderComponent<RelaxMode>();
            var stack = comp.FindComponents<MudStack>()[1];

            Assert.Equal(5, stack.Instance.Spacing);
            Assert.False(stack.Instance.Row);
            Assert.NotNull(stack);
        }

        [Fact]
        public void Text_Description()
        {
            var comp = RenderComponent<RelaxMode>();
            var mudtext = comp.FindComponents<MudText>()[2];

            Assert.NotNull(mudtext);
            Assert.Equal(Typo.body1, mudtext.Instance.Typo);
            mudtext.MarkupMatches("<p class=\"mud-typography mud-typography-body1\">relaxmode_description_ua</p>");
        }

        [Fact]
        public void Text_History()
        {
            var comp = RenderComponent<RelaxMode>();
            var mudtext = comp.FindComponents<MudText>()[3];

            Assert.NotNull(mudtext);
            Assert.Equal(Typo.h5, mudtext.Instance.Typo);
            mudtext.Find("h5").MarkupMatches("<h5 class=\"mud-typography mud-typography-h5\">history_ua</h5>");
        }

        [Fact]
        public void Test_Paper3()
        {
            var comp = RenderComponent<RelaxMode>();
            var paper = comp.FindComponents<MudPaper>()[2];

            Assert.NotNull(paper);
            Assert.Equal("d-flex justify-space-between", paper.Instance.Class);
            Assert.Equal(0, paper.Instance.Elevation);
        }

        [Fact]
        public void Test_Relaxmodedate()
        {
            var comp = RenderComponent<RelaxMode>();
            var mudtext = comp.FindComponents<MudText>()[4];

            Assert.NotNull(mudtext);
            Assert.Equal(Typo.body1, mudtext.Instance.Typo);
            //Assert.Equal(DateTime.Now, Preferences.Get("LastmodeD", DateTime.Now));

        }

        [Fact]
        public void ModeText()
        {
            var comp = RenderComponent<RelaxMode>();
            var mudtext = comp.FindComponents<MudText>()[5];

            Assert.NotNull(mudtext);
            Assert.Equal(Typo.body1, mudtext.Instance.Typo);

        }

    }
}
