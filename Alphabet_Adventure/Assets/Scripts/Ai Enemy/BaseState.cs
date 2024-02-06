public abstract class BaseState
{
    //instance of enemyClass
    //instance of StateMachine
    public Enemy enemy;
    public StateMachine stateMachine;

    public abstract void enterState();
    public abstract void performState();
    public abstract void exitState();

}
