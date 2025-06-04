namespace BL.Strategy
{
    public interface IEffortStrategy
    {
        double CalculateEffortMinutes(object activityDto);
    }
}
