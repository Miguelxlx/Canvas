// SubmissionStatusConverter.cs
using System.Globalization;
using CanvasRemake.Models;

namespace CanvasRemake.Converters
{
    public class SubmissionStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Assignment assignment && parameter is Student student)
            {
                return assignment.Submissions.Any(s => s.StudentId == student.ID) ? "Submitted" : "Missing";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}