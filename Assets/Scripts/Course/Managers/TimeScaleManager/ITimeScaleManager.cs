namespace Course.Managers.TimeScaleManager
{
    public interface ITimeScaleManager
    {
        void BeginTimeScale(TimeScaleHandle handle, float scale);
        void EndTimeScale(TimeScaleHandle handle);
    }
}
