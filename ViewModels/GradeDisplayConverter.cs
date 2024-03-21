using System.Globalization;
using CanvasRemake.Models;

namespace CanvasRemake.Converters
{
    public class GradeDisplayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] is Assignment assignment && values[1] is string studentId)
            {
                var submission = assignment.Submissions.FirstOrDefault(s => s.StudentId == studentId);

                if (submission != null)
                {
                    return $"{submission.Grade}/{assignment.TotalAvailablePoints}";
                }

                return $"0/{assignment.TotalAvailablePoints}";
            }

            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}