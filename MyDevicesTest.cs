using AngleSharp.Common;
using BionicApp.Pages.Add_Device.My_Devices;
using Bunit;
using MudBlazor;
using Ossur.Bionics.Common;
using System.Globalization;
using Xunit;
using static MudBlazor.CategoryTypes;
using Color = MudBlazor.Color;

namespace BionicAppTestRunner.BionicAppUi
{
    public class MyDevicesTest : BionicAppUiTestBase
    {
        [Fact]
        public void Stack_Test()
        {
            var comp = RenderComponent<MyDevices>();
            var stack = comp.FindComponent<MudStack>();

            Assert.Equal(0, stack.Instance.Spacing);
            Assert.Equal("stackLayout", stack.Instance.Class);
            Assert.False(stack.Instance.Row);
            Assert.NotNull(stack);
        }

        [Fact]
        public async void MyDevicesText_Display()
        {
            await Manager.Instance.Login("https://bionicregistry40dev.azurewebsites.net/api/v1", "tst_admin@example.com", "tst_admin_42");

            const string key = "TranslationCutoffDate";

            var cutoff = Manager.Instance.GetValue(key, DateTime.MinValue);
            await Manager.Instance.CloudSync.PullTranslationsFromCloud(cutoff, 1, 1000, "en", "USERAPP_V1.0");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");

            var comp = RenderComponent<MyDevices>();
            var mudText = comp.FindComponent<MudText>();

            Assert.Equal(Align.Center, mudText.Instance.Align);
            Assert.Equal(Typo.h6, mudText.Instance.Typo);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-h6 mud-typography-align-center\">My Devices</h6>");
        }

        //[Fact]
        //public void MydevicesTextDisplay()
        //{
        //    var comp = RenderComponent<MyDevices>();
        //    var mudtext = comp.FindComponents<MudText>()[0];
        //    mudtext.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-h6 mud-typography-align-center\">mydevices_ua</h6>");
        //}

        [Fact]
        public void MudExapnsion_Properties()
        {
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanels>();

            Assert.NotNull(exp);
            Assert.Equal("ma-0 pa-0", exp.Instance.Class);
            Assert.False(exp.Instance.MultiExpansion);
        }

        [Fact]
        public void Tests_ExpansionPanel()
        {
            mydevicemethod();

            var comp = RenderComponent<MyDevices>();
            //var expansionPanel = comp.FindAll(".mud-panel-expanded");
            var expansionPanel = comp.FindComponent<MudExpansionPanel>();

            Assert.NotNull(expansionPanel);
            Assert.Equal("padding:0px;margin:0px;", expansionPanel.Instance.Style);
            Assert.Equal("ma-0 pa-0", expansionPanel.Instance.Class);
            Assert.True(expansionPanel.Instance.IsInitiallyExpanded);

        }

        [Fact]
        public void MudStack0()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var ms = exp.FindComponent<MudStack>();
            Assert.NotNull(ms);
            Assert.Equal(0, ms.Instance.Spacing);
            Assert.True(ms.Instance.Row);
            Assert.Equal(Justify.SpaceBetween, ms.Instance.Justify);

        }

        [Fact]
        public void Test_DeviceName()
        {
            mydevicemethod();

            var comp = RenderComponent<MyDevices>();
            var expansionPanel = comp.FindComponent<MudExpansionPanel>();
            var mudText = expansionPanel.FindComponents<MudText>()[0];

            Assert.NotNull(mudText);
            Assert.Equal("ma-0 pa-0", mudText.Instance.Class);
            mudText.Find("h6").MarkupMatches("<h6 class=\"mud-typography mud-typography-h6 ma-0 pa-0\">390775</h6>");
            Assert.Equal(Typo.h6, mudText.Instance.Typo);

        }

        [Fact]
        public void MudStack2()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var ms = exp.FindComponents<MudStack>()[2];
            Assert.NotNull(ms);
            Assert.Equal(2, ms.Instance.Spacing);
            Assert.True(ms.Instance.Row);
            Assert.Equal(Justify.SpaceAround, ms.Instance.Justify);
            Assert.Equal(AlignItems.Center, ms.Instance.AlignItems);
        }

        [Fact]
        public void Test_PeripheralId()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var expansionPanel = comp.FindComponent<MudExpansionPanel>();
            var mudText = expansionPanel.FindComponents<MudText>()[1];

            Assert.NotNull(mudText);
            Assert.Equal(Typo.caption, mudText.Instance.Typo);
            mudText.MarkupMatches("<span class=\"mud-typography mud-typography-caption\">390775</span>");
        }

        [Fact]
        public void MudStack3()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var ms = exp.FindComponents<MudStack>()[3];

            Assert.NotNull(ms);
            Assert.Equal(1, ms.Instance.Spacing);
            Assert.True(ms.Instance.Row);
            Assert.Equal(Justify.SpaceAround, ms.Instance.Justify);
            Assert.Equal(AlignItems.Center, ms.Instance.AlignItems);
        }

        [Fact]
        public void Test_BatteryImg_Prprts()
        {

            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var image = exp.FindComponent<MudImage>();

            Assert.NotNull(image);
            Assert.Equal(ObjectFit.Fill, image.Instance.ObjectFit);
            Assert.Equal("/images/battery.png", image.Instance.Src);
            Assert.Equal(0, image.Instance.Elevation);
            Assert.Equal(15, image.Instance.Width);
            Assert.Equal(20, image.Instance.Height);
            Assert.Equal(ObjectPosition.Center, image.Instance.ObjectPosition);

        }

        [Fact]
        public void Test_BatteryStatus()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var mudText = exp.FindComponents<MudText>()[2];

            Assert.NotNull(mudText);
            Assert.Equal(Typo.caption, mudText.Instance.Typo);
            mudText.MarkupMatches("<span class=\"mud-typography mud-typography-caption\">0%</span>");
        }

        [Fact]
        public void Test_mudDividerproperties()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var div = exp.FindComponents<MudDivider>()[1];

            Assert.NotNull(div);
            Assert.True(div.Instance.FlexItem);
            Assert.True(div.Instance.Vertical);
        }

        [Fact]
        public void MudStack4()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var ms = exp.FindComponents<MudStack>()[4];

            Assert.NotNull(ms);
            Assert.Equal(0, ms.Instance.Spacing);
            Assert.True(ms.Instance.Row);
            Assert.Equal(Justify.SpaceAround, ms.Instance.Justify);
            Assert.Equal(AlignItems.Center, ms.Instance.AlignItems);
        }

        [Fact]
        public void MudIcon_Walk()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var icon = exp.FindComponents<MudIcon>()[0];

            Assert.NotNull(icon);
            Assert.Equal("width:15px;height:20px;", icon.Instance.Style);
            Assert.Equal(Icons.Material.Filled.DirectionsWalk, icon.Instance.Icon);
        }

        [Fact]
        public void StepCount_Text()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var mudText = exp.FindComponents<MudText>()[3];

            Assert.NotNull(mudText);
            mudText.MarkupMatches("<span class=\"mud-typography mud-typography-caption\">0</span>");
            Assert.Equal(Typo.caption, mudText.Instance.Typo);

        }

        [Fact]
        public void Test_MudIconButton()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var button = exp.FindComponent<MudIconButton>();

            Assert.NotNull(button);
            Assert.Equal("ml-6", button.Instance.Class);
            Assert.True(button.Instance.Disabled);

        }

        [Fact]
        public void AddDeviceButton_Properties()
        {
            var comp = RenderComponent<MyDevices>();
            var button = comp.FindComponent<MudButton>();

            Assert.NotNull(button);
            Assert.Equal(Variant.Filled, button.Instance.Variant);
            Assert.Equal(Color.Primary, button.Instance.Color);
            Assert.Equal("ml-auto", button.Instance.Class);
            Assert.True(button.Instance.FullWidth);
            Assert.Equal("height:50px; position:absolute;bottom:0px; text-transform:none;", button.Instance.Style);
            button.MarkupMatches("<button blazor:onclick=\"1\" type=\"button\" class=\"mud-button-root mud-button mud-button-filled mud-button-filled-primary mud-button-filled-size-medium mud-width-full mud-ripple ml-auto\" style=\"height:50px; position:absolute;bottom:0px; text-transform:none;\" blazor:onclick:stopPropagation blazor:elementReference=\"\"><span class=\"mud-button-label\">add_device_ua</span></button>");
        }

        [Fact]
        public void Test_MudPaper()
        {
            mydevicemethod();
            var comp = RenderComponent<MyDevices>();
            var exp = comp.FindComponent<MudExpansionPanel>();
            var paper = exp.FindComponents<MudPaper>()[0];

            Assert.NotNull(paper);
            Assert.Equal("d-flex flex-row flex-wrap justify-center flex-grow-1 gap-4", paper.Instance.Class);
            Assert.Equal(0, paper.Instance.Elevation);
        }

        [Fact]
        public void Testing_tabviews()
        {
            var comp = RenderComponent<MyDevices>();
            
            var expnls = comp.FindComponent<MudExpansionPanels>();
            mydevicemethod();

            var exp = expnls.FindAll("mud-expand-panel mud-panel-expanded mud-elevation-1 mud-expand-panel-border ma-0 pa-0");

            expnls.Instance.ExpandAll();

            //Assert.Equal(6, comp.Instance.tabViewOptions.Count);



        }






    }

}
