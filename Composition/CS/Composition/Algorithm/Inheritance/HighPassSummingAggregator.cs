using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Inheritance
{
    /// <summary>
    /// Should filter out measurements with an X or Y that are less than or equal to 2
    /// You'll need to inherit and override methods from other classes in the inheritance folder
    /// </summary>
    public class HighPassSummingAggregator : PointsAggregator
    {
        public HighPassSummingAggregator(IEnumerable<Measurement> measurements) 
            : base(measurements)
        {
        }

        private const int LowerBoundary = 2;

        protected override IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements)
            => measurements.Where(m => m.X > LowerBoundary && m.Y > LowerBoundary);

        protected override Measurement AggregateMeasurements(IEnumerable<Measurement> measurements)
            => measurements.Aggregate(
                (a, b) => new Measurement(a.X + b.X, a.Y + b.Y));
    }
}