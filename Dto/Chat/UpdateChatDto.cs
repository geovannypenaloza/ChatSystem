namespace ChatSystem.Dto.Chat
{
    public class UpdateChatDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; } 
        public required string Description { get; set; } 
    }
}
