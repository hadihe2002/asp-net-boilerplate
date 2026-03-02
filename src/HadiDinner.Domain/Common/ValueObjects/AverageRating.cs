using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    public double Value { get; private set; }
    public int RatingCount { get; private set; }

    private AverageRating() { }

    private AverageRating(byte value, int ratingCount)
    {
        Value = value;
        RatingCount = ratingCount;
    }

    public static AverageRating Create(byte value = 0, int ratingCount = 0)
    {
        return new(value, ratingCount);
    }

    public void AddRating(Rating rating)
    {
        Value = ((Value * RatingCount) + rating.Value) / (RatingCount + 1);
        RatingCount++;
    }

    public void RemoveRating(Rating rating)
    {
        Value = ((Value * RatingCount) - rating.Value) / (RatingCount - 1);
        RatingCount--;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
