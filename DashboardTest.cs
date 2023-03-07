using BionicApp.Pages.Add_Device;
using Bunit;
using MudBlazor;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class DashboardTest : BionicAppUiTestBase
    {
        [Fact]
        public void Tabs_DisplayTest()
        {
            var component = RenderComponent<MudTabs>(parameters => parameters
            .Add(p => p.Class, "tabContent")
            );
            var actualName = component.Find(".tabContent");
            Assert.NotNull(actualName);

        }

        [Fact]
        public void Test_tabPanelCount()
        {
            var comp = RenderComponent<Dashboard>();
            var mudtab = comp.FindComponent<MudTabs>();
            var panelcount = mudtab.Instance.Panels.Count();
            Assert.Equal(3, panelcount);
        }

        [Fact]
        public void UserPanel_Properties()
        {
            var component = RenderComponent<Dashboard>();
            var mudtab = component.FindComponent<MudTabs>();
            var activepanel = mudtab.Instance.ActivePanel;

            var aptext = activepanel.Text;
            Assert.NotNull(activepanel);
            Assert.Equal("user_ua", aptext);

            var icon = mudtab.Instance.ActivePanel.Icon;
            Assert.NotNull(activepanel);
            Assert.Equal(Icons.Material.Filled.Person, icon);


            Assert.NotNull(activepanel.Style);
            Assert.Equal("text-transform:none;", activepanel.Style);
        }

        [Fact]
        public void Adddevicepanel_properties()
        {
            var component = RenderComponent<Dashboard>();
            var mudtab = component.FindComponent<MudTabs>();
            var adpanel = mudtab.Instance.Panels[1];

            var adptext = adpanel.Text;
            Assert.NotNull(adptext);
            Assert.Equal("mydevices_ua", adptext);

            var icon = adpanel.Icon;
            Assert.NotNull(icon);
            Assert.Equal(Icons.Material.Filled.FormatListBulleted, icon);

            Assert.NotNull(adpanel.Style);
            Assert.Equal("text-transform:none;", adpanel.Style);
        }

        [Fact]
        public void Infopanel_properties()
        {
            var component = RenderComponent<Dashboard>();
            var mudtab = component.FindComponent<MudTabs>();
            var infopanel = mudtab.Instance.Panels[2];
            
            var infotext = infopanel.Text;
            Assert.NotNull(infotext);
            Assert.Equal("info_ua", infotext);

            var icon = infopanel.Icon;
            Assert.NotNull(icon);
            Assert.Equal(Icons.Material.Filled.Info, icon);

            Assert.NotNull(infopanel.Style);
            Assert.Equal("text-transform:none;", infopanel.Style);
            Assert.NotNull(infopanel.Tag);



        }




        //var mtp = comp.FindAll("div.mud-tabs-panels").GetEnumerator().MoveNext();


        [Fact]
        public async Task Test_TabSwitching()
        {
            // Arrange
            var comp = RenderComponent<Dashboard>();

            // Act
            var firstTab = comp.FindAll("div.mud-tab")[0];
            firstTab.Click();
            await Task.Delay(1000); // waiting for MudTabs animation to complete

            // Assert
            var firstTabPanel = comp.FindAll("div.mud-tab-panels")[0];
            Assert.Contains("mud-tabs-panel-active", firstTabPanel.ClassList);

            // Act
            var secondTab = comp.FindAll("div.mud-tab")[1];
            secondTab.Click();
            await Task.Delay(1000);

            // Assert
            var secondTabPanel = comp.FindAll("div.mud-tab-panels")[1];
            Assert.Contains("mud-tabs-panel-active", secondTabPanel.ClassList);
        }




        //[Fact]
        //public async Task Test_Height()
        //{
        //    // Arrange
        //    var expectedHeight = 800;
        //    var comp = RenderComponent<MudTabs>(
        //        builder => builder.Add(x => x.Value, "0"));

        //    // Act
        //    await comp.InvokeAsync(() => comp.Instance.SetHeight(expectedHeight));

        //    // Assert
        //    var tabsElement = comp.Find("div.mud-tabs") as IHtmlElement;
        //    var actualHeight = tabsElement.OffsetHeight;
        //    Assert.Equal(expectedHeight, actualHeight);
        //}

        //[Fact]
        //public void Test_HeightChange()
        //{
        //    // Arrange
        //    var expectedHeight = 800;
        //    var comp = RenderComponent<MudTabs>(parameters => parameters
        //        .Add(p => p.Value, "0")
        //        .Add(p => p.Height, expectedHeight.ToString()));

        //    // Act
        //    comp.SetParametersAndRender(parameters => parameters
        //        .Add(p => p.Height, expectedHeight.ToString()));

        //    // Assert
        //    var tabsPanel = comp.Find("div.mud-tabs-panels");
        //    var actualHeight = tabsPanel.GetBoundingClientRect().Height;
        //    Assert.Equal(expectedHeight, actualHeight);
        //}


        [Fact]
        public void Test_TabView_Height_Change()
        {
            var expectedcount = 3;
            var comp = RenderComponent<Dashboard>();
            var mtab = comp.FindComponent<MudTabs>();
            var tabp = mtab.FindAll("div.mud-tab-panels");
            Assert.Equal(expectedcount, tabp.Count);

            //var expectedHeight = 800;

            //comp.Instance.MaxHeight = expectedHeight;

            //comp.WaitForAssertion(() =>
            //{
            //    var tabContentElements = comp.FindAll("div.mud-tab-panels");
            //    foreach (var element in tabContentElements)
            //    {
            //        Assert.Equal($"{expectedHeight}px", element.GetAttribute("style").Split(';').FirstOrDefault(s => s.Contains("max-height"))?.Split(':')[1]?.Trim());
            //        //getattribute to get styles -split method to split style attribute value into array of individual styles - firstordefault -to first style decoration contains maxheight - if exists - split into property name and value seperated by : -finally trim removing whitespaces from property value--- then compare with maxheight
            //    }
            //});
        }

        //[Fact]
        //public async Task Window_Height_Change()
        //{
        //    // Arrange
        //    var windowHeight = 800;
        //    var expectedHeightCss = $"{windowHeight}px";
        //    var expectedWrapperHeight = $"calc({expectedHeightCss} - 64px)";

        //    var comp = RenderComponent<Dashboard>(
        //        new[] {
        //    ComponentParameter.CreateParameter("Value", "0")
        //        });

        //    // Act
        //    await comp.InvokeAsync(() => comp.Instance._height = windowHeight);
        //    await comp.InvokeAsync(() => comp.Instance.CreateTabs());

        //    // Assert
        //    var wrapper = comp.Find(".wrapperContent");
        //    var wrapperStyle = wrapper.GetAttribute("style");
        //    Assert.Contains(expectedWrapperHeight, wrapperStyle);

        //    var tabs = comp.FindAll(".tabItem");
        //    foreach (var tab in tabs)
        //    {
        //        var expectedTabStyle = $"width: 117px; height: {expectedHeightCss};";
        //        Assert.Equal(expectedTabStyle, tab.GetAttribute("style"));
        //    }
        //}

        //    [Fact]
        //    public async Task Test_Window_Height()
        //    {
        //        // Arrange
        //        var height = 800;
        //        var comp = RenderComponent<Dashboard>(new[] {
        //    Parameter(nameof(Dashboard.Value), "0")
        //});
        //        comp.Instance._height = height;

        //        // Act
        //        await comp.InvokeAsync(() => comp.Instance.CreateTabs());

        //        // Assert
        //        var wrapperContent = comp.Find(".wrapperContent");
        //        var expectedHeightCss = $"{height}px";
        //        var expectedWrapperContentHeight = $"calc({expectedHeightCss} - 0px)";
        //        Assert.Equal(expectedWrapperContentHeight, wrapperContent.GetAttribute("style"));
        //    }




        //[Fact]
        //public void UserTab_HasCorrectName()
        //{
        //    // Arrange
        //    var component = RenderComponent<Dashboard>(parameters =>
        //        parameters
        //            .Add(p => p.Value, "0")
        //    );

        //    // Act
        //    var tab = component.Find(".tabItem");
        //    var name = tab.TextContent.Trim();

        //    // Assert
        //    Assert.Equal("User", name);
        //}

        //[Fact]
        //public void UserTabCorrectName()
        //{
        //    var userTab = RenderComponent<MudTabPanel>(p =>
        //        p.Add(x => x.Text, "User")
        //         .Add(x => x.Icon, Icons.Material.Filled.Person)
        //         .Add(x => x.Tag, "user_ua")
        //    );

        //    // Assert that the tab has the correct name
        //    Assert.Equal("User", userTab.ToString());
        //}

        //[Fact]
        //public async Task TabSwitching()
        //{
        //    // Arrange
        //    var comp = RenderComponent<MudTabs>();

        //    // Add tabs to the component
        //    var tab1 = comp.Instance.AddTab("Tab 1");
        //    var tab2 = comp.Instance.AddTab("Tab 2");

        //    // Act
        //    await comp.InvokeAsync(() =>
        //    {
        //        // Click on the first tab
        //        comp.FindAll("div.mud-tab")[0].Click();
        //    });

        //    await Task.Delay(1000); // Wait for MudTabs animation to complete

        //    // Assert
        //    var activeTabPanel = comp.Find("div.mud-tabs-panel-active");
        //    Assert.Equal(tab1, activeTabPanel.Instance);

        //    // Act
        //    await comp.InvokeAsync(() =>
        //    {
        //        // Click on the second tab
        //        comp.FindAll("div.mud-tab")[1].Click();
        //    });

        //    await Task.Delay(1000); // Wait for MudTabs animation to complete

        //    // Assert
        //    activeTabPanel = comp.Find("div.mud-tabs-panel-active");
        //    Assert.Equal(tab2, activeTabPanel.Instance);
        //}

        //[Fact]
        //public async Task Test_TabSwitching()
        //{
        //    // Arrange
        //    var comp = RenderComponent<MudTabs>();

        //    // Act
        //    var tab1 = comp.Find("div.mud-tab", t => t.TextContent == "Tab 1");
        //    tab1.Click();
        //    await Task.Delay(1000); // waiting for MudTabs animation to complete

        //    // Assert
        //    var activePanel1 = comp.Find("div.mud-tabs-panel-active", p => p.HasAttribute("role") && p.GetAttribute("role") == "tabpanel");
        //    Assert.NotNull(activePanel1);
        //    Assert.Equal("Tab 1 Content", activePanel1.TextContent.Trim());

        //    // Act
        //    var tab2 = comp.Find("div.mud-tab", t => t.TextContent == "Tab 2");
        //    tab2.Click();
        //    await Task.Delay(1000);

        //    // Assert
        //    var activePanel2 = comp.Find("div.mud-tabs-panel-active", p => p.HasAttribute("role") && p.GetAttribute("role") == "tabpanel");
        //    Assert.NotNull(activePanel2);
        //    Assert.Equal("Tab 2 Content", activePanel2.TextContent.Trim());
        //}






    }
}

