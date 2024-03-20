// SubmissionStatusConverter.cs
using System;
using System.Globalization;
using CanvasRemake.Models;

namespace CanvasRemake.Converters
{
    public class SubmissionStatusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] is Assignment assignment && values[1] is string studentId)
            {
                return assignment.Submissions.Any(s => s.StudentId == studentId) ? "Submitted" : "Missing";
            }

            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}