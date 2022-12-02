namespace DeskCopilot
{
    internal class CopilotButton
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public ButtonType Type { get; set; }

        public CopilotButton(string name, string value, string icon, ButtonType type)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Value = value;
            Icon = icon;
            Type = type;
        }
    }

    public enum ButtonType
    {
        None = 0,
        Tap = 1,
        LongPress = 2,
        Text = 3,
        Progress = 4,
        Folder = 5,
    }
}
