namespace DeskCopilot
{
    internal class CopilotLayout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CopilotButton[,] Buttons { get; set; }

        public CopilotLayout(string name, string description, CopilotButton[,] buttons)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Width = buttons.GetLength(1);
            Height = buttons.GetLength(0);
            Buttons = buttons;
        }
    }
}
