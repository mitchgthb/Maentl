namespace BL.Strategy
{
    public interface IEffortStrategy
    {
        double CalculateEffortMinutes(object activityDto);
        double EstimateEffort(object source);

    }
}
