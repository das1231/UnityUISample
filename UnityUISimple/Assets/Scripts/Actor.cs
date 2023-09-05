using UnityEngine.TextCore.Text;

public class Actor
{
    public int hp = 0;
    public int attack = 0;
}
public class Master : Actor
{
    public Master(int _hp, int _attack)
    {
        hp = _hp;
        attack = _attack;
    }
}
public class Enemy : Actor
{
    public Enemy(int _hp, int _attack)
    {
        hp = _hp;
        attack = _attack;
    }
}
