namespace Enemy_Behaviours
{
    public interface Health
    {
        public void Health(Enemy enemy);
        public double TakeDamage(double damage);
    }
    public interface Movement
    {
        public void Move(Enemy enemy);
        public void Rotation(Enemy enemy);
        public Enemy_Behaviours.Movement GetNextBehaviour();
    }
    public interface Death
    {
        public void OnDestruction(Enemy enemy);
    }
    public interface Reward
    {
        public void GetReward(Enemy enemy);
    }
    public interface Weapon
    {
        public void Shoot(Enemy enemy);
        public void ShootOverTime(Enemy enemy);
    }
}

