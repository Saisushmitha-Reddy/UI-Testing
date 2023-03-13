using BionicApp.Pages.Add_Device;
using Bunit;
using MudBlazor;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class AddDevicesTest : BionicAppUiTestBase
    {
        [Fact]
        public void MudStack_Test()
        {
            var comp = RenderComponent<AddDevices>();
            var stack = comp.FindComponent<MudStack>();

            Assert.Equal(3, stack.Instance.Spacing);
            Assert.Equal("pa-2 stepsCarouselStatck", stack.Instance.Class);
            Assert.False(stack.Instance.Row);
            Assert.NotNull(stack);

        }
    }
}
