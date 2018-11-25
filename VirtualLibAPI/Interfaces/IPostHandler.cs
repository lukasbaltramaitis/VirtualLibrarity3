using VirtualLibrarity.Interfaces;

namespace VirtualLibAPI
{
    public interface IPostHandler
    {
        int HandlePost<F>(F face)
            where F:IFace;
    }
}
