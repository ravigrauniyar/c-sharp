using System;
namespace Internship{

    public interface IGUIFactory{
        public IButton CreateButton();
        public ILabel CreateLabel();
    }
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton(){
            return new WindowsButton();
        }
        public ILabel CreateLabel(){
            return new WindowsLabel();
        }
    }
    public class MacOSFactory : IGUIFactory
    {
        public IButton CreateButton(){
            return new MacOSButton();
        }
        public ILabel CreateLabel(){
            return new MacOSLabel();
        }
    }
    public interface IButton{
        void Render();
    }
    public interface ILabel{
        void Render();
    }
    public class WindowsButton: IButton
    {
        public void Render(){
            Console.WriteLine("Windows button rendered!");
        }
    }
    public class WindowsLabel: ILabel
    {
        public void Render(){
            Console.WriteLine("Windows label rendered!");
        }
    }
    public class MacOSButton: IButton
    {
        public void Render(){
            Console.WriteLine("MacOS button rendered!");
        }
    }
    public class MacOSLabel: ILabel
    {
        public void Render(){
            Console.WriteLine("MacOS label rendered!");
        }
    }
    public class App{
        private readonly IGUIFactory _guiFactory;
        public App(IGUIFactory guiFactory){
            _guiFactory = guiFactory;
        }
        public void Run(){
            var button = _guiFactory.CreateButton();
            var label = _guiFactory.CreateLabel();
            button.Render();
            label.Render();
        }
    }
    public class AbstractFactoryDemo{

        public void designPatternDemo(){

            IGUIFactory windowsGUI = new WindowsFactory();
            App windowsApp = new App(windowsGUI);
            
            IGUIFactory macOSGUI = new MacOSFactory();
            App macOSApp = new App(macOSGUI);
            
            windowsApp.Run();
            macOSApp.Run();
        }
    }
}