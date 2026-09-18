public abstract class Enemy
{
    public PictureBox Sprite { get; protected set; }
    protected int speed;
    protected Random rnd = new Random();

    public Enemy(PictureBox sprite, int speed)
    {
        this.Sprite = sprite;
        this.speed = speed;
    }

    // Método abstrato que permite que as subclasses reescrevam //
    public virtual void Move()
    {
        Sprite.Top += speed;
    }

    public void ResetPosition()
    {
        Sprite.Top = rnd.Next(100, 800) * -1;
        Sprite.Left = rnd.Next(20, 600);
    }
}

// Inimigo Padrão //
public class NormalEnemy : Enemy
{
    public NormalEnemy(PictureBox sprite, int speed) : base(sprite, speed) { }
}

//Inimigo Rápido que desce com o dobro da velocidade do inimigo normal //
public class FastEnemy : Enemy
{
    public FastEnemy(PictureBox sprite, int speed) : base(sprite, speed) { }

    public override void Move()
    {
        Sprite.Top += (speed * 2);
    }
}
