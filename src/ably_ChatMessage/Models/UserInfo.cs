namespace ably_ChatMessage.Models
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public string DisplayName => $"{(Role == "Admin" ? "관리자" : "일반 사용자")}";
    }
}
