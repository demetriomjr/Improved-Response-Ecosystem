using Microsoft.EntityFrameworkCore;

namespace Models.Interfaces_Abstracts
{
    public abstract class SQLPersistentModel
    {
        public enum BaseStatusOptions
        {
            DELETED = -1,
            INACTIVE = 0,
            ACTIVE = 1
        }

        public uint Id { get; set; } = 0;
        public BaseStatusOptions Status { get; set; } = BaseStatusOptions.ACTIVE;
        public DateTime? CreatedAt { get; set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
