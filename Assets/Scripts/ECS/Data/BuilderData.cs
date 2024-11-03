using Builder;

namespace ECS.Data
{
    public class BuilderData
    {
        public readonly EnemyMileBuilder EnemyMileBuilder = new();
        public readonly EnemyRangeBuilder EnemyRangeBuilder = new();
        public readonly PlayerEntityBuilder PlayerBuilder = new();
        public readonly ProjectileEntityBuilder ProjectileBuilder = new();
        
        //todo передалай удалив спавнер, или подумай по лучше
    }
}