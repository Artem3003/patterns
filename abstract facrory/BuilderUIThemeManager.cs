using System;

namespace abstractFactory
{
    // Task: Building a UI Theme Manager
    // Description: You are tasked with building a UI theme manager 
    // for a desktop application. The application should allow 
    // users to switch between different themes, such as light mode and dark mode.
    // Each theme consists of various UI components, including buttons, 
    // textboxes, labels, and background colors. 
    // The goal is to implement this feature in a flexible and maintainable way 
    // using the Abstract Factory pattern.

    // Abstract facrory interface
    interface IUIThemeFactory
    {
        IButton CreateButton();

        ITextBox CreateTextBox();

        ILabel CreateLabel();

        void SetBackgroundColor();
    }

    // Products interfaces
    interface IButton
    {
        void Render();
    }

    interface ITextBox
    {
        void Render();
    }

    interface ILabel
    {
        void Render();
    }

    // Concrete factories
    class LightModeUIThemeFactory : IUIThemeFactory
    {
        public IButton CreateButton()
        {
            return new LightButton();
        }

        public ILabel CreateLabel()
        {
            return new LightLabel();
        }

        public ITextBox CreateTextBox()
        {
            return new LightTextBox();
        }

        public void SetBackgroundColor()
        {
            System.Console.WriteLine("Backgound colo: light");
        }
    }

    class DarkModeUIThemeFactory : IUIThemeFactory
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }

        public ILabel CreateLabel()
        {
            return new DarkLabel();
        }

        public ITextBox CreateTextBox()
        {
            return new DarkTextBox();
        }

        public void SetBackgroundColor()
        {
            System.Console.WriteLine("Background color: dark");
        }
    }

    // buttons
    class LightButton : IButton
    {
        private int width;
        private int height;
        private double boarderLength;
        private string font;
        private string color;
        
        public LightButton()
        {
            this.width = 20;
            this.height = 10;
            this.boarderLength = 1.0;
            this.font = "Sans-serif";
            this.color = "light";
        }

        public void Render()
        {
            System.Console.WriteLine($"Light button with {boarderLength} border length, {width} width and {height} height, {font} font");
        }
    }

    // Products
    class DarkButton : IButton
    {
        private int width;
        private int height;
        private double boarderLength;
        private string font;
        private string color;
        
        public DarkButton()
        {
            this.width = 20;
            this.height = 10;
            this.boarderLength = 1.0;
            this.font = "Sans-serif";
            this.color = "dark";
        }

        public void Render()
        {
            System.Console.WriteLine($"Dark button with {boarderLength} border length, {width} width and {height} height, {font} font");
        }
    }

    // labels
    class LightLabel : ILabel
    {
        private string color;
        private string font;
        private string type;
        private string id;

        public LightLabel()
        {
            this.color = "light";
            this.font = "Sans-serif";
            this.type = "text";
            this.id = "username";
        }

        public void Render()
        {
            System.Console.WriteLine($"Light label with {font} font, type={type}, id={id}");
        }
    }

    class DarkLabel : ILabel
    {
        private string color;
        private string font;
        private string type;
        private string id;

        public DarkLabel()
        {
            this.color = "dark";
            this.font = "Sans-serif";
            this.type = "text";
            this.id = "username";
        }

        public void Render()
        {
            System.Console.WriteLine($"Dark label with {font} font, type={type}, id={id}");
        }
    }

    // textboxes
    class LightTextBox : ITextBox
    {
        private string color;
        private string text;
        public LightTextBox()
        {
            this.color = "loght";
            this.text = "Hello, world!";

        }
        public void Render()
        {
            System.Console.WriteLine($"Light textbox with text: {text}");;
        }
    }

    class DarkTextBox : ITextBox
    {
        private string color;
        private string text;
        public DarkTextBox()
        {
            this.color = "dark";
            this.text = "Hello, world!";

        }
        public void Render()
        {
            System.Console.WriteLine($"Dark textbox with text: {text}");;
        }
    }

    // Client
    class ThemeManager
    {
        private IUIThemeFactory currentThemeFactory; 
        public ThemeManager(IUIThemeFactory themeFactory)
        {
            currentThemeFactory = themeFactory;
        }

        public void ApplyTheme()
        {
            currentThemeFactory.SetBackgroundColor();
        }

        public void RenderUI()
        {
            IButton button = currentThemeFactory.CreateButton();
            ILabel lable = currentThemeFactory.CreateLabel();
            ITextBox textbox = currentThemeFactory.CreateTextBox();

            button.Render();
            lable.Render();
            textbox.Render();
        }
    }
}