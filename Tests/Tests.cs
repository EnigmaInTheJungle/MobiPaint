using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [TestCase("New")]
        [TestCase("Open")]
        [TestCase("Save")]
        [TestCase("Save as..")]
        [TestCase("Save in cloud")]
        [TestCase("Load from cloud")]
        [TestCase("Exit")]
        public void TestFileMenu(string item)
        {
            TestMenuItem("File", item);
        }

        [TestCase("Rename")]
        [TestCase("Close")]
        [TestCase("Close all")]
        public void TestWindowMenu(string item)
        {
            TestMenuItem("Window", item);
        }

        [TestCase("Simple Figure")]
        [TestCase("Figure with text")]
        public void TestPluginsMenu(string item)
        {
            TestMenuItem("Plugins", item);
        }

        [TestCase("Dark")]
        [TestCase("Light")]
        [TestCase("Pink")]
        public void TestSkinsMenu(string item)
        {
            TestMenuItem("Skins", item);
        }

        [TestCase("English")]
        [TestCase("Russian")]
        [TestCase("Ukrainian")]
        public void TestLangMenu(string item)
        {
            TestMenuItem("Language", item);
        }

        [TestCase("About..")]
        [TestCase("Show help..")]
        public void TestHelpMenu(string item)
        {
            TestMenuItem("Help", item);
        }

        [TestCase("action_newtab", "NewTab clicked")]
        [TestCase("action_color", "Color clicked")]
        [TestCase("action_figure", "Figure clicked")]
        [TestCase("action_width", "Width clicked")]
        [TestCase("action_text", "Text clicked")]
        [TestCase("action_image", "Image clicked")]
        public void TestToolBar(string item, string res)
        {
            app.Tap(c => c.Id(item));
            app.WaitForElement(c => c.Text(res));
            app.WaitForNoElement(c => c.Text(res));
        }

        public void TestMenuItem(string menu, string item)
        {
            app.Tap(c => c.Id("toolbar").All().Index(1));
            app.Tap(c => c.Text(menu));
            app.Tap(c => c.Text(item));
            app.WaitForElement(c => c.Text(item));
            app.WaitForNoElement(c => c.Text(item));
        }
    }
}