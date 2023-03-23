using BionicApp.Pages.Add_Device.My_Devices;
using Bunit;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class StepCountUI : BionicAppUiTestBase
    {
        [Fact]
        public void CheckDisplayName()
        {
            Mydevicemethod2();
            var component = RenderComponent<StepCount>();
            var mudtext = component.FindComponents<MudText>()[1];
            Assert.Equal(Typo.subtitle1, mudtext.Instance.Typo);
            mudtext.Find("b").MarkupMatches("<b>390775</b>");
        }
        [Fact]
        public void CheckModelName()
        {
            Mydevicemethod2();
            var component = RenderComponent<StepCount>();
            var mudtext = component.FindComponents<MudText>()[2];
            Assert.Equal(Typo.caption, mudtext.Instance.Typo);
            mudtext.MarkupMatches("<span class=\"mud-typography mud-typography-caption\">PROPRIO_FOOT</span>");
        }
        [Fact]
        public void CheckstepCountText()
        {
            Mydevicemethod2();
            var component = RenderComponent<StepCount>();
            var mudpaper = component.FindComponent<MudPaper>();
            Assert.Equal("mx-auto pa-12 rounded-circle", mudpaper.Instance.Class);
            Assert.Equal("background-color: #D9D9D9;", mudpaper.Instance.Style);
            var mudtext = mudpaper.FindComponent<MudText>();
            Assert.Equal(Typo.body1, mudtext.Instance.Typo);
            mudtext.MarkupMatches("<p class=\"mud-typography mud-typography-body1\">0</p>");
        }
    }
}
