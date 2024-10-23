using Builder;

namespace ECS.Data
{
    public class BuilderData
    {
        public readonly EnemyMileBuilder EnemyMileBuilder = new EnemyMileBuilder();
        public readonly EnemyRangeBuilder EnemyRangeBuilder = new EnemyRangeBuilder();
        public readonly PlayerEntityBuilder PlayerBuilder = new PlayerEntityBuilder();
        public readonly ProjectileEntityBuilder ProjectileBuilder = new ProjectileEntityBuilder();
        
        //todo передалай удалив спавнер, или подумай по лучше
    }
}