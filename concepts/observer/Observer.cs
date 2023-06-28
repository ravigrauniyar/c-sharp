using System;
namespace Internship
{
    public interface UI
    {
        void AttachComponent(IComponent component);
        void DetachComponent(IComponent component);
        void NotifyComponent();
    }
    public class UIDesign : UI
    {
        private List<IComponent> components = new List<IComponent>();
        private string theme;
        public string Theme
        {
            get { return theme; }
            set
            {
                if (theme != value)
                {
                    theme = value;
                    NotifyComponent();
                }
            }
        }
        public void AttachComponent(IComponent component)
        {
            Console.WriteLine("\nAttaching component {0}.\n", component.GetName());
            components.Add(component);
        }
        public void DetachComponent(IComponent component)
        {
            Console.WriteLine("\nDetaching component {0}.\n", component.GetName());
            components.Remove(component);
        }
        public void NotifyComponent()
        {
            foreach (Component component in components)
            {
                component.Update(this);
            }
        }
    }
    public interface IComponent
    {
        void Update(UIDesign UI);
        string GetName();
    }
    public class Component : IComponent
    {
        private string name;
        public Component(string _name)
        {
            name = _name;
        }
        public void Update(UIDesign UI)
        {
            Console.WriteLine("\n{0} theme is : {1}.\n", name, UI.Theme);
        }
        public string GetName(){
            return name;
        }
    }
    public class ObserverDemo
    {
        public void designPatternDemo()
        {
            UIDesign uiDesign = new UIDesign();
            Component Button = new Component("Button");
            Component TextField = new Component("TextField");

            uiDesign.AttachComponent(Button);
            uiDesign.AttachComponent(TextField);
            uiDesign.Theme = "Light";

            uiDesign.DetachComponent(Button);
            uiDesign.Theme = "Dark";
        }
    }
}