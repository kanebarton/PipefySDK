namespace Axis.PipefySdk
{
    public interface IPipefyPagedResponse
    {
        IPipefyQueryPageInfo QueryPageInfo { get; }
        int ItemCount { get; }

        int AppendData(object response);
        void ApplyRequestFiltering(IPipefyRequest request);
    }
}
