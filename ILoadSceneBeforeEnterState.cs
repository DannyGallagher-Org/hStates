using RSG;

namespace hStates
{
    public interface ILoadSceneBeforeEnterState
    {
        IPromise LoadScene();
    }
}