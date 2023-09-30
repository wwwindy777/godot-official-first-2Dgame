using Godot;
using System;

public partial class Player : Area2D
{
    [Signal]
    //用了委托，能定义一个方法，和Java的函数接口很像
    public delegate void HitEventHandler();

    [Export] private int Speed { get; set; } = 500; // How fast the player will move (pixels/sec).

    private Vector2 ScreenSize; // Size of the game window.

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //这个GetViewportRect()方法是继承的CanvasItem，可以获得窗口大小
        ScreenSize = GetViewportRect().Size;
        Hide();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right"))
        {
            velocity.X += 1;
        }

        if (Input.IsActionPressed("move_left"))
        {
            velocity.X -= 1;
        }

        if (Input.IsActionPressed("move_down"))
        {
            velocity.Y += 1;
        }

        if (Input.IsActionPressed("move_up"))
        {
            velocity.Y -= 1;
        }

        //GetNode是Node类的方法，也是继承过来的，用于获取当前节点相对路径处的子节点
        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
            //控制动画是否播放
            animatedSprite2D.Play();
        }
        else
        {
            animatedSprite2D.Stop();
        }

        //Position表示根节点的位置，也是继承Node的属性
        Position += velocity * (float)delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
            y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
        );

        if (velocity.X != 0)
        {
            animatedSprite2D.Animation = "walk";
            animatedSprite2D.FlipV = false;
            // See the note below about boolean assignment.
            animatedSprite2D.FlipH = velocity.X < 0;
        }
        else if (velocity.Y != 0)
        {
            animatedSprite2D.Animation = "up";
            animatedSprite2D.FlipV = velocity.Y > 0;
        }
    }
    public void Start(Vector2 position)
    {
        Position = position;
        Show();
        GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
    }
    private void OnBodyEntered(PhysicsBody2D body)
    {
        Hide(); // Player disappears after being hit.
        EmitSignal(SignalName.Hit);
        // Must be deferred as we can't change physics properties on a physics callback.
        GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
    }
}