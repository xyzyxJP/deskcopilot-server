namespace DeskCopilot
{
    internal class CopilotLayout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CopilotButton[][] Buttons { get; set; }

        public CopilotLayout(string id, string name, string description, CopilotButton[][] buttons)
        {
            Id = id;
            Name = name;
            Description = description;
            Buttons = buttons;
        }
    }
}
