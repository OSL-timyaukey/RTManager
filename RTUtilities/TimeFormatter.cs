namespace RTUtilities
{
    /// <summary>
    /// Take a string like "nnnnnn" or "nnnn[.nnn][ ]h[???]" and
    /// convert it to an integer number of minutes.
    /// For example, "100" -> 100, "2h" -> 120, "0.5h" -> 90, "3 hours" -> 180,
    /// "2.5 hams" -> 150.
    /// </summary>
    public class TimeFormatter : FieldFormatter
    {
        public override string Format(object input)
        {
            string time = (string)input;
            int endIndex = time.ToLower().IndexOf("h");
            if (endIndex > 0)
            {
                time = time.Substring(0, endIndex).TrimEnd(' ');
                return ((int)(double.Parse(time) * 60.0D)).ToString();
            }
            else
            {
                return time;
            }
        }
    }
}
