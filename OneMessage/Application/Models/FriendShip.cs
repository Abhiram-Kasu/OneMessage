using Spark.Library.Database;

namespace OneMessage.Application.Models;

public class FriendShip : BaseModel
{
    public virtual User FromUser { get; set; }
    public int FromUserId { get; set; }
    public virtual User ToUser { get; set; }
    public int ToUserId { get; set; }

}
