public interface IPlayerStats
{
    float MaxHealth { get; set; }
    float MaxMP { get; set; }
    float PhysicalDamage { get; set; }
    float MagicDamage { get; set; }
    float EvasionChance { get; set; }
    float PhysicalResist { get; set; }
    float MagicalResist { get; set; }
}